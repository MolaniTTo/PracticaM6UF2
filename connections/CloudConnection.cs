using System;
using Npgsql;

namespace cat.itb.M6UF2EA3.connections
{
    public class CloudConnection
    {
        private String HOST = "salt.db.elephantsql.com:5432"; // Ubicació de la BD.
        private String DB = "qjycudrm"; // Nom de la BD.
        private String USER = "qjycudrm";
        private String PASSWORD = "QJsJC7hDPRbUmFy0eFq0ksmWZdlV5BjB";

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