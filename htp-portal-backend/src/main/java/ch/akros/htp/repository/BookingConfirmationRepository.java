package ch.akros.htp.repository;

import ch.akros.htp.model.BookingConfirmation;
import com.azure.spring.data.cosmos.repository.Query;
import com.azure.spring.data.cosmos.repository.ReactiveCosmosRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import reactor.core.publisher.Flux;

@Repository
public interface BookingConfirmationRepository extends ReactiveCosmosRepository<BookingConfirmation, String> {

//    @Query("SELECT * FROM c where (@vendorId=''  or c.vendorId = @vendorId) " +
//            "( @dateFrom='' or c.dateFrom = @dateFrom ) " +
//            "( @dateTo='' or c.dateTo = @dateTo  @dateTo='') ")
//    Flux<BookingConfirmation> findSpecificBookingConfirmations(@Param("vendorId") String vendorId,
//                                                   @Param("dateFrom") String dateFrom,
//                                                   @Param("dateTo") String dateTo
//    );

    @Query("SELECT * FROM c where (@vendorId=''  or c.vendorId = @vendorId) ")
    Flux<BookingConfirmation> findSpecificVendor(@Param("vendorId") String vendorId
    );


}
