using ConnectionStringHandler;
using MySql.Data.MySqlClient;
using System;
using YourDreamCarDAL.Queries;
using YourDreamCarInterfaces.Queries;
using YourDreamCarLogic.Logic;

namespace YourDreamCarFactory
{
    public static class CarFactory
    {
        public static ConnectionString connectionString = new ConnectionString("Server=studmysql01.fhict.local;Uid=dbi437981;Database=dbi437981;Pwd=Dierenasiel;");
        
        public static ICarQueries _carQueries = new CarQueries(connectionString);
        public static CarLogic GetCarLogic()
        {
            return new CarLogic(_carQueries);
        }
    }
}
