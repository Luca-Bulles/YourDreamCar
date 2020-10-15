using System;
using System.Collections.Generic;
using System.Text;

namespace YourDreamCarInterfaces.Queries
{
    public interface ICarQueries
    {
        IEnumerable<ICar> GetAllCars();
    }
}
