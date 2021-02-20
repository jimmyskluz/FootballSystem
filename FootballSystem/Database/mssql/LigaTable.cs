using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace FootballSystem.ORM.mssql
{
    public class LigaTable
    {
        private static string SQL_SELECT = "SELECT idLiga, nazev, zacatek, konec FROM Liga";

        private static string SQL_INSERT = "INSERT into Liga (nazev, zacatek, konec) VALUES (@nazev, @zacatek, @konec)";

        private static string SQL_UPDATE = "UPDATE Liga SET nazev=@nazev, zacatek=@zacatek, konec=@konec where idLiga=@idLiga";

        //9.1
        public static int Insert(Liga liga, Database pDb = null)
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
                PrepareCommand(command, liga);
                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //9.3
        public static Collection<Liga> Select(Database pDb = null)
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

                    Collection<Liga> rozhodci = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return rozhodci;
                }
            }
        }


        //9.2
        public static int Update(Liga liga, Database pDb = null)
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
                command.Parameters.AddWithValue("@idLiga", liga.IdLiga);
                PrepareCommand(command, liga);

                int status = db.ExecuteNonQuery(command);
                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        private static void PrepareCommand(SqlCommand command, Liga liga)
        {
            command.Parameters.AddWithValue("@nazev", liga.Nazev);
            command.Parameters.AddWithValue("@zacatek", liga.Zacatek);
            command.Parameters.AddWithValue("@konec", liga.Konec);
        }

        private static Collection<Liga> Read(SqlDataReader reader)
        {
            var ligy = new Collection<Liga>();

            while (reader.Read())
            {
                int i = -1;

                Liga liga = new Liga()
                {
                    IdLiga = reader.GetInt32(++i),
                    Nazev = reader.GetString(++i),
                };
                if (!reader.IsDBNull(++i))
                    liga.Zacatek = reader.GetDateTime(i);
                if (!reader.IsDBNull(++i))
                    liga.Konec = reader.GetDateTime(i);
                ligy.Add(liga);
            }
            return ligy;
        }
    }
}
