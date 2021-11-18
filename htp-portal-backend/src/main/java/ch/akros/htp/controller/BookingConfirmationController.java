package ch.akros.htp.controller;

import ch.akros.htp.api.model.BookingConfirmation;
import ch.akros.htp.model.BookingSearchCriteria;
import ch.akros.htp.service.BookingConfirmationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import reactor.core.publisher.Flux;

@RestController
@CrossOrigin(origins = "*")
public class BookingConfirmationController {

    @Autowired
    BookingConfirmationService confirmationService;

    @Autowired
    BookingSearchCriteria bookingSearchCriteria;

    @GetMapping(value = "/bookings", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<BookingConfirmation> getBookings(@RequestParam(name = "hotelName", defaultValue = "") String hotelName) {
        bookingSearchCriteria.setHotelName(hotelName);
        confirmationService.loadAllSavedBookings();
        return confirmationService.bookingConfirmationStreamProcessor;
    }
}
