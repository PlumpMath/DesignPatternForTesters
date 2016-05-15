//-----------------------------------------------------------------------
// <copyright file="EliteMovieEntryPoint.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Util
{
  using System;
  using System.Collections.Generic;
  using Entity;
  using Interfaces;

  public class EliteMovieEntryPoint
  {
    private IEliteMoviePage eliteMovie;

    public EliteMovieEntryPoint()
    {
      this.eliteMovie = ContainerFactory.Get<IEliteMoviePage>();
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

    internal ICollection<Seat> ObtainBookedSeats(string film, string showTime)
    {
      return this.eliteMovie
        .SelectFilm(film)
        .SelectShowtimeAndAmountSeats(showTime, 1)
        .BookedSeats();
    }
  }
}
