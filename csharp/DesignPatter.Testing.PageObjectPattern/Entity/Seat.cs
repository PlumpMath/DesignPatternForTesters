using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatter.Testing.PageObjectPattern.Entity
{
    internal class Seat
    {
        public int row { get; set; }
        public int column { get; set; }
        public bool aisle { get; set; }
        public bool booked { get; set; }
        public int preferencePoints { get; set; }

        public override bool Equals(object obj)
        {
            Seat other = obj as Seat;

            return other != null &&
                this.column == other.column &&
                this.row == other.row;
        }

        public override int GetHashCode()
        {
            return this.column.GetHashCode() ^
                this.row.GetHashCode();
        }
    }

}
