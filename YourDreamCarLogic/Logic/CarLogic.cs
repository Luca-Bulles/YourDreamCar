﻿using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces;
using YourDreamCarInterfaces.Logic;

namespace YourDreamCarLogic.Logic
{
    class CarLogic: ICarLogic
    {
        public IEnumerable<ICar> GetAllAnimals()
        {
            return CarQueries.GetAllCars();
        }

        public IEnumerable<ICar> GetAllCars()
        {
            throw new NotImplementedException();
        }
    }
}
