package ch.akros.htp.hotelvendor.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import ch.akros.htp.hotelvendor.entity.room.RoomEntity;
import ch.akros.htp.hotelvendor.entity.room.RoomEntity.RoomType;

public interface RoomRepository extends JpaRepository<RoomEntity, Long> {

	List<RoomEntity> findByPriceAndType(int price,RoomType roomType);
}
