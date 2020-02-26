// <copyright file="ItemExtensionIdentical.cs" company="Lastminute">
//     Copyright (c) Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceipt
{
    /// <summary>
    /// Class to Extend the Class Item and make it able to compare with other items.
    /// We do not implement IComparable Here because Item may have an ID in the future and
    /// Some Items may be repeated. We assume that comparison is case sensitive, but may change.
    /// </summary>
    public static class ItemExtensionIdentical
    {
        /// <summary>
        /// Gets whether an Item have the same values than other. They can be different objects.
        /// </summary>
        /// <param name="item">First Item to compare.</param>
        /// <param name="itemOther">Second Item to compare.</param>
        /// <returns>True if the Item values are identicals.</returns>
        public static bool IsIdentical(this Item item, Item itemOther)
        {
            // Different Name, price and Quantity
            return item.Name == itemOther.Name &&
                    item.Price == itemOther.Price &&
                    item.Quantity == itemOther.Quantity;
        }
    }
}