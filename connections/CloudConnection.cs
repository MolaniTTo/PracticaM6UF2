using System;
using Npgsql;

namespace PracticaM6UF2.connections
{
    public class CloudConnection
    {
        private String HOST = "salt.db.elephantsql.com:5432"; // Ubicació de la BD.
        private String DB = "dojhyjni"; // Nom de la BD.
        private String USER = "dojhyjni";
        private String PASSWORD = "TjLqhmBHaysviUzvrowkfLbICvX2RX09";

        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(
                "Host=" + HOST + ";" + "Username=" + USER + ";" +
                "Password=" + PASSWORD + ";" + "Database=" + DB + ";"
            );
            conn.Open();
            return conn;
        }
    }
}