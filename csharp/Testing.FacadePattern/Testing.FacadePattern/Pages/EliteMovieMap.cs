//-----------------------------------------------------------------------
// <copyright file="EliteMovieMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FacadePattern.Pages
{
  #region Imports

  using OpenQA.Selenium;
  using Template;

  #endregion Imports

  internal class EliteMovieMap : BasePageElementMap
  {
    #region Properties

    public IWebElement SearchFilm =>
        this.Driver.FindElement(By.CssSelector(".searchfield"));

    public IWebElement FirstFilm =>
        this.Driver.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));

    #endregion Properties
  }
}
