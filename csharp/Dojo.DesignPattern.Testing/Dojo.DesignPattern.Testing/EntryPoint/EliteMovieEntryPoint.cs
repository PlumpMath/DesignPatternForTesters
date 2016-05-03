using System;
using System.Collections.Generic;
using System.Threading;
using Dojo.DesignPattern.Testing.Entity;
using Dojo.DesignPattern.Testing.Pages;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.EntryPoint
{
  public class EliteMovieEntryPoint
  {
    private EliteMoviePage eliteMovie;
    private SchedulePage schedule;
    private SelectSeatPage selectSeat;
    private ConfirmationPage confirmation;

    private IWebDriver driver;

    public EliteMovieEntryPoint(IWebDriver driver)
    {
      this.driver = driver;
      this.eliteMovie = new EliteMoviePage(driver);
      this.schedule = new SchedulePage(driver);
      this.selectSeat = new SelectSeatPage(driver);
      this.confirmation = new ConfirmationPage(driver);
    }

    public void Reserve(Reserve reserve)
    {
      eliteMovie.SelectFilm(reserve.Film);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      schedule.SelectShowTime(reserve.Showtime, reserve.Seats.Count);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      selectSeat.SelectSeatsAndContinue(reserve.Seats);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      confirmation.Confirm();
    }

    public List<Seat> TryToSelectSeats(Reserve reserve, int seatNumber)
    {
      eliteMovie.SelectFilm(reserve.Film);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      schedule.SelectShowTime(reserve.Showtime, seatNumber);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      return selectSeat.SelectSeat(reserve.Seats);
    }

    public string TryToRereserve(Reserve reserve)
    {
      eliteMovie.SelectFilm(reserve.Film);
      Thread.Sleep(TimeSpan.FromSeconds(1));
      schedule.SelectShowTime(reserve.Showtime, reserve.Seats.Count);
      Thread.Sleep(TimeSpan.FromSeconds(1));

      return this.driver.SwitchTo().Alert().Text;
    }

    internal bool FindFilm(string filmName)
    {
      return eliteMovie.FindFilm(filmName);
    }
  }
}
