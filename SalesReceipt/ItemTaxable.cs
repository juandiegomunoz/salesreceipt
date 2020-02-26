// <copyright file="ItemTaxable.cs" company="Lastminute">
//     Copyright (c) Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceipt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NLog;

    /// <summary>
    /// This Class Implements a sellable item allowing to calculate the taxes.
    /// </summary>
    public class ItemTaxable : Item, ITaxable
    {
        /// <summary>
        /// List of taxes applied to the item.
        /// </summary>
        private static List<Tax> taxes = new List<Tax>();

        /// <summary>
        /// Operations log.
        /// </summary>
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Apply a new tax to the item.
        /// </summary>
        /// <param name="tax">Tax to be added.</param>
        /// <returns>Whether the tax has been added or not.</returns>
        public static bool ApplyTax(Tax tax)
        {
            try
            {
                taxes.Add(tax);
            }
            catch (Exception err)
            {
                logger.Error(err, "Could'n Apply new Tax.");
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public float GetBasePrice()
        {
            return this.Quantity * this.Price;
        }

        /// <inheritdoc/>
        public float GetPriceAfterTaxes()
        {
            return this.GetBasePrice() + this.GetTaxesPrice();
        }

        /// <inheritdoc/>
        public float GetTaxesPrice()
        {
            float output = 0F;
            foreach (Tax tax in taxes)
            {
                output += this.CalculateTax(tax);
            }

            return this.Quantity * output;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            // Return string
            return FormattableString.Invariant($"{this.Quantity} {this.Name}: {this.GetPriceAfterTaxes():F2}");
        }

        /// <summary>
        /// Caculate the tax amount over the Item price.
        /// </summary>
        /// <param name="tax">Tax to apply.</param>
        /// <returns>Amount of tax to increment.</returns>
        private float CalculateTax(Tax tax)
        {
            // Tax doesn't apply
            if (!this.TaxableBy(tax))
            {
                return 0;
            }

            // Calculate
            float output = this.Price * tax.Rate / 100;

            // Round up
            output = (float)Math.Ceiling(output * 20F) / 20F;

            // Return value
            return output;
        }

        /// <summary>
        /// Returns whether a tax apply to the item or not.
        /// </summary>
        /// <param name="tax">Tax to compare.</param>
        /// <returns>True if the tax must be applied. False otherwise.</returns>
        private bool TaxableBy(Tax tax)
        {
            // Is included
            if (tax.Include != null && tax.Include.Length > 0)
            {
                return tax.Include.Any(s => this.Name.ToUpper().Contains(s.ToUpper()));
            }

            // Is Excluded
            if (tax.Exclude != null && tax.Exclude.Length > 0)
            {
                return !tax.Exclude.Any(s => this.Name.ToUpper().Contains(s.ToUpper()));
            }

            // Default
            return true;
        }
    }
}