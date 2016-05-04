using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Testing.FacadePattern.Util
{
  public class DriverSingleton
  {
    private readonly static Lazy<DriverSingleton> lazy = new Lazy<DriverSingleton>(() => new DriverSingleton());

    public IWebDriver Browser { get; }
    public WebDriverWait Wait { get; }

    private DriverSingleton()
    {
      this.Browser = new FirefoxDriver();
      this.Wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(30));
    }

    public static DriverSingleton Instance =>
      lazy.Value;
  }
}
