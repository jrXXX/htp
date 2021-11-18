package ch.akros.htp.configuration;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.reactive.function.client.WebClient;

/**
 * Class contains bean instantiation related to Web Client.
 *
 */
@Configuration
public class WebClientConfiguration {

	@Bean
	public WebClient getWebClient() {
		return WebClient.create();
	}
}
