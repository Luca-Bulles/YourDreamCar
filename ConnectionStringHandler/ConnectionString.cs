using MySql.Data.MySqlClient;
using System;

namespace ConnectionStringHandler
{
    public class ConnectionString
    {
        public ConnectionString(string connectionString)
        {
            SqlConnection = new MySqlConnection(connectionString);
        }

        public MySqlConnection SqlConnection { get; set; }
    }
}
