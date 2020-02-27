// <copyright file="PerformanceTest.cs" company="Lastminute">
//     Copyright © Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceiptTest
{
    using System;
    using System.Diagnostics;
    using Lastminute.SalesReceipt;
    using Microsoft.Extensions.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class to test performance of the classes.
    /// </summary>
    [TestClass]
    public class PerformanceTest
    {

        /// <summary>
        /// Test to check how long takes read and print results.
        /// /// </summary>
        [TestMethod]
        public void TimeTest()
        {
            // Get expected inputs and ouptuts
            int[] sizes = ConfigurationTest.Config.GetSection("PerformanceTest:Sizes").Get<int[]>();
            int[] times = ConfigurationTest.Config.GetSection("PerformanceTest:Times").Get<int[]>();

            // Check if sizes and times are same length
            Assert.AreEqual(sizes.Length, times.Length);

            // Create stopwatch
            Stopwatch sw = new Stopwatch();

            // Loop over the inputs
            for (int i = 0; i < sizes.Length; i++)
            {

                // Generate list and process output
                sw.Restart();
                ItemList list = GenerateList(sizes[i]);
                Console.WriteLine(list.Write());
                sw.Stop();

                // Check Output time
                Assert.IsTrue(sw.Elapsed < TimeSpan.FromSeconds(times[i]));
            }
        }

        /// <summary>
        /// Generates a random list of item.
        /// </summary>
        /// <param name="size">Expected size of the list.</param>
        /// <returns>List of items.</returns>
        private ItemList GenerateList(int size)
        {

            // Get items list
            string[] items = ConfigurationTest.Config.GetSection("PerformanceTest:Items").Get<string[]>();

            // Creates random
            Random random = new Random();

            // Creates list
            ItemList output = new ItemList();

            for (int i = 0; i < size; i++)
            {
                // Creates item
                ItemTaxable item = new ItemTaxable();

                // Fill data
                item.Quantity = random.Next(1, 100);
                item.Price = random.Next(1, 1000);
                item.Name = (random.Next(0, 1) == 0) ? "imported" : string.Empty;
                item.Name += " " + items[random.Next(0, items.Length - 1)];

                // Add item
                output.Add(item);
            }

            // Return
            return output;
        }
    }
}