using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarDAL.DTO;
using MySql.Data.MySqlClient;
using YourDreamCarInterfaces;
using YourDreamCarInterfaces.Queries;
using YourDreamCarInterfaces.DAL;
using ConnectionStringHandler;

namespace YourDreamCarDAL.Queries
{
    public class CarQueries : ICarQueries
    {
        private readonly ConnectionString _connection;

        public CarQueries(ConnectionString connection)
        {
            this._connection = connection;
        }
        //READ in CRUD
        IEnumerable<ICarDTO> ICarQueries.GetAllCars()
        {
            _connection.SqlConnection.Open();
            string query = "Select * FROM cars_cars;";
            List<ICarDTO> cars = new List<ICarDTO>();

            MySqlCommand cmd = new MySqlCommand(query, _connection.SqlConnection);

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
            _connection.SqlConnection.Close();
            return cars;
        }


        //Create in CRUD
        public void CreateCar(ICar car)
        {
            _connection.SqlConnection.Open();
            string query = "INSERT INTO cars_cars VALUES (@Id, @Name, @Model, @HorsePower, @Price, @Year, @Description, @ImageSrc); ";

            MySqlCommand cmd = new MySqlCommand(query, _connection.SqlConnection);
            cmd.Parameters.AddWithValue("@Id", car.Id);
            cmd.Parameters.AddWithValue("@Name", car.Name);
            cmd.Parameters.AddWithValue("@Model", car.Model);
            cmd.Parameters.AddWithValue("@HorsePower", car.HorsePower);
            cmd.Parameters.AddWithValue("@Price", car.Price);
            cmd.Parameters.AddWithValue("@Year", car.Year);
            cmd.Parameters.AddWithValue("@Description", car.Description);
            cmd.Parameters.AddWithValue("@ImageSrc", car.ImageSrc);

            cmd.ExecuteNonQuery();
            _connection.SqlConnection.Close();

        }
        //Update in CRUD
        public void EditCar(ICar car)
        {
            string query = "UPDATE cars_cars SET Name = @Name, Model = @Model, HorsePower = @HorsePower, Price = @Price, Year = @Year, Description = @Description, ImageSrc = @ImageSrc WHERE id = @id;";

            MySqlCommand cmd = new MySqlCommand(query, _connection.SqlConnection);
            cmd.Parameters.AddWithValue("@Id", car.Id);
            cmd.Parameters.AddWithValue("@Name", car.Name);
            cmd.Parameters.AddWithValue("@Model", car.Model);
            cmd.Parameters.AddWithValue("@HorsePower", car.HorsePower);
            cmd.Parameters.AddWithValue("@Price", car.Price);
            cmd.Parameters.AddWithValue("@Year", car.Year);
            cmd.Parameters.AddWithValue("@Description", car.Description);
            cmd.Parameters.AddWithValue("@ImageSrc", car.ImageSrc);

            cmd.ExecuteNonQuery();
            _connection.SqlConnection.Close();


        }
        //Delete in CRUD
        public void DeleteCar(int id)
        {
            _connection.SqlConnection.Open();
            string query = "DELETE FROM cars_cars WHERE Id = @Id;";

            MySqlCommand cmd = new MySqlCommand(query, _connection.SqlConnection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            _connection.SqlConnection.Close();

        }
        public ICar GetById(ICar car)
        {
            _connection.SqlConnection.Open();
            string query = "SELECT * FROM cars_cars WHERE Id = @Id; ";

            MySqlCommand cmd = new MySqlCommand(query, _connection.SqlConnection);
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
