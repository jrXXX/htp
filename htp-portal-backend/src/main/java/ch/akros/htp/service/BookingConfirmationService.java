package ch.akros.htp.service;

import ch.akros.htp.bindings.KafkaListenerBinding;
import ch.akros.htp.model.BookingConfirmation;
import ch.akros.htp.model.BookingSearchCriteria;
import ch.akros.htp.repository.BookingConfirmationRepository;
import ch.akros.htp.util.BookingConfirmationMapper;
import lombok.extern.slf4j.Slf4j;
import org.apache.kafka.streams.kstream.KStream;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.cloud.stream.annotation.EnableBinding;
import org.springframework.cloud.stream.annotation.StreamListener;
import org.springframework.stereotype.Service;
import reactor.core.publisher.EmitterProcessor;

import java.util.Optional;

@EnableBinding(KafkaListenerBinding.class)
@Slf4j
@Service
public class BookingConfirmationService {

    public final EmitterProcessor<ch.akros.htp.api.model.BookingConfirmation> bookingConfirmationStreamProcessor = EmitterProcessor.create();
    @Autowired
    BookingSearchCriteria bookingSearchCriteria;
    @Autowired
    private BookingConfirmationRepository repository;

    @StreamListener("booking-confirmation-channel")
    public void process(KStream<String, ch.akros.htp.api.model.BookingConfirmation> input) {
        input.foreach((K, V) -> {
            log.info(String.format("Key : %s, Value %s", K, V));
            final BookingConfirmation bookingConfirmation = BookingConfirmationMapper.BOOKING_CONFIRMATION_MAPPER_INSTANCE.convertApiBookingConfirmationToDto(V);
            repository.save(bookingConfirmation).
                    doOnNext(t -> this.bookingConfirmationStreamProcessor.onNext(V)).
                    doOnNext(t -> log.info("New Booking confimation arrived :  *" + t)).
                    subscribe();

        });
    }

    public void loadAllSavedBookings() {
                     repository.findSpecificVendor(Optional.ofNullable(bookingSearchCriteria.getHotelName()).orElse(""))
                    .doOnNext(t -> this.bookingConfirmationStreamProcessor.onNext(BookingConfirmationMapper.BOOKING_CONFIRMATION_MAPPER_INSTANCE.convertDtoToApiBookingConfirmation(t)))
                    .doOnNext(t -> log.info("Found *" + t))
                    .subscribe();
    }

}
