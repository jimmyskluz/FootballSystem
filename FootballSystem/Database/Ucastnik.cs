using System.Text;

namespace FootballSystem.ORM
{       
    public class Ucastnik
    {
        public int IdLiga { get; set; }
        public int IdTym { get; set; }
        public int Body { get; set; }

        public Tym Tym { get; set; }
        public int PocetZapasu { get; set; }
        public int Vyhry { get; set; }
        public int Remizy { get; set; }
        public int Prohry { get; set; }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Tym.Jmeno)
                .Append(", ")
                .Append(PocetZapasu)
                .Append(", ")
                .Append(Vyhry)
                .Append(", ")
                .Append(Remizy)
                .Append(", ")
                .Append(Prohry)
                .Append(", ")
                .Append(Body);
            return str.ToString();
        }
    }
}
