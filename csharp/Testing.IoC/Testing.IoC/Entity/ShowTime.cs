//-----------------------------------------------------------------------
// <copyright file="Showtime.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.Ioc.Entity
{
  #region Imports

  using System.Collections.Generic;
  using Newtonsoft.Json;

  #endregion Imports

  public class Showtime
  {
    #region Properties

    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "movieId")]
    public int MovieId { get; set; }

    [JsonProperty(PropertyName = "timeInMilliseconds")]
    public long TimeInMilliseconds { get; set; }

    [JsonProperty(PropertyName = "seats")]
    public IReadOnlyCollection<Seat[]> Seats { get; set; }

    #endregion Properties
  }
}
