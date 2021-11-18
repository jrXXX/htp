package ch.akros.htp.hotelvendor.service;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;

import java.time.LocalDate;
import java.util.List;
import java.util.Set;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.context.SpringBootTest.WebEnvironment;
import org.springframework.test.context.TestPropertySource;
import org.springframework.transaction.annotation.Transactional;

import ch.akros.htp.api.model.SearchRequest;
import ch.akros.htp.api.model.SearchRequest.CurrencyEnum;
import ch.akros.htp.hotelvendor.entity.booking.Booking;
import ch.akros.htp.hotelvendor.entity.hotel.HotelEntity;
import ch.akros.htp.hotelvendor.entity.room.RoomEntity;
import ch.akros.htp.hotelvendor.entity.room.RoomEntity.RoomType;

@SpringBootTest(webEnvironment = WebEnvironment.RANDOM_PORT)
@TestPropertySource(locations = "classpath:application-test.yml")
@Transactional
public class RoomServiceIntegrationTest {

	private final RoomService roomService;

	@Autowired
	public RoomServiceIntegrationTest(RoomService roomService) {
		this.roomService = roomService;
	}

	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void searchRoomByPriceAndTypeTest() {
		var rooms = roomService.findByPriceAndType(125, RoomType.KING);
		assertThat(rooms.size()).isEqualTo(2);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void filterHotelDeepLinkTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		a101.setId(1L);
		Booking booking = new Booking(LocalDate.of(2021, 6, 20), LocalDate.of(2021, 6, 24), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		var rooms = roomService.filteredRooms(hotel.getRooms(), getBasicRequest());
		assertThat(rooms.size()).isEqualTo(1);

		RoomEntity onlyRoom = rooms.get(0);
		String deepLink = onlyRoom.getDeepLink();

		assertThat(deepLink).isEqualTo(
				"frontEndUrl/rooms/book/?id=1&roomName=A101&roomPrice=105&roomType=double&bookFrom=2021-05-21&bookTo=2021-05-24");
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}
	
	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void filterHotelMoreThanOneBookingsTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking1 = new Booking(LocalDate.of(2021, 6, 20), LocalDate.of(2021, 6, 24), a101, 150);
		Booking booking2 = new Booking(LocalDate.of(2021, 6, 25), LocalDate.of(2021, 6, 27), a101, 150);
		a101.setBookings(List.of(booking1,booking2));
		hotel.setRooms(Set.of(a101));
		var rooms = roomService.filteredRooms(hotel.getRooms(), getBasicRequest());
		assertThat(rooms.size()).isEqualTo(1);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void conflictedDatesTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 5, 20), LocalDate.of(2021, 5, 24), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		var rooms = roomService.filteredRooms(hotel.getRooms(), getBasicRequest());
		assertThat(rooms.size()).isEqualTo(0);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Test the received exception when requestDate is null
	 */
	@Test
	public void requestDateNullTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 5, 20), LocalDate.of(2021, 5, 24), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		SearchRequest req = getBasicRequest();
		req.setDateFrom(null);
		req.setDateTo(null);
		NullPointerException exception = assertThrows(NullPointerException.class,
				() -> roomService.filteredRooms(hotel.getRooms(), req));
		String expectedMessage = "Request date from is null";
		String actualMessageString = exception.getMessage();
		assertThat(actualMessageString).contains(expectedMessage);

		req.setDateFrom(LocalDate.of(2021, 5, 21));
		exception = assertThrows(NullPointerException.class, () -> roomService.filteredRooms(hotel.getRooms(), req));
		expectedMessage = "Request date to is null";
		actualMessageString = exception.getMessage();
		assertThat(actualMessageString).contains(expectedMessage);
	}

	/**
	 * Test the received exception when dateFrom is after date to
	 */
	@Test
	public void requestDateFromAfterRequestDateToTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 5, 20), LocalDate.of(2021, 5, 24), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		SearchRequest req = getBasicRequest();
		req.setDateFrom(LocalDate.of(2021, 5, 23));
		req.setDateTo(LocalDate.of(2021, 5, 21));
		// date From after date to
		IllegalArgumentException exception = assertThrows(IllegalArgumentException.class,
				() -> roomService.filteredRooms(hotel.getRooms(), req));
		String expectedMessage = "Date 'From' is equal or after the date 'to'";
		String actualMessageString = exception.getMessage();
		assertThat(actualMessageString).contains(expectedMessage);

		// date from equal to date to
		req.setDateTo(LocalDate.of(2021, 5, 23));
		exception = assertThrows(IllegalArgumentException.class, () -> roomService.filteredRooms(hotel.getRooms(), req));
		expectedMessage = "Date 'From' is equal or after the date 'to'";
		actualMessageString = exception.getMessage();
		assertThat(actualMessageString).contains(expectedMessage);
	}

	/**
	 * Test the received exception when price from is greater than the price to
	 */
	@Test
	public void requestPriceFromGreaterThanPriceTo() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 5, 20), LocalDate.of(2021, 5, 24), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		SearchRequest req = getBasicRequest();
		req.setPriceFrom(1000);
		req.setPriceTo(50);
		IllegalArgumentException exception = assertThrows(IllegalArgumentException.class,
				() -> roomService.filteredRooms(hotel.getRooms(), req));
		String expectedMessage = "Price 'from' is bigger than the price 'to' !";
		String actualMessageString = exception.getMessage();
		assertThat(actualMessageString).contains(expectedMessage);
	}

	/**
	 * Test when the price From and the Price To are Null
	 */
	@Test
	public void requestPriceFromAndPriceToNullTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 6, 22), LocalDate.of(2021, 6, 23), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		SearchRequest req = getBasicRequest();
		req.setPriceFrom(null);
		req.setPriceTo(null);
		var rooms = roomService.filteredRooms(hotel.getRooms(), req);
		assertThat(rooms.size()).isEqualTo(1);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Test when the price of the room is higher than the request price range
	 */
	@Test
	public void roomPriceHigherThanRequestPriceRangeTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 6, 22), LocalDate.of(2021, 6, 23), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		SearchRequest req = getBasicRequest();
		req.setPriceFrom(50);
		req.setPriceTo(75);
		var rooms = roomService.filteredRooms(hotel.getRooms(), req);
		assertThat(rooms.size()).isEqualTo(0);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Test when the price of the room is lower than the request price range
	 */
	@Test
	public void roomPriceLowerThanRequestPriceRangeTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 6, 22), LocalDate.of(2021, 6, 23), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		SearchRequest req = getBasicRequest();
		req.setPriceFrom(150);
		req.setPriceTo(151);
		var rooms = roomService.filteredRooms(hotel.getRooms(), req);
		assertThat(rooms.size()).isEqualTo(0);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Test when the price of the room is inside the request price range
	 */
	@Test
	public void roomPriceInsideRequestPriceRangeTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 6, 22), LocalDate.of(2021, 6, 23), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		SearchRequest req = getBasicRequest();
		req.setPriceFrom(50);
		req.setPriceTo(110);
		var rooms = roomService.filteredRooms(hotel.getRooms(), req);
		assertThat(rooms.size()).isEqualTo(1);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Test when the request price range matches exactly the price of the room.
	 * (Price from= Price to)
	 */
	@Test
	public void requestPriceRangeSameAsRoomPriceTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 6, 22), LocalDate.of(2021, 6, 23), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		SearchRequest req = getBasicRequest();
		req.setPriceFrom(105);
		req.setPriceTo(105);
		var rooms = roomService.filteredRooms(hotel.getRooms(), req);
		assertThat(rooms.size()).isEqualTo(1);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void conflictingRequestDateFromTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 5, 23), LocalDate.of(2021, 5, 25), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		var rooms = roomService.filteredRooms(hotel.getRooms(), getBasicRequest());
		assertThat(rooms.size()).isEqualTo(0);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void conflictingRequestDateToTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 5, 20), LocalDate.of(2021, 5, 23), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		var rooms = roomService.filteredRooms(hotel.getRooms(), getBasicRequest());
		assertThat(rooms.size()).isEqualTo(0);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void conflictingBothRequestDatesOutsideOfRangeTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 5, 19), LocalDate.of(2021, 5, 25), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		var rooms = roomService.filteredRooms(hotel.getRooms(), getBasicRequest());
		assertThat(rooms.size()).isEqualTo(0);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void conflictingBothRequestDatesInsideOfRangeTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 5, 22), LocalDate.of(2021, 5, 23), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		var rooms = roomService.filteredRooms(hotel.getRooms(), getBasicRequest());
		assertThat(rooms.size()).isEqualTo(0);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void notConflictingRequestDatesBeforeBookedDatesTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 4, 22), LocalDate.of(2021, 4, 23), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		var rooms = roomService.filteredRooms(hotel.getRooms(), getBasicRequest());
		assertThat(rooms.size()).isEqualTo(1);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void notConflictingRequestDatesAfterBookedDatesTest() {
		HotelEntity hotel = new HotelEntity();
		RoomEntity a101 = new RoomEntity("A101", RoomType.DOUBLE, 105);
		Booking booking = new Booking(LocalDate.of(2021, 7, 22), LocalDate.of(2021, 7, 23), a101, 150);
		a101.setBookings(List.of(booking));
		hotel.setRooms(Set.of(a101));
		var rooms = roomService.filteredRooms(hotel.getRooms(), getBasicRequest());
		assertThat(rooms.size()).isEqualTo(1);
		rooms.forEach(e -> assertThat(e).isInstanceOf(RoomEntity.class));
	}

	private SearchRequest getBasicRequest() {
		SearchRequest req = new SearchRequest();
		req.setDateFrom(LocalDate.of(2021, 5, 21));
		req.setDateTo(LocalDate.of(2021, 5, 24));
		req.setPriceFrom(100);
		req.setPriceTo(150);
		req.setCurrency(CurrencyEnum.CHF);
		return req;
	}

}