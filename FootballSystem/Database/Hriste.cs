using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.ORM
{
    public class Hriste
    {
        public int IdHriste { get; set; }
        public string Misto { get; set; }
        public string Povrch { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(IdHriste)
                .Append(", ")
                .Append(Misto)
                .Append(", ")
                .Append(Povrch);
            return str.ToString();
        }
    }
}
