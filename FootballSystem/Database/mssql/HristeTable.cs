using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace FootballSystem.ORM.mssql
{
    public class HristeTable
    {
        private static string SQL_SELECT = "SELECT idHriste, misto, povrch FROM Hriste";

        private static string SQL_INSERT = "INSERT into Hriste (misto, povrch) VALUES (@misto, @povrch)";

        private static string SQL_UPDATE = "UPDATE Hriste SET misto=@misto, povrch=@povrch";

        private static string SQL_DELETE = "DELETE FROM Hriste WHERE idHriste=@idHriste";

        //2.1
        public static int Insert(Hriste hriste, Database pDb = null)
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
                PrepareCommand(command, hriste);
                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //2.4
        public static Collection<Hriste> Select(Database pDb = null)
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

                    Collection<Hriste> hriste = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return hriste;
                }
            }
        }

        //2.2
        public static int Update(Hriste hriste, Database pDb = null)
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
                command.Parameters.AddWithValue("@idHriste", hriste.IdHriste);
                PrepareCommand(command, hriste);

                int status = db.ExecuteNonQuery(command);
                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //2.3
        public static int Delete(int idHriste, Database pDb = null)
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
                command.Parameters.AddWithValue("@idHriste", idHriste);

                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }
                return status;
            }
        }

        private static void PrepareCommand(SqlCommand command, Hriste hriste)
        {
            command.Parameters.AddWithValue("@misto", hriste.Misto);
            command.Parameters.AddWithValue("@povrch", hriste.Povrch);
        }

        private static Collection<Hriste> Read(SqlDataReader reader)
        {
            var hriste = new Collection<Hriste>();

            while (reader.Read())
            {
                int i = -1;

                Hriste hr = new Hriste()
                {
                    IdHriste = reader.GetInt32(++i),
                    Misto = reader.GetString(++i),
                    Povrch = reader.GetString(++i)
                };
                hriste.Add(hr);
            }
            return hriste;
        }
    }
}
