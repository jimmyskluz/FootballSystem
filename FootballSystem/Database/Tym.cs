using System;
using System.Text;

namespace FootballSystem.ORM
{
    public class Tym
    {
        public int IdTym { get; set; }
        public string Jmeno { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(IdTym)
                .Append(". ")
                .Append(Jmeno);
            return str.ToString();
        }
    }
}
