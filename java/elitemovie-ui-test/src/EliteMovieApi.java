import java.util.ArrayList;
import java.util.List;

import org.springframework.http.ResponseEntity;
import org.springframework.web.client.RestTemplate;

import model.Seat;
import model.Theather;

public class EliteMovieApi {

	public String[] getBookedSeats() {
		RestTemplate restTemplate = new RestTemplate();
		String urlToRequest = "http://localhost:8080/rest/showtime/2";
	
		ResponseEntity<Theather> response = restTemplate.getForEntity(urlToRequest, Theather.class);
		
		Theather theater = response.getBody();
		List<String> filterSeats = new ArrayList<String>();
		
		for (List<Seat> columnSeats : theater.getSeats()) {
			for (Seat seat : columnSeats) {
				if (seat.isBooked()) {
					filterSeats.add(seat.getRow() + "," + seat.getColumn());
				}
			}
		}
		
		String[] bookedSeats = new String[filterSeats.size()];
		return filterSeats.toArray(bookedSeats);	
	}
}
