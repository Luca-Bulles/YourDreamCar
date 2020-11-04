using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YourDreamCar.Models;
using YourDreamCarInterfaces.Logic;

namespace YourDreamCar.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarLogic carLogic;
        public CarController(ICarLogic _carLogic)
        {
            this.carLogic = _carLogic;
        }
        public IActionResult Admin()
        {
            var allCars = carLogic.GetAllCars();
            var cars = new List<CarViewModel>();
            foreach (var car in allCars)
            {
                cars.Add(new CarViewModel
                {
                    Id = car.Id,
                    Name = car.Name,
                    Model = car.Model,
                    HorsePower = car.HorsePower,
                    Price = car.Price,
                    Year = car.Year,
                    Description = car.Description,
                    ImageSrc = car.ImageSrc
                }
                );
            }
            return View(cars);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            CarViewModel carViewModel = new CarViewModel();
            carLogic.GetById(carViewModel);

            return View(carViewModel);
            
        }
        [HttpPost]
        public ActionResult Create(CarViewModel car)
        {
            carlogic.CreateCar(car);

            return RedirectToAction("Admin");
        }
    }
}
