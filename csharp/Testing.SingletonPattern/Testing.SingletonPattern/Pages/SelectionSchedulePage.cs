//-----------------------------------------------------------------------
// <copyright file="SelectionSchedulePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.SingletonPattern.Pages
{
  #region Imports

  using System.Globalization;
  using OpenQA.Selenium;
  using Template;

  #endregion Imports

  internal class SelectionSchedulePage : BasePage<SelectionScheduleMap>
  {
    #region Constructors

    public SelectionSchedulePage() : base()
    {
    }

    #endregion Constructors

    #region Methods

    public AssignSeatPage SelectFunctionAndAmountSeats(string function, int seats)
    {
      this.Map.Function.SelectByText(function);
      this.Map.Seats.SelectByValue(seats.ToString(CultureInfo.CurrentCulture));
      this.Map.Continue.Click();

      return new AssignSeatPage();
    }

    #endregion Methods
  }
}
