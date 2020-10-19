using Renci.SshNet.Security.Cryptography.Ciphers.Modes;
using System;
using System.Collections.Generic;
using System.Text;
using YourDreamCarInterfaces;
using YourDreamCarInterfaces.DAL;
using YourDreamCarInterfaces.Logic;
using YourDreamCarInterfaces.Queries;

namespace YourDreamCarLogic.Logic
{
    public class CarLogic: ICarLogic
    {
        private readonly ICarQueries carQueries;
        public CarLogic(ICarQueries _carQueries)
        {
            this.carQueries = _carQueries;
        }
        public IEnumerable<ICarDTO> GetAllCars()
        {
            return carQueries.GetAllCars();
        }
    }
}
