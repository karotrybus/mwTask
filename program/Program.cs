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
            DateRange dateRange = new DateRange();

            if (args.Length != 2)
            {
                Console.WriteLine("Please enter {0} more date(s).\n", (2-args.Length));
                Console.WriteLine("Usage: program.exe <parameter> <parameter>");
                Console.WriteLine("     where <parameter> is a date in a correct format.");
                dateRange.PrintPatterns();
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                return 1;
            }

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            string argument1 = args[0];
            string argument2 = args[1];

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