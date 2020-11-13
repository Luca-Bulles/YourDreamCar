using System;
using System.Collections.Generic;
using System.Text;

namespace YourDreamCarInterfaces.DAL
{
    public interface IAccountLoginQueries
    {
        bool Login(ILogin user);
    }
}
