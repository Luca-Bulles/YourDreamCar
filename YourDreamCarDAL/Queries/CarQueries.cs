using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarDAL.DTO;
using MySql.Data.MySqlClient;
using YourDreamCarInterfaces;
using YourDreamCarInterfaces.Queries;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarDAL.Queries
{
    public class CarQueries: ICarQueries
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
        public IEnumerable<ICarDTO> GetAllCars()
        {
            string query = "Select * FROM cars_cars;";
            List<ICarDTO> cars = new List<ICarDTO>();

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

        IEnumerable<ICar> ICarQueries.GetAllCars()
        {
            throw new NotImplementedException();
        }

        public ICar GetById(ICar car)
        {
            string query = "SELECT * FROM cars_cars WHERE Id = @Id; ";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", car.Id);
                cmd.Parameters.AddWithValue("@Name", car.Name);
                cmd.Parameters.AddWithValue("@Model", car.Model);
                cmd.Parameters.AddWithValue("@Horsepower", car.HorsePower);
                cmd.Parameters.AddWithValue("@Price", car.Price);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@Description", car.Description);
                cmd.Parameters.AddWithValue("@ImageSrc", car.ImageSrc);
            }
            return car;
        }
    }
}
