//-----------------------------------------------------------------------
// <copyright file="AssignSeatMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Pages
{
  #region Imports

  using static System.FormattableString;
  using OpenQA.Selenium;
  using Template;
  using Util;

  #endregion Imports

  public class AssignSeatMap : BasePageElementMap
  {
    #region Properties

    public IWebElement Continue =>
        this.Browser.FindElement(By.CssSelector("button.btn:nth-child(2)"));

    #endregion Properties

    #region Methods

    public IWebElement Seat(int row, int column)
    {
      string selector = Invariant($"label[for=\'{row},{column}']");
      By seat = By.CssSelector(selector);
      this.Wait.Until(driver => driver.FindElement(seat));
      return this.Browser.FindElement(seat);
    }

    #endregion Methods
  }
}