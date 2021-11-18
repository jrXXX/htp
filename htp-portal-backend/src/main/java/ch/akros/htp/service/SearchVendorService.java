package ch.akros.htp.service;

import static java.util.Arrays.stream;
import static java.util.stream.Collectors.toList;

import java.net.URI;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.concurrent.atomic.AtomicBoolean;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.ParameterizedTypeReference;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.reactive.function.client.WebClient;

import com.google.common.reflect.TypeToken;
import com.microsoft.applicationinsights.core.dependencies.google.gson.GsonBuilder;
import com.microsoft.applicationinsights.core.dependencies.google.gson.JsonDeserializer;
import com.microsoft.applicationinsights.core.dependencies.google.gson.JsonPrimitive;
import com.microsoft.applicationinsights.core.dependencies.google.gson.JsonSerializer;

import ch.akros.htp.api.model.SearchRequest;
import ch.akros.htp.api.model.SearchResponse;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import reactor.core.publisher.Mono;

@Service
@RequiredArgsConstructor
@Slf4j
public class SearchVendorService {
	@Value("${vendors}")
	private String[] vendorUrls;

	private final WebClient webClient;

	/**
	 * Connects to the subscribed vendors and searches for hotels depending on the
	 * searchRequest
	 * 
	 * @param req the SearchRequest object. Must not be <code>null</code>.
	 * 
	 * @return a ResponseEntity containing list of search responses.
	 */
	public List<SearchResponse> getSearchResponsesFromVendors(SearchRequest req) {
		System.getenv().entrySet().stream()
				.forEach(e -> log.info(String.format("env : %s => %s\n", e.getKey(), e.getValue())));
		System.getProperties().entrySet().stream()
				.forEach(e -> log.info(String.format("prop : %s => %s\n", e.getKey(), e.getValue())));

		return stream(vendorUrls).map(u -> getResponses(req, u)).flatMap(List::stream).collect(toList());
	}

	private List<SearchResponse> getResponses(SearchRequest request, String url) {
		log.info("request to: " + url);

		AtomicBoolean hasError = new AtomicBoolean(false);

		var result = webClient.post()//
				.uri(URI.create(url)).body(Mono.just(request), SearchRequest.class).retrieve()//
				.toEntity(new ParameterizedTypeReference<List<SearchResponse>>() {
				})//
				.onErrorResume(x -> {
					log.error(x.getMessage());
					hasError.set(true);
					return Mono.empty();
				})//
				.blockOptional()//
				.orElse(ResponseEntity.status(HttpStatus.NOT_FOUND).body(Collections.emptyList()))//
				.getBody();

		return hasError.get() ? getResponseAlternative(request, url) : result;
	}

	private List<SearchResponse> getResponseAlternative(SearchRequest request, String url) {
		log.info("alternative request to: " + url);

		try {
			var dateFormat = "yyyy-MM-dd";
			DateTimeFormatter formatter = DateTimeFormatter.ofPattern(dateFormat);

			var json = new GsonBuilder().setDateFormat(dateFormat).registerTypeAdapter(LocalDate.class,
					(JsonSerializer<LocalDate>) (localDate, type, jsonSerializationContext) -> {
						try {
							return new JsonPrimitive(formatter.format(localDate));
						} catch (Exception e) {
							e.printStackTrace();
							return null;
						}
					}).create().toJson(request);

			log.debug("json:" + json.toString());

			HttpHeaders headers = new HttpHeaders();
			headers.setContentType(MediaType.APPLICATION_JSON);

			var entity = new HttpEntity<String>(json, headers);
			var answer = new RestTemplate().postForObject(url, entity, String.class);

			log.debug(answer);

			var listType = new TypeToken<ArrayList<SearchResponse>>() {
			}.getType();

			return new GsonBuilder().setDateFormat("yyyy-MM-dd")
					.registerTypeAdapter(Date.class, (JsonDeserializer<Date>) (jsonValue, typeOfT, context) -> {
						try {
							return jsonValue == null ? null
									: new SimpleDateFormat("yyyy-MM-dd").parse(jsonValue.getAsString());
						} catch (Exception e) {
							e.printStackTrace();
							return null;
						}
					}).registerTypeAdapter(LocalDate.class,
							(JsonDeserializer<LocalDate>) (jsonValue, typeOfT, context) -> {
								try {
									return jsonValue == null ? null
											: LocalDate.parse(jsonValue.getAsString(), formatter);
								} catch (Exception e) {
									e.printStackTrace();
									return null;
								}
							})
					.create().fromJson(answer, listType);
		} catch (Exception e) {
			e.printStackTrace();
			return Collections.emptyList();
		}
	}
}
