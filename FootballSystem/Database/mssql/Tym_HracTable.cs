using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace FootballSystem.ORM.mssql
{
    public class Tym_HracTable
    {
        private static string SQL_SELECT = "SELECT idHrac, idTym, zacatek, konec FROM Tym_Hrac";

        private static string SQL_INSERT = "INSERT into Tym_Hrac (idTym, idHrac, getdate()) VALUES (@idTym, @idHrac, @zacatek)";

        //11.1
        public static int Insert(Tym_Hrac tym_hrac, Database pDb = null)
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
                PrepareCommand(command, tym_hrac);
                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //11.2
        public static int Update(string jmenoHrace, string staryTym, string novyTym, Database pDb = null)
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
            using (SqlCommand command = db.CreateCommand("Prestup"))
            {
                command.Parameters.AddWithValue("@p_hrac", jmenoHrace);
                command.Parameters.AddWithValue("@p_StaryTym", staryTym);
                command.Parameters.AddWithValue("@p_NovyTym", novyTym);

                int status = db.ExecuteNonQuery(command);
                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }


        public static Collection<Tym_Hrac> Select(Database pDb = null)
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

                    Collection<Tym_Hrac> hraciTymu = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return hraciTymu;
                }
            }
        }

        private static void PrepareCommand(SqlCommand command, Tym_Hrac tym_hrac)
        {
            command.Parameters.AddWithValue("@idTym", tym_hrac.IdTym);
            command.Parameters.AddWithValue("@idHrac", tym_hrac.IdHrac);
        }


        private static Collection<Tym_Hrac> Read(SqlDataReader reader)
        {
            var hraciTymu = new Collection<Tym_Hrac>();

            while (reader.Read())
            {
                int i = -1;

                Tym_Hrac ht = new Tym_Hrac()
                {
                    IdTym = reader.GetInt32(++i),
                    IdHrac = reader.GetInt32(++i),
                    Zacatek = reader.GetDateTime(++i),
                };

                if (!reader.IsDBNull(++i))
                    ht.Konec = reader.GetDateTime(i);
                hraciTymu.Add(ht);
            }
            return hraciTymu;
        }
    }
}
