//-----------------------------------------------------------------------
// <copyright file="EliteMovieEntryPoint.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.SingletonPattern.Util
{
  using System;
  using System.Threading;
  using Entity;
  using OpenQA.Selenium;
  using Pages;

  public class EliteMovieEntryPoint
  {
    private EliteMoviePage eliteMovie;
    private SelectionSchedulePage schedule;
    private AssignSeatPage assignSeat;
    private ConfirmationPage confirmation;

    public EliteMovieEntryPoint()
    {
      this.eliteMovie = new EliteMoviePage();
      this.schedule = new SelectionSchedulePage();
      this.assignSeat = new AssignSeatPage();
      this.confirmation = new ConfirmationPage();
    }

    public void Reserve(Reserve informationReserve)
    {
      if (informationReserve == null)
      {
        throw new ArgumentNullException(nameof(informationReserve));
      }

      this.eliteMovie.SelectFilm(informationReserve.Film);
      this.schedule.SelectFunctionAndAmountSeats(informationReserve.Function, informationReserve.Seats.Count);
      this.assignSeat.SelectSeats(informationReserve.Seats);
      this.confirmation.Finish();
    }
  }
}
