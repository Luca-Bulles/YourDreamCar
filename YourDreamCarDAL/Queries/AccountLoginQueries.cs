using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace YourDreamCarDAL.Queries
{
    public class AccountLoginQueries
    {
        public string ConnectionString { get; set; }

        public AccountLoginQueries()
        {
            this.ConnectionString = "Server=studmysql01.fhict.local;Uid=dbi437981;Database=dbi437981;Pwd=Dierenasiel;";
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
