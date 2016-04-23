//-----------------------------------------------------------------------
// <copyright file="EliteMovieEntryPoint.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FluentPattern.Util
{
  using System;
  using System.Threading;
  using Entity;
  using OpenQA.Selenium;
  using Pages;

  public class EliteMovieEntryPoint
  {
    private EliteMoviePage eliteMovie;

    public EliteMovieEntryPoint()
    {
      this.eliteMovie = new EliteMoviePage();
    }

    public void Reserve(Reserve informationReserve)
    {
      if (informationReserve == null)
      {
        throw new ArgumentNullException(nameof(informationReserve));
      }

      this.eliteMovie
        .SelectFilm(informationReserve.Film)
        .SelectFunctionAndAmountSeats(informationReserve.Function, informationReserve.Seats.Count)
        .SelectSeats(informationReserve.Seats)
        .Finish();
    }
  }
}
