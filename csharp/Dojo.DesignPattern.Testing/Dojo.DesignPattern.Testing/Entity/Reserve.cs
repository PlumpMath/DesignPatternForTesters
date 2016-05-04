//-----------------------------------------------------------------------
// <copyright file="Reserve.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Entity
{
  using System.Collections.Generic;

  public class Reserve
  {
    public Reserve()
    {
    }

    public Reserve(string film, string showtime)
    {
      this.Film = film;
      this.Showtime = showtime;
      this.Seats = new List<Seat>();
    }

    public string Film { get; set; }

    public string Showtime { get; set; }

    public ICollection<Seat> Seats { get; }
  }
}
