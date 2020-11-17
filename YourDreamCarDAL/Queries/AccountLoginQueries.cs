using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarDAL.Queries
{
    public class AccountLoginQueries : IAccountLoginQueries
    {
        public string ConnectionString { get; set; }

        public AccountLoginQueries()
        {
            this.ConnectionString = "Server=studmysql01.fhict.local;Uid=dbi437981;Database=dbi437981;Pwd=Dierenasiel;";
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public bool Login(ILogin user)
        {
            bool login = false;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand query = new MySqlCommand("SELECT * FROM cars_account WHERE Email = @Email AND Password = SHA1(@Password);", conn))
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
                conn.Close();
            }
            return login;
            
        }
    }
}
