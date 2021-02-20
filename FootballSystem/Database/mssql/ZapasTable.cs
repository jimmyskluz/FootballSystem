using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace FootballSystem.ORM.mssql
{
    public class ZapasTable
    {
        private static string SQL_SELECT = "SELECT top(4)idZapas, idLiga, konani, idHriste, idRozhodci, idDomaci, idHoste, skore_domaci, skore_hoste FROM Zapas where skore_domaci is not null and skore_hoste is not null order by konani desc";
        private static string SQL_SELECT2 = "SELECT idZapas, idLiga, konani  FROM Zapas where idDomaci=@v_idDomaci and idHoste=@v_idHoste";

        private static string SQL_INSERT = "INSERT into Zapas (idLiga, konani, idHriste, idRozhodci, idDomaci, idHoste) VALUES (@idLiga, @konani, @idHriste, @idRozhodci, @idDomaci, @idHoste)";

        private static string SQL_DELETE = "DELETE FROM Zapas WHERE idZapas=@idZapas";

        private static string SQL_UPDATE = "UPDATE Zapas SET konani=@konani, idHriste=@idHriste, idRozhodci=@idRozhodci, skore_domaci=@skore_domaci, skore_hoste=@skore_hoste where idZapas=@idZapas";

        //1.1
        public static int Insert(Zapas zapas, Database pDb = null)
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
                PrepareCommand(command, zapas);
                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //1.5
        public static Collection<Zapas> Select(Database pDb = null)
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
                    Collection<Zapas> zapasy = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return zapasy;
                }
            }
        }

        //1.2
        public static int Update(Zapas zapas, Database pDb = null)
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
                command.Parameters.AddWithValue("@idHrac", zapas.IdZapas);
                PrepareCommand(command, zapas);

                int status = db.ExecuteNonQuery(command);
                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //1.3
        public static int Delete(int idZapas, Database pDb = null)
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
                command.Parameters.AddWithValue("@idZapas", idZapas);

                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }
                return status;
            }
        }


        private static void PrepareCommand(SqlCommand command, Zapas zapas)
        {
            command.Parameters.AddWithValue("@idLiga", zapas.IdLiga);
            command.Parameters.AddWithValue("@konani", zapas.Konani);
            command.Parameters.AddWithValue("@idHriste", zapas.IdHriste);
            command.Parameters.AddWithValue("@idRozhodci", zapas.IdRozhodci);
            command.Parameters.AddWithValue("@idDomaci", zapas.IdDomaci);
            command.Parameters.AddWithValue("@idHoste", zapas.IdHoste);
        }

        private static Collection<Zapas> Read(SqlDataReader reader)
        {
            var zapasy = new Collection<Zapas>();

            while (reader.Read())
            {
                int i = -1;

                Zapas zapas = new Zapas()
                {
                    IdZapas = reader.GetInt32(++i),
                    IdLiga = reader.GetInt32(++i),
                    Konani = reader.GetDateTime(++i),
                    IdHriste = reader.GetInt32(++i),
                    IdRozhodci = reader.GetInt32(++i),
                    IdDomaci = reader.GetInt32(++i),
                    IdHoste = reader.GetInt32(++i),
                };
                if (!reader.IsDBNull(++i))
                    zapas.Skore_domaci= reader.GetInt32(i);
                if (!reader.IsDBNull(++i))
                    zapas.Skore_hoste= reader.GetInt32(i);

                zapasy.Add(zapas);
            }
            return zapasy;
        }

        public static Zapas Select2(int idDomaci, int idHoste, Database pDb = null)
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
            using (SqlCommand command = db.CreateCommand(SQL_SELECT2))
            {
                command.Parameters.AddWithValue("@v_idDomaci", idDomaci);
                command.Parameters.AddWithValue("@v_idHoste", idHoste);
                using (SqlDataReader reader = db.Select(command))
                {
                    Zapas zapas = new Zapas();
                    if (reader.Read())
                    {
                        zapas.IdZapas = reader.GetInt32(0);
                        zapas.IdLiga = reader.GetInt32(1);
                        zapas.Konani = reader.GetDateTime(2);
                    }
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return zapas;
                }
            }
        }
    }
}
