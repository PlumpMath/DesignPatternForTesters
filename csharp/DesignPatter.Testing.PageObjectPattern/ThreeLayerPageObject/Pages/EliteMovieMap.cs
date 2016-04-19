//-----------------------------------------------------------------------
// <copyright file="EliteMovieMap.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.ThreeLayerPageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;

  #endregion Imports

  internal class EliteMovieMap
  {
    #region Attributes

    private readonly IWebDriver driver;

    #endregion Attributes

    #region Constructors

    public EliteMovieMap(IWebDriver driver)
    {
      this.driver = driver;
    }

    #endregion Constructors

    #region Properties

    public IWebElement SearchFilm =>
        this.driver.FindElement(By.CssSelector(".searchfield"));

    public IWebElement FirstFilm =>
        this.driver.FindElement(By.CssSelector("a.ng-scope:nth-child(1) > img:nth-child(1)"));

    #endregion Properties
  }
}
