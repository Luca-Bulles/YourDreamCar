using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using YourDreamCarInterfaces.Adapters;

namespace YourDreamCar.Adapters
{
    public class ConnectionStringAdapter : IConnectionStringAdapter
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");       
        }
    }
}
