using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DesignPatter.Testing.PageObjectPattern.PageObject.Pages
{
    internal class SelectionSchedulePage
    {
        private readonly IWebDriver driver;

        public SelectionSchedulePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private SelectElement Function =>
            new SelectElement(this.driver.FindElement(By.Id("showTime")));

        private SelectElement Seats => 
            new SelectElement(driver.FindElement(By.Name("seats")));


        private IWebElement Continue =>
            this.driver.FindElement(By.CssSelector("input.btn"));

        public void SelectFunction(int value)
        {
            this.Function.SelectByValue(value.ToString());
        }

        public void SelectNumberSeats(int seats)
        {
            this.Seats.SelectByValue(seats.ToString());
        }

        public AssignSeatPage NextStep()
        {
            this.Continue.Click();
            return new AssignSeatPage(this.driver);
        }
    }
}
