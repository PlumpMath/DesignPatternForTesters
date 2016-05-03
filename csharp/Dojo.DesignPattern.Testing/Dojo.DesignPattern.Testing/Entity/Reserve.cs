using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.DesignPattern.Testing.Entity
{
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

    public List<Seat> Seats { get; }
  }
}
