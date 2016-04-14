using OpenQA.Selenium;

namespace DesignPatter.Testing.PageObjectPattern.PageObject.Pages
{
    internal class AssignSeatPage
    {
        private readonly IWebDriver driver;

        public AssignSeatPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement FirstSeat =>
            this.driver.FindElement(By.CssSelector("label[for='4,12']"));


        private IWebElement SecondSeat =>
            this.driver.FindElement(By.CssSelector("label[for='4,13']"));

        private IWebElement ThirdSeat =>
            this.driver.FindElement(By.CssSelector("label[for=\'4,14']"));

        private IWebElement Continue =>
            this.driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));

        public void SelectFirstSeat()
        {
            this.FirstSeat.Click();
        }

        public void SelectSecondSeat()
        {
            this.SecondSeat.Click();
        }

        public void SelectThirdSeat()
        {
            this.ThirdSeat.Click();
        }

        public ConfirmationPage NextStep()
        {
            this.Continue.Click();

            return new ConfirmationPage(this.driver);
        }

    }
}
