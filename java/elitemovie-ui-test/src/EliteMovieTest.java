import org.junit.After;
import org.junit.Before;
import org.junit.Test;
// this is recomended for call the Assert methods with a cleaner syntax.
// reference :review http://junit.sourceforge.net/javadoc/org/junit/Assert.html
import static org.junit.Assert.*;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.springframework.http.ResponseEntity;
import org.springframework.web.client.RestTemplate;

import model.Theather;
import page.ConfirmPage;
import page.EliteMoviePage;
import page.SchedulePage;
import page.SelectSeatPage;

public class EliteMovieTest {

	private WebDriver driver;
	
	@Before
	public void setup() {
		this.driver = new FirefoxDriver();
	}
	
	@After
	public void teardown() {
		this.driver.close();
	}

	@Test
	public void reserve() throws InterruptedException {
        String[] seats= new String[] {
            	"4,12", "4,13", "4,14"
            };

		this.driver.navigate().to("http://localhost:8080/");
		
		EliteMoviePage eliteMovie = new EliteMoviePage(this.driver);
		eliteMovie.selectFilm("El violinista del diablo");

        Thread.sleep(1000);
        SchedulePage schedule = new SchedulePage(this.driver);
        schedule.scheduleMovie("2", "3");

        Thread.sleep(1000);
        SelectSeatPage selectSeat = new SelectSeatPage(this.driver);
        selectSeat.select(seats);

        Thread.sleep(1000);
        ConfirmPage confirm = new ConfirmPage(this.driver);
        confirm.finalize();
        
		eliteMovie.selectFilm("El violinista del diablo");
        Thread.sleep(1000);
        schedule.scheduleMovie("2", "1");

        Thread.sleep(1000);
        String[] bookedSeats = selectSeat.getBookedSeats();
        
        assertArrayEquals(seats, bookedSeats);
	}
	
	@Test
	public void reserveApiValidation() throws InterruptedException {
        String[] seats= new String[] {
            	"2,12", "2,13", "2,14"
            };

		this.driver.navigate().to("http://localhost:8080/");
		
		EliteMoviePage eliteMovie = new EliteMoviePage(this.driver);
		eliteMovie.selectFilm("El violinista del diablo");

        Thread.sleep(1000);
        SchedulePage schedule = new SchedulePage(this.driver);
        schedule.scheduleMovie("2", "3");

        Thread.sleep(1000);
        SelectSeatPage selectSeat = new SelectSeatPage(this.driver);
        selectSeat.select(seats);

        Thread.sleep(1000);
        ConfirmPage confirm = new ConfirmPage(this.driver);
        confirm.finalize();

        EliteMovieApi api = new EliteMovieApi();
        String[] bookedSeats = api.getBookedSeats();
                
        assertArrayEquals(seats, bookedSeats);
	}

}

