using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.DataLayer.Util
{
    public sealed class ConnectionUtil
    {
        private readonly string connectionString = string.Empty;
        private static readonly ConnectionUtil connectionUtil = new ConnectionUtil();
        public string GetConnectionString()
        {
            return this.connectionString;
        }

        private ConnectionUtil()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json");

           IConfiguration configuration = builder.Build();
           connectionString = configuration.GetConnectionString("Default");

        }
        public static ConnectionUtil GetInstance()
        {
            return connectionUtil; 
        }
    }
}
