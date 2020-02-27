// <copyright file="ItemList.cs" company="Lastminute">
// Copyright (c) 2020 Lastminute. All rights reserved.
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
            // Return Write joint
            return string.Join(Environment.NewLine, Write());
        }

        /// <summary>
        /// Gets the string output of the list. yielding results is more effective than compose a string.
        /// </summary>
        /// <returns>A string representing the Item List, with the Sales Taxes and the Total at the end.</returns>
        public IEnumerable<string> Write()
        {
            // Write the item list
            foreach (ItemTaxable item in this)
            {
                yield return item.ToString();
            }

            // Write sales taxes
            yield return $"Sales Taxes: {this.TotalTaxes:n2}";

            // Write Total
            yield return $"Total: {this.Total:n2}";
        }
    }
}