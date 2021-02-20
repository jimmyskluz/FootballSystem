using System;
using System.Collections.Generic;
using System.Text;

namespace FootballSystem.ORM
{
    public class Rozhodci
    {
        public int IdRozhodci { get; set; }
        public string Jmeno { get; set; }
        public DateTime Datum_narozeni { get; set; }

        public List<Zapas> Zapasy { get; set; }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(IdRozhodci)
                .Append(", ")
                .Append(Jmeno)
                .Append(", ")
                .Append(Datum_narozeni);
            return str.ToString();
        }
    }
}
