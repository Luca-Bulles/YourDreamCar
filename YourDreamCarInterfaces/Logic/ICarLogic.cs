using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces.DAL;

namespace YourDreamCarInterfaces.Logic
{
    public interface ICarLogic
    {
        IEnumerable<ICarDTO> GetAllCars();
        ICar GetById(ICar car);
        void CreateCar(ICar car);
        ICar EditCar(ICar car);
        void DeleteCar(int id);
    }
}
