using System;
using System.Collections.Generic;
using System.Text;

namespace YourDreamCarInterfaces.Logic
{
    public interface ICarLogic
    {
        IEnumerable<ICar> GetAllCars();
    }
}
