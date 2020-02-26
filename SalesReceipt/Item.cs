// <copyright file="Item.cs" company="Lastminute">
//     Copyright (c) Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceipt
{
    /// <summary>
    /// Class to represent a shopping item.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets how many units of the Item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets Name of the Item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Base Price of the Item.
        /// </summary>
        public float Price { get; set; }
    }
}