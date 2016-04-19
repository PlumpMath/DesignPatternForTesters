//-----------------------------------------------------------------------
// <copyright file="SelectionSchedulePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.ThreeLayerPageObject.Pages
{
  #region Imports

  using System.Globalization;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Support.UI;

  #endregion Imports

  internal class SelectionSchedulePage
  {
    #region Attributes

    private readonly IWebDriver driver;
    private SelectionScheduleMap map;

    #endregion Attributes

    #region Constructors

    public SelectionSchedulePage(IWebDriver driver)
    {
      this.driver = driver;
      this.map = new SelectionScheduleMap(this.driver);
    }

    #endregion Constructors

    #region Methods

    public AssignSeatPage SelectFunctionAndAmountSeats(int function, int seats)
    {
      this.map.Function.SelectByValue(function.ToString(CultureInfo.CurrentCulture));
      this.map.Seats.SelectByValue(seats.ToString(CultureInfo.CurrentCulture));
      this.map.Continue.Click();
      return new AssignSeatPage(this.driver);
    }

    #endregion Methods
  }
}
