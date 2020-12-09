using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.DAL;
using YourDreamCarInterfaces.Logic;

namespace YourDreamCarLogic.Account
{
    public class AccountRegisterLogic : IAccountRegisterLogic
    {
        private readonly IAccountRegisterQueries accountRegister;
        public AccountRegisterLogic(IAccountRegisterQueries _accountRegister)
        {
            accountRegister = _accountRegister;
        }
        public void CreateUser(IAccount account)
        {
            var _account = new Account
            {
                Id = account.Id,
                Name = account.Name,
                MiddleName = account.MiddleName,
                LastName = account.LastName,
                DateOfBirth = account.DateOfBirth,
                Email = account.Email,
                Adress = account.Adress,
                City = account.City,
                Username = account.Username,
                Password = account.Password,
                Role = account.Role
            };

            accountRegister.CreateUser(_account);
        }
    }
}
