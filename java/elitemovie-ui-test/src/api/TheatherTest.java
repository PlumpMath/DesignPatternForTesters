package api;

import static org.junit.Assert.*;

import org.junit.Test;
import org.springframework.http.ResponseEntity;
import org.springframework.web.client.RestTemplate;

import model.Theather;

public class TheatherTest {

	@Test
	public void getPositionsForEmptyTheather() {
		RestTemplate restTemplate = new RestTemplate();
		String urlToRequest = "http://localhost:8080/rest/showtime/3";
	
		//esta es la linea que hace magia y se encarga de tomar la respuesta y serializarla en objeto de java Theather.java
		ResponseEntity<Theather> response = restTemplate.getForEntity(urlToRequest, Theather.class);
		System.out.println(response.getBody().getMovieId());
		assertEquals(true, true);
	}
}
