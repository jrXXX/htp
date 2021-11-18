package ch.akros.htp.configuration;

import org.springframework.boot.autoconfigure.security.oauth2.resource.OAuth2ResourceServerProperties;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.oauth2.jwt.JwtDecoder;
import org.springframework.security.oauth2.jwt.NimbusJwtDecoder;

/**
 * Class containing security configuration and bean instantiation related to
 * security.
 *
 */
@Configuration
public class SecurityConfiguration extends WebSecurityConfigurerAdapter {

	@Override
	public void configure(HttpSecurity http) throws Exception {
		http
				.cors().and()
				.httpBasic().disable()
				.csrf().disable()
				.authorizeRequests()
				// Allow Swagger-Ui Paths
				.antMatchers("/").permitAll()
				.antMatchers("/v3/**").permitAll()
				.antMatchers("/swagger-ui.html").permitAll()
				.antMatchers("/swagger-ui/**").permitAll()
				.antMatchers("/booking/**").permitAll()
				.antMatchers("/hotelSearch/**").permitAll();
				// Allow GET on resources

				// Authenticate other Requests
				/*.anyRequest()
				.authenticated()
				.and()
				.oauth2ResourceServer()
				.jwt();*/
	}

	@Bean
	public JwtDecoder customDecoder(OAuth2ResourceServerProperties properties) {
		// Use spring.security.oauth2.resourceserver.jwt.jwk-set-uri key in
		// authentication.properties to retrieve JwkSet
		return NimbusJwtDecoder.withJwkSetUri(properties.getJwt().getJwkSetUri()).build();
	}

	@Bean
	public PasswordEncoder passwordEncoder() {
		return new BCryptPasswordEncoder();
	}
}
