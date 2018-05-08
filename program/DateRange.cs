using System;
using System.Collections.Generic;
using System.Globalization;

namespace program
{
    public class DateRange
    {
        private List<String> patterns;    // = { "dd/MM/yyyy", "MM.dd.yyyy", "MM-dd-yyyy", "yyyy/MM/dd", "yyyy.MM.dd", "yyyy-MM-dd"};
        public List<String> Patterns { get { return patterns; } }
        private List<DateTime> dates;

        public DateRange()
        {
            patterns = new List<String>();
            foreach (var pattern in DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns('d'))
            {
                patterns.Add(pattern);
            }

            dates = new List<DateTime>();
        }

        public bool StringToDate(string dateString)
        {
            bool check = DateTime.TryParseExact(dateString, patterns.ToArray(), CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime date);
            if (check)
            {
                dates.Add(date);
                return true;
            }
            else
            {
                PrintError(dateString);
                return false;
            }
        }

        public DateTime GetNewestDate()
        {
            DateTime result = DateTime.MinValue;
            foreach(var date in dates)
            {
                if(date > result)
                {
                    result = date;
                }
            }
            return result;
        }

        public DateTime GetOldestDate()
        {
            DateTime result = DateTime.MaxValue;
            foreach(var date in dates)
            {
                if(date < result)
                {
                    result = date;
                }
            }

            return result;
        }

        public void PrintDates()
        {
            DateTime date1 = GetOldestDate();
            DateTime date2 = GetNewestDate();

            if (!(date1.Year == date2.Year))
            {
                Console.WriteLine("{0} - {1}", date1.ToString("dd.MM.yyyy"), date2.ToString("dd.MM.yyyy"));
            }
            else
            {
                if (!(date1.Month == date2.Month))
                {
                    Console.WriteLine("{0} - {1}", date1.ToString("dd.MM"), date2.ToString("dd.MM.yyyy"));
                }
                else
                {
                    Console.WriteLine("{0} - {1}", date1.ToString("dd"), date2.ToString("dd.MM.yyyy"));
                }
            }
        }

        private void PrintError(string argument)
        {
            Console.WriteLine("{0} is invalid. Could be out of range or wrong format.\n", argument);
            PrintPatterns();
        }

        public void PrintPatterns()
        {
            Console.WriteLine("     Acceptable date formats:");
            foreach(var pattern in patterns)
            {
                Console.WriteLine("     {0}", pattern);
            }
        }
    }
}
