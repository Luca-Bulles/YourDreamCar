using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarDAL.Queries
{
    public class AccountRegisterQueries : IAccountRegisterQueries
    {
        public string ConnectionString { get; set; }

        public AccountRegisterQueries()
        {
            this.ConnectionString = "Server=studmysql01.fhict.local;Uid=dbi437981;Database=dbi437981;Pwd=Dierenasiel;";
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public void CreateUser(IAccount account)
        {
            string query = "INSERT INTO cars_account VALUES (@Id, @Name, @MiddleName, @LastName, @DateOfBirth, @Email, @Adress, @City, @Username, SHA1(@Password), @Role); ";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
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
                conn.Close();
            }
        }
    }
}
