//-----------------------------------------------------------------------
// <copyright file="ConfirmationMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.SingletonPattern.Pages
{
  #region Imports

  using OpenQA.Selenium;
  using Template;
  using Util;

  #endregion Imports

  internal class ConfirmationMap : BasePageElementMap
  {
    #region Properties

    public IWebElement Finilize
    {
      get
      {
        By button = By.CssSelector(".btn");
        this.Wait.Until(driver => driver.FindElement(button));
        return this.Browser.FindElement(button);
      }
    }

    #endregion Properties
  }
}
