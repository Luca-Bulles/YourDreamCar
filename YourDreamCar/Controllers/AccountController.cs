using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourDreamCarInterfaces.Logic;

namespace YourDreamCar.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRegisterLogic accountRegisterLogic;
        public AccountController(IAccountRegisterLogic _accountRegisterLogic)
        {
            accountRegisterLogic = _accountRegisterLogic;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
