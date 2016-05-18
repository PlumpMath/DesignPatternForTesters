package model;

public class Seat {

	private long row;
	private long column;
	private boolean aisle;
	private boolean booked;
	private long preferencePoints;
	
	public long getRow() {
		return row;
	}
	public void setRow(long row) {
		this.row = row;
	}
	public long getColumn() {
		return column;
	}
	public void setColumn(long column) {
		this.column = column;
	}
	public boolean isAisle() {
		return aisle;
	}
	public void setAisle(boolean aisle) {
		this.aisle = aisle;
	}
	public boolean isBooked() {
		return booked;
	}
	public void setBooked(boolean booked) {
		this.booked = booked;
	}
	public long getPreferencePoints() {
		return preferencePoints;
	}
	public void setPreferencePoints(long preferencePoints) {
		this.preferencePoints = preferencePoints;
	}
}
