using System;
using System.Text;

namespace FootballSystem.ORM
{
    public class Zapas
    {
        public int IdZapas { get; set; }
        public int IdLiga { get; set; }
        public DateTime Konani { get; set; }
        public int Skore_domaci { get; set; }
        public int Skore_hoste { get; set; }
        public int IdHriste { get; set; }
        public int IdRozhodci { get; set; }
        public int IdDomaci { get; set; }
        public int IdHoste { get; set; }


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(IdZapas)
                .Append(", ")
                .Append(IdLiga)
                .Append(", ")
                .Append(Konani)
                .Append(", ")
                .Append(Skore_domaci)
                .Append(", ")
                .Append(Skore_hoste)
                .Append(", ")
                .Append(IdHriste)
                .Append(", ")
                .Append(IdRozhodci)
                .Append(", ")
                .Append(IdDomaci)
                .Append(", ")
                .Append(IdHoste);
            return str.ToString();
        }
    }
}
