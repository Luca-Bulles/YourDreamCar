using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace YourDreamCarDAL.Queries
{
    class CarQueries
    {
        public string ConnectionString { get; set; }

        public CarQueries()
        {
            this.ConnectionString = "Server=studmysql01.fhict.local;Uid=dbi437981;Database=dbi437981;Pwd=Dierenasiel;";
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        //READ in CRUD
        public void GetAllCars()
        {
            string query = "Select * FROM cars_cars;";
            //<ICars> cars = new List<ICars>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                }
            }
        }
    }
}
