//-----------------------------------------------------------------------
// <copyright file="ReserveTest.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

[assembly: System.CLSCompliant(true)]

namespace DesignPatter.Testing.PageObjectPattern.PageObject
{
  #region Imports

  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using System.Threading;
  using Entity;
  using Newtonsoft.Json;
  using NUnit.Framework;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Firefox;
  using Pages;

  #endregion Imports

  [TestFixture]
  public class ReserveTest
  {
    #region Attributes

    private string url = "http://localhost:8080/";

    #endregion Attributes

    #region Tests

    [Test]
    public void ReserveThreeSeatsPageObjectPattern()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        Uri uri = new Uri(this.url);
        driver.Navigate().GoToUrl(uri);

        EliteMoviePage eliteMoviePage = new EliteMoviePage(driver);
        SelectionSchedulePage schedulePage = eliteMoviePage.SelectFilm("El Violinista del diablo");

        Thread.Sleep(TimeSpan.FromSeconds(3));
        AssignSeatPage assignSeatPage = schedulePage.SelectFunctionAndAmountSeats(2, 3);

        Thread.Sleep(TimeSpan.FromSeconds(3));
        ConfirmationPage confirmationPage = assignSeatPage.SelectSeats();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        confirmationPage.Finish();
      }

      List<Seat> bookedSeats = ReserveTest.ObtainReserveSeats();

      List<Seat> expectedResult = new List<Seat>()
      {
        new Seat() { Booked = true, Column = 12, Row = 4 },
        new Seat() { Booked = true, Column = 13, Row = 4 },
        new Seat() { Booked = true, Column = 14, Row = 4 }
      };

      CollectionAssert.AreEquivalent(expectedResult, bookedSeats);
    }

    #endregion Tests

    #region Private Methods

    private static List<Seat> ObtainReserveSeats()
    {
      List<Seat> bookedSeats = new List<Seat>();

      using (WebClient request = new WebClient())
      {
        string response = request.DownloadString("http://localhost:8080/rest/showtime/2");

        ShowTime showTime = JsonConvert.DeserializeObject<ShowTime>(response);
        showTime.Seats.ForEach(block => bookedSeats.AddRange(block.Where(seat => seat.Booked)));
      }

      return bookedSeats;
    }

    #endregion Pivate Methods
  }
}