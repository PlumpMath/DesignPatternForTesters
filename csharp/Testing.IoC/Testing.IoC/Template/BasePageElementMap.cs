//-----------------------------------------------------------------------
// <copyright file="BasePageElementMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Template
{
  #region Imports

  using OpenQA.Selenium;
  using OpenQA.Selenium.Support.UI;
  using Util;

  #endregion

  public class BasePageElementMap
  {
    #region Constructors

    public BasePageElementMap()
    {
      this.Browser = Driver.Instance.Browser;
      this.Wait = Driver.Instance.Wait;
    }

    #endregion Constructors

    #region Properties

    public IWebDriver Browser { get; }

    public WebDriverWait Wait { get; }

    #endregion Properties
  }
}
