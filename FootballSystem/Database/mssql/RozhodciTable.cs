using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace FootballSystem.ORM.mssql
{
    public class RozhodciTable
    {
        private static string SQL_SELECT = "SELECT idRozhodci, jmeno, datum_narozeni FROM Rozhodci";
        private static string SQL_SELECT2= "SELECT r.idRozhodci, r.jmeno, z.idzapas FROM Rozhodci r join zapas z on z.idrozhodci=r.idrozhodci order by idrozhodci";

        private static string SQL_INSERT = "INSERT into Rozhodci (jmeno, datum_narozeni) VALUES (@jmeno, @datum_narozeni)";

        private static string SQL_UPDATE = "UPDATE Rozhodci SET jmeno=@jmeno, datum_narozeni=@datum_narozeni where idRozhodci=@idRozhodci";

        private static string SQL_DELETE = "DELETE FROM Rozhodci WHERE idRozhodci=@idRozhodci";

        // 1 ku N
        public static List<Rozhodci> Select2(Database pDb = null)
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
                using (SqlDataReader reader = db.Select(command))
                {

                    var rozhodci = new List<Rozhodci>();

                    while (reader.Read())
                    {
                        int i = -1;

                        var RozhodciID = reader.GetInt32(++i);
                        var rozhodciJmeno = reader.GetString(++i);
                        var ZapasId = reader.GetInt32(++i);

                        var rozhod = rozhodci.FirstOrDefault(p => p.IdRozhodci == RozhodciID);
                        if (rozhod == null)
                        {
                            rozhod = new Rozhodci();
                            rozhod.IdRozhodci = RozhodciID;
                            rozhod.Jmeno = rozhodciJmeno;

                            Zapas zapas = new Zapas()
                            {
                                IdZapas = ZapasId
                            };
                            rozhod.Zapasy = new List<Zapas>();

                            rozhod.Zapasy.Add(zapas);

                            rozhodci.Add(rozhod);
                        }
                        else
                        {
                            Zapas zapas = new Zapas()
                            {
                                IdZapas = ZapasId
                            };

                            if (!rozhod.Zapasy.Contains(zapas))
                                rozhod.Zapasy.Add(zapas);
                        }
                    }

                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return rozhodci;
                }
            }
        }


        //4.1
        public static int Insert(Rozhodci rozhodci, Database pDb = null)
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
                PrepareCommand(command, rozhodci);
                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //4.4
        public static Collection<Rozhodci> Select(Database pDb = null)
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

                    Collection<Rozhodci> rozhodci = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return rozhodci;
                }
            }
        }

        //4.2
        public static int Update(Rozhodci rozhodci, Database pDb = null)
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
                command.Parameters.AddWithValue("@idRozhodci", rozhodci.IdRozhodci);

                PrepareCommand(command, rozhodci);

                int status = db.ExecuteNonQuery(command);
                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //4.3
        public static int Delete(Rozhodci rozhodci, Database pDb = null)
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
                command.Parameters.AddWithValue("@idRozhodci", rozhodci.IdRozhodci);

                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }
                return status;
            }
        }

        //4.5
        public static int ListOfMatches(int mesic, Database pDb = null)
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
            using (SqlCommand command = db.CreateCommand("rozpis"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_mesic", mesic);

                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }
                return status;
            }
        }

        private static void PrepareCommand(SqlCommand command, Rozhodci rozhodci)
        {
            command.Parameters.AddWithValue("@jmeno", rozhodci.Jmeno);
            command.Parameters.AddWithValue("@datum_narozeni", rozhodci.Datum_narozeni);
        }

        private static Collection<Rozhodci> Read(SqlDataReader reader)
        {
            Collection<Rozhodci> rozhodci = new Collection<Rozhodci>();

            while (reader.Read())
            {
                int i = -1;

                Rozhodci roz = new Rozhodci()
                {
                    IdRozhodci = reader.GetInt32(++i),
                    Jmeno = reader.GetString(++i),
                };
                if (!reader.IsDBNull(++i))
                    roz.Datum_narozeni = reader.GetDateTime(i);
                rozhodci.Add(roz);
            }
            return rozhodci;
        }
    }
}
