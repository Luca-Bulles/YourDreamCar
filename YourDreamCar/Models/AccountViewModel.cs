using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCar.Models
{
    public class AccountViewModel : IAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
