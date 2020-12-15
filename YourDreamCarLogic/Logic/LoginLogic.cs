using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.DAL;
using YourDreamCarInterfaces.Logic;

namespace YourDreamCarLogic.Logic
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IAccountLoginQueries loginQueries;
        public LoginLogic(IAccountLoginQueries _loginQueries)
        {
            loginQueries = _loginQueries;
        }
        public bool Login(ILogin user)
        {
            //Hier bepalen of de user is ingelogd ipv in dal
            return loginQueries.Login(user);
        }
    }
}
