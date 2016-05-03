using System;
using System.Collections.Generic;
using Dojo.DesignPattern.Testing.Entity;
using Dojo.DesignPattern.Testing.Template;
using OpenQA.Selenium;

namespace Dojo.DesignPattern.Testing.Pages
{
  public class SelectSeatPage : PageBase<SelectSeatMap>
  {
    public SelectSeatPage(IWebDriver driver) : base(driver)
    {

    }

    public ConfirmationPage SelectSeatsAndContinue(List<Seat> seats)
    {
      seats.ForEach(seat => this.Map.Seat(seat.Row, seat.Column).Click());
      this.Map.Continue.Click();

      return new ConfirmationPage(this.Driver);
    }

    public List<Seat> SelectSeat(List<Seat> seats)
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

    public bool IsSelectedSeat(Seat seat)
    {
      return this.Map.SeatProperty(seat.Row, seat.Column).Selected;
    }
  }
}
