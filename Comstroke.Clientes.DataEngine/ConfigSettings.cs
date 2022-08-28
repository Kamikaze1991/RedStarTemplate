using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace $safeprojectname$
{
    public static class ConfigSettings
    {
        /// <summary>
        /// File config
        /// </summary>
        public static IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// File Config get conection DB
        /// </summary>
        /// <param name="dataBaseName"></param>
        /// <returns></returns>
        public static string ConectionDB(string dataBaseName)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return Configuration.GetConnectionString(dataBaseName);
        }
    }
}
