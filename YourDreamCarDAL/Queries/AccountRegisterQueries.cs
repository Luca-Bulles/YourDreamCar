using ConnectionStringHandler;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarDAL.Queries
{
    public class AccountRegisterQueries : IAccountRegisterQueries
    {
        private readonly ConnectionString _connection;

        public AccountRegisterQueries(ConnectionString connection)
        {
            this._connection = connection;
        }
        public void CreateUser(IAccount account)
        {
            string query = "INSERT INTO cars_account VALUES (@Id, @Name, @MiddleName, @LastName, @DateOfBirth, @Email, @Adress, @City, @Username, SHA1(@Password), @Role); ";
            _connection.SqlConnection.Open();

            MySqlCommand cmd = new MySqlCommand(query, _connection.SqlConnection);
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
            _connection.SqlConnection.Close();
        }
    }
}
