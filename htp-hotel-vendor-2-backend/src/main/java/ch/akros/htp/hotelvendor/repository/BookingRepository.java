package ch.akros.htp.hotelvendor.repository;

import java.time.LocalDate;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import ch.akros.htp.hotelvendor.entity.booking.Booking;

@Repository
public interface BookingRepository extends JpaRepository<Booking, Long> {

	@Query("select b from booking b where b.bookedFrom = :bookedFrom and b.bookedTo = :bookedTo and b.room.id = :roomID")
	Optional<Booking> findBookingByDateFromAndDateToAndRoomId(LocalDate bookedFrom, LocalDate bookedTo, Long roomID);
}
