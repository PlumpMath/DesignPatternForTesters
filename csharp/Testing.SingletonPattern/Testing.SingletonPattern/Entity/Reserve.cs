//-----------------------------------------------------------------------
// <copyright file="Reserve.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.SingletonPattern.Entity
{
  using System.Collections.Generic;
  #region Imports

  using System.Collections.ObjectModel;

  #endregion Imports

  public class Reserve
  {
    #region Properties

    public Reserve(Collection<Seat> seats)
    {
      this.Seats = new ReadOnlyCollection<Seat>(seats);
    }

    public string Film { get; set; }

    public string Function { get; set; }

    public ReadOnlyCollection<Seat> Seats { get; }

    #endregion Properties
  }
}
