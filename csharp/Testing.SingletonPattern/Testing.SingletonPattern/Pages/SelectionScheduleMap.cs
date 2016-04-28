//-----------------------------------------------------------------------
// <copyright file="SelectionScheduleMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.SingletonPattern.Pages
{
  #region Imports

  using OpenQA.Selenium;
  using OpenQA.Selenium.Support.UI;
  using Template;
  using Util;

  #endregion Imports

  internal class SelectionScheduleMap : BasePageElementMap
  {
    #region Properties

    public SelectElement Function
    {
      get
      {
        By showTime = By.Id("showTime");
        this.Wait.Until(driver => driver.FindElement(showTime));
        return new SelectElement(this.Browser.FindElement(showTime));
      }
    }

  public SelectElement Seats =>
        new SelectElement(this.Browser.FindElement(By.Name("seats")));

    public IWebElement Continue =>
        this.Browser.FindElement(By.CssSelector("input.btn"));

    #endregion properties
  }
}
