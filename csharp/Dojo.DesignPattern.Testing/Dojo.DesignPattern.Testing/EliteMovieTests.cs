namespace Dojo.DesignPattern.Testing
{
  #region Imports

  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Drawing;
  using System.Linq;
  using System.Net;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;
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
    public void ReserveThreeSeatsNonPattern()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {
        
        driver.Navigate().GoToUrl("http://localhost:8080/");

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys("El Violinista del Diablo");

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

      List<JToken> bookedSeats = new List<JToken>();
      using (WebClient request = new WebClient())
      {
        string response = request.DownloadString("http://localhost:8080/rest/showtime/2");
        JObject showTime = JsonConvert.DeserializeObject<JObject> (response);

        showTime.GetValue("seats").ToList().ForEach(block => bookedSeats.AddRange(block.Where(seat => seat.Value<JObject>().GetValue("booked").Value<bool>())));
      }

      List<Point> result = bookedSeats.ToList().Select(token => new Point(
        token.ToObject<JObject>().GetValue("row").ToObject<int>(),
        token.ToObject<JObject>().GetValue("column").ToObject<int>())).ToList();

      List<Point> expectedResult = new List<Point>()
      {
        new Point(4, 12),
        new Point(4, 13),
        new Point(4, 14)
      };

      CollectionAssert.AreEquivalent(expectedResult, result);
    }

    [Test]
    public void SelectMoreSeatsThanAllowedErrorTest()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {

        driver.Navigate().GoToUrl("http://localhost:8080/");

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys("El Violinista del Diablo");

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
        IWebElement firstSeat = driver.FindElement(By.CssSelector("label[for='1,12']"));
        firstSeat.Click();

        IWebElement secondSeat = driver.FindElement(By.CssSelector("label[for='1,13']"));
        secondSeat.Click();

        IWebElement thirdSeat = driver.FindElement(By.CssSelector("label[for=\'1,14']"));
        thirdSeat.Click();

        IWebElement fourthSeat = driver.FindElement(By.CssSelector("label[for=\'1,15']"));
        fourthSeat.Click();
        fourthSeat.Click();

        bool isFourthSeatSelected = driver.FindElement(By.CssSelector(@"#\31 \,15")).Selected;
        Assert.AreEqual(false, isFourthSeatSelected);
      }
    }

    [Test]
    public void FullShowTime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {

        driver.Navigate().GoToUrl("http://localhost:8080/");

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys("El libro de la vida");

        IWebElement film = driver.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));
        film.Click();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        SelectElement function = new SelectElement(driver.FindElement(By.Id("showTime")));
        function.SelectByValue("6");

        SelectElement seats = new SelectElement(driver.FindElement(By.Name("seats")));
        seats.SelectByValue("3");

        IWebElement continueOption = driver.FindElement(By.CssSelector("input.btn"));
        continueOption.Click();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        string text = driver.SwitchTo().Alert().Text;

        Assert.AreEqual(text, "Solo hay 0 sillas disponibles.");
      }
    }

    [Test]
    public void TwoSeatsAvailableShowTime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {

        driver.Navigate().GoToUrl("http://localhost:8080/");

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys("Donde se esconde el diablo");

        IWebElement film = driver.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));
        film.Click();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        SelectElement function = new SelectElement(driver.FindElement(By.Id("showTime")));
        function.SelectByValue("9");

        SelectElement seats = new SelectElement(driver.FindElement(By.Name("seats")));
        seats.SelectByValue("3");

        IWebElement continueOption = driver.FindElement(By.CssSelector("input.btn"));
        continueOption.Click();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        string text = driver.SwitchTo().Alert().Text;

        Assert.AreEqual(text, "Solo hay 2 sillas disponibles.");
      }
    }

    [Test]
    public void ThreeSeatsAvailableShowTime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {

        driver.Navigate().GoToUrl("http://localhost:8080/");

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys("Primicia Mortal");

        IWebElement film = driver.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));
        film.Click();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        SelectElement function = new SelectElement(driver.FindElement(By.Id("showTime")));
        function.SelectByValue("12");

        SelectElement seats = new SelectElement(driver.FindElement(By.Name("seats")));
        seats.SelectByValue("6");

        IWebElement continueOption = driver.FindElement(By.CssSelector("input.btn"));
        continueOption.Click();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        string text = driver.SwitchTo().Alert().Text;

        Assert.AreEqual(text, "Solo hay 3 sillas disponibles.");
      }
    }

    [Test]
    public void ForSeatsAvailableShowTime()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {

        driver.Navigate().GoToUrl("http://localhost:8080/");

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys("Relatos Salvajes");

        IWebElement film = driver.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));
        film.Click();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        SelectElement function = new SelectElement(driver.FindElement(By.Id("showTime")));
        function.SelectByValue("15");

        SelectElement seats = new SelectElement(driver.FindElement(By.Name("seats")));
        seats.SelectByValue("6");

        IWebElement continueOption = driver.FindElement(By.CssSelector("input.btn"));
        continueOption.Click();

        Thread.Sleep(TimeSpan.FromSeconds(3));
        string text = driver.SwitchTo().Alert().Text;

        Assert.AreEqual(text, "Solo hay 4 sillas disponibles.");
      }
    }

    [Test]
    public void NotOmitTheAccentsTest()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {

        driver.Navigate().GoToUrl("http://localhost:8080/");

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys("Exodo, Dioses y Reyes");

        ReadOnlyCollection<IWebElement> film = driver.FindElements(By.CssSelector("a.ng-scope"));

        Assert.IsTrue(film.Any());
      }
    }

    [Test]
    public void NotOmitTheCommaTest()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {

        driver.Navigate().GoToUrl("http://localhost:8080/");

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys("Pancho el perro millonario");

        ReadOnlyCollection<IWebElement> film = driver.FindElements(By.CssSelector("a.ng-scope"));

        Assert.IsTrue(film.Any());
      }
    }

    [Test]
    public void NotOmitTheColonTest()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {

        driver.Navigate().GoToUrl("http://localhost:8080/");

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys("Los Juegos del Hambre: Sinsajo Parte 1");

        ReadOnlyCollection<IWebElement> film = driver.FindElements(By.CssSelector("a.ng-scope"));

        Assert.IsTrue(film.Any());
      }
    }

    [Test]
    public void NonSearchForPartsOfNameTest()
    {
      using (IWebDriver driver = new FirefoxDriver())
      {

        driver.Navigate().GoToUrl("http://localhost:8080/");

        IWebElement searchFilm = driver.FindElement(By.CssSelector(".searchfield"));
        searchFilm.SendKeys("Violinista Diablo");

        ReadOnlyCollection<IWebElement> film = driver.FindElements(By.CssSelector("a.ng-scope"));

        Assert.IsTrue(film.Any());
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
