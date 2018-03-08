﻿using Nager.Date.Extensions;
using System;

namespace Nager.Date.TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Test1();

            Console.ReadLine();
        }

        private static void Test1()
        {
            var date = DateTime.Today;
            var countryCode = CountryCode.US;
            var provider = DateSystem.GetProvider(countryCode);

            do
            {
                date = date.AddDays(1);
            } while (DateSystem.IsPublicHoliday(date, countryCode) || provider.IsWeekend(date));
        }

        private static void Test2()
        {
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.CH, 2017);
            foreach (var publicHoliday in publicHolidays)
            {
                Console.WriteLine("{0:dd.MM.yyyy} {1} {2}", publicHoliday.Date, publicHoliday.LocalName, publicHoliday.Global);
            }
        }
    }
}