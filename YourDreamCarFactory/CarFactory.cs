using System;
using YourDreamCarDAL.Queries;
using YourDreamCarInterfaces.Queries;
using YourDreamCarLogic.Logic;

namespace YourDreamCarFactory
{
    public static class CarFactory
    {
        public static ICarQueries _carQueries = new CarQueries();
        public static CarLogic GetCarLogic()
        {
            return new CarLogic(_carQueries);
        }
    }
}
