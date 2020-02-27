// <copyright file="ItemExtensionStrings.cs" company="Lastminute">
// Copyright (c) 2020 Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceipt
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension to load Items from and to a string.
    /// </summary>
    public static class ItemExtensionStrings
    {
        /// <summary>
        /// Loads data into an Item.
        /// </summary>
        /// <param name="item">Item to be populated with the new data.</param>
        /// <param name="input">String input with the data in format [quantity] [description] at [price].</param>
        public static void LoadFromString(this Item item, string input)
        {
            // Get the strings
            List<string> words = new List<string>(input.Split(' '));

            // Empty input
            if (words.Count == 0)
            {
                return;
            }

            // First one is the Quantity
            if (int.TryParse(words[0], out int q))
            {
                item.Quantity = q;
            }

            words.RemoveAt(0);

            // There is no more information
            if (words.Count == 0)
            {
                return;
            }

            // Last one is the price
            if (float.TryParse(words[words.Count - 1], out float p))
            {
                item.Price = p;
            }

            words.RemoveAt(words.Count - 1);

            // There is no more information
            if (words.Count == 0)
            {
                return;
            }

            // The rest is the description
            item.Name = string.Empty;

            // Handle imported word and put at the beginning
            string imported = words.Find(w => w.ToUpper() == "IMPORTED");
            if (imported != null)
            {
                words.Remove(imported);
                words.Insert(0, imported);
            }

            // Handle at
            string at = words.Find(s => s.ToUpper() == "AT");
            if (at != null)
            {
                words.Remove(at);
            }

            // Set Name
            item.Name = string.Join(' ', words);
        }

        /// <summary>
        /// Gets a string representing the item.
        /// </summary>
        /// <param name="item">Item to be parsed.</param>
        /// <returns>String representing the Item in the format [quantity] [description] at [price].</returns>
        public static string ToString(this Item item)
        {
            return item.Quantity + " " + item.Name + " at " + item.Price;
        }
    }
}