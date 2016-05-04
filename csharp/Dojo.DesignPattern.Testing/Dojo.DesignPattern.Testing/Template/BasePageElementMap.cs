//-----------------------------------------------------------------------
// <copyright file="BasePageElementMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Template
{
  using OpenQA.Selenium;
  using OpenQA.Selenium.Support.UI;

  public class BasePageElementMap
  {
    #region  Constructors

    public BasePageElementMap()
    {
      this.Driver = WebDriver.Instance.Browser;
      this.Wait = WebDriver.Instance.Wait;
    }

    #endregion  Constructors
    
    #region Properties

    public IWebDriver Driver { get; }

    public WebDriverWait Wait { get; }

    #endregion Properties
  }
}
