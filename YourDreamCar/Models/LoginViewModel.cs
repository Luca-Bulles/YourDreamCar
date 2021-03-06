﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCar.Models
{
    public class LoginViewModel : ILogin
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Input a valid Emailaddress")]
        [Display(Name = "Emailaddress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Input a valid password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
