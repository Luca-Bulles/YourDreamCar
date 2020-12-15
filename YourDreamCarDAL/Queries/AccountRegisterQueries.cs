using ConnectionStringHandler;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.Adapters;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarDAL.Queries
{
    public class AccountRegisterQueries : IAccountRegisterQueries
    {
        private readonly MySqlConnection _connection;

        public AccountRegisterQueries(IConnectionStringAdapter connectionAdapter)
        {
            MySqlConnection sqlConnection = new MySqlConnection(connectionAdapter.GetConnectionString());
            this._connection = sqlConnection;
        }
        public void CreateUser(IAccount account)
        {
            string query = "INSERT INTO cars_account VALUES (@Id, @Name, @MiddleName, @LastName, @DateOfBirth, @Email, @Adress, @City, @Username, SHA1(@Password), @Role); ";
            _connection.Open();

            MySqlCommand cmd = new MySqlCommand(query, _connection);
            cmd.Parameters.AddWithValue("@Id", account.Id);
            cmd.Parameters.AddWithValue("@Name", account.Name);
            cmd.Parameters.AddWithValue("@MiddleName", account.MiddleName);
            cmd.Parameters.AddWithValue("@LastName", account.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", account.DateOfBirth);
            cmd.Parameters.AddWithValue("@Email", account.Email);
            cmd.Parameters.AddWithValue("@Adress", account.Adress);
            cmd.Parameters.AddWithValue("@City", account.City);
            cmd.Parameters.AddWithValue("@Username", account.Username);
            cmd.Parameters.AddWithValue("@Password", account.Password);
            cmd.Parameters.AddWithValue("@Role", account.Role);

            cmd.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
