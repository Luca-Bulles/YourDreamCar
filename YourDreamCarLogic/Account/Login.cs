using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarLogic.Account
{
    public class Login : ILogin
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
