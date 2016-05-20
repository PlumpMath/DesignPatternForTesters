package page;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class EliteMoviePage {
	
	private WebDriver driver;
	
	public EliteMoviePage(WebDriver driver) {
		this.driver = driver;
	}

	private WebElement getSearhFilm() {
		return this.driver.findElement(By.cssSelector(".searchfield"));
	}
	
	private WebElement getFilm() {
		return driver.findElement(By.cssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));
	}
	
	public void selectFilm(String filmName) {
	    this.getSearhFilm().sendKeys(filmName);
	    this.getFilm().click();
	}
}
