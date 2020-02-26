// <copyright file="StandardTest.cs" company="Lastminute">
//     Copyright © Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceiptTest
{
    using System.IO;
    using Lastminute.SalesReceipt;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class to test performance of the classes.
    /// </summary>
    [TestClass]
    public class StandardTest
    {
        private string dataInputDirectory = "data/input";
        private string dataOutputDirectory = "data/output";

        /// <summary>
        /// Taking input files in data/input folder, compare the results with the files in data/output folder.
        /// </summary>
        [TestMethod]
        public void CompareInputOutput()
        {
            foreach (string file in Directory.GetFiles(this.dataInputDirectory))
            {
                // Create the list
                ItemList list = new ItemList();
                foreach (string line in File.ReadLines(file))
                {
                    ItemTaxable item = (ItemTaxable)Item.FromString(line);
                    list.Add(item);
                }

                // Read the output
                string fileOut = Path.Combine(this.dataOutputDirectory, Path.GetFileName(file));
                string expected = File.ReadAllText(fileOut);

                // Compare
                Assert.AreEqual(expected, list.ToString());
            }
        }
    }
}