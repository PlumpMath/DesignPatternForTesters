//-----------------------------------------------------------------------
// <copyright file="ReserveTest.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

[assembly: System.CLSCompliant(true)]

namespace Testing.FacadePattern
{
  #region Imports

  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Threading;
  using Entity;
  using NUnit.Framework;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Firefox;
  using Pages;
  using Util;
  using Validation;
  #endregion Imports

  [TestFixture]
  public class ReserveTest
  {
    #region Attributes

    private string url = "http://localhost:8080/";
    EliteMovieEntryPoint eliteMovie;

    #endregion Attributes

    #region Tests

    [Test]
    public void ReserveThreeSeatsAdvancePageObjectPattern()
    {
      Collection<Seat> seats = new Collection<Seat>
      {
        new Seat() { Column = 12, Row = 4 },
        new Seat() { Column = 13, Row = 4 },
        new Seat() { Column = 14, Row = 4 }
      };

      Reserve reserve = new Reserve(seats)
      {
        Film = "El Violinista del diablo",
        Function = "2020-03-02 20:00"
      };

      using (IWebDriver driver = new FirefoxDriver())
      {
        Uri uri = new Uri(this.url);
        driver.Navigate().GoToUrl(uri);

        EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint(driver);
        eliteMovie.Reserve(reserve);
      }

      GenericApiValidator.AssertBookedSeats(seats);
    }

    #endregion Tests
  }
}
