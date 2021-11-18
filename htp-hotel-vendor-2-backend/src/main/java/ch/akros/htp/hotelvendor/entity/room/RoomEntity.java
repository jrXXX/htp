package ch.akros.htp.hotelvendor.entity.room;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.FetchType;
import javax.persistence.ForeignKey;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Transient;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.Size;


import ch.akros.htp.hotelvendor.entity.booking.Booking;
import ch.akros.htp.hotelvendor.entity.hotel.HotelEntity;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;

@NoArgsConstructor
@Entity
@Getter
@Setter
@ToString
@Table(name = "ROOM")
public class RoomEntity {
	@Id
	@Column(name = "id", unique = true)
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;

	@NotBlank
	@Size(min = 3, max = 100)
	@Column(name = "NAME")
	private String name;

	@Enumerated(EnumType.STRING)
	@Column(name = "TYPE")
	private RoomType type;
	
	@Column(name = "PRICE")
	private int price;
	
	@Transient
	private String deepLink;

	@ManyToOne
	@ToString.Exclude
	@JoinColumn(referencedColumnName = "id", name = "HOTEL_ID", foreignKey = @ForeignKey(name = "hotel_id_room_fk"))
	private HotelEntity hotel;

	@OneToMany(mappedBy = "room", cascade = CascadeType.ALL, fetch = FetchType.EAGER)
	@ToString.Exclude
	private List<Booking> bookings = new ArrayList<>();

	public RoomEntity(@NotBlank @Size(min = 3, max = 100) String name, RoomType type,int price) {
		super();
		this.name = name;
		this.type = type;
		this.price = price;
	}

	public enum RoomType {

		SINGLE, DOUBLE, TRIPLE, QUAD, QUEEN, KING, TWIN, DOUBLE_DOUBLE, STUDIO;
	}
}
