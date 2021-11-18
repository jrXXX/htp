package ch.akros.htp.hotelvendor.service;

import static ch.akros.htp.hotelvendor.constant.BookRoomConstant.CONFLICT;
import static ch.akros.htp.hotelvendor.constant.BookRoomConstant.CONFLICT_MESSAGE;
import static ch.akros.htp.hotelvendor.constant.BookRoomConstant.OK;
import static ch.akros.htp.hotelvendor.constant.BookRoomConstant.OK_MESSAGE;
import static ch.akros.htp.hotelvendor.util.RoomMapper.ROOM_MAPPER_INSTANCE;
import static java.util.Objects.requireNonNull;

import java.time.LocalDate;
import java.util.Optional;

import org.springframework.stereotype.Service;

import ch.akros.htp.api.model.BookingRequest;
import ch.akros.htp.api.model.BookingResponse;
import ch.akros.htp.api.model.Room;
import ch.akros.htp.hotelvendor.entity.booking.Booking;
import ch.akros.htp.hotelvendor.entity.room.RoomEntity;
import ch.akros.htp.hotelvendor.repository.BookingRepository;
import lombok.AllArgsConstructor;

@Service
@AllArgsConstructor
public class BookingService {


	private final BookingRepository bookingRepository;

	/**
	 * 
	 * @param booking the booking request
	 * @return a List of booking responses depended on the Booking requests
	 */
	public BookingResponse book(final BookingRequest req) {

		requireNonNull(req, "Request object can not be null");

		Room room = requireNonNull(req.getRoom(), "Room cannot be null");
		LocalDate bookDateFrom = requireNonNull(req.getDateFrom(), "DateFrom cannot be null");
		LocalDate bookDateTo = requireNonNull(req.getDateTo(), "DateTo cannot be null");

		RoomEntity convertRoomDtoToEntity = ROOM_MAPPER_INSTANCE.convertRoomDtoToEntity(room);
		Booking booking = new Booking(bookDateFrom, bookDateTo, convertRoomDtoToEntity);

		Optional<Booking> foundBooking = bookingRepository.findBookingByDateFromAndDateToAndRoomId(bookDateFrom,
				bookDateTo, room.getId());

		BookingResponse response = new BookingResponse().roomPaid(true).room(room).dateFrom(bookDateFrom)
				.dateTo(bookDateTo);
		foundBooking.ifPresentOrElse(x -> response.responseMessage(CONFLICT_MESSAGE).responseStatus(CONFLICT), () -> {
			response.responseMessage(OK_MESSAGE).responseStatus(OK);
			bookingRepository.save(booking);
		});
		return getBookingResponse(response);
	}

	private BookingResponse getBookingResponse(BookingResponse response) {
		return response;
	}

}
