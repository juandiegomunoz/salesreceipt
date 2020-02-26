// <copyright file="ExtremeValuesTest.cs" company="Lastminute">
//     Copyright © Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceiptTest
{
    using Lastminute.SalesReceipt;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class to test extreme input values.
    /// </summary>
    [TestClass]
    public class ExtremeValuesTest
    {
        [TestMethod]
        private void MaxValues()
        {
            // Create item
            ItemTaxable item1 = new ItemTaxable()
            {
                Name = "Very expensive item",
                Quantity = int.MaxValue,
                Price = float.MaxValue,
            };

            // Create Tax
            Tax tax = new Tax()
            {
                Name = "Horrendus Tax",
                Rate = 150,
            };

            // Apply tax
            ItemTaxable.ApplyTax(tax);

            // Expected output
            Assert.AreEqual("adfadfa", item1.ToString());
        }
    }
}