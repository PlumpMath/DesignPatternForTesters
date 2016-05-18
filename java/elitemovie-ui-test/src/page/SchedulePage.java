package page;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.Select;

public class SchedulePage {

	private WebDriver driver;
	
	public SchedulePage(WebDriver driver) {
		this.driver = driver;
	}
	
	private Select getShowTime() {
		return new Select(driver.findElement(By.id("showTime")));
	}
	
	private Select getSeats() {
		return new Select(driver.findElement(By.name("seats")));

	}
	
	private WebElement getContinue() {
		return driver.findElement(By.cssSelector("input.btn"));
	}
	
	public void scheduleMovie(String showmovie, String accountSeats) {
	    this.getShowTime().selectByValue (showmovie);
	    this.getSeats().selectByValue(accountSeats);
	    this.getContinue().click();
	}
}
