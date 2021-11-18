package ch.akros.htp.controller;

import java.util.List;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RestController;

import ch.akros.htp.api.HotelSearchApi;
import ch.akros.htp.api.model.SearchRequest;
import ch.akros.htp.api.model.SearchResponse;
import ch.akros.htp.service.SearchVendorService;
import lombok.AllArgsConstructor;

/**
 * Controller for the communication with subscribed Vendors.
 *
 */
@RestController
@AllArgsConstructor
@CrossOrigin
public class SearchVendorController implements HotelSearchApi {

	private final SearchVendorService searchVendorService;

	/**
	 * Connects to the subscribed vendors and searches for hotels depending on the
	 * searchRequest
	 * 
	 * @param req the SearchRequest object. Must not be <code>null</code>.
	 * 
	 * @return a ResponseEntity containing list of search responses.
	 */
	public ResponseEntity<List<SearchResponse>> searchHotels(SearchRequest req) {
		return ResponseEntity.ok(searchVendorService.getSearchResponsesFromVendors(req));
	}

}
