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
        void CreateCar(ICar car);
        void EditCar(ICar car);
        void DeleteCar(int id);
    }
}
