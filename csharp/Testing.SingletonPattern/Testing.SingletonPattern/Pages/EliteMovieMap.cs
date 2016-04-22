//-----------------------------------------------------------------------
// <copyright file="EliteMovieMap.cs" company="ShareKnowledge">
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

  internal class EliteMovieMap : BasePageElementMap
  {
    #region Properties

    public IWebElement SearchFilm =>
        this.Browser.FindElement(By.CssSelector(".searchfield"));

    public IWebElement FirstFilm =>
        this.Browser.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));

    #endregion Properties
  }
}
