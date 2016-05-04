//-----------------------------------------------------------------------
// <copyright file="SchedulePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Pages
{
  using System.Globalization;
  using OpenQA.Selenium;
  using Template;

  public class SchedulePage : PageBase<SchedulePageMap>
  {
    internal SelectSeatPage SelectShowTime(string showTime, int seats)
    {
      this.Map.ShowTime.SelectByValue(showTime);
      this.Map.Seats.SelectByValue(seats.ToString(CultureInfo.CurrentCulture));
      this.Map.Continue.Click();

      return new SelectSeatPage();
    }
  }
}