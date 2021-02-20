using System;
using System.Text;


namespace FootballSystem.ORM
{
    public class Tym_Hrac
    {
        public int IdTym { get; set; }
        public int IdHrac { get; set; }
        public DateTime Zacatek { get; set; }
        public DateTime Konec { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(IdTym)
                .Append(", ")
                .Append(IdHrac)
                .Append(", ")
                .Append(Zacatek)
                .Append(", ")
                .Append(Konec);
            return str.ToString();
        }
    }
}
