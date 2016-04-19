//-----------------------------------------------------------------------
// <copyright file="AssignSeatMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FacadePattern.Pages
{
  #region Imports

  using static System.FormattableString;
  using OpenQA.Selenium;
  using Template;

  #endregion Imports

  internal class AssignSeatMap : BasePageElementMap
  {
    #region Properties

    public IWebElement Continue =>
        this.Driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));

    #endregion Properties

    #region Methods

    public IWebElement Seat(int row, int column)
    {
      string selector = Invariant($"label[for=\'{row},{column}']");
      return this.Driver.FindElement(By.CssSelector(selector));
    }

    #endregion Methods
  }
}