//-----------------------------------------------------------------------
// <copyright file="Seat.cs" company="ShareKnowledge">
//     Copyright (c) ShareKnowledge. All rights reserved.
// </copyright>
// <author>Alejandro Perdomo</author>
//-----------------------------------------------------------------------

namespace DesignPatter.Testing.PageObjectPattern.Entity
{
  #region Imports

  using Newtonsoft.Json;

  #endregion Imports

  internal class Seat
  {
    #region Properties

    [JsonProperty(PropertyName = "row")]
    public int Row { get; set; }

    [JsonProperty(PropertyName = "column")]
    public int Column { get; set; }

    [JsonProperty(PropertyName = "booked")]
    public bool Booked { get; set; }

    #endregion Properties

    #region Methods

    public override bool Equals(object obj)
    {
      Seat other = obj as Seat;

      return other != null &&
          this.Column == other.Column &&
          this.Row == other.Row;
    }

    public override int GetHashCode()
    {
      return this.Column.GetHashCode() ^
          this.Row.GetHashCode();
    }

    #endregion Methods
  }
}
