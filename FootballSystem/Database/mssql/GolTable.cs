using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;

namespace FootballSystem.ORM.mssql
{
    public class GolTable
    {
        private static string SQL_SELECT = "SELECT top(10) h.idhrac, h.jmeno, COUNT(g.idgol) as pocet FROM Gol g join hrac h on h.idHrac=g.idHrac group by h.idhrac,h.jmeno order by pocet desc";

        //6.1
        public static int Insert(int idZapas, int idHrac, int cas, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }
            using (db)
            using (SqlCommand command = db.CreateCommand("PridejGol"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_idzapas", idZapas);
                command.Parameters.AddWithValue("@p_idhrac", idHrac);
                command.Parameters.AddWithValue("@p_cas", cas);

                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //6.2
        public static Collection<Gol> Select(Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            using (db)
            using (SqlCommand command = db.CreateCommand(SQL_SELECT))
            {
                using (SqlDataReader reader = db.Select(command))
                {

                    Collection<Gol> goly = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return goly;
                }
            }
        }

        private static Collection<Gol> Read(SqlDataReader reader)
        {
            var goly = new Collection<Gol>();

            while (reader.Read())
            {
                int i = -1;


                Gol gol = new Gol();
                gol.Hrac = new Hrac();
                gol.Hrac.IdHrac = reader.GetInt32(++i);
                gol.Hrac.Jmeno = reader.GetString(++i);
                gol.PocetGolu = reader.GetInt32(++i);
                
                goly.Add(gol);
            }
            return goly;
        }
    }
}
