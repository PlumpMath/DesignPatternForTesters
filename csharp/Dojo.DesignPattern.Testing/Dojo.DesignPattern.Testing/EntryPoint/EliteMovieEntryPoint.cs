//-----------------------------------------------------------------------
// <copyright file="EliteMovieEntryPoint.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.EntryPoint
{
  using System;
  using System.Collections.Generic;
  using System.Threading;
  using Entity;
  using OpenQA.Selenium;
  using Pages;

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

    internal void Reserve(Reserve reserveInfo)
    {
      this.eliteMovie.SelectFilm(reserveInfo.Film);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      this.schedule.SelectShowTime(reserveInfo.Showtime, reserveInfo.Seats.Count);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      this.selectSeat.SelectSeatsAndContinue(reserveInfo.Seats);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      this.confirmation.Confirm();
    }

    internal ICollection<Seat> TryToSelectSeats(Reserve reserve, int seatNumber)
    {
      this.eliteMovie.SelectFilm(reserve.Film);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      this.schedule.SelectShowTime(reserve.Showtime, seatNumber);
      Thread.Sleep(TimeSpan.FromSeconds(2));
      return this.selectSeat.SelectSeat(reserve.Seats);
    }

    internal string TryToReserve(Reserve reserve)
    {
      this.eliteMovie.SelectFilm(reserve.Film);
      Thread.Sleep(TimeSpan.FromSeconds(1));
      this.schedule.SelectShowTime(reserve.Showtime, reserve.Seats.Count);
      Thread.Sleep(TimeSpan.FromSeconds(1));

      return this.driver.SwitchTo().Alert().Text;
    }

    internal bool FindFilm(string filmName)
    {
      return this.eliteMovie.FindFilm(filmName);
    }

    internal ICollection<Seat> ObtainBookedSeats(Reserve reserve)
    {
      this.eliteMovie.SelectFilm(reserve.Film);
      Thread.Sleep(TimeSpan.FromSeconds(1));
      this.schedule.SelectShowTime(reserve.Showtime, reserve.Seats.Count);
      Thread.Sleep(TimeSpan.FromSeconds(1));
      return this.selectSeat.ObtainBookedSeats();
    }
  }
}
