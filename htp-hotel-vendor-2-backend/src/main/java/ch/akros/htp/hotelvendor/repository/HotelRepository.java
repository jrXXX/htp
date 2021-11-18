package ch.akros.htp.hotelvendor.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import ch.akros.htp.hotelvendor.entity.hotel.HotelEntity;

@Repository
public interface HotelRepository extends JpaRepository<HotelEntity, Long> {

    /**
     * @param query The search query. Must be all lower case.
     * @return Results matching the query. Searched fields are hotel name, city, and country name.
     */
    @Query(value = "SELECT h FROM HotelEntity h JOIN h.country c " +
            "WHERE LOWER(h.name) LIKE %:query% OR LOWER(h.city) LIKE %:query% OR LOWER(c.name) LIKE %:query%")
    List<HotelEntity> findByQuery(@Param("query") String query);


    /**
     * @param name of the hotel
     * @return a Hotel
     */
    @Query("select h from HotelEntity h where h.name = :name")
    HotelEntity findByName(String name);


    @Query(value = "select h from HotelEntity h join h.country c " +
            "where h.city like %:city% AND c.name like %:country% ")
    List<HotelEntity> findByCityAndCountry(String city, String country);

    @Query(value = "select h from HotelEntity h join h.country c " +
            "where (h.city like %:city% AND (TRIM(:postalCode) = '' OR h.zipCode = :postalCode)) AND c.name like %:country% ")
    List<HotelEntity> findByCityWithEventualPostalCodeAndCountry(String city, String postalCode, String country);

}
