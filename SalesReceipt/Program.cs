// <copyright file="Program.cs" company="Lastminute">
//     Copyright (c) Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceipt
{
    using System;
    using System.IO;

    /// <summary>
    /// Execution point of the project.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Entry point of the application.
        /// </summary>
        /// <param name="args">Array of arguments passed to the method.</param>
        public static void Main(string[] args)
        {
            // Start
            Console.WriteLine("Starting Sales Receipt Program");

            // Read files in the input folder
            foreach (string file in Directory.GetFiles("data"))
            {
                Console.WriteLine($"FILE : {file}");
                Console.WriteLine("INPUT");
                ItemList list = new ItemList();
                foreach (string line in File.ReadLines(file))
                {
                    Item item = new Item();
                    item.LoadFromString(line);
                    list.Add((ItemTaxable)item);
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("OUTPUT");
                Console.Write(list.ToString());
            }

            // End
            Console.WriteLine("Program Finished.");
        }
    }
}
