package ch.akros.htp.hotelvendor.service;

import ch.akros.htp.api.model.BookingConfirmation;
import ch.akros.htp.api.model.BookingRequest;
import ch.akros.htp.api.model.BookingResponse;
import ch.akros.htp.api.model.Room;
import ch.akros.htp.hotelvendor.entity.booking.Booking;
import ch.akros.htp.hotelvendor.entity.room.RoomEntity;
import ch.akros.htp.hotelvendor.repository.BookingRepository;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import lombok.val;

import org.apache.commons.lang3.builder.ReflectionToStringBuilder;
import org.apache.commons.lang3.builder.ToStringStyle;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.kafka.config.TopicBuilder;
import org.springframework.kafka.core.KafkaTemplate;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.util.Base64;
import java.util.Optional;

import static ch.akros.htp.hotelvendor.constant.BookRoomConstant.*;
import static ch.akros.htp.hotelvendor.util.RoomMapper.ROOM_MAPPER_INSTANCE;
import static java.util.Objects.requireNonNull;

@Service
@RequiredArgsConstructor
@Slf4j
public class BookingService {


    private final BookingRepository bookingRepository;

    @Autowired
    private KafkaTemplate<String, BookingConfirmation> kafkaTemplate;

    @Value("${vendor.id}")
    private String currentVendorId;

    /**
     * @param req the booking request
     * @return a List of booking responses depended on the Booking requests
     */
    public BookingResponse book(final BookingRequest req) {
        requireNonNull(req, "Request object can not be null");

        log.info(String.format(">>> htp-hotel-vendor-2-backend\n%s\n",
				ReflectionToStringBuilder.toString(req, ToStringStyle.MULTI_LINE_STYLE)));
        
        Room room = requireNonNull(req.getRoom(), "Room cannot be null");
        
        log.info(String.format(">>> htp-hotel-vendor-2-backend\n%s\n",
				ReflectionToStringBuilder.toString(room, ToStringStyle.MULTI_LINE_STYLE)));
        
        LocalDate bookDateFrom = requireNonNull(req.getDateFrom(), "DateFrom cannot be null");
        LocalDate bookDateTo = requireNonNull(req.getDateTo(), "DateTo cannot be null");

        RoomEntity convertRoomDtoToEntity = ROOM_MAPPER_INSTANCE.convertRoomDtoToEntity(room);
        Booking booking = new Booking(bookDateFrom, bookDateTo, convertRoomDtoToEntity, room.getPrice());

        Optional<Booking> foundBooking = bookingRepository.findBookingByDateFromAndDateToAndRoomId(bookDateFrom,
                bookDateTo, room.getId());

        BookingResponse response = new BookingResponse().roomPaid(true).room(room).dateFrom(bookDateFrom)
                .dateTo(bookDateTo);
        foundBooking.ifPresentOrElse(x -> response.responseMessage(CONFLICT_MESSAGE).responseStatus(CONFLICT), () -> {
            val bookingConfirmation = bookingRepository.save(booking);
            response.responseMessage(OK_MESSAGE).responseStatus(OK);
            val portalRef = req.getPortalRef();
            Optional.ofNullable(org.apache.commons.codec.binary.Base64.isBase64(portalRef.getBytes()))
                    .filter( t  -> t == true)
                    .ifPresent(
                        t -> {
                            val topicName = createTopicWithPortalId(portalRef);
                            dispatchBookingConfirmation(topicName, bookingConfirmation, req);
                        }
                    );

        });
        return getBookingResponse(response);
    }

    private String createTopicWithPortalId(final String portalId) {

        // org.apache.commons.codec.binary.Base64.isBase64(portalId.getBytes());
        // try to create a new topic
        val topicName = new String(Base64.getDecoder().decode(portalId));
        TopicBuilder.name(topicName).build();
        return topicName;
    }

    private void dispatchBookingConfirmation(String topicName, Booking bookingConfirmation, final BookingRequest bookingRequest) {
        log.info(String.format("Confirming booking came from Portal %s, From %s to  %s. used Topic %s ",
                bookingConfirmation.getId().toString(),
                bookingRequest.getDateFrom().toString(),
                bookingRequest.getDateTo().toString(),
                topicName));
        BookingConfirmation confirmation = new BookingConfirmation();
        confirmation.setBookingDate(LocalDate.now().toString());
        confirmation.setBookingId(bookingConfirmation.getId().toString());
        confirmation.setDateFrom(bookingRequest.getDateFrom());
        confirmation.setDateTo(bookingRequest.getDateTo());
        confirmation.setRoomPaid(true);
        confirmation.setCurrency(bookingRequest.getRoom().getCurrency().toString());
        confirmation.setVendorId(currentVendorId);
        confirmation.setCustomerName(bookingRequest.getCustomerName());
        confirmation.setCustomerEmail(bookingRequest.getCustomerEmail());
        confirmation.setCustomerPhonenumber(bookingRequest.getCustomerPhonenumber());
        confirmation.setBookingPrice(String.valueOf(bookingRequest.getRoom().getPrice()));
        kafkaTemplate.send(topicName, bookingConfirmation.getId().toString(), confirmation);
    }

    private BookingResponse getBookingResponse(BookingResponse response) {
        return response;
    }

}
