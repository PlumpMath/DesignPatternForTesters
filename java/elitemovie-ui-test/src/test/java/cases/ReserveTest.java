package cases;

import static org.junit.Assert.assertArrayEquals;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;

import api.EliteMovieApi;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import page.ConfirmPage;
import page.EliteMoviePage;
import page.SchedulePage;
import page.SelectSeatPage;


public class ReserveTest {

	private String movieName;

	private String showtime;

	private String seatsAccount;

	private String[] seats;

	private String[] expectedBookedSeats;
	
	@Given("^the film \"([^\"]*)\", the showtime \"([^\"]*)\" and the \"([^\"]*)\" reservation$")
	public void preparate(String movieName, String showtime, String seatsAccount) throws Throwable {
		this.movieName = movieName;
		this.showtime = showtime;
		this.seatsAccount = seatsAccount;
	}

	@When("^reverve the seats \"([^\"]*)\"$")
	public void reserve(String seatsInformation) throws Throwable {
		this.seats = seatsInformation.split(";");
		
		WebDriver driver = null;

		try {
			driver = new FirefoxDriver();
			driver.navigate().to("http://localhost:8080/");

			EliteMoviePage eliteMovie = new EliteMoviePage(driver);
			eliteMovie.selectFilm(this.movieName);

			Thread.sleep(1000);
	        SchedulePage schedule = new SchedulePage(driver);
	        schedule.scheduleMovie(this.showtime, this.seatsAccount);

	        Thread.sleep(1000);
	        SelectSeatPage selectSeat = new SelectSeatPage(driver);
	        selectSeat.select(seats);
	        
	        Thread.sleep(1000);
	        ConfirmPage confirm = new ConfirmPage(driver);
	        confirm.finalize();

	        EliteMovieApi api = new EliteMovieApi();
	        this.expectedBookedSeats = api.getBookedSeats();
		} catch (Exception e) {
				e.printStackTrace();
		} finally {
			if ( driver != null ) {
				driver.close();
			}
		}
	}

	@Then("^the teather should display the seats like booked$")
	public void verificationReserve() throws Throwable {
		assertArrayEquals(this.seats, this.expectedBookedSeats);	
	}
}
		
