package ch.akros.htp.hotelvendor.util;

import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

import ch.akros.htp.hotelvendor.entity.image.ImageEntity;
import org.mapstruct.BeanMapping;
import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.mapstruct.MappingTarget;
import org.mapstruct.NullValuePropertyMappingStrategy;
import org.mapstruct.factory.Mappers;

import ch.akros.htp.api.model.Facility;
import ch.akros.htp.api.model.Image;
import ch.akros.htp.api.model.Hotel;
import ch.akros.htp.hotelvendor.entity.facilityassignment.FacilityAssignment;
import ch.akros.htp.hotelvendor.entity.facilityassignment.FacilityAssignmentID;
import ch.akros.htp.hotelvendor.entity.hotel.HotelEntity;

@Mapper
public interface HotelMapper {

	HotelMapper HOTEL_MAPPER_INSTANCE = Mappers.getMapper(HotelMapper.class);

	@Mapping(source = "image", target = "imageEntities")
	@Mapping(expression = "java(facilitiesToAssignments(source.getFacilities(), source))", target = "facilityAssignments")
	HotelEntity convertHotelDtoToEntity(Hotel source);

	@Mapping(expression = "java(imageEntitiesToImages(source.getImageEntities()))", target = "image")
	@Mapping(expression = "java(assignmentEntitiesToFacilities(source.getFacilityAssignments()))", target = "facilities")
	Hotel convertHotelEntityToDto(HotelEntity source);

	@BeanMapping(nullValuePropertyMappingStrategy = NullValuePropertyMappingStrategy.IGNORE)
	void updateHotelEntityFromDto(Hotel source, @MappingTarget HotelEntity target);

	default List<Facility> assignmentEntitiesToFacilities(Set<FacilityAssignment> target) {
		return target.stream().map(FacilityAssignment::getFacility)
				.map(x -> new Facility().id(x.getId()).name(x.getName())).collect(Collectors.toList());
	}

	default Set<FacilityAssignment> facilitiesToAssignments(List<Facility> target, Hotel hotel) {
		return target.stream()
				.map(x -> new FacilityAssignment(new FacilityAssignmentID(hotel.getId(), x.getId()), null, null))
				.collect(Collectors.toSet());
	}

	default List<Image> imageEntitiesToImages(Set<ImageEntity> target) {
		return target.stream()
				.map(x -> new Image().
						name(x.getName()).
						id(x.getId()).
						height(x.getHeight()).
						width(x.getWidth()).
						image(x.getDownloadUrl()).
						thumbImage(x.getDownloadUrl()).
						alt(String.format("Image %d", x.getId()) )
				)
				.collect(Collectors.toList());
	}

}
