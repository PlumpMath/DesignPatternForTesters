using System.Collections.ObjectModel;
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

    public ReadOnlyCollection<IWebElement> MovieListings =>
      this.Driver.FindElements(By.CssSelector("a.ng-scope"));
  }
}
