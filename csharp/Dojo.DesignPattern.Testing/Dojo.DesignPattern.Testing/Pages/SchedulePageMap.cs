using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dojo.DesignPattern.Testing.Template;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Dojo.DesignPattern.Testing.Pages
{
  public class SchedulePageMap : BasePageElementMap
  {
    public SelectElement ShowTime =>
      new SelectElement(this.Driver.FindElement(By.Id("showTime")));

    public SelectElement Seats =>
      new SelectElement(this.Driver.FindElement(By.Name("seats")));

    public IWebElement Continue =>
      this.Driver.FindElement(By.CssSelector("input.btn"));
  }
}
