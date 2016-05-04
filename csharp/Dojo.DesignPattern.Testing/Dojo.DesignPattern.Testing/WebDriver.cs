//-----------------------------------------------------------------------
// <copyright file="WebDriver.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing
{
  using System;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using OpenQA.Selenium.Edge;
  using OpenQA.Selenium.Firefox;
  using OpenQA.Selenium.IE;
  using OpenQA.Selenium.Support.UI;

  internal class WebDriver
  {
    private static readonly Lazy<WebDriver> Lazy = new Lazy<WebDriver>(() => new WebDriver());

    private WebDriver()
    {
      this.Browser = ObtainBrowserInstance(Type);
      this.Wait = new WebDriverWait(this.Browser, WaitTime);
    }

    public static WebDriver Instance
      => Lazy.Value;

    internal static BrowserType Type { get; set; }

    internal static TimeSpan WaitTime { get; set; }

    internal IWebDriver Browser { get; }

    internal WebDriverWait Wait { get; }

    internal static void Finish()
    {
      Instance.Browser.Dispose();
    }

    private static IWebDriver ObtainBrowserInstance(BrowserType type)
    {
      IWebDriver result = null;

      switch (type)
      {
        case BrowserType.Firefox:
          result = new FirefoxDriver();
          break;
        case BrowserType.Chrome:
          result = new ChromeDriver();
          break;
        case BrowserType.InterneteExplorer:
          result = new InternetExplorerDriver();
          break;
        case BrowserType.Edge:
          result = new EdgeDriver();
          break;
        default:
          break;
      }

      return result;
    }
  }
}
