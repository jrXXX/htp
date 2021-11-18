package ch.akros.htp.hotelvendor.controller;

import static org.assertj.core.api.Assertions.assertThat;

import java.time.LocalDate;

import org.hamcrest.Matchers;
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
public class HotelControllerIntegrationTest2 {
	private final WebTestClient webTestClient;

	@Autowired
	public HotelControllerIntegrationTest2(WebTestClient webTestClient) {
		this.webTestClient = webTestClient;
	}

	/**
	 * scenario: WebTestClient reads all hotels
	 */
	@Test
	public void hotelsAreAvailableOverRestBern() {
		BodyContentSpec body = webTestClient.post().uri("/hotelSearch")
				.body(BodyInserters.fromValue(getBasicRequest("Bern"))).exchange().expectStatus().isOk().expectBody();

		System.out.println(new String(body.returnResult().getResponseBody()));

		body.jsonPath("$.*", Matchers.hasSize(2));
		assertThat(body).hasNoNullFieldsOrProperties();

	}

	/**
	 * scenario: WebTestClient reads all hotels
	 */
	@Test
	public void hotelsAreAvailableOverRestBerny() {
		BodyContentSpec body = webTestClient.post().uri("/hotelSearch")
				.body(BodyInserters.fromValue(getBasicRequest("Berny"))).exchange().expectStatus().isOk().expectBody();

		body.jsonPath("$.*", Matchers.hasSize(0));
		assertThat(body).hasNoNullFieldsOrProperties();

	}

	private SearchRequest getBasicRequest(String city) {
		SearchRequest req = new SearchRequest();
		req.setDestinationCity(city);
		req.setDestinationCountry("Switzerland");
		req.setDateFrom(LocalDate.of(2021, 12, 21));
		req.setDateTo(LocalDate.of(2021, 12, 23));
		req.setCurrency(CurrencyEnum.CHF);
		return req;
	}
}