using ConnectionStringHandler;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarDAL.Queries
{
    public class AccountLoginQueries : IAccountLoginQueries
    {
        private readonly ConnectionString _connection;

        public AccountLoginQueries(ConnectionString connection)
        {
            this._connection = connection;
        }
        public bool Login(ILogin user)
        {
            bool login = false;

            _connection.SqlConnection.Open();
            using (MySqlCommand query = new MySqlCommand("SELECT * FROM cars_account WHERE Email = @Email AND Password = SHA1(@Password);", _connection.SqlConnection))
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
                    login = true;
                }

            }
            _connection.SqlConnection.Close();
            return login;

        }
    }
}
