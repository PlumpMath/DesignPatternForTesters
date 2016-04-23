//-----------------------------------------------------------------------
// <copyright file="IAssignSeatPage.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Util.Interfaces
{
  #region Imports

  using System.Collections.Generic;
  using Testing.Ioc.Entity;

  #endregion Imports

  public interface IAssignSeatPage
  {
    IConfirmationPage SelectSeats(ICollection<Seat> seats);
  }
}