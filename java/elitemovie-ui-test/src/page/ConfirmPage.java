package page;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class ConfirmPage {

	private WebDriver driver;
	
	public ConfirmPage(WebDriver driver) {
		this.driver = driver;
	}
	
	private WebElement getFinalize() {
		return this.driver.findElement(By.cssSelector(".btn"));
	}
	
	public void finalize() {
		this.getFinalize().click();
	}
}
