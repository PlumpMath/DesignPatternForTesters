//-----------------------------------------------------------------------
// <copyright file="GenericApiValidator.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Validation
{
  #region Imports

  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Entity;
  using NUnit.Framework;

  #endregion Imports

  internal static class GenericApiValidator
  {
    public static void AssertBookedSeats(ICollection<Seat> expectedResult)
    {
      Showtime showTime = ApiConsumer.RequestGet<Showtime>(new Uri("http://localhost:8080/rest/showtime/3"));
      List<Seat> bookedSeats = new List<Seat>();
      showTime.Seats.ToList().ForEach(block => bookedSeats.AddRange(block.Where(seat => seat.Booked)));

      CollectionAssert.AreEquivalent(expectedResult, bookedSeats);
    }
  }
}
