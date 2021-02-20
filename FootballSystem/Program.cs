using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballSystem.ORM.Forms;
using FootballSystem.ORM.mssql;
using System.Windows.Forms;


namespace FootballSystem.ORM
{
    static class Program
    {
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.Run(new hlavni());
            
            /*
            Database db = new Database();
            db.Connect();
            Console.WriteLine("Seznam ucastniku ligy");
            foreach (var ucastnik in UcastnikTable.Select(1, db))
            {
                Console.WriteLine(ucastnik);
            }
            db.Connect();

            Console.WriteLine();
            Console.WriteLine("Seznam lig");
            foreach (var liga in LigaTable.Select(db))
            {
                Console.WriteLine(liga);
            }
            db.Connect();

            Console.WriteLine();
            Console.WriteLine("Seznam tymu");
            foreach (var tym in TymTable.Select(db))
            {
                Console.WriteLine(tym);
            }
            db.Connect();

            Console.WriteLine();
            Console.WriteLine("Seznam zapasu");
            foreach (var zapas in ZapasTable.Select(db))
            {
                Console.WriteLine(zapas);
            }
            db.Connect();

            Console.WriteLine();
            Console.WriteLine("Seznam rozhodcich");
            foreach (var rozhodci in RozhodciTable.Select(db))
            {
                Console.WriteLine(rozhodci);
            }
            db.Connect();

            Console.WriteLine();
            Console.WriteLine("Seznam hracu");
            foreach (var hrac in HracTable.Select(db))
            {
                Console.WriteLine(hrac);
            }
            db.Connect();

            Console.WriteLine();
            Console.WriteLine("Seznam hrist");
            foreach (var hriste in HristeTable.Select(db))
            {
                Console.WriteLine(hriste);
            }
            db.Connect();

            Console.WriteLine();
            Console.WriteLine("Seznam golu");
            foreach (var gol in GolTable.Select(db))
            {
                Console.WriteLine(gol);
            }
            db.Connect();

            Console.WriteLine();
            Console.WriteLine("Seznam trestu");
            foreach (var trest in TrestTable.Select(db))
            {
                Console.WriteLine(trest);
            }
            db.Connect();

            Console.WriteLine();
            Console.WriteLine("Seznam hracu hrajich v zapasech");
            foreach (var hh in Hrac_HralTable.Select(db))
            {
                Console.WriteLine(hh);
            }
            db.Connect();

            Console.WriteLine();
            Console.WriteLine("Seznam hracu tymu");
            foreach (var ht in Tym_HracTable.Select(db))
            {
                Console.WriteLine(ht);
            }
            */
        }
    }
}
