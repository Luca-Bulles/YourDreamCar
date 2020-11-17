using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCar.Models
{
    public class AccountViewModel : IAccount
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Input your name")]
        public string Name { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Input your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Input your date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Input your Email adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Input your adress")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Input your City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Create a new username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Create a password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Value for {0} must be between {2} and {1} characters ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Choose between 'Gebruiker' and 'Medewerker'")]
        public string Role { get; set; }

    }
}
