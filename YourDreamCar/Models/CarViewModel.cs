using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YourDreamCarInterfaces;

namespace YourDreamCar.Models
{
    public class CarViewModel: ICar
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Input the brand name of the car")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Input the model name of the car")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Input the amount of horsepower of the car")]
        [Range(200, 4000,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int HorsePower { get; set; }

        [Required(ErrorMessage = "Input the price in euro's of the car")]
        [Range(1, 99999999,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Input the build year of the car")]
        [Range(1900, 2021,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Input the description of the car")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Input the image name of the car")]
        public string ImageSrc { get; set; }
    }
}
