//-----------------------------------------------------------------------
// <copyright file="EliteMoviePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FluentPattern.Pages
{
  #region Imports

  using Template;
  #endregion Imports

  internal class EliteMoviePage : BasePage<EliteMovieMap>
  {
    #region Constructors

    public EliteMoviePage() : base()
    {
    }

    #endregion Constructors

    #region Methods

    public SelectionSchedulePage SelectFilm(string film)
    {
      this.Map.SearchFilm.SendKeys(film);
      this.Map.FirstFilm.Click();
      return new SelectionSchedulePage();
    }

    #endregion Methods 
  }
}
