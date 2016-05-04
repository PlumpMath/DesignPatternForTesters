//-----------------------------------------------------------------------
// <copyright file="Showtime.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Dojo.DesignPattern.Testing.Entity
{
  using System.Collections.Generic;
  using Newtonsoft.Json;

  public class Showtime
  {
    [JsonProperty(PropertyName = "seats")]
    public List<Seat[]> Seats { get; set; }
  }
}
