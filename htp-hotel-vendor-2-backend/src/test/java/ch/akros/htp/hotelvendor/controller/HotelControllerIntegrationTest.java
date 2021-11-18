package ch.akros.htp.hotelvendor.controller;

import static org.assertj.core.api.Assertions.assertThat;

import java.time.LocalDate;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.context.SpringBootTest.WebEnvironment;
import org.springframework.test.context.TestPropertySource;
import org.springframework.test.web.reactive.server.WebTestClient;
import org.springframework.test.web.reactive.server.WebTestClient.BodyContentSpec;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.reactive.function.BodyInserters;

import ch.akros.htp.api.model.SearchRequest;
import ch.akros.htp.api.model.SearchRequest.CurrencyEnum;

@SpringBootTest(webEnvironment = WebEnvironment.RANDOM_PORT)
@TestPropertySource(locations = "classpath:application-test.yml")
@Transactional
public class HotelControllerIntegrationTest {
	private final WebTestClient webTestClient;

	@Autowired
	public HotelControllerIntegrationTest(WebTestClient webTestClient) {
		this.webTestClient = webTestClient;
	}

	/**
	 * scenario: WebTestClient reads all hotels
	 */
	@Test
	public void hotelsAreAvailableOverRest() {
		BodyContentSpec body = webTestClient.post().uri("/hotelSearch").body(BodyInserters.fromValue(getBasicRequest()))
				.exchange().expectStatus().isOk().expectBody();

		body.jsonPath("$.[*].hotel.name").isEqualTo("Bellevue Palace");
		assertThat(body).hasNoNullFieldsOrProperties();

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