package ch.akros.htp.controller;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;

import ch.akros.htp.api.GetFacilitiesApi;
import ch.akros.htp.api.model.Facility;

/**
 * Controller for providing a static facilities list for the time being.
 *
 */
@RestController
public class FacilitiesController implements GetFacilitiesApi {

	private static final String[] FACILITIES = { "Terrace", "Lobby", "Bellevue Bar", "SPA", "Pool", "WiFi", "Bar",
			"Fitness" };

	@Override
	public ResponseEntity<List<Facility>> getFacilities() {
		List<Facility> facilities = Arrays.stream(FACILITIES).map(f->new Facility().name(f)).collect(Collectors.toList());
		return ResponseEntity.ok(facilities);
	}
}
