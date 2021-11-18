package ch.akros.htp.bindings;

import ch.akros.htp.api.model.BookingRequest;
import org.apache.kafka.streams.kstream.KStream;
import org.springframework.cloud.stream.annotation.Input;

public interface KafkaListenerBinding {
    @Input("booking-confirmation-channel")
    KStream<String, BookingRequest> inputStream();
}
