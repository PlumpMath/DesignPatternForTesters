//-----------------------------------------------------------------------
// <copyright file="SelectSeatPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Pages
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;
  using Entity;
  using OpenQA.Selenium;
  using Template;

  public class SelectSeatPage : PageBase<SelectSeatMap>
  {
    public ConfirmationPage SelectSeatsAndContinue(ICollection<Seat> seats)
    {
      seats.ToList().ForEach(seat => this.Map.Seat(seat.Row, seat.Column).Click());
      this.Map.Continue.Click();

      return new ConfirmationPage();
    }

    internal ICollection<Seat> SelectSeat(ICollection<Seat> seats)
    {
      List<Seat> result = new List<Seat>();
      Seat newSeat;

      foreach (Seat current in seats)
      {
        this.Map.Seat(current.Row, current.Column).Click();
        newSeat = new Seat(current.Row, current.Column);
        newSeat.Booked = this.IsSelectedSeat(newSeat);

        result.Add(newSeat);
      }

      return result;
    }

    internal bool IsSelectedSeat(Seat seat)
    {
      return this.Map.SeatProperty(seat.Row, seat.Column).Selected;
    }

    internal ICollection<Seat> ObtainBookedSeats()
    {
      List<Seat> bookedSeats = new List<Seat>();
      this.Map.BookedSeats
        .ToList()
        .ForEach(element => bookedSeats.Add(
          SelectSeatPage.ConvertToSeat(element.GetAttribute("id"))));

      return bookedSeats;
    }

    internal string AlertMessage()
    {
      return this.Driver.SwitchTo().Alert().Text;
    }

    private static Seat ConvertToSeat(string position)
    {
      string[] axis = position.Split(',');

      return new Seat
      {
        Row = Convert.ToInt32(axis[0], CultureInfo.CurrentCulture),
        Column = Convert.ToInt32(axis[1], CultureInfo.CurrentCulture)
      };
    }
  }
}
