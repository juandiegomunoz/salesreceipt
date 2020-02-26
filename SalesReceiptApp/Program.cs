// <copyright file="Program.cs" company="Lastminute">
//     Copyright (c) Lastminute. All rights reserved.
// </copyright>

namespace Lastminute.SalesReceiptApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Lastminute.SalesReceipt;

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

            // Load config
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            // Set Taxes
            foreach (Tax tax in config.GetSection("Taxes").Get<List<Tax>>())
            {
                ItemTaxable.ApplyTax(tax);
            }

            // Read files in the input folder
            foreach (string file in Directory.GetFiles("data"))
            {
                Console.WriteLine(Environment.NewLine + new string('=', 20));
                Console.WriteLine($"FILE : {file}");
                Console.WriteLine(Environment.NewLine + "INPUT");
                Console.WriteLine(new string('-', 5));
                ItemList list = new ItemList();
                foreach (string line in File.ReadLines(file))
                {
                    ItemTaxable item = new ItemTaxable();
                    item.LoadFromString(line);
                    list.Add(item);
                    Console.WriteLine(line);
                }

                Console.WriteLine(Environment.NewLine + "OUTPUT");
                Console.WriteLine(new string('-', 6));
                Console.WriteLine(list.ToString());
            }

            // End
            Console.WriteLine("Program Finished.");
        }
    }
}
