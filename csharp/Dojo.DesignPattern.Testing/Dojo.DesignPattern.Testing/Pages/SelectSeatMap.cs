//-----------------------------------------------------------------------
// <copyright file="SelectSeatMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Pages
{
  using System;
  using System.Collections.ObjectModel;
  using OpenQA.Selenium;
  using Template;

  public class SelectSeatMap : BasePageElementMap
  {
    public IWebElement Continue =>
      this.Driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));

    public ReadOnlyCollection<IWebElement> BookedSeats =>
      this.Driver.FindElements(By.CssSelector("input[disabled=disabled][type=checkbox]"));

    public IWebElement Seat(int row, int colum)
    {
      return this.Driver.FindElement(By.CssSelector(
        FormattableString.Invariant($"label[for='{row},{colum}']")));
    }

    public IWebElement SeatProperty(int row, int colum)
    {
      return this.Driver.FindElement(By.Id(
        FormattableString.Invariant($"{row},{colum}")));
    }
  }
}