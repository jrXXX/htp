package ch.akros.htp.controller;

import static ch.akros.htp.api.model.SearchResponse.CurrencyEnum.CHF;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

import java.time.LocalDate;
import java.util.List;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.test.context.TestPropertySource;
import org.springframework.test.web.servlet.MockMvc;

import ch.akros.htp.api.model.Country;
import ch.akros.htp.api.model.Hotel;
import ch.akros.htp.api.model.Room;
import ch.akros.htp.api.model.SearchRequest;
import ch.akros.htp.api.model.SearchResponse;
import ch.akros.htp.service.SearchVendorService;

@WebMvcTest
@TestPropertySource(locations = "classpath:application-test.yml")
public class SearchVendorControllerTest {

	@Autowired
	private MockMvc mockMvc;

	@MockBean
	private SearchVendorService searchVendorService;

	/**
	 * Tests that the endpoints returns the given response while given a mocked
	 * request.
	 * 
	 * @throws Exception in case an exception occurs.
	 */
	@Test
	public void hotelSearchMockedInputTest() throws Exception {
		when(searchVendorService.getSearchResponsesFromVendors(getBasicRequest()))
				.thenReturn(List.of(getBasicResponse()));
		this.mockMvc.perform(post("/hotelSearch").contentType(MediaType.APPLICATION_JSON).content(getContent()))
				.andDo(print()).andExpect(status().isOk())
				.andExpect(content().json("[{\"hotel\": {\"name\":\"Bellevue Palace\"}}]"));
	}

	/**
	 * Tests that the endpoint is active and returns an empty list as the vendors
	 * are separate microservices which are not running during testing.
	 * 
	 * @throws Exception in case an exception occurs.
	 */
	@Test
	public void hotelSearchVendorsOfflineTest() throws Exception {
		this.mockMvc.perform(post("/hotelSearch").contentType(MediaType.APPLICATION_JSON).content(getContent()))
				.andDo(print()).andExpect(status().isOk()).andExpect(content().string("[]"));
	}

	private String getContent() {
		StringBuilder sb = new StringBuilder();
		sb.append("{");
		sb.append("\"hotelName\": ").append("\"Bellevue Palace\"");
		sb.append("}");

		return sb.toString();
	}

	private SearchRequest getBasicRequest() {
		SearchRequest req = new SearchRequest();
		req.setHotelName("Bellevue Palace");
		return req;
	}

	private SearchResponse getBasicResponse() {
		SearchResponse req = new SearchResponse();
		req.setCurrency(CHF);
		req.setDateFrom(LocalDate.of(2021, 5, 21));
		req.setDateTo(LocalDate.of(2021, 5, 23));
		req.setNumberOfGuests(5);

		Hotel hotel = new Hotel();
		hotel.name("Bellevue Palace").zipCode("8004").price(150).city("Bern").country(new Country().name("Switzerland"))
				.rooms(List.of(new Room().name("101A").price(50)));
		req.setHotel(hotel);
		return req;
	}

}
