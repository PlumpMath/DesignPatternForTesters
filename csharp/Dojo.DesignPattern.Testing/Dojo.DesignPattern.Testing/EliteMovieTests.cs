//-----------------------------------------------------------------------
// <copyright file="EliteMovieTests.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

[assembly: System.CLSCompliant(true)]

namespace Dojo.DesignPattern.Testing
{
  using System;
  #region Imports

  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using Entity;
  using EntryPoint;
  using Newtonsoft.Json;
  using NUnit.Framework;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Firefox;

  #endregion Imports

  [TestFixture]
  public class EliteMovieTests
  {
    private Uri uri = new Uri("http://localhost:8080/");

    [Test]
    public void ReserveThreeSeats()
    {
      Reserve reserve = new Reserve("El Violinista del Diablo", "2");

      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        reserve.Seats.Add(new Seat(4, 12));
        reserve.Seats.Add(new Seat(4, 13));
        reserve.Seats.Add(new Seat(4, 14));

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        eliteMovie.Reserve(reserve);
      }
      
      List<Seat> bookedSeats = new List<Seat>();
      using (WebClient request = new WebClient())
      {
        string response = request.DownloadString("http://localhost:8080/rest/showtime/2");
        Showtime showTime = JsonConvert.DeserializeObject<Showtime>(response);

        showTime.Seats.ForEach(block => bookedSeats.AddRange(block.Where(seat => seat.Booked)));
      }

      CollectionAssert.AreEquivalent(reserve.Seats, bookedSeats);
    }

    [Test]
    public void SelectMoreSeatsThanAllowedErrorTest()
    {
      Reserve reserve = new Reserve("El Violinista del Diablo", "2");

      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        reserve.Seats.Add(new Seat(2, 12));
        reserve.Seats.Add(new Seat(2, 13));
        reserve.Seats.Add(new Seat(2, 14));
        reserve.Seats.Add(new Seat(2, 15));

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        ICollection<Seat> seats = eliteMovie.TryToSelectSeats(reserve, 3);

        bool isFourthSeatSelected = seats.ElementAt(3).Booked;
        Assert.AreEqual(false, isFourthSeatSelected);
      }
    }

    [Test]
    public void FullShowtime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        Reserve reserve = new Reserve("El libro de la vida", "6");
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        string message = eliteMovie.TryToReserve(reserve);

        Assert.AreEqual(message, "Solo hay 0 sillas disponibles.");
      }
    }

    [Test]
    public void TwoSeatsAvailableShowtime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        Reserve reserve = new Reserve("Donde se esconde el diablo", "9");
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        string message = eliteMovie.TryToReserve(reserve);

        Assert.AreEqual(message, "Solo hay 2 sillas disponibles.");
      }
    }

    [Test]
    public void ThreeSeatsAvailableShowtime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        Reserve reserve = new Reserve("Primicia Mortal", "12");
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        string message = eliteMovie.TryToReserve(reserve);

        Assert.AreEqual(message, "Solo hay 3 sillas disponibles.");
      }
    }

    [Test]
    public void ForSeatsAvailableShowtime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        Reserve reserve = new Reserve("Relatos Salvajes", "15");
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        string message = eliteMovie.TryToReserve(reserve);

        Assert.AreEqual(message, "Solo hay 4 sillas disponibles.");
      }
    }

    [Test]
    public void NotOmitTheAccentsTest()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        bool found = eliteMovie.FindFilm("Exodo, Dioses y Reyes");

        Assert.IsTrue(found);
      }
    }

    [Test]
    public void NotOmitTheCommaTest()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        bool found = eliteMovie.FindFilm("Pancho el perro millonario");

        Assert.IsTrue(found);
      }
    }

    [Test]
    public void NotOmitTheColonTest()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        bool found = eliteMovie.FindFilm("Los Juegos del Hambre: Sinsajo Parte 1");

        Assert.IsTrue(found);
      }
    }

    [Test]
    public void NonSearchForPartsOfNameTest()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        bool found = eliteMovie.FindFilm("Violinista Diablo");

        Assert.IsTrue(found);
      }
    }

    [Test]
    public void ValidateThatFullShowtimeAllSeatsAreUnavailable()
    {
      this.uri = new Uri("http://localhost:8080/#/seat_selection/6/3");

      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        SelectedSeatEntryPoint selectSeat = new SelectedSeatEntryPoint(driver);
        bool isFullShowMovie = selectSeat.IsFull();

        Assert.AreEqual(true, isFullShowMovie);
      }
    }

    [Test]
    public void AfterReserveVerifyThatTheSeatsAreUnavailable()
    {
      Reserve reserve = new Reserve("El Violinista del Diablo", "2");

      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(this.uri);

        reserve.Seats.Add(new Seat(4, 12));
        reserve.Seats.Add(new Seat(4, 13));
        reserve.Seats.Add(new Seat(4, 14));

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        eliteMovie.Reserve(reserve);

        ICollection<Seat> bookedSeats = eliteMovie.ObtainBookedSeats(reserve);

        foreach (Seat currentSeat in reserve.Seats)
        {
          CollectionAssert.Contains(bookedSeats, currentSeat);
        }
      }
    }
  }
}
