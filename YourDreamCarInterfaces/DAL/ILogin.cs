using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YourDreamCarInterfaces.DAL
{
    public interface ILogin
    {
        int UserId { get; set; }

        [Required(ErrorMessage = "Input a valid Emailaddress")]
        [Display(Name = "Emailaddress")]
        [DataType(DataType.EmailAddress)]
        string Email { get; set; }

        [Required(ErrorMessage = "Input a valid password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        string Password { get; set; }
    }
}
