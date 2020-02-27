// <copyright file="ExtremeValuesTest.cs" company="Lastminute">
//     Copyright © Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceiptTest
{
    using System.Collections.Generic;
    using Lastminute.SalesReceipt;
    using Microsoft.Extensions.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class to test extreme input values.
    /// </summary>
    [TestClass]
    public class ExtremeValuesTest
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="config"></param>
        public ExtremeValuesTest()
        {
            // Apply Taxes
            foreach (Tax tax in ConfigurationTest.Config.GetSection("ExtremeValuesTest:Taxes").Get<List<Tax>>())
            {
                ItemTaxable.ApplyTax(tax);
            }
        }

        [TestMethod]
        public void MaxValues()
        {
            // Get expected inputs and ouptuts
            string[] inputs = ConfigurationTest.Config.GetSection("ExtremeValuesTest:Inputs").Get<string[]>();
            string[] outputs = ConfigurationTest.Config.GetSection("ExtremeValuesTest:Outputs").Get<string[]>();

            // Check inputs and outpus are the same length
            Assert.AreEqual(inputs.Length, outputs.Length);

            // Compare inputs and outputs
            for (int i = 0; i < inputs.Length; i++)
            {
                ItemTaxable item = new ItemTaxable();
                item.LoadFromString(inputs[i]);
                Assert.AreEqual(item.ToString(), outputs[i]);
            }
        }
    }
}