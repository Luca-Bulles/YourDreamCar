using ConnectionStringHandler;
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
        // Iedereen weet nu dat er een connectionstring in carfactory zit. Niet nice :(
        // Connectionstring zou geen onderdeel moeten zijn van de car... CARRRRR.. factory ^_^
        //public static IConnectionStringAdapter adapter;//maak een adapter aan
        // In principe is deze niet echt nodig voor de buitenwereld, aangezien daar je car logic voor bestaat :)
        //public static ICarQueries _carQueries = new CarQueries(adapter);//geef adapter mee
        public static readonly IConnectionStringAdapter _connection;
        public static CarLogic GetCarLogic(IConnectionStringAdapter adapter)
        {
            ICarQueries carQueries = new CarQueries(adapter);
            return new CarLogic(carQueries);
        }
    }
}
