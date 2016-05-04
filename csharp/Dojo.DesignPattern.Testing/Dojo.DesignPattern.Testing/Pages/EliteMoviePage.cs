//-----------------------------------------------------------------------
// <copyright file="EliteMoviePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Pages
{
  using System.Linq;
  using OpenQA.Selenium;
  using Template;

  public class EliteMoviePage : PageBase<EliteMovieMap>
  {
    public SchedulePage SelectFilm(string filmName)
    {
      this.Map.SearchFilm.SendKeys(filmName);
      this.Map.Film.Click();

      return new SchedulePage();
    }

    internal bool FindFilm(string filmName)
    {
      this.Map.SearchFilm.SendKeys(filmName);
      return this.Map.MovieListings.Any();
    }
  }
}
