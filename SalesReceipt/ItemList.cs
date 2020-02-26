// <copyright file="ItemList.cs" company="Lastminute">
//     Copyright (c) Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceipt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class to represent a list of shopping items.
    /// </summary>
    public class ItemList : List<ItemTaxable>
    {
        /// <summary>
        /// Gets the total price of the Item List.
        /// </summary>
        public float Total
        {
            get
            {
                return this.Sum(item => item.GetPriceAfterTaxes());
            }
        }

        /// <summary>
        /// Gets the total base price of the Item List.
        /// </summary>
        public float TotalBase
        {
            get
            {
                return this.Sum(item => item.GetBasePrice());
            }
        }

        /// <summary>
        /// Gets the total taxes charged in the Item List.
        /// </summary>
        public float TotalTaxes
        {
            get
            {
                return this.Sum(item => item.GetTaxesPrice());
            }
        }

        /// <summary>
        /// Gets the representation of the list in a string.
        /// </summary>
        /// <returns>A string representing the Item List, with the Sales Taxes and the Total at the end.</returns>
        public override string ToString()
        {
            // Prepare output
            string output = string.Empty;

            // Write the item list
            foreach (ItemTaxable item in this)
            {
                output += item.ToString() + Environment.NewLine;
            }

            // Write sales taxes
            output += $"Sales Taxes: {this.TotalTaxes:n2}{Environment.NewLine}";

            // Write Total
            output += $"Total: {this.Total:n2}";

            // Return output
            return output;
        }
    }
}