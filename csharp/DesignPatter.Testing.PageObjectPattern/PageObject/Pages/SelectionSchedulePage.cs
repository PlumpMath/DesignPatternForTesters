//-----------------------------------------------------------------------
// <copyright file="SelectionSchedulePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.PageObject.Pages
{
  using System.Globalization;
  #region Imports

  using OpenQA.Selenium;
  using OpenQA.Selenium.Support.UI;

  #endregion Imports

  internal class SelectionSchedulePage
  {
    #region Attributes

    private readonly IWebDriver driver;

    #endregion Attributes

    #region Constructors

    public SelectionSchedulePage(IWebDriver driver)
    {
      this.driver = driver;
    }

    #endregion Constructors

    #region Properties

    private SelectElement Function =>
        new SelectElement(this.driver.FindElement(By.Id("showTime")));

    private SelectElement Seats =>
        new SelectElement(this.driver.FindElement(By.Name("seats")));

    private IWebElement Continue =>
        this.driver.FindElement(By.CssSelector("input.btn"));

    #endregion properties

    #region Methods

    public AssignSeatPage SelectFunctionAndAmountSeats(int function, int seats)
    {
      this.Function.SelectByValue(function.ToString(CultureInfo.CurrentCulture));
      this.Seats.SelectByValue(seats.ToString(CultureInfo.CurrentCulture));
      this.Continue.Click();
      return new AssignSeatPage(this.driver);
    }

    #endregion Methods
  }
}
