using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourDreamCar.Models;
using YourDreamCarInterfaces.Logic;

namespace YourDreamCar.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginLogic loginLogic;
        public LoginController(ILoginLogic _loginLogic)
        {
            loginLogic = _loginLogic;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            bool login = loginLogic.Login(loginViewModel);
            if (login)
            {
                HttpContext.Session.SetString("Email", loginViewModel.Email);
                HttpContext.Session.SetInt32("UserId", loginViewModel.UserId);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            try
            {
                //is de gebruiker ingelogd
                if (HttpContext.Session.GetInt32("UserId") != null)
                {
                    //log uit
                    HttpContext.Session.Clear();
                }
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return View();
            }
        }
    }
}
