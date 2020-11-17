using System;
using System.Collections.Generic;
using System.Text;

namespace YourDreamCarInterfaces.DAL
{
    public interface IAccount
    {
        int Id { get; set; }
        string Name { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        string Email { get; set; }
        string Adress { get; set; }
        string City { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Role { get; set; }
    }
}
