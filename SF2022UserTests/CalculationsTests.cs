using Microsoft.VisualStudio.TestTools.UnitTesting;
using SF2022UserNNLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022UserNNLib.Tests
{
    [TestClass()]
    public class CalculationsTests
    {

        [TestMethod()]
        public void AvailablePeriodsTest1()
        {
            TimeSpan[] startTimes = { TimeSpan.Parse("10:00"), TimeSpan.Parse("11:00"), TimeSpan.Parse("15:00"), TimeSpan.Parse("15:30"), TimeSpan.Parse("16:50") };
            int[] durations = { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = TimeSpan.Parse("08:00");
            TimeSpan endWorkingTime = TimeSpan.Parse("18:00");
            int consultationTime = 31;

            Calculations calculator = new Calculations();
            string[] availablePeriods = calculator.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.AreEqual(availablePeriods[0], "08:00-08:31");
            Assert.AreEqual(availablePeriods[1], "08:31-09:02");
            Assert.AreEqual(availablePeriods[2], "09:02-09:33");
            Assert.AreEqual(availablePeriods[3], "11:30-12:01");
            Assert.AreEqual(availablePeriods[4], "12:01-12:32");
            Assert.AreEqual(availablePeriods[5], "12:32-13:03");
            Assert.AreEqual(availablePeriods[6], "13:03-13:34");
            Assert.AreEqual(availablePeriods[7], "13:34-14:05");
            Assert.AreEqual(availablePeriods[8], "14:05-14:36");
            Assert.AreEqual(availablePeriods[9], "15:10-15:41");
            Assert.AreEqual(availablePeriods[10], "15:41-16:12");
            Assert.AreEqual(availablePeriods[11], "16:12-16:43");



        }
        [TestMethod()]
        public void AvailablePeriodsTest2()
        {
            TimeSpan[] startTimes = { TimeSpan.Parse("10:00"), TimeSpan.Parse("11:00"), TimeSpan.Parse("15:00"), TimeSpan.Parse("15:30"), TimeSpan.Parse("16:50") };
            int[] durations = { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = TimeSpan.Parse("08:00");
            TimeSpan endWorkingTime = TimeSpan.Parse("18:00");
            int consultationTime = 31;

            Calculations calculator = new Calculations();
            string[] availablePeriods = calculator.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);

            Assert.AreEqual(availablePeriods[0], "08:00-08:31");
            Assert.AreEqual(availablePeriods[1], "08:31-09:02");
            Assert.AreEqual(availablePeriods[2], "09:02-09:33");
            Assert.AreEqual(availablePeriods[3], "11:30-12:01");
            Assert.AreEqual(availablePeriods[4], "12:01-12:32");
            Assert.AreEqual(availablePeriods[5], "12:32-13:03");
            Assert.AreEqual(availablePeriods[6], "13:03-13:34");
            Assert.AreEqual(availablePeriods[7], "13:34-14:05");
            Assert.AreEqual(availablePeriods[8], "14:05-14:36");
            Assert.AreEqual(availablePeriods[9], "15:10-15:41");
            Assert.AreEqual(availablePeriods[10], "15:41-16:12");
            Assert.AreEqual(availablePeriods[11], "16:12-16:43");

        }
        [TestMethod()]
        public void AvailablePeriodsTest3()
        {
            TimeSpan[] startTimes = { TimeSpan.Parse("10:00"), TimeSpan.Parse("11:00"), TimeSpan.Parse("15:00"), TimeSpan.Parse("15:30"), TimeSpan.Parse("16:50") };
            int[] durations = { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = TimeSpan.Parse("08:00");
            TimeSpan endWorkingTime = TimeSpan.Parse("18:00");
            int consultationTime = 32;

            Calculations calculator = new Calculations();
            string[] availablePeriods = calculator.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);


            Assert.AreEqual(availablePeriods[0], "08:00-08:32");
            Assert.AreEqual(availablePeriods[1], "08:32-09:04");
            Assert.AreEqual(availablePeriods[2], "09:04-09:36");
            Assert.AreEqual(availablePeriods[3], "11:30-12:02");
            Assert.AreEqual(availablePeriods[4], "12:02-12:34");
        }
        [TestMethod()]
        public void AvailablePeriodsTest4()
        {
            TimeSpan[] startTimes = { TimeSpan.Parse("10:00"), TimeSpan.Parse("11:00"), TimeSpan.Parse("15:00"), TimeSpan.Parse("15:30"), TimeSpan.Parse("16:50") };
            int[] durations = { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = TimeSpan.Parse("08:00");
            TimeSpan endWorkingTime = TimeSpan.Parse("18:00");
            int consultationTime = 33;

            Calculations calculator = new Calculations();
            string[] availablePeriods = calculator.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            Assert.AreEqual(availablePeriods[0], "08:00-08:33");
            Assert.AreEqual(availablePeriods[1], "08:33-09:06");
            Assert.AreEqual(availablePeriods[2], "09:06-09:39");
            Assert.AreEqual(availablePeriods[3], "11:30-12:03");
            Assert.AreEqual(availablePeriods[4], "12:03-12:36");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.OverflowException))]
        public void AvailablePeriodsTest5()
        {

          TimeSpan[] startTimes = { TimeSpan.Parse("10:00"), TimeSpan.Parse("11:00"), TimeSpan.Parse("-28:00"), TimeSpan.Parse("15:30"), TimeSpan.Parse("16:50") };
        }
        }
}