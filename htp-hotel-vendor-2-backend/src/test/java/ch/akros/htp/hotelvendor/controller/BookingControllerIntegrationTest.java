package ch.akros.htp.hotelvendor.controller;

import static org.assertj.core.api.Assertions.assertThat;

import java.io.IOException;
import java.time.LocalDate;

import javax.transaction.Transactional;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.context.SpringBootTest.WebEnvironment;
import org.springframework.http.MediaType;
import org.springframework.test.context.TestPropertySource;
import org.springframework.test.web.reactive.server.JsonPathAssertions;
import org.springframework.test.web.reactive.server.WebTestClient;
import org.springframework.test.web.reactive.server.WebTestClient.BodyContentSpec;
import org.springframework.web.reactive.function.BodyInserters;

import ch.akros.htp.api.model.BookingRequest;
import ch.akros.htp.api.model.Room;
import ch.akros.htp.api.model.Room.CurrencyEnum;
import ch.akros.htp.api.model.Room.TypeEnum;

@SpringBootTest(webEnvironment = WebEnvironment.RANDOM_PORT)
@TestPropertySource(locations = "classpath:application-test.yml")
@Transactional
public class BookingControllerIntegrationTest {

	private final WebTestClient webTestClient;

	@Autowired
	public BookingControllerIntegrationTest(WebTestClient webTestClient) {
		this.webTestClient = webTestClient;
	}

	@Test
	public void bookingResponseTest() throws IOException {
		final var request = createBookingRequest();
		BodyContentSpec expectBody = webTestClient.post().uri("/roomBooking").accept(MediaType.APPLICATION_JSON)
				.body(BodyInserters.fromValue(request)).exchange().expectStatus().isOk().expectBody();
		JsonPathAssertions jsonPath = expectBody.jsonPath("$.[*].responseMessage");
		assertThat(expectBody).hasNoNullFieldsOrProperties();
		jsonPath.isEqualTo("Room Booked!");
	}

	@Test
	public void bookingResponseThrowsExceptionTest() throws IOException {
		final var request = createBookingRequest();
		request.setRoom(null);
		BodyContentSpec expectBody = webTestClient.post().uri("/roomBooking").accept(MediaType.APPLICATION_JSON)
				.body(BodyInserters.fromValue(request)).exchange().expectStatus().isNotFound().expectBody();
		JsonPathAssertions jsonPath = expectBody.jsonPath("$.[*].responseMessage");
		assertThat(expectBody).hasNoNullFieldsOrProperties();
		jsonPath.isEqualTo("Room cannot be null");
	}

	private BookingRequest createBookingRequest() {
		Room room = new Room().id(1L).name("101A").price(100).currency(CurrencyEnum.CHF).type(TypeEnum.KING);
		return new BookingRequest().dateFrom(LocalDate.now()).dateTo(LocalDate.now()).room(room);
	}
}
