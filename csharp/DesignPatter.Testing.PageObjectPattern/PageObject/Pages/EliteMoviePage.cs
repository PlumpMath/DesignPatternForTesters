using OpenQA.Selenium;

namespace DesignPatter.Testing.PageObjectPattern.PageObject.Pages
{
    internal class EliteMoviePage
    {
        private readonly IWebDriver driver;

        public EliteMoviePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement SearchFilm =>
            driver.FindElement(By.CssSelector(".searchfield"));


        private IWebElement FirstFilm =>
            driver.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));


        public void TypeFilmInSearchBar(string text)
        {
            this.SearchFilm.SendKeys(text);
        }

        public SelectionSchedulePage SelectFirstFilm()
        {
            this.FirstFilm.Click();
            return new SelectionSchedulePage(this.driver);
        } 
    }
}
