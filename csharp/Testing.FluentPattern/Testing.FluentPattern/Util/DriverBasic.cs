﻿//-----------------------------------------------------------------------
// <copyright file="DriverBasic.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FluentPattern.Util
{
  #region Imports

  using System;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using OpenQA.Selenium.Edge;
  using OpenQA.Selenium.Firefox;
  using OpenQA.Selenium.IE;
  using OpenQA.Selenium.Support.UI;

  #endregion Imports

  public class DriverBasic
  {
    #region Attributes

    private static DriverBasic instance;

    #endregion Attributes

    #region Constructors

    private DriverBasic()
    {
      this.Browser = ObtainDriver(BrowserType);
      this.Wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(30));
    }

    #endregion Constructors

    #region Properties

    public static BrowserType BrowserType { get; set; }

    public static DriverBasic Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new DriverBasic();
        }

        return instance;
      }
    }

    public IWebDriver Browser { get; }

    public WebDriverWait Wait { get; }

    #endregion Properties

    #region Methods

    #region Publics

    public void StopBrowser()
    {
      this.Browser.Quit();
    }

    #endregion Publics

    #region Privates

    private static IWebDriver ObtainDriver(BrowserType browserType)
    {
      IWebDriver driver = null;

      switch (browserType)
      {
        case BrowserType.Firefox:
          driver = new FirefoxDriver();
          break;

        case BrowserType.Chrome:
          driver = new ChromeDriver();
          break;

        case BrowserType.InternetExplorer:
          driver = new InternetExplorerDriver();
          break;

        case BrowserType.Edge:
          driver = new EdgeDriver();
          break;

        default:
          break;
      }

      return driver;
    }

    #endregion Privates

    #endregion Methods
  }
}
