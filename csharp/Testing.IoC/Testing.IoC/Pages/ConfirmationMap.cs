//-----------------------------------------------------------------------
// <copyright file="ConfirmationMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Pages
{
  #region Imports

  using OpenQA.Selenium;
  using Template;
  using Util;

  #endregion Imports

  public class ConfirmationMap : BasePageElementMap
  {
    #region Properties

    public IWebElement Alert
    {
      get
      {
        By alert = By.CssSelector(".alert");
        this.Wait.Until(driver => driver.FindElement(alert));

        return this.Browser.FindElement(alert);
      }
    }

    public IWebElement Finalize
    {
      get
      {
        this.Wait.Until(driver => this.Alert);

        By button = By.CssSelector(".btn");
        this.Wait.Until(driver => driver.FindElement(button));
        return this.Browser.FindElement(button);
      }
    }

    #endregion Properties
  }
}
