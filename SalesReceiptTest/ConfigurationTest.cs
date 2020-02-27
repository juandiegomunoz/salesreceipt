// <copyright file="ConfigurationTest.cs" company="Lastminute">
//     Copyright © Lastminute. All rights reserved.
// </copyright>

using Microsoft.Extensions.Configuration;

namespace Lastminute.SalesReceiptTest
{
    /// <summary>
    /// Class to read the configuration File.
    /// </summary>
    public class ConfigurationTest
    {
        /// <summary>
        /// Internal value of config.
        /// </summary>
        private static IConfiguration config;

        /// <summary>
        /// Exposes internal config member.
        /// </summary>
        public static IConfiguration Config
        {
            get
            {
                // Create config
                if (config == null)
                {
                    config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                }

                // Return internal
                return config;
            }
        }
    }
}