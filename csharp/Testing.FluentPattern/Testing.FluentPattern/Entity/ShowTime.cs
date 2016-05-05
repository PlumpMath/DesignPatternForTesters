//-----------------------------------------------------------------------
// <copyright file="ShowTime.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace Testing.FluentPattern.Entity
{
  #region Imports

  using System.Collections.Generic;
  using Newtonsoft.Json;

  #endregion Imports

  internal class ShowTime
  {
    #region Properties

    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "movieId")]
    public int MovieId { get; set; }

    [JsonProperty(PropertyName = "timeInMilliseconds")]
    public long TimeInMilliseconds { get; set; }

    [JsonProperty(PropertyName = "seats")]
    public List<Seat[]> Seats { get; set; }

    #endregion Properties
  }
}
