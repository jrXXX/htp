package ch.akros.htp.hotelvendor.util;

import java.util.List;

import org.mapstruct.BeanMapping;
import org.mapstruct.Mapper;
import org.mapstruct.MappingTarget;
import org.mapstruct.NullValuePropertyMappingStrategy;
import org.mapstruct.factory.Mappers;

import ch.akros.htp.api.model.Room;
import ch.akros.htp.hotelvendor.entity.room.RoomEntity;

@Mapper
public interface RoomMapper {

	RoomMapper ROOM_MAPPER_INSTANCE = Mappers.getMapper(RoomMapper.class);

	List<RoomEntity> convertRoomDtoToEntity(List<Room> source);

	RoomEntity convertRoomDtoToEntity(Room source);

	List<Room> convertRoomEntityToDto(List<RoomEntity> room);

	Room convertRoomEntityToDto(RoomEntity room);

	@BeanMapping(nullValuePropertyMappingStrategy = NullValuePropertyMappingStrategy.IGNORE)
	void updateRoomEntityFromDto(List<Room> source, @MappingTarget List<RoomEntity> target);

	@BeanMapping(nullValuePropertyMappingStrategy = NullValuePropertyMappingStrategy.IGNORE)
	void updateRoomEntityFromDto(Room source, @MappingTarget RoomEntity target);
}
