package ch.akros.htp.hotelvendor.service;

import static org.assertj.core.api.Assertions.assertThat;

import java.time.LocalDate;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.context.SpringBootTest.WebEnvironment;
import org.springframework.test.context.TestPropertySource;
import org.springframework.transaction.annotation.Transactional;

import ch.akros.htp.api.model.BookingRequest;
import ch.akros.htp.api.model.BookingResponse;
import ch.akros.htp.api.model.Room;
import ch.akros.htp.api.model.Room.TypeEnum;
import ch.akros.htp.hotelvendor.service.BookingService;

@SpringBootTest(webEnvironment = WebEnvironment.RANDOM_PORT)
@TestPropertySource(locations = "classpath:application-test.yml")
@Transactional
public class BookingServiceIntegrationTest {

	private final BookingService bookingService;

	@Autowired
	public BookingServiceIntegrationTest(BookingService bookingService) {
		this.bookingService = bookingService;
	}

	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void bookRoomTest() {
		BookingRequest req = getBasicRequest();
		var response = bookingService.book(req);
		assertThat(response.getResponseMessage()).contains("Room Booked!");
		assertThat(response).isInstanceOf(BookingResponse.class);
	}
	
	/**
	 * Search for Rooms according to the request
	 */
	@Test
	public void bookAlreadyBookedRoomTest() {
		BookingRequest req = getBasicRequest();
		var response = bookingService.book(req);
		
		response =bookingService.book(req);
		assertThat(response.getResponseMessage()).contains("Room was booked from someone else in the meantime. Search again.");
	}


	private BookingRequest getBasicRequest() {
		BookingRequest req = new BookingRequest();
		req.dateFrom(LocalDate.of(2021, 10, 25));
		req.dateTo(LocalDate.of(2021, 11, 30));
		req.room(new Room().id(1L).name("101").type(TypeEnum.KING).price(125));
		return req;
	}

}