using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Common
{
    public class HelperAppSettings
    {
        private static IConfigurationRoot _configuration;

        public HelperAppSettings(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public static string ConnectionString
        {
            get
            {
                return _configuration.GetConnectionString("Blog");
            }
        }
    }
}
