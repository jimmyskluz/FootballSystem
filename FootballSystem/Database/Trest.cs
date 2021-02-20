using System;
using System.Text;

namespace FootballSystem.ORM
{
    public class Trest
    {
        public int IdTrest { get; set; }
        public int Cas { get; set; }
        public int Delka { get; set; }
        public int IdZapas { get; set; }
        public int IdHrac { get; set; }

        public Hrac Hrac { get; set; }
        public int Minuty { get; set; }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Hrac.Jmeno)
                .Append(", ")
                .Append(Minuty);
            return str.ToString();
        }
    }
}
