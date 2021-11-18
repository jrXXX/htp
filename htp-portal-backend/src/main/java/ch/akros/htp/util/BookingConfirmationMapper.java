package ch.akros.htp.util;

import ch.akros.htp.model.BookingConfirmation;
import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.mapstruct.factory.Mappers;

import java.time.LocalDate;

@Mapper
public interface BookingConfirmationMapper {

    BookingConfirmationMapper BOOKING_CONFIRMATION_MAPPER_INSTANCE = Mappers.getMapper(BookingConfirmationMapper.class);

    default String assignDateToString(LocalDate source) {
        return source.toString();
    }

    default  LocalDate assignStringToDate( String source) {
        return LocalDate.parse(source);
    }

    @Mapping(expression = "java(assignDateToString(source.getDateFrom()))", target = "dateFrom")
    @Mapping(expression = "java(assignDateToString(source.getDateTo()))", target = "dateTo")
    BookingConfirmation convertApiBookingConfirmationToDto(ch.akros.htp.api.model.BookingConfirmation source);

    @Mapping(expression = "java(assignStringToDate(source.getDateFrom()))", target = "dateFrom")
    @Mapping(expression = "java(assignStringToDate(source.getDateTo()))", target = "dateTo")
    ch.akros.htp.api.model.BookingConfirmation convertDtoToApiBookingConfirmation(BookingConfirmation source);

}



