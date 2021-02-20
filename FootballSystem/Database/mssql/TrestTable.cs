using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;

namespace FootballSystem.ORM.mssql
{
    public class TrestTable
    {
        private static string SQL_SELECT = "SELECT  h.idhrac, h.jmeno, SUM(t.delka) as pocet FROM Trest t join hrac h on h.idHrac=t.idHrac group by h.idhrac, h.jmeno order by pocet desc";

        //7.1
        public static int Insert(int idZapas, int idHrac, int cas, int delka, Database pDb = null)
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
            using (SqlCommand command = db.CreateCommand("PridejTrest"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_idzapas", idZapas);
                command.Parameters.AddWithValue("@p_idhrac", idHrac);
                command.Parameters.AddWithValue("@p_cas", cas);
                command.Parameters.AddWithValue("@p_delka", delka); int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //7.2
        public static Collection<Trest> Select(Database pDb = null)
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

                    Collection<Trest> tresty = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return tresty;
                }
            }
        }

        private static Collection<Trest> Read(SqlDataReader reader)
        {
            var tresty = new Collection<Trest>();

            while (reader.Read())
            {
                int i = -1;

                Trest trest = new Trest();
                trest.Hrac = new Hrac();
                trest.Hrac.IdHrac = reader.GetInt32(++i);
                trest.Hrac.Jmeno = reader.GetString(++i);
                trest.Minuty = reader.GetInt32(++i);

                tresty.Add(trest);
            }
            return tresty;
        }
    }
}
