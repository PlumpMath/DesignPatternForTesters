//-----------------------------------------------------------------------
// <copyright file="SelectionSchedulePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Pages
{
  #region Imports

  using System.Globalization;
  using OpenQA.Selenium;
  using Template;

  #endregion Imports

  internal class SelectionSchedulePage : BasePage<SelectionScheduleMap>
  {
    #region Constructors

    public SelectionSchedulePage(IWebDriver driver) : base(driver)
    {
    }

    #endregion Constructors

    #region Methods

    public AssignSeatPage SelectFunctionAndAmountSeats(int function, int seats)
    {
      this.Map.Function.SelectByValue(function.ToString(CultureInfo.CurrentCulture));
      this.Map.Seats.SelectByValue(seats.ToString(CultureInfo.CurrentCulture));
      this.Map.Continue.Click();
      return new AssignSeatPage(this.Driver);
    }

    #endregion Methods
  }
}
