package ch.akros.htp.hotelvendor.service;

import static org.assertj.core.api.Assertions.assertThat;
import static org.junit.jupiter.api.Assertions.assertThrows;

import java.time.LocalDate;
import java.util.Collections;
import java.util.List;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.context.SpringBootTest.WebEnvironment;
import org.springframework.test.context.TestPropertySource;
import org.springframework.transaction.annotation.Transactional;

import ch.akros.htp.api.model.Facility;
import ch.akros.htp.api.model.SearchRequest;
import ch.akros.htp.api.model.SearchRequest.CurrencyEnum;
import ch.akros.htp.api.model.SearchResponse;

@SpringBootTest(webEnvironment = WebEnvironment.RANDOM_PORT)
@TestPropertySource(locations = "classpath:application-test.yml")
@Transactional
public class HotelServiceIntegrationTest {

	private final HotelService hotelService;

	@Autowired
	public HotelServiceIntegrationTest(HotelService hotelService) {
		this.hotelService = hotelService;
	}

	/**
	 * Search for Hotels according to the request
	 */
	@Test
	public void searchHotelsTest() {
		SearchRequest req = getBasicRequest();
		req.setFacilityList(List.of(new Facility().name("SPA")));
		var hotels = hotelService.searchHotels(req);
		assertThat(hotels.size()).isEqualTo(1);
		hotels.forEach(e -> assertThat(e).isInstanceOf(SearchResponse.class));
	}

	/**
	 * Search for Hotels according to the request with only set postal code
	 */
	@Test
	public void searchHotelsWithPostalCodeTest() {
		SearchRequest req = getBasicRequest();
		req.setFacilityList(List.of(new Facility().name("SPA")));
		req.setDestinationPostalCode("3011");
		req.setDestinationCity("NoCity");
		var hotels = hotelService.searchHotels(req);
		assertThat(hotels.size()).isEqualTo(0);
		hotels.forEach(e -> assertThat(e).isInstanceOf(SearchResponse.class));
	}

	/**
	 * Search for Hotels according to the request with wrong city and wrong  set postal code
	 */
	@Test
	public void searchHotelsWithWrongCityAndWrongPostalCodeTest() {
		SearchRequest req = getBasicRequest();
		req.setFacilityList(List.of(new Facility().name("SPA")));
		req.setDestinationPostalCode("30110");
		req.setDestinationCity("NoCity");
		var hotels = hotelService.searchHotels(req);
		assertThat(hotels.size()).isEqualTo(0);
		hotels.forEach(e -> assertThat(e).isInstanceOf(SearchResponse.class));
	}


	/**
	 * Search for Hotels according to the request with different city and different  set postal code
	 */
	@Test
	public void searchHotelsWithDifferentCityAndDifferentPostalCodeTest() {
		SearchRequest req = getBasicRequest();
		req.setFacilityList(List.of(new Facility().name("SPA")));
		req.setDestinationPostalCode("8048");
		req.setDestinationCity("Zurich");
		req.setHotelName("");
		var hotels = hotelService.searchHotels(req);
		assertThat(hotels.size()).isEqualTo(1);
		hotels.forEach(e -> assertThat(e).isInstanceOf(SearchResponse.class));
	}

	/**
	 * Search for Hotels according to the request with different city and different  set postal code
	 */
	@Test
	public void searchHotelsWithDifferentCityAndPostalCodeForAnotherCityTest() {
		SearchRequest req = getBasicRequest();
		req.setFacilityList(List.of(new Facility().name("SPA")));
		req.setDestinationPostalCode("7035");
		req.setDestinationCity("Zurich");
		req.setHotelName("");
		var hotels = hotelService.searchHotels(req);
		assertThat(hotels.size()).isEqualTo(0);
		hotels.forEach(e -> assertThat(e).isInstanceOf(SearchResponse.class));
	}

	/**
	 * Search for hotels while the price from is greater than the price from
	 */
	@Test
	public void searchHotelsPriceFromGreaterThanPriceToTest() {
		SearchRequest req = getBasicRequest();
		req.setFacilityList(List.of(new Facility().name("SPA")));
		req.setPriceFrom(1000);
		req.setPriceTo(100);
		IllegalArgumentException exception = assertThrows(IllegalArgumentException.class,
				() -> hotelService.searchHotels(req));
		String expectedMessage = "Price 'from' is bigger than the price 'to' !";
		String actualMessageString = exception.getMessage();
		assertThat(actualMessageString).contains(expectedMessage);
	}

	/**
	 * Search for hotels between a valid price range, between an invalid price range
	 * which is less than the hotel price and between an invalid price range which
	 * is more than the hotel price.
	 */
	@Test
	public void searchHotelsAccordingToPriceTest() {
		SearchRequest req = getBasicRequest();
		req.setFacilityList(List.of(new Facility().name("SPA")));
		req.setPriceFrom(50);
		req.setPriceTo(1000);
		var hotels = hotelService.searchHotels(req);
		assertThat(hotels.size()).isEqualTo(1);

		req.setPriceFrom(50);
		req.setPriceTo(51);
		hotels = hotelService.searchHotels(req);
		assertThat(hotels.size()).isEqualTo(0);

		req.setPriceFrom(111);
		req.setPriceTo(120);
		hotels = hotelService.searchHotels(req);
		assertThat(hotels.size()).isEqualTo(0);
	}

	/**
	 * Search for hotels with an empty facility list
	 */
	@Test
	public void searchHotelsWithEmptyFacilitiesTest() {
		SearchRequest req = getBasicRequest();
		req.setFacilityList(Collections.emptyList());
		var hotels = hotelService.searchHotels(req);
		assertThat(hotels.size()).isEqualTo(1);
	}

	/**
	 * search for hotels while the facility list is null
	 */
	@Test
	public void searchHotelsWithNullFacilitiesTest() {
		SearchRequest req = getBasicRequest();
		var hotels = hotelService.searchHotels(req);
		assertThat(hotels.size()).isEqualTo(1);
	}

	private SearchRequest getBasicRequest() {
		SearchRequest req = new SearchRequest();
		req.setDestinationCity("Bern");
		req.setDestinationCountry("Switzerland");
		req.setHotelName("Bellevue Palace");
		req.setDateFrom(LocalDate.of(2021, 5, 21));
		req.setDateTo(LocalDate.of(2021, 5, 23));
		req.setCurrency(CurrencyEnum.CHF);
		return req;
	}

}