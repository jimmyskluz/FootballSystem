using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace FootballSystem.ORM.mssql
{
    public class Hrac_HralTable
    {
        private static string SQL_SELECT = "SELECT idZapas, idHrac FROM Hrac_Hral";

        private static string SQL_INSERT = "INSERT into Hrac_Hral (idZapas, idHrac) VALUES (@v_idZapas, @v_idHrac)";

        private static string SQL_UPDATE = "UPDATE Hrac_Hral SET idZapas=@idZapas, idHrac=@idHrac";

        //8.1
        public static int Insert(int idZapas, int idHrac, Database pDb = null)
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
                command.Parameters.AddWithValue("@v_idZapas", idZapas);
                command.Parameters.AddWithValue("@v_idHrac", idHrac);

                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //8.3
        public static Collection<Hrac_Hral> Select(Database pDb = null)
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

                    Collection<Hrac_Hral> hraciTymu = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return hraciTymu;
                }
            }
        }

        //8.2
        public static int Update(Hrac_Hral hrac_hral, Database pDb = null)
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
                PrepareCommand(command, hrac_hral);

                int status = db.ExecuteNonQuery(command);
                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        private static void PrepareCommand(SqlCommand command, Hrac_Hral hrac_hral)
        {
            command.Parameters.AddWithValue("@idHrac", hrac_hral.IdHrac);
            command.Parameters.AddWithValue("@idZapas", hrac_hral.IdZapas);
        }

        private static Collection<Hrac_Hral> Read(SqlDataReader reader)
        {
            var sestava = new Collection<Hrac_Hral>();

            while (reader.Read())
            {
                int i = -1;

                Hrac_Hral hrac = new Hrac_Hral
                {
                    IdZapas = reader.GetInt32(++i),
                    IdHrac = reader.GetInt32(++i)
                };

                sestava.Add(hrac);
            }
            return sestava;
        }
    }
}
