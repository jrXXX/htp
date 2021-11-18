package ch.akros.htp.model;

import com.azure.spring.data.cosmos.core.mapping.Container;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.data.annotation.Id;

@Container(containerName = "bookingconfirmation")
@Data
@AllArgsConstructor
@NoArgsConstructor
public class BookingConfirmation {

    private Boolean roomPaid;

    private String dateFrom;

    private String dateTo;

    private String customerName;

    private String customerEmail;

    private String customerPhonenumber;

    private String bookingDate;

    private String bookingPrice;

    private String currency;

    private String vendorId;

    @Id
    private String bookingId;
}
