// <copyright file="Tax.cs" company="Lastminute">
// Copyright (c) 2020 Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceipt
{
    /// <summary>
    /// Class to represent a tax.
    /// </summary>
    public class Tax
    {
        /// <summary>
        /// Gets or sets the Name used to identify the tax.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the List of string to look for in order to include an item.
        /// </summary>
        public string[] Include { get; set; }

        /// <summary>
        /// Gets or sets the List of string to look for in the name of the item in order to exclude it.
        /// </summary>
        public string[] Exclude { get; set; }

        /// <summary>
        /// Gets or sets the Rate to apply.
        /// </summary>
        public float Rate { get; set; }
    }
}