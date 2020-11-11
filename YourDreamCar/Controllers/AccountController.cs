using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourDreamCar.Models;
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
        [HttpGet]
        public ActionResult CreateUser()
        {
            var accountViewModel = new AccountViewModel();
            return View(accountViewModel);
        }
        [HttpPost]
        public ActionResult CreateUser(AccountViewModel account)
        {
            accountRegisterLogic.CreateUser(account);
            return View();
        }
    }
}
