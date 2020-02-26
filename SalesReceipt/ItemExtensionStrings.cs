// <copyright file="ItemLoaderExtension.cs" company="Lastminute">
//     Copyright (c) Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceipt
{
    public partial class Item
    {
        /// <summary>
        /// Generates a new Item and Loads data into it. 
        /// </summary>
        /// <param name="input"></param>
        public static Item FromString(string input)
        {
            // Prepare output
            Item item = new Item();
            // Get the strings
            string[] words = input.Split(' ');
            // Empty input
            if (words.Length == 0) return item;
            // First one is the Quantity
            if (int.TryParse(words[0], out int q)) item.Quantity = q;
            // There is no more information
            if (words.Length < 2) return item;
            // Last one is the price
            if (float.TryParse(words[words.Length - 1], out float p)) item.Price = p;
            // There is no more information
            if (words.Length < 3) return item;
            // The rest is the description
            item.Name = string.Empty;
            for (int i = 1; i < words.Length - 1; i++) item.Name += words[i] + " ";
            // Remove final ' at '
            if (item.Name.EndsWith(" at ")) item.Name = item.Name.Remove(item.Name.Length - 4);
            // Return output
            return item;
        }
    }
}