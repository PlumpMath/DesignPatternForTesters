using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dojo.DesignPattern.Testing.Entity
{
  public class ShowTime
  {
    [JsonProperty(PropertyName = "seats")]
    public List<List<Seat>> Seats { get; set; }
  }
}
