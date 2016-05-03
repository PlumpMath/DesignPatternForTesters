using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dojo.DesignPattern.Testing.Entity
{
  public class Seat
  {
    public Seat() : this(0, 0)
    {
    }

    public Seat(int row, int column) : this(row, column, false)
    {
    }

    public Seat(int row, int column, bool booked)
    {
      this.Row = row;
      this.Column = column;
      this.Booked = booked;
    }

    [JsonProperty(PropertyName = "row")]
    public int Row { get; set; }

    [JsonProperty(PropertyName = "column")]
    public int Column { get; set; }

    [JsonProperty(PropertyName = "booked")]
    public bool Booked { get; set; }

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
  }
}
