//-----------------------------------------------------------------------
// <copyright file="EliteMovieUiValidator.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Validation
{
  #region Imports

  using System.Collections.Generic;
  using Entity;
  using Interfaces;
  using NUnit.Framework;
  using Util;

  #endregion Imports

  public class EliteMovieUiValidator : IEliteMovieValidator
  {
    public Reserve Reserve
    {
      get;
      set;
    }

    public void VerifiesReserveSeats()
    {
      EliteMovieEntryPoint entryPoint = new EliteMovieEntryPoint();
      ICollection<Seat> bookedSeats = entryPoint.ObtainBookedSeats(this.Reserve.Film, this.Reserve.Function);

      foreach (Seat currentSeat in Reserve.Seats)
      {
        CollectionAssert.Contains(bookedSeats, currentSeat);
      }
    }
  }
}
