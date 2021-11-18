package ch.akros.htp.security;

import lombok.extern.slf4j.Slf4j;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.test.context.TestPropertySource;

import static org.assertj.core.api.Assertions.assertThat;

@SpringBootTest
@TestPropertySource(locations = "classpath:application-test.yml")
@Slf4j
public class PasswordEncoderTest {

    /**
     * scenario: encryption and decryption of password with BCrypt algorithm. encrypted password will be saved in db
     */
    @Test
    public void testPassword() {
        final var passwordEncoder = new BCryptPasswordEncoder();
        final var encode = passwordEncoder.encode("password123");
        log.info(encode);

        final var result = passwordEncoder.matches("password123", encode);
        assertThat(result).isTrue();
    }
}
