using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarDAL.DTO;
using MySql.Data.MySqlClient;
using YourDreamCarInterfaces;
using YourDreamCarInterfaces.Queries;
using YourDreamCarInterfaces.DAL;
using ConnectionStringHandler;
using YourDreamCarInterfaces.Adapters;

namespace YourDreamCarDAL.Queries
{
    public class CarQueries : ICarQueries
    {
        private readonly MySqlConnection _connection;

        public CarQueries(IConnectionStringAdapter connectionAdapter)//geef connectionadpater mee constructor
        {
            _connection = new MySqlConnection(connectionAdapter.GetConnectionString());
        }
        //READ in CRUD
        IEnumerable<ICarDTO> ICarQueries.GetAllCars()
        {
            _connection.Open();
            string query = "Select * FROM cars_cars;";
            List<ICarDTO> cars = new List<ICarDTO>();

            MySqlCommand cmd = new MySqlCommand(query, _connection);

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
            _connection.Close();
            return cars;
        }


        //Create in CRUD
        public void CreateCar(ICar car)
        {
            _connection.Open();
            string query = "INSERT INTO cars_cars VALUES (@Id, @Name, @Model, @HorsePower, @Price, @Year, @Description, @ImageSrc); ";

            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@Id", car.Id);
            cmd.Parameters.AddWithValue("@Name", car.Name);
            cmd.Parameters.AddWithValue("@Model", car.Model);
            cmd.Parameters.AddWithValue("@HorsePower", car.HorsePower);
            cmd.Parameters.AddWithValue("@Price", car.Price);
            cmd.Parameters.AddWithValue("@Year", car.Year);
            cmd.Parameters.AddWithValue("@Description", car.Description);
            cmd.Parameters.AddWithValue("@ImageSrc", car.ImageSrc);

            cmd.ExecuteNonQuery();
            _connection.Close();

        }
        //Update in CRUD
        public void EditCar(ICar car)
        {
            string query = "UPDATE cars_cars SET Name = @Name, Model = @Model, HorsePower = @HorsePower, Price = @Price, Year = @Year, Description = @Description, ImageSrc = @ImageSrc WHERE id = @id;";

            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@Id", car.Id);
            cmd.Parameters.AddWithValue("@Name", car.Name);
            cmd.Parameters.AddWithValue("@Model", car.Model);
            cmd.Parameters.AddWithValue("@HorsePower", car.HorsePower);
            cmd.Parameters.AddWithValue("@Price", car.Price);
            cmd.Parameters.AddWithValue("@Year", car.Year);
            cmd.Parameters.AddWithValue("@Description", car.Description);
            cmd.Parameters.AddWithValue("@ImageSrc", car.ImageSrc);

            cmd.ExecuteNonQuery();
            _connection.Close();


        }
        //Delete in CRUD
        public void DeleteCar(int id)
        {
            _connection.Open();
            string query = "DELETE FROM cars_cars WHERE Id = @Id;";

            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            _connection.Close();

        }
        public ICar GetById(ICar car)
        {
            _connection.Open();
            string query = "SELECT * FROM cars_cars WHERE Id = @Id; ";

            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@Id", car.Id);
            cmd.Parameters.AddWithValue("@Name", car.Name);
            cmd.Parameters.AddWithValue("@Model", car.Model);
            cmd.Parameters.AddWithValue("@Horsepower", car.HorsePower);
            cmd.Parameters.AddWithValue("@Price", car.Price);
            cmd.Parameters.AddWithValue("@Year", car.Year);
            cmd.Parameters.AddWithValue("@Description", car.Description);
            cmd.Parameters.AddWithValue("@ImageSrc", car.ImageSrc);

            return car;
        }
    }
}
