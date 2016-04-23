//-----------------------------------------------------------------------
// <copyright file="SelectionSchedulePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Pages
{
  #region Imports

  using System.Globalization;
  using OpenQA.Selenium;
  using Template;
  using Util;
  using Util.Interfaces;
  #endregion Imports

  public class SelectionSchedulePage : BasePage<SelectionScheduleMap>, ISelectionSchedulePage
  {
    #region Constructors

    public SelectionSchedulePage() : base()
    {
    }

    #endregion Constructors

    #region Methods

    public IAssignSeatPage SelectShowtimeAndAmountSeats(string showtime, int seats)
    {
      this.Map.Function.SelectByText(showtime);
      this.Map.Seats.SelectByValue(seats.ToString(CultureInfo.CurrentCulture));
      this.Map.Continue.Click();

      return PageFactory.Get<IAssignSeatPage>();
    }

    #endregion Methods
  }
}
