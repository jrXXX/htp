package ch.akros.htp.hotelvendor.constant;

import org.springframework.http.HttpStatus;

import lombok.AccessLevel;
import lombok.AllArgsConstructor;

@AllArgsConstructor(access = AccessLevel.PRIVATE)
public class BookRoomConstant {
	
	public static final int CONFLICT = HttpStatus.CONFLICT.value();
	public static final String CONFLICT_MESSAGE = "Room was booked from someone else in the meantime. Search again.";
	public static final int OK = HttpStatus.OK.value();
	public static final String OK_MESSAGE = "Room Booked!";

	
}
