using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace program
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Please enter {0} more date(s)", (2-args.Length));
                Console.ReadKey();
                return 1;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            string argument1 = args[0];
            string argument2 = args[1];

            DateRange dateRange = new DateRange();

            if (dateRange.StringToDate(argument1) && dateRange.StringToDate(argument2))
            {
                dateRange.PrintDates();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            return 0;
        }
    }
}