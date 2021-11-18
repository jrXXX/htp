package ch.akros.htp.hotelvendor.entity.facilityassignment;

import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.ForeignKey;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.MapsId;
import javax.persistence.Table;

import ch.akros.htp.hotelvendor.entity.facility.FacilityEntity;
import ch.akros.htp.hotelvendor.entity.hotel.HotelEntity;
import lombok.Getter;
import lombok.Setter;

@Entity(name = "FacilityAssignment")
@Table(name = "facility_assignment")
@Setter
@Getter
public class FacilityAssignment {

	@EmbeddedId
	private FacilityAssignmentID facilityAssignmentID;

	@ManyToOne
	@MapsId(value = "hotelId")
	@JoinColumn(name = "hotel_id", foreignKey = @ForeignKey(name = "facilityassignment_hotel_id_fk"))
	private HotelEntity hotel;

	@MapsId(value = "facilityId")
	@ManyToOne
	@JoinColumn(name = "facility_id", foreignKey = @ForeignKey(name = "facilityassignment_facility_id_fk"))
	private FacilityEntity facility;

	public FacilityAssignment() {
	}

	public FacilityAssignment(HotelEntity hotel, FacilityEntity facility) {
		this.hotel = hotel;
		this.facility = facility;
	}

	public FacilityAssignment(FacilityAssignmentID facilityAssignmentID, HotelEntity hotel, FacilityEntity facility) {
		this.facilityAssignmentID = facilityAssignmentID;
		this.hotel = hotel;
		this.facility = facility;
	}

}
