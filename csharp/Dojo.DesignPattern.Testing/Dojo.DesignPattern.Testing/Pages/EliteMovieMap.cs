//-----------------------------------------------------------------------
// <copyright file="EliteMovieMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Pages
{
  using System.Collections.ObjectModel;
  using OpenQA.Selenium;
  using Template;

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
