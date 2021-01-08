using ConnectionStringHandler;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.Adapters;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarDAL.Queries
{
    public class AccountLoginQueries : IAccountLoginQueries
    {
        private readonly MySqlConnection _connection;

        public AccountLoginQueries(IConnectionStringAdapter connectionAdapter)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionAdapter.GetConnectionString());
            this._connection = sqlConnection;
        }
        public ILogin Login(ILogin user)
        {

            _connection.Open();
            using (MySqlCommand query = new MySqlCommand("SELECT * FROM cars_account WHERE Email = @Email AND Password = SHA1(@Password);", _connection))
            {
                query.Parameters.AddWithValue("@Email", user.Email);
                query.Parameters.AddWithValue("@Password", user.Password);

                var reader = query.ExecuteReader();
                //controle of de user bestaat
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.UserId = reader.GetInt32(0);
                        user.Email = reader.GetString(1);
                    }
                }

            }
            _connection.Close();
            return user;

        }
    }
}
