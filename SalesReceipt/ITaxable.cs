// <copyright file="ITaxable.cs" company="Lastminute">
// Copyright © Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceipt
{
    /// <summary>
    /// This interface defines the methods to implement for any taxable item.
    /// </summary>
    public interface ITaxable
    {
        /// <summary>
        /// Get the Base price of an item before taxes.
        /// </summary>
        /// <returns>Base price of the item.</returns>
        float GetBasePrice();

        /// <summary>
        /// Get the Price of the item once taxes have been applied.
        /// </summary>
        /// <returns>Item Price after Taxes.</returns>
        float GetPriceAfterTaxes();

        /// <summary>
        /// Gets the tax import amount of the price.
        /// </summary>
        /// <returns>The amount of taxes charged for the item.</returns>
        float GetTaxesPrice();
    }
}