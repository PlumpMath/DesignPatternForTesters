//-----------------------------------------------------------------------
// <copyright file="ReserveTest.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

[assembly: System.CLSCompliant(true)]

namespace Testing.SingletonPattern
{
  #region Imports

  using System;
  using System.Collections.ObjectModel;
  using Entity;
  using NUnit.Framework;
  using Util;
  using Validation;

  #endregion Imports

  [TestFixture]
  public class ReserveTest
  {
    #region Attributes

    private string url = "http://localhost:8080/";

    #endregion Attributes

    #region Tests

    [SetUp]
    public void Setup()
    {
      Driver.BrowserType = BrowserType.Chrome;
    }

    [TearDown]
    public void Teardown()
    {
      Driver.Instance.StopBrowser();
    }

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

      Uri uri = new Uri(this.url);
      Driver.Instance.Browser.Navigate().GoToUrl(uri);

      EliteMovieEntryPoint eliteMovie = new EliteMovieEntryPoint();
      eliteMovie.Reserve(reserve);

      GenericApiValidator.AssertBookedSeats(seats);
    }

    #endregion Tests
  }
}
