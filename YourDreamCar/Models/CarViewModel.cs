﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourDreamCar.Models
{
    public class CarViewModel: YourDreamCarInterfaces.DAL.ICarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public float Price { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImageSrc { get; set; }
    }
}