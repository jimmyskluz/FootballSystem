using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.ORM
{
    public class Liga
    {
        public int IdLiga { get; set; }
        public string Nazev { get; set; }
        public DateTime Zacatek { get; set; }
        public DateTime Konec { get; set; }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(IdLiga)
                .Append(", ")
                .Append(Nazev)
                .Append(", ")
                .Append(Zacatek)
                .Append(", ")
                .Append(Konec);
            return str.ToString();
        }
    }
}
