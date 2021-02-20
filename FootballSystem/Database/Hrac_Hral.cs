using System;
using System.Text;

namespace FootballSystem.ORM
{
    public class Hrac_Hral
    {
        public int IdZapas { get; set; }
        public int IdHrac { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(IdZapas)
                .Append(", ")
                .Append(IdHrac);
            return str.ToString();
        }

    }
}
