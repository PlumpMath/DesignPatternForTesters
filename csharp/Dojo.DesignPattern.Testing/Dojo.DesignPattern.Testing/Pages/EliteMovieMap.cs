using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dojo.DesignPattern.Testing.Template;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.Pages
{
  public class EliteMovieMap : BasePageElementMap
  {
    public IWebElement SearchFilm =>
      this.Driver.FindElement(By.CssSelector(".searchfield"));

    public IWebElement Film =>
      this.Driver.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));
  }
}
