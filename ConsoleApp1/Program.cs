using SF2022UserNNLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeSpan[] startTimes = { TimeSpan.Parse("10:00"), TimeSpan.Parse("11:00"), TimeSpan.Parse("-28:00"), TimeSpan.Parse("15:30"), TimeSpan.Parse("16:50") };
            int[] durations = { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = TimeSpan.Parse("08:00");
            TimeSpan endWorkingTime = TimeSpan.Parse("19:00");
            int consultationTime = 32;

            Calculations calculator = new Calculations();
            string[] availablePeriods = calculator.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            foreach(string period in availablePeriods)
            {
                Console.WriteLine(period);
            }
            Console.ReadLine();
        }
    }
}
