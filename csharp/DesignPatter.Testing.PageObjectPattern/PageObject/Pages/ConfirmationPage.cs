using OpenQA.Selenium;

namespace DesignPatter.Testing.PageObjectPattern.PageObject.Pages
{
    internal class ConfirmationPage
    {
        private readonly IWebDriver driver;

        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Finilize =>
            this.driver.FindElement(By.CssSelector(".btn"));

        public EliteMoviePage Finish()
        {
            this.Finilize.Click();
            return new EliteMoviePage(this.driver);
        }
    }
}
