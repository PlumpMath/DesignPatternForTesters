package page;

import java.util.List;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class SelectSeatPage {

	private WebDriver driver;
	
	public SelectSeatPage(WebDriver driver) {
		this.driver = driver;
	}
	
	private WebElement getSeat(String position) {
		return this.driver.findElement(By.cssSelector("label[for='" + position + "']"));
	}
	
	private WebElement getContinue() {
		return this.driver.findElement(By.cssSelector("button.btn:nth-child(2)"));
	}
	
	private List<WebElement> getElementBookedSeats() {
		return this.driver.findElements(By.cssSelector("input[disabled=disabled][type=checkbox]"));
	}
	
	public void select(String[] seatsPosition) {
		for (String position : seatsPosition) {
			this.getSeat(position).click();
		}
		
		this.getContinue().click();
	}
	
	public String[] getBookedSeats() {
		List<WebElement> elements = this.getElementBookedSeats();
		String[] bookedSeats = new String[elements.size()];
		
		for (int i = 0; i < bookedSeats.length; i++) {
			bookedSeats[i] = elements.get(i).getAttribute("id");
		}
		
		return bookedSeats;
	}
	
}
