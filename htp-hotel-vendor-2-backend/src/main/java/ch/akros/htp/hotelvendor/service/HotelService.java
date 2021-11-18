package ch.akros.htp.hotelvendor.service;

import static ch.akros.htp.hotelvendor.util.HotelMapper.HOTEL_MAPPER_INSTANCE;
import static ch.akros.htp.hotelvendor.util.RoomMapper.ROOM_MAPPER_INSTANCE;
import static java.util.Objects.requireNonNull;

import java.util.List;
import java.util.function.Predicate;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import org.apache.commons.lang3.StringUtils;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import ch.akros.htp.api.model.Facility;
import ch.akros.htp.api.model.Hotel;
import ch.akros.htp.api.model.SearchRequest;
import ch.akros.htp.api.model.SearchResponse;
import ch.akros.htp.hotelvendor.entity.hotel.HotelEntity;
import ch.akros.htp.hotelvendor.entity.room.RoomEntity;
import ch.akros.htp.hotelvendor.repository.HotelRepository;
import lombok.AllArgsConstructor;

@Service
@Transactional
@AllArgsConstructor
public class HotelService {

	private final HotelRepository hotelRepository;
	private final RoomService roomService;

	/**
	 * 
	 * @param req the booking request
	 * @return a List of booking responses depended on the Booking requests
	 */
	public List<SearchResponse> searchHotels(final SearchRequest req) {
		requireNonNull(req, "Request object can not be null");
		return getFilteredHotels(req).map(hotelEntity -> getSearchResponse(req, hotelEntity))
				.collect(Collectors.toList());
	}

	private Stream<Hotel> getFilteredHotels(final SearchRequest req) {
		final String destinationCity = requireNonNull(req.getDestinationCity(), "City can not be null");
		final String destinationCountry = requireNonNull(req.getDestinationCountry(), "Country can not be null");
		final String destinationPostalCode = StringUtils.trimToEmpty(req.getDestinationPostalCode());
		requireNonNull(req.getDateFrom(), "Date 'from' cannot be null");
		requireNonNull(req.getDateTo(), "Date 'to' cannot be null");

		Stream<HotelEntity> hotelStream = hotelRepository.findByCityWithEventualPostalCodeAndCountry(destinationCity, destinationPostalCode, destinationCountry)
				.parallelStream();

		hotelStream = filterByName(hotelStream, StringUtils.trimToEmpty(req.getHotelName()));
		hotelStream = filterByFacilities(hotelStream, req.getFacilityList());
		Stream<Hotel> hotelsWithAvailableRooms = findHotelsWithAvailableRoomsAndConvertToDto(hotelStream, req);
		return hotelsWithAvailableRooms;
	}

	private Stream<Hotel>findHotelsWithAvailableRoomsAndConvertToDto(Stream<HotelEntity> hotelStream, SearchRequest req) {
		return hotelStream.map(hotel -> {
			List<RoomEntity> rooms = roomService.filteredRooms(hotel.getRooms(), req);
			Hotel hotelDto = HOTEL_MAPPER_INSTANCE.convertHotelEntityToDto(hotel);
			hotelDto.setRooms(ROOM_MAPPER_INSTANCE.convertRoomEntityToDto(rooms));
			return hotelDto;
		}).filter(hotelDto -> !hotelDto.getRooms().isEmpty());
	}

	private Stream<HotelEntity> filterByFacilities(Stream<HotelEntity> hotelStream,
			final List<Facility> requestedFacilities) {
		if (requestedFacilities != null && !requestedFacilities.isEmpty()) {
			hotelStream = hotelStream.filter(areFacilitiesIncluded(requestedFacilities));
		}
		return hotelStream;
	}

	private Stream<HotelEntity> filterByName(Stream<HotelEntity> hotelStream, final String hotelName) {

		return StringUtils.isNotEmpty(hotelName)
				? hotelStream.filter(requestedHotel -> hotelName.equalsIgnoreCase(requestedHotel.getName()))
				: hotelStream;
	}



	private SearchResponse getSearchResponse(final SearchRequest request, Hotel hotelDto) {
		return new SearchResponse()//
				.currency(SearchResponse.CurrencyEnum.fromValue(request.getCurrency().getValue()))//
				.dateFrom(request.getDateFrom())//
				.dateTo(request.getDateTo())//
				.numberOfGuests(request.getNumberOfGuests())//
				.hotel(hotelDto);
	}

	private Predicate<? super HotelEntity> areFacilitiesIncluded(List<Facility> requestedFacilities) {
		return hotelEntity -> {
			List<String> requestedFacilityNames = requestedFacilities.stream().map(e -> e.getName().toLowerCase())
					.collect(Collectors.toList());
			List<String> offeredFacilityNames = hotelEntity.getFacilityAssignments().stream()
					.map(e -> e.getFacility().getName().toLowerCase()).collect(Collectors.toList());
			return offeredFacilityNames.containsAll(requestedFacilityNames);
		};
	}

}
