using System;
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

    public EliteMovieEntryPoint(IWebDriver driver)
    {
      this.eliteMovie = new EliteMoviePage(driver);
      this.schedule = new SchedulePage(driver);
      this.selectSeat = new SelectSeatPage(driver);
      this.confirmation = new ConfirmationPage(driver);
    }

    public void Reserve(Reserve reserve)
    {
      eliteMovie.SelectFilm(reserve.Film);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      schedule.SelectShowTime(reserve.Showtime, reserve.NumberSeats);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      selectSeat.SelectSeats();
      Thread.Sleep(TimeSpan.FromSeconds(2));
      confirmation.Confirm();
    }
  }
}
