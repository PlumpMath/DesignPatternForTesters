//-----------------------------------------------------------------------
// <copyright file="ISelectionSchedulePage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Util.Interfaces
{
  public interface ISelectionSchedulePage
  {
    IAssignSeatPage SelectShowtimeAndAmountSeats(string showtime, int seats);
  }
}