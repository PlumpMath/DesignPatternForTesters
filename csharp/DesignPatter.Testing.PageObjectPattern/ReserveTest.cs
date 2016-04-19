//-----------------------------------------------------------------------
// <copyright file="ReserveTest.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern
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
  using OpenQA.Selenium.Support.UI;
  using Properties;
  #endregion Imports

  [TestFixture]
  public class ReserveTest
  {
    private string url = "http://localhost:8080/";

    [Test]
    public void ReserveThreeSeatsNonPattern()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        driver.Navigate().GoToUrl(new Uri(this.url));

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys(Resources.FilmName);

        IWebElement film = driver.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));
        film.Click();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        SelectElement function = new SelectElement(driver.FindElement(By.Id("showTime")));
        function.SelectByValue("2");

        SelectElement seats = new SelectElement(driver.FindElement(By.Name("seats")));
        seats.SelectByValue("3");

        IWebElement continueOption = driver.FindElement(By.CssSelector("input.btn"));
        continueOption.Click();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        IWebElement firstSeat = driver.FindElement(By.CssSelector("label[for='4,12']"));
        firstSeat.Click();

        IWebElement secondSeat = driver.FindElement(By.CssSelector("label[for='4,13']"));
        secondSeat.Click();

        IWebElement thirdSeat = driver.FindElement(By.CssSelector("label[for=\'4,14']"));
        thirdSeat.Click();

        IWebElement continueOption2 = driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));
        continueOption2.Click();

        IWebElement finilize = driver.FindElement(By.CssSelector(".btn"));
        finilize.Click();
      }

      List<Seat> bookedSeats = new List<Seat>();

      using (WebClient request = new WebClient())
      {
        string response = request.DownloadString("http://localhost:8080/rest/showtime/2");
        ShowTime showTime = JsonConvert.DeserializeObject<ShowTime>(response);

        showTime.Seats.ForEach(block => bookedSeats.AddRange(block.Where(seat => seat.Booked)));
      }

      List<Seat> expectedResult = new List<Seat>()
      {
        new Seat() { Booked = true, Column = 12, Row = 4 },
        new Seat() { Booked = true, Column = 13, Row = 4 },
        new Seat() { Booked = true, Column = 14, Row = 4 }
      };

      CollectionAssert.AreEquivalent(expectedResult, bookedSeats);
    }
  }
}
