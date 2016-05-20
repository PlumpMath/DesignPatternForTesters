package model;

import java.util.ArrayList;
import java.util.List;

public class Theather {

	private long id;
	private List<List<Seat>> seats = new ArrayList<List<Seat>>();
	private long movieId;
	private long timeInMilliseconds;
	
	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	public List<List<Seat>> getSeats() {
		return seats;
	}
	public void setSeats(List<List<Seat>> seats) {
		this.seats = seats;
	}
	public long getMovieId() {
		return movieId;
	}
	public void setMovieId(long movieId) {
		this.movieId = movieId;
	}
	public long getTimeInMilliseconds() {
		return timeInMilliseconds;
	}
	public void setTimeInMilliseconds(long timeInMilliseconds) {
		this.timeInMilliseconds = timeInMilliseconds;
	}
	
}
