package ch.akros.htp.hotelvendor.service;

import static java.lang.Integer.MAX_VALUE;
import static java.util.Objects.requireNonNull;

import java.time.LocalDate;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import ch.akros.htp.api.model.SearchRequest;
import ch.akros.htp.hotelvendor.entity.booking.Booking;
import ch.akros.htp.hotelvendor.entity.room.RoomEntity;
import ch.akros.htp.hotelvendor.entity.room.RoomEntity.RoomType;
import ch.akros.htp.hotelvendor.exception.ObjectNotFoundException;
import ch.akros.htp.hotelvendor.repository.RoomRepository;
import lombok.RequiredArgsConstructor;

@Service
@RequiredArgsConstructor
public class RoomService {

	@Value("${frontEndUrl}")
	private String frontEndUrl;

	private final RoomRepository roomRepository;

	public RoomEntity findByID(Long id) throws ObjectNotFoundException {
		return roomRepository.findById(id).orElseThrow(() -> new ObjectNotFoundException("room Not Found"));
	}

	public List<RoomEntity> findByPriceAndType(int price, RoomType roomType) {
		return roomRepository.findByPriceAndType(price, roomType);
	}

	public List<RoomEntity> filteredRooms(Set<RoomEntity> rooms, SearchRequest request) {
		rooms = new HashSet<>(rooms);
		rooms.stream().map(RoomEntity::getBookings).flatMap(List<Booking>::stream).filter(filterByDates(request))
				.map(Booking::getRoom).collect(Collectors.toList()).forEach(rooms::remove);
		Stream<RoomEntity> filteredRooms = rooms.stream().filter(filterByPriceRange(request));

		return filteredRooms.map(generateDeepLink(request)).collect(Collectors.toList());
	}

	private Predicate<Booking> filterByDates(SearchRequest request) {
		LocalDate dateFrom = requireNonNull(request.getDateFrom(), "Request date from is null");
		LocalDate dateTo = requireNonNull(request.getDateTo(), "Request date to is null");
		if (dateFrom.isEqual(dateTo) || dateFrom.isAfter(dateTo)) {
			throw new IllegalArgumentException("Date 'From' is equal or after the date 'to'");
		}
		return b -> !isNotConflicting(dateFrom, dateTo, b);
	}

	private Function<? super RoomEntity, ? extends RoomEntity> generateDeepLink(SearchRequest request) {
		return room -> {
			String deepLink = String.format("%s/rooms/book/?id=%s&roomName=%s&roomPrice=%s&roomType=%s&bookFrom=%s&bookTo=%s",
					frontEndUrl, room.getId(), room.getName(), room.getPrice(), room.getType().name().toLowerCase(),
					request.getDateFrom(), request.getDateTo());
			room.setDeepLink(deepLink);
			return room;
		};
	}

	/**
	 * The 2 date ranges do not conflict when the whole range is before the other
	 * range or the opposite. So NOT to be coflicted both the from and to of the
	 * request should be before the from of the booked. OR both of the booked from
	 * and To should be before the req From.
	 * 
	 * 
	 * @param reqFrom
	 * @param reqTo
	 * @param booking
	 * @return
	 */
	private boolean isNotConflicting(LocalDate reqFrom, LocalDate reqTo, Booking booking) {
		LocalDate bookedFrom = booking.getBookedFrom();
		LocalDate bookedTo = booking.getBookedTo();
		return reqFrom.isBefore(bookedFrom) && reqTo.isBefore(bookedFrom)
				|| bookedFrom.isBefore(reqFrom) && bookedTo.isBefore(reqFrom);
	}

	private Predicate<? super RoomEntity> filterByPriceRange(SearchRequest request) {
		Integer priceFrom = request.getPriceFrom() == null ? 0 : request.getPriceFrom();
		Integer priceTo = request.getPriceTo() == null ? MAX_VALUE : request.getPriceTo();
		if (priceFrom > priceTo) {
			throw new IllegalArgumentException("Price 'from' is bigger than the price 'to' !");
		}
		return r -> r.getPrice() >= priceFrom && r.getPrice() <= priceTo;
	}

}
