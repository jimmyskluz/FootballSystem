using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;

namespace FootballSystem.ORM.mssql
{
    public class UcastnikTable
    {
        private static string SQL_SELECT = "select t.jmeno, (select count(*) from zapas where skore_domaci is not null and iddomaci=t.idtym) +" +
            "(select count(*) from zapas where skore_hoste is not null and idhoste = t.idtym) as pocet," +
            "(select count(*) from zapas where skore_domaci > skore_hoste and iddomaci = t.idtym) +" +
            "(select count(*) from zapas where skore_domaci<skore_hoste and idhoste=t.idtym) as vyhra," +
            "(select count(*) from zapas where skore_domaci = skore_hoste and iddomaci=t.idtym) +" +
            "(select count(*) from zapas where skore_domaci = skore_hoste and idhoste=t.idtym) as remiza," +
            "(select count(*) from zapas where skore_domaci<skore_hoste and iddomaci=t.idtym) +" +
            "(select count(*) from zapas where skore_domaci > skore_hoste and idhoste=t.idtym) as prohra," +
            "u.body from tym t join ucastnik u on u.idtym=t.idtym join liga l on l.idliga=u.idliga " +
            "where l.idliga=@v_idLiga order by u.body desc";

        private static string SQL_INSERT = "INSERT into Ucastnik (idLiga, idTym) VALUES (@idLiga, @idTym)";

        //10.1
        public static int Insert(Ucastnik ucastnik, Database pDb = null)
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
                PrepareCommand(command, ucastnik);
                int status = db.ExecuteNonQuery(command);

                if (pDb == null)
                {
                    db.Close();
                }

                return status;
            }
        }

        //10.2
        public static Collection<Ucastnik> Select(int idLiga, Database pDb = null)
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
                command.Parameters.AddWithValue("@v_idLiga", idLiga);

                using (SqlDataReader reader = db.Select(command))
                {
                    Collection<Ucastnik> ucastnici = Read(reader);
                    reader.Close();

                    if (pDb == null)
                    {
                        db.Close();
                    }

                    return ucastnici;
                }
            }
        }

        //10.3
        public static int Update(int idZapas, Database pDb = null)
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

            SqlCommand command = db.CreateCommand("PridejBody");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@p_idzapas", idZapas);

            int status = db.ExecuteNonQuery(command);
            if (pDb == null)
            {
                db.Close();
            }

            return status;
        }

        private static void PrepareCommand(SqlCommand command, Ucastnik ucastnik)
        {
            command.Parameters.AddWithValue("@idLiga", ucastnik.IdLiga);
            command.Parameters.AddWithValue("@idTym", ucastnik.IdTym);
        }

        private static Collection<Ucastnik> Read(SqlDataReader reader)
        {
            var ucastnici = new Collection<Ucastnik>();

            while (reader.Read())
            {
                int i = -1;

                Ucastnik ucastik = new Ucastnik();
                ucastik.Tym = new Tym();
                ucastik.Tym.Jmeno = reader.GetString(++i);
                ucastik.PocetZapasu = reader.GetInt32(++i);
                ucastik.Vyhry = reader.GetInt32(++i);
                ucastik.Remizy = reader.GetInt32(++i);
                ucastik.Prohry = reader.GetInt32(++i);
                ucastik.Body = reader.GetInt32(++i);

                ucastnici.Add(ucastik);
            }
            return ucastnici;
        }
    }
}
