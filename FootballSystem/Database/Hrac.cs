using System;
using System.Text;

namespace FootballSystem.ORM
{
    public class Hrac
    {
        public int IdHrac { get; set; }
        public string Jmeno { get; set; }
        public DateTime Datum_narozeni { get; set; }
        public string TymJmeno { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(IdHrac)
                .Append(", ")
                .Append(Jmeno)
                .Append(", ")
                .Append(Datum_narozeni);
            return str.ToString();
        }
    }
}
