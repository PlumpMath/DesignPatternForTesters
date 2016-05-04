//-----------------------------------------------------------------------
// <copyright file="SelectedSeatEntryPoint.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.EntryPoint
{
  using OpenQA.Selenium;
  using Pages;

  internal class SelectedSeatEntryPoint
  {
    private SelectSeatPage selectSeat;

    public SelectedSeatEntryPoint()
    {
      this.selectSeat = new SelectSeatPage();
    }

    public bool IsFull()
    {
      return this.selectSeat.ObtainBookedSeats().Count == 200;
    }
  }
}
