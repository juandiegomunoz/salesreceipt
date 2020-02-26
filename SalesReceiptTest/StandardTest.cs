// <copyright file="StandardTest.cs" company="Lastminute">
//     Copyright © Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceiptTest
{
    using System.Collections.Generic;
    using System.IO;
    using Lastminute.SalesReceipt;
    using Microsoft.Extensions.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class to test performance of the classes.
    /// </summary>
    [TestClass]
    public class StandardTest
    {
        private readonly IConfiguration config;

        public StandardTest()
        {
            // Read Config
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            
            // Apply Taxes
            foreach (Tax tax in config.GetSection("StandardTest:Taxes").Get<List<Tax>>())
            {
                ItemTaxable.ApplyTax(tax);
            }
        }

        /// <summary>
        /// Taking input files in data/input folder, compare the results with the files in data/output folder.
        /// </summary>
        [TestMethod]
        public void CompareInputOutput()
        {
            foreach (string file in Directory.GetFiles(config["DataTest:Input"]))
            {
                // Create the list
                ItemList list = new ItemList();
                foreach (string line in File.ReadLines(file))
                {
                    ItemTaxable item = new ItemTaxable();
                    item.LoadFromString(line);
                    list.Add(item);
                }

                // Read the output
                string fileOut = Path.Combine(config["DataTest:Output"], Path.GetFileName(file));
                string expected = File.ReadAllText(fileOut);

                // Compare
                Assert.AreEqual(expected, list.ToString());
            }
        }
    }
}