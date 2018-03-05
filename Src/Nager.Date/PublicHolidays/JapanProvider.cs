﻿using Nager.Date.Contract;
using Nager.Date.Extensions;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using AASharp;

namespace Nager.Date.PublicHolidays
{
    class JapanProvider : IPublicHolidayProvider
    {
        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.JP;
            var items = new List<PublicHoliday>();

            //Japan Public holidays
            //https://en.wikipedia.org/wiki/Public_holidays_in_Japan
            //https://en.wikipedia.org/wiki/Golden_Week_(Japan)
            //https://www.boj.or.jp/en/about/outline/holi.htm/

            var secondMondayInJanuary = DateSystem.FindDay(year, 1, DayOfWeek.Monday, 2);
            var thirdMondayInJuly = DateSystem.FindDay(year, 7, DayOfWeek.Monday, 3);
            var thirdMondayInSeptember = DateSystem.FindDay(year, 9, DayOfWeek.Monday, 3);
            var secondMondayInOctober = DateSystem.FindDay(year, 10, DayOfWeek.Monday, 2);

            var newYearsDay = new DateTime(year, 1, 1).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var foundationDay = new DateTime(year, 2, 11).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var showaDay = new DateTime(year, 4, 29).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var memorialDay = new DateTime(year, 5, 3).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var greeneryDay = new DateTime(year, 5, 4).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var childrensDay = new DateTime(year, 5, 5).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var mountainDay = new DateTime(year, 8, 11).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var cultureDay = new DateTime(year, 11, 3).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var thanksgivingDay = new DateTime(year, 11, 23).Shift(saturday => saturday, sunday => sunday.AddDays(1));
            var emperorsBirthday = new DateTime(year,12,23).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            items.Add(new PublicHoliday(newYearsDay, "元日", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInJanuary, "成人の日", "Coming of Age Day", countryCode));
            items.Add(new PublicHoliday(foundationDay, "建国記念の日", "Foundation Day", countryCode));
            items.Add(new PublicHoliday(GetVernalEquinox(year), "春分の日", "Vernal Equinox Day", countryCode));
            items.Add(new PublicHoliday(showaDay, "昭和の日", "Shōwa Day", countryCode));
            items.Add(new PublicHoliday(memorialDay, "憲法記念日", "Constitution Memorial Day", countryCode));
            items.Add(new PublicHoliday(greeneryDay, "みどりの日", "Greenery Day", countryCode));
            items.Add(new PublicHoliday(childrensDay, "こどもの日", "Children's Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInJuly, "海の日", "Marine Day", countryCode));
            items.Add(new PublicHoliday(mountainDay, "山の日", "Mountain Day", countryCode));
            items.Add(new PublicHoliday(thirdMondayInSeptember, "(敬老の日", "Respect for the Aged Day", countryCode));
            items.Add(new PublicHoliday(GetAutumnalEquinox(year), "秋分の日", "Autumnal Equinox Day", countryCode));
            items.Add(new PublicHoliday(secondMondayInOctober, "体育の日", "Health and Sports Day", countryCode));
            items.Add(new PublicHoliday(cultureDay, "文化の日", "Culture Day", countryCode));
            items.Add(new PublicHoliday(thanksgivingDay, "勤労感謝の日", "Labour Thanksgiving Day", countryCode));
            //Will change to the date of the new emperor on the death of the current one
            items.Add(new PublicHoliday(emperorsBirthday, "天皇誕生日", "The Emperor's Birthday", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Golden_Week_(Japan)
        /// Get the Golden Week for a given year
        /// </summary>
        /// <param name="year"></param>
        public DateTime GetGoldenWeekStartDate(int year)
        {
            var showaDay = new DateTime(year, 4, 29).Shift(saturday => saturday, sunday => sunday.AddDays(1));

            return showaDay;
        }

        private DateTime GetVernalEquinox(int year)
        {
            long curYear = 0, month = 0, day = 0, hour = 0, minutes = 0;
            double seconds = 0;
            var date = new AASDate();
            var spring = AASEquinoxesAndSolstices.NorthwardEquinox(year, true);
            date.Set(spring, true);
            date.Get(ref curYear, ref month, ref day, ref hour, ref minutes, ref seconds);
            var dt = new DateTime((int)curYear, (int)month, (int)day, (int)hour, (int)minutes, (int)seconds);
            var converDt = TimeZoneInfo.ConvertTimeFromUtc(dt, timeZone);
            return converDt;

        }

        private DateTime GetAutumnalEquinox(int year)
        {
            long curYear = 0, month = 0, day = 0, hour = 0, minutes = 0;
            double seconds = 0;
            var date = new AASDate();
            var spring = AASEquinoxesAndSolstices.SouthwardEquinox(year, true);
            date.Set(spring, true);
            date.Get(ref curYear, ref month, ref day, ref hour, ref minutes, ref seconds);
            var dt = new DateTime((int)curYear, (int)month, (int)day, (int)hour, (int)minutes, (int)seconds);
            var converDt = TimeZoneInfo.ConvertTimeFromUtc(dt, timeZone);
            return converDt;
        }
    }
}