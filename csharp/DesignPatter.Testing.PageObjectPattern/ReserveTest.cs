using DesignPatter.Testing.PageObjectPattern.Entity;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace DesignPatter.Testing.PageObjectPattern
{
    [TestFixture]
    public class ReserveTest
    {
        [Test]
        public void ReserveThreeSeats_NonPattern()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:8080/");

            IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
            searchFilm.SendKeys("El Violinista del diablo");

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
            driver.Close();

            List<Seat> bookedSeats = new List<Seat>();


            using (WebClient request = new WebClient())
            {
                string response = request.DownloadString("http://localhost:8080/rest/showtime/2");
                ShowTime showTime = JsonConvert.DeserializeObject<ShowTime>(response);

                showTime.seats.ForEach(block => bookedSeats.AddRange(block.Where(seat => seat.booked)));
            }

            List<Seat> expectedResult = new List<Seat>() {
                new Seat() { aisle = false, booked = true, preferencePoints = 100, column = 12, row = 4},
                new Seat() { aisle = false, booked = true, preferencePoints = 100, column = 13, row = 4},
                new Seat() { aisle = false, booked = true, preferencePoints = 100, column = 14, row = 4}
            };
            CollectionAssert.AreEquivalent(expectedResult, bookedSeats);
        }
    }
}
