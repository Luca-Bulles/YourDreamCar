using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarDAL.DTO;
using MySql.Data.MySqlClient;
using YourDreamCarInterfaces;

namespace YourDreamCarDAL.Queries
{
    public class CarQueries
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
        public IEnumerable<ICar> GetAllCars()
        {
            string query = "Select * FROM cars_cars;";
            List<ICar> cars = new List<ICar>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cars.Add(new CarDTO()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Model = reader.GetString(2),
                        HorsePower = reader.GetInt32(3),
                        Price = reader.GetFloat(4),
                        Year = reader.GetInt32(5),
                        Description = reader.GetString(6),
                        ImageSrc = reader.GetString(7)

                    });
                    
                }
            }
            return cars;
        }
    }
}
