package ch.akros.htp.hotelvendor.entity.hotel;

import java.util.HashSet;
import java.util.Set;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.ForeignKey;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.Max;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

import ch.akros.htp.hotelvendor.entity.country.CountryEntity;
import ch.akros.htp.hotelvendor.entity.facilityassignment.FacilityAssignment;
import ch.akros.htp.hotelvendor.entity.image.ImageEntity;
import ch.akros.htp.hotelvendor.entity.room.RoomEntity;
import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;

@NoArgsConstructor
@AllArgsConstructor(access = AccessLevel.PRIVATE)
@Builder
@Entity
@Getter
@Setter
@ToString
@Table(name = "HOTEL")
public class HotelEntity {

	@Id
	@Column(name = "ID", unique = true)
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;

	@NotBlank
	@Size(min = 3, max = 100)
	@Column(name = "NAME")
	private String name;

	@Max(5)
	@Column(name = "STARS", nullable = false)
	private Integer stars;

	@NotBlank
	@Column(name = "ZIP_CODE")
	private String zipCode;

	@NotBlank
	@Column(name = "STREET")
	private String street;

	@NotBlank
	@Column(name = "CITY")
	private String city;

	@NotBlank
	@Column(name = "HOUSE_NUMBER")
	private String houseNumber;

	@NotBlank
	@Column(name = "HOMEPAGE")
	private String homepage;

	@OneToMany(mappedBy = "hotel", cascade = CascadeType.ALL, orphanRemoval = true, fetch = FetchType.EAGER)
	@Builder.Default
	@ToString.Exclude
	private Set<RoomEntity> rooms = new HashSet<>();

	@OneToMany(mappedBy = "hotel", cascade = CascadeType.ALL, orphanRemoval = true, fetch = FetchType.EAGER)
	@Builder.Default
	@ToString.Exclude
	private Set<FacilityAssignment> facilityAssignments = new HashSet<>();

	@OneToMany(mappedBy = "hotel", cascade = CascadeType.ALL, orphanRemoval = true, fetch = FetchType.EAGER)
	@Builder.Default
	@ToString.Exclude
	private Set<ImageEntity> imageEntities = new HashSet<>();

	@ManyToOne(fetch = FetchType.LAZY, cascade = CascadeType.ALL)
	@JoinColumn(referencedColumnName = "id", name = "COUNTRY_ID", foreignKey = @ForeignKey(name = "country_id_hotel_fk"))
	@ToString.Exclude
	private CountryEntity country;
}
