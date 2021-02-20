using System;
using System.Text;


namespace FootballSystem.ORM
{
    public class Gol
    {
        public int IdGol { get; set; }
        public int Cas { get; set; }
        public int IdZapas { get; set; }
        public int IdHrac { get; set; }

        public Hrac Hrac { get; set; }
        public int PocetGolu { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Hrac.Jmeno)
                .Append(", ")
                .Append(PocetGolu);
            return str.ToString();
        }
    }
}
