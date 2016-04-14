using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatter.Testing.PageObjectPattern.Entity
{
    internal class ShowTime
    {
        public int id { get; set; }
        public int movieId {get; set; }
        public long timeInMilliseconds { get; set; }
        public List<Seat[]> seats {get; set;}
    }
}
