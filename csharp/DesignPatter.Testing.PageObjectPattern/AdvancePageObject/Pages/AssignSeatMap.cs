//-----------------------------------------------------------------------
// <copyright file="AssignSeatMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;
  using Template;

  #endregion Imports

  internal class AssignSeatMap : BasePageElementMap
  {
    #region Properties

    public IWebElement FirstSeat =>
        this.Driver.FindElement(By.CssSelector("label[for='4,12']"));

    public IWebElement SecondSeat =>
        this.Driver.FindElement(By.CssSelector("label[for='4,13']"));

    public IWebElement ThirdSeat =>
        this.Driver.FindElement(By.CssSelector("label[for=\'4,14']"));

    public IWebElement Continue =>
        this.Driver.FindElement(By.CssSelector("button.btn:nth-child(2)"));

    #endregion Properties
  }
}