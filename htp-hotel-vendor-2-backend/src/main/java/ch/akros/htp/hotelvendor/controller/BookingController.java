package ch.akros.htp.hotelvendor.controller;

import java.util.List;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RestController;

import ch.akros.htp.api.RoomBookingApi;
import ch.akros.htp.api.model.BookingRequest;
import ch.akros.htp.api.model.BookingResponse;
import ch.akros.htp.hotelvendor.service.BookingService;
import lombok.AllArgsConstructor;

@RestController
@AllArgsConstructor
@CrossOrigin(origins = "*", allowedHeaders = "*")
public class BookingController implements RoomBookingApi {
	private final BookingService bookingService;

	@Override
	public ResponseEntity<List<BookingResponse>> bookRoom(BookingRequest booking) {
		try {
			BookingResponse book = bookingService.book(booking);
			return ResponseEntity.status(book.getResponseStatus()).body(List.of(book));
		} catch (Exception ex) {
			BookingResponse br = new BookingResponse();
			br.setResponseMessage(ex.getMessage());
			return ResponseEntity.status(HttpStatus.NOT_FOUND).body(List.of(br));
		}
	}
}
