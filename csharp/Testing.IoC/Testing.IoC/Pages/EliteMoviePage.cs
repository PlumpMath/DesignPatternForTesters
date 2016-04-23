//-----------------------------------------------------------------------
// <copyright file="EliteMoviePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Pages
{
  #region Imports

  using Template;
  using Util;
  using Util.Interfaces;
  #endregion Imports

  public class EliteMoviePage : BasePage<EliteMovieMap>, IEliteMoviePage
  {
    #region Constructors

    public EliteMoviePage() : base()
    {
    }

    #endregion Constructors

    #region Methods

    public ISelectionSchedulePage SelectFilm(string film)
    {
      this.Map.SearchFilm.SendKeys(film);
      this.Map.FirstFilm.Click();

      return PageFactory.Get<ISelectionSchedulePage>();
    }

    #endregion Methods 
  }
}
