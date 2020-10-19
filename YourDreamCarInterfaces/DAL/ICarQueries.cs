using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarInterfaces.Queries
{
    public interface ICarQueries
    {
        IEnumerable<ICarDTO> GetAllCars();
        ICar GetById(ICar car);
    }
}
