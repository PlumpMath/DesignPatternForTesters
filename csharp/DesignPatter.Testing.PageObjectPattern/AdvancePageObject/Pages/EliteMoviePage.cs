//-----------------------------------------------------------------------
// <copyright file="EliteMoviePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.AdvancePageObject.Pages
{
  #region Imports

  using OpenQA.Selenium;
  using Template;
  #endregion Imports

  internal class EliteMoviePage : BasePage<EliteMovieMap>
  {
    #region Constructors

    public EliteMoviePage(IWebDriver driver) : base(driver)
    {
    }

    #endregion Constructors

    #region Methods

    public SelectionSchedulePage SelectFilm(string film)
    {
      this.Map.SearchFilm.SendKeys(film);
      this.Map.FirstFilm.Click();
      return new SelectionSchedulePage(this.Driver);
    }

    #endregion Methods 
  }
}
