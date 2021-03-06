﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using YourDreamCar.Adapters;
using YourDreamCar.Models;
using YourDreamCarFactory;
using YourDreamCarInterfaces.Adapters;
using YourDreamCarInterfaces.Logic;

namespace YourDreamCar.Controllers
{

    public class CarController : Controller
    {
        private readonly ICarLogic _carLogic;
        public CarController(IConnectionStringAdapter adapter) // en dus hier injecteren
        {
            // Wat je hier zou kunnen doen is je connectionstring adapter gebruiken voor het dorsturen van de connectionstring naar de factory :D
            _carLogic = CarFactory.GetCarLogic(adapter);
        }
        public IActionResult Admin()
        {
            var allCars = _carLogic.GetAllCars();
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
            _carLogic.GetById(carViewModel);

            return View(carViewModel);
            
        }
        [HttpPost]
        public ActionResult Edit(CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                _carLogic.EditCar(car);

                return RedirectToAction("Admin");
            }

            return View();
            
        }
        public ActionResult Delete(int id)
        {
            _carLogic.DeleteCar(id);

            return RedirectToAction("Admin");
        }
        [HttpGet]
        public ActionResult Create()
        {
            var car = new CarViewModel();

            return View(car);
        }
        [HttpPost]
        public ActionResult Create(CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                _carLogic.CreateCar(car);

                return RedirectToAction("Admin");
            }
            return View();

        }
        public IActionResult AvailableCars()
        {

            var allCars = _carLogic.GetAllCars();
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
        public IActionResult UnderConstruction()
        {
            return View();
        }
    }
}
