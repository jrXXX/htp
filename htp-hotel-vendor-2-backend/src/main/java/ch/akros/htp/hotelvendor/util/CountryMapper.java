package ch.akros.htp.hotelvendor.util;

import org.mapstruct.Mapper;
import org.mapstruct.factory.Mappers;

import ch.akros.htp.api.model.Country;
import ch.akros.htp.hotelvendor.entity.country.CountryEntity;

@Mapper
public interface CountryMapper {

    CountryMapper COUNTRY_MAPPER_INSTANCE = Mappers.getMapper(CountryMapper.class);

    CountryEntity convertCountryDtoToEntity(Country source);

    Country convertCountryEntityToDto(CountryEntity source);
}
