using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;

namespace FootballSystem.ORM.mssql
{
    public class HracTable
    {
        private static string SQL_SELECT = "SELECT h.idHrac, jmeno, datum_narozeni FROM Hrac h join tym_hrac th on th.idhrac=h.idhrac where th.idTym=@v_idTym";
        private static string SQL_SELECTTym = "SELECT jmeno FROM Tym t join tym_hrac th on th.idtym=t.idtym where th.idhrac= @v_idHrac";

        private static string SQL_UPDATE = "UPDATE Hrac SET jmeno=@jmeno, datum_narozeni=@datum_narozeni where idHrac=@idHrac";

        private static string SQL_DELETE = "DELETE FROM Hrac WHERE idHrac=@idHrac";

        //3.1
        public static int Insert(Hrac hrac, Tym tym, Database pDb = null)
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
            using (SqlCommand command = db.CreateCommand("pridejHrace"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_hrac", hrac.Jmeno);
                command.Parameters.AddWithValue("@p_tym", tym.Jmeno);
                command.Parameters.AddWithValue("@p_datum", hrac.Datum_narozeni);

                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //3.4
        public static Collection<Hrac> Select(int idTym, Database pDb = null)
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
                command.Parameters.AddWithValue("@v_idTym", idTym);

                using (SqlDataReader reader = db.Select(command))
                {

                    Collection<Hrac> hrac = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return hrac;
                }
            }
        }

        //3.2
        public static int Update(Hrac hrac, Database pDb = null)
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
            using (SqlCommand command = db.CreateCommand(SQL_UPDATE))
            {
                command.Parameters.AddWithValue("@idHrac", hrac.IdHrac);
                PrepareCommand(command, hrac);

                int status = db.ExecuteNonQuery(command);
                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //3.3
        public static int Delete(int idHrac, Database pDb = null)
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
            using (SqlCommand command = db.CreateCommand(SQL_DELETE))
            {
                command.Parameters.AddWithValue("@idHrac", idHrac);

                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }
                return status;
            }
        }

        private static void PrepareCommand(SqlCommand command, Hrac hrac)
        {
            command.Parameters.AddWithValue("@jmeno", hrac.Jmeno);
            command.Parameters.AddWithValue("@datum_narozeni", hrac.Datum_narozeni);
        }

        private static Collection<Hrac> Read(SqlDataReader reader)
        {
            var hrac = new Collection<Hrac>();

            while (reader.Read())
            {
                int i = -1;

                Hrac hr = new Hrac()
                {
                    IdHrac = reader.GetInt32(++i),
                    Jmeno = reader.GetString(++i),
                    Datum_narozeni = reader.GetDateTime(++i)
                };
                hrac.Add(hr);
            }
            return hrac;
        }

        public static Hrac SelectTym(int idHrac, Database pDb = null)
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
            using (SqlCommand command = db.CreateCommand(SQL_SELECTTym))
            {
                command.Parameters.AddWithValue("@v_idHrac", idHrac);
                using (SqlDataReader reader = db.Select(command))
                {
                    Hrac h = new Hrac();
                    if (reader.Read())
                    {
                        h.TymJmeno = reader.GetString(0);
                    }
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return h;
                }
            }
        }
    }
}
