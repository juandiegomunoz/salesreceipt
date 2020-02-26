// <copyright file="DataTest.cs" company="Lastminute">
//  Copyright © Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceiptTest
{
    using System.IO;
    using Lastminute.SalesReceipt;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Class to test Data components for Sales Receipt Project.
    /// </summary>
    [TestClass]
    public class DataTest
    {
        private readonly IConfiguration config;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="config"></param>
        public DataTest()
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        /// <summary>
        /// Load All data files from directory.
        /// </summary>
        [TestMethod]
        public void LoadListFromFile()
        {
            foreach (string file in Directory.GetFiles(config["DataTest:Input"]))
            {
                foreach (string line in File.ReadLines(file))
                {
                    Item item = new Item();
                    item.LoadFromString(line);
                }
            }
        }

        /// <summary>
        /// Verify the quality of the data.
        /// </summary>
        [TestMethod]
        public void VerifyDataParsing()
        {
            // Get expected inputs and ouptuts
            string[] inputs = config.GetSection("DataTest:Items:Input").Get<string[]>();
            Item[] outputs = config.GetSection("DataTest:Items:Output").Get<Item[]>();
            // Check are the same length
            Assert.AreEqual(inputs.Length, outputs.Length);
            // Compare
            for (int i = 0; i < inputs.Length; i++)
            {
                Item itemInput = new Item();
                itemInput.LoadFromString(inputs[i]);
                Item itemOutput = outputs[i];
                Assert.IsTrue(itemInput.IsIdentical(itemOutput));
            }
        }
    }
}
