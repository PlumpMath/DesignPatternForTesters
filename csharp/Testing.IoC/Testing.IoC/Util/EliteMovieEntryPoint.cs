//-----------------------------------------------------------------------
// <copyright file="EliteMovieEntryPoint.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Util
{
  using System;
  using System.Threading;
  using Entity;
  using Interfaces;
  using OpenQA.Selenium;
  using Pages;

  public class EliteMovieEntryPoint
  {
    private IEliteMoviePage eliteMovie;

    public EliteMovieEntryPoint()
    {
      this.eliteMovie = PageFactory.Get<IEliteMoviePage>();
    }

    public void Reserve(Reserve informationReserve)
    {
      if (informationReserve == null)
      {
        throw new ArgumentNullException(nameof(informationReserve));
      }

      this.eliteMovie
        .SelectFilm(informationReserve.Film)
        .SelectShowtimeAndAmountSeats(informationReserve.Function, informationReserve.Seats.Count)
        .SelectSeats(informationReserve.Seats)
        .Finish();
    }
  }
}
