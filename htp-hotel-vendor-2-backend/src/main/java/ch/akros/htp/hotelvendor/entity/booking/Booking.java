package ch.akros.htp.hotelvendor.entity.booking;

import java.time.LocalDate;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.ForeignKey;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import ch.akros.htp.hotelvendor.entity.room.RoomEntity;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;

@NoArgsConstructor
@Getter
@Setter
@ToString
@Entity(name = "booking")
@Table(name = "booking")
public class Booking {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id")
	private Long id;

	@Column(name = "booked_from")
	private LocalDate bookedFrom;

	@Column(name = "booked_to")
	private LocalDate bookedTo;
	
	@ManyToOne
	@JoinColumn(referencedColumnName = "id", name = "room_id", foreignKey = @ForeignKey(name = "room_id_booking_fk"))
	private RoomEntity room;

	public Booking(LocalDate bookedFrom, LocalDate bookedTo, RoomEntity room) {
		super();
		this.bookedFrom = bookedFrom;
		this.bookedTo = bookedTo;
		this.room = room;
	}
	
	

}
