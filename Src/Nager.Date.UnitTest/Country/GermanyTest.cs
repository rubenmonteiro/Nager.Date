﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Nager.Date.UnitTest.Country
{
    [TestClass]
    public class GermanyTest
    {
        [TestMethod]
        public void TestGermanyCorpusChristi()
        {
            var yearToTest = 2017;
            var catholicProvider = new MockProvider();
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, yearToTest);
            var easterSunday = catholicProvider.EasterSunday(yearToTest);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            Assert.AreEqual(easterSunday.AddDays(60), corpusChristi);
        }

        [TestMethod]
        public void TestGermanyCorpusChristi2017()
        {
            var yearToTest = 2017;
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, yearToTest);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            var expectedDate2017 = new DateTime(yearToTest, 6, 15);
            Assert.AreEqual(expectedDate2017, corpusChristi);
        }

        [TestMethod]
        public void TestGermanyCorpusChristi2026()
        {
            var yearToTest = 2026;
            var publicHolidays = DateSystem.GetPublicHoliday(CountryCode.DE, yearToTest);
            var corpusChristi = publicHolidays.First(x => x.LocalName == "Fronleichnam").Date;
            var expectedDate2026 = new DateTime(yearToTest, 6, 4);
            Assert.AreEqual(expectedDate2026, corpusChristi);
        }

        [TestMethod]
        public void TestGermanyIsOfficialPublicHolidayByCountyWithCountySpecificEpiphany2017()
        {
            var isPublicHolidayInBW = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2017, 1, 6), CountryCode.DE, "DE-BW");
            var isPublicHolidayInNW = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2017, 1, 6), CountryCode.DE, "DE-NW");

            Assert.IsTrue(isPublicHolidayInBW);
            Assert.IsFalse(isPublicHolidayInNW);
        }

        [TestMethod]
        public void TestGermanyIsOfficialPublicHolidayByCountyWithGlobalChristmasDay2017()
        {
            var isPublicHolidayInBW = DateSystem.IsOfficialPublicHolidayByCounty(new DateTime(2017, 12, 25), CountryCode.DE, "DE-BW");

            Assert.IsTrue(isPublicHolidayInBW);
        }
    }
}