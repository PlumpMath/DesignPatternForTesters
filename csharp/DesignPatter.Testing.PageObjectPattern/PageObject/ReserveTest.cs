using DesignPatter.Testing.PageObjectPattern.Entity;
using DesignPatter.Testing.PageObjectPattern.PageObject.Pages;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace DesignPatter.Testing.PageObjectPattern.PageObject
{
    [TestFixture]
    public class ReserveTest
    {
        [Test]
        public void ReserveThreeSeats_PageObjectPattern()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:8080/");

            EliteMoviePage eliteMoviePage = new EliteMoviePage(driver);
            eliteMoviePage.TypeFilmInSearchBar("El Violinista del diablo");
            SelectionSchedulePage schedulePage = eliteMoviePage.SelectFirstFilm();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            schedulePage.SelectFunction(2);
            schedulePage.SelectNumberSeats(3);
            AssignSeatPage assignSeatPage = schedulePage.NextStep();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            assignSeatPage.SelectFirstSeat();
            assignSeatPage.SelectSecondSeat();
            assignSeatPage.SelectThirdSeat();
            ConfirmationPage confirmationPage = assignSeatPage.NextStep();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            confirmationPage.Finish();

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
