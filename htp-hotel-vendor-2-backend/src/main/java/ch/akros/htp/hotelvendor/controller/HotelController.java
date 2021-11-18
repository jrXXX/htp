package ch.akros.htp.hotelvendor.controller;

import java.util.List;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;

import ch.akros.htp.api.HotelSearchApi;
import ch.akros.htp.api.model.SearchRequest;
import ch.akros.htp.api.model.SearchResponse;
import ch.akros.htp.hotelvendor.service.HotelService;
import lombok.AllArgsConstructor;

@RestController
@AllArgsConstructor
public class HotelController implements HotelSearchApi {
	private final HotelService hotelService;

	@Override
	public ResponseEntity<List<SearchResponse>> searchHotels(SearchRequest request) {
		try {
			return ResponseEntity.ok(hotelService.searchHotels(request));
		} catch (Exception ex) {
			return ResponseEntity.notFound().build();
		}

	}
}
