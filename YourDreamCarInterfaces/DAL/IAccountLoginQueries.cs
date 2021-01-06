using System;
using System.Collections.Generic;
using System.Text;

namespace YourDreamCarInterfaces.DAL
{
    public interface IAccountLoginQueries
    {
        ILogin Login(ILogin user);
    }
}
