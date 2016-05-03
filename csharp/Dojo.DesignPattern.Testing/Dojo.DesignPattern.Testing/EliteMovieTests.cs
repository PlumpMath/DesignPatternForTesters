namespace Dojo.DesignPattern.Testing
{
  #region Imports

  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Drawing;
  using System.Linq;
  using System.Net;
  using System.Threading;
  using Entity;
  using EntryPoint;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using NUnit.Framework;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Firefox;
  using OpenQA.Selenium.Support.UI;
  #endregion Imports

  [TestFixture]
  public class EliteMovieTests
  {
    [Test]
    public void ReserveThreeSeats()
    {
      Reserve reserve = new Reserve("El Violinista del Diablo", "2");

      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl("http://localhost:8080/");

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
        ShowTime showTime = JsonConvert.DeserializeObject<ShowTime>(response);

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
        driver.Navigate().GoToUrl("http://localhost:8080/");

        reserve.Seats.Add(new Seat(2, 12));
        reserve.Seats.Add(new Seat(2, 13));
        reserve.Seats.Add(new Seat(2, 14));
        reserve.Seats.Add(new Seat(2, 15));

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        List<Seat> seats = eliteMovie.TryToSelectSeats(reserve, 3);

        bool isFourthSeatSelected = seats[3].Booked;
        Assert.AreEqual(false, isFourthSeatSelected);
      }
    }

    [Test]
    public void FullShowTime()
    {

      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl("http://localhost:8080/");

        Reserve reserve = new Reserve("El libro de la vida", "6");
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        string message = eliteMovie.TryToRereserve(reserve);

        Assert.AreEqual(message, "Solo hay 0 sillas disponibles.");
      }
    }

    [Test]
    public void TwoSeatsAvailableShowTime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl("http://localhost:8080/");

        Reserve reserve = new Reserve("Donde se esconde el diablo", "9");
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        string message = eliteMovie.TryToRereserve(reserve);

        Assert.AreEqual(message, "Solo hay 2 sillas disponibles.");
      }
    }

    [Test]
    public void ThreeSeatsAvailableShowTime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl("http://localhost:8080/");

        Reserve reserve = new Reserve("Primicia Mortal", "12");
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        string message = eliteMovie.TryToRereserve(reserve);

        Assert.AreEqual(message, "Solo hay 3 sillas disponibles.");
      }
    }

    [Test]
    public void ForSeatsAvailableShowTime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl("http://localhost:8080/");

        Reserve reserve = new Reserve("Relatos Salvajes", "15");
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());
        reserve.Seats.Add(new Seat());

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        string message = eliteMovie.TryToRereserve(reserve);

        Assert.AreEqual(message, "Solo hay 4 sillas disponibles.");
      }
    }

    [Test]
    public void NotOmitTheAccentsTest()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl("http://localhost:8080/");

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
        driver.Navigate().GoToUrl("http://localhost:8080/");

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
        driver.Navigate().GoToUrl("http://localhost:8080/");

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
        driver.Navigate().GoToUrl("http://localhost:8080/");

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        bool found = eliteMovie.FindFilm("Violinista Diablo");

        Assert.IsTrue(found);
      }
    }

    [Test]
    public void ValidateThatFullShowTimeAllSeatsAreUnavailable()
    {
    }

    [Test]
    public void AfterReserveVerifyThatTheSeatsAreUnavailable()
    {

    }
  }
}
