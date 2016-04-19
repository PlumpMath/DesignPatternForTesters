//-----------------------------------------------------------------------
// <copyright file="SelectionScheduleMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FacadePattern.Pages
{
  #region Imports

  using OpenQA.Selenium;
  using OpenQA.Selenium.Support.UI;
  using Template;

  #endregion Imports

  internal class SelectionScheduleMap : BasePageElementMap
  {
    #region Properties

    public SelectElement Function =>
        new SelectElement(this.Driver.FindElement(By.Id("showTime")));

    public SelectElement Seats =>
        new SelectElement(this.Driver.FindElement(By.Name("seats")));

    public IWebElement Continue =>
        this.Driver.FindElement(By.CssSelector("input.btn"));

    #endregion properties
  }
}
