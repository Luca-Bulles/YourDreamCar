﻿using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarInterfaces.Logic
{
    public interface IAccountRegisterLogic
    {
        void CreateUser(IAccount account);
    }
}
