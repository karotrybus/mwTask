using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using program;

namespace program.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void StringToDateTest()
        {
            //arrange
            bool expected = true;            
            string dateString = "2018-05-12";
            DateRange dateRange = new DateRange();

            //act
            bool actual = dateRange.StringToDate(dateString);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringToDateUSTest()
        {
            //arrange
            bool expected = true;
            string dateString = "05/12/2018";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            DateRange dateRange = new DateRange();

            //act
            bool actual = dateRange.StringToDate(dateString);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringToDateFailsTest()
        {
            //arrange
            bool expected = false;
            string dateString = "05/12/2018";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
            DateRange dateRange = new DateRange();

            //act
            bool actual = dateRange.StringToDate(dateString);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringToDateOutOfRangeTest()
        {
            //arrange
            bool expected = false;
            string dateString = "35/12/2018";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
            DateRange dateRange = new DateRange();

            //act
            bool actual = dateRange.StringToDate(dateString);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNewestDateTest()
        {
            DateRange dateRange = new DateRange();
            dateRange.StringToDate("2018-05-12");
            dateRange.StringToDate("2018-05-14");

            DateTime expected = new DateTime(2018, 5, 14);
            DateTime actual = dateRange.GetNewestDate();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOldestDateTest()
        {
            DateRange dateRange = new DateRange();
            dateRange.StringToDate("2018-05-12");
            dateRange.StringToDate("2018-05-14");

            DateTime expected = new DateTime(2018, 5, 12);
            DateTime actual = dateRange.GetOldestDate();

            Assert.AreEqual(expected, actual);
        }
    }
}
