package ch.akros.htp;

import ch.akros.htp.model.BookingSearchCriteria;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.context.annotation.RequestScope;

/**
 * Entry Point for the spring boot application
 *
 */
@SpringBootApplication
@CrossOrigin(origins = "*")
public class HtpBackendSpringbootApplication {
	public static void main(String[] args) {
		SpringApplication.run(HtpBackendSpringbootApplication.class, args);
	}

	@Bean
	BookingSearchCriteria bookingSearchCriteria(){
		return new BookingSearchCriteria();
	}

}
