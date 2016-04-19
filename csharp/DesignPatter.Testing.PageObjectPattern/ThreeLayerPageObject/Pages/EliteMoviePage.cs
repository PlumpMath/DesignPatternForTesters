//-----------------------------------------------------------------------
// <copyright file="EliteMoviePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.ThreeLayerPageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;

  #endregion Imports

  internal class EliteMoviePage
  {
    #region Attributes

    private readonly IWebDriver driver;
    private readonly EliteMovieMap map;

    #endregion Attributes

    #region Constructors

    public EliteMoviePage(IWebDriver driver)
    {
      this.driver = driver;
      this.map = new EliteMovieMap(this.driver);
    }

    #endregion Constructors

    #region Methods

    public SelectionSchedulePage SelectFilm(string film)
    {
      this.map.SearchFilm.SendKeys(film);
      this.map.FirstFilm.Click();
      return new SelectionSchedulePage(this.driver);
    }

    #endregion Methods 
  }
}
