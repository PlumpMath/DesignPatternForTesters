//-----------------------------------------------------------------------
// <copyright file="AssignSeatPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.PageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;

  #endregion Imports

  internal class AssignSeatPage
  {
    #region Attributes

    private readonly IWebDriver driver;

    #endregion Attributes

    #region Constructors

    public AssignSeatPage(IWebDriver driver)
    {
      this.driver = driver;
    }

    #endregion Constructors

    #region Properties

    private IWebElement FirstSeat =>
        this.driver.FindElement(By.CssSelector("label[for='4,12']"));

    private IWebElement SecondSeat =>
        this.driver.FindElement(By.CssSelector("label[for='4,13']"));

    private IWebElement ThirdSeat =>
        this.driver.FindElement(By.CssSelector("label[for=\'4,14']"));

    private IWebElement Continue =>
        this.driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));

    #endregion Properties

    #region Methods

    public ConfirmationPage SelectSeats()
    {
      this.FirstSeat.Click();
      this.SecondSeat.Click();
      this.ThirdSeat.Click();

      this.Continue.Click();
      return new ConfirmationPage(this.driver);
    }

    #endregion Methods
  }
}