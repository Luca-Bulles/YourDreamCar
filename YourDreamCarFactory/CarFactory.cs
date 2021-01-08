using MySql.Data.MySqlClient;
using System;
using YourDreamCarDAL.Queries;
using YourDreamCarInterfaces.Adapters;
using YourDreamCarInterfaces.Queries;
using YourDreamCarLogic.Logic;


namespace YourDreamCarFactory
{
    public static class CarFactory
    {
        public static readonly IConnectionStringAdapter _connection;
        public static CarLogic GetCarLogic(IConnectionStringAdapter adapter)
        {
            ICarQueries carQueries = new CarQueries(adapter);
            return new CarLogic(carQueries);
        }
    }
}
