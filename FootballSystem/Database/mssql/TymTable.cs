using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace FootballSystem.ORM.mssql
{
    public class TymTable
    {
        private static string SQL_SELECT = "SELECT idTym, jmeno FROM Tym";
        private static string SQL_SELECTName = "SELECT jmeno FROM Tym where idTym=@v_idtym";

        private static string SQL_INSERT = "INSERT into Tym (jmeno) VALUES (@jmeno)";

        private static string SQL_UPDATE = "UPDATE Tym SET jmeno=@jmeno where idTym=@idTym";

        private static string SQL_DELETE = "DELETE FROM Tym WHERE idTym=@idTym";

        //5.1
        public static int Insert(Tym tym, Database pDb = null)
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
            using (SqlCommand command = db.CreateCommand(SQL_INSERT))
            {
                PrepareCommand(command, tym);
                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //5.4
        public static Collection<Tym> Select(Database pDb = null)
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

                    Collection<Tym> rozhodci = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return rozhodci;
                }
            }
        }

        //5.2
        public static int Update(Tym tym, Database pDb = null)
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
                command.Parameters.AddWithValue("@idTym", tym.IdTym);
                PrepareCommand(command, tym);

                int status = db.ExecuteNonQuery(command);
                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //5.3
        public static int Delete(Tym tym, Database pDb = null)
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
                command.Parameters.AddWithValue("@idTym", tym.IdTym);

                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }
                return status;
            }
        }

        private static void PrepareCommand(SqlCommand command, Tym tym)
        {
            command.Parameters.AddWithValue("@jmeno", tym.Jmeno);
        }

        private static Collection<Tym> Read(SqlDataReader reader)
        {
            Collection<Tym> tymy = new Collection<Tym>();

            while (reader.Read())
            {
                int i = -1;

                Tym tym = new Tym()
                {
                    IdTym = reader.GetInt32(++i),
                    Jmeno = reader.GetString(++i),
                };
                tymy.Add(tym);
            }
            return tymy;
        }
        public static Tym SelectName( int idTym, Database pDb = null)
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
            using (SqlCommand command = db.CreateCommand(SQL_SELECTName))
            {
                command.Parameters.AddWithValue("@v_idtym", idTym);
                using (SqlDataReader reader = db.Select(command))
                {
                    Tym t = new Tym();
                    if (reader.Read())
                    {
                        t.Jmeno = reader.GetString(0);
                    }
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return t;
                }
            }
        }
    }
}
