﻿using System;

namespace Nager.Date.Model
{
    public class PublicHoliday
    {
        public DateTime Date { get; set; }
        public string LocalName { get; set; }
        public string Name { get; set; }

        //ISO 3166-1 alpha-2
        public CountryCode CountryCode { get; set; }

        public bool Fixed { get; set; }
        public bool CountyOfficialHoliday { get; set; }
        public bool CountyAdministrationHoliday { get; set; }
        public bool Global { get { return this.Counties?.Length > 0 ? false : true; } }

        //ISO-3166-2
        public string[] Counties { get; set; }

        public PublicHolidayType Type { get; set; }
        public int? LaunchYear { get; set; }

        /// <summary>
        /// Add Public Holiday (fixed is true)
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="localName"></param>
        /// <param name="englishName"></param>
        /// <param name="countryCode">ISO 3166-1 ALPHA-2</param>
        /// <param name="launchYear"></param>
        /// <param name="counties">ISO-3166-2</param>
        /// <param name="countyOfficialHoliday"></param>
        /// <param name="countyAdministrationHoliday"></param>
        public PublicHoliday(int year, int month, int day, string localName, string englishName, CountryCode countryCode, int? launchYear = null, string[] counties = null, bool countyOfficialHoliday = true, bool countyAdministrationHoliday = true, PublicHolidayType type = PublicHolidayType.Public)
        {
            this.Date = new DateTime(year, month, day);
            this.LocalName = localName;
            this.Name = englishName;
            this.CountryCode = countryCode;
            this.Fixed = true;
            this.CountyOfficialHoliday = countyOfficialHoliday;
            this.CountyAdministrationHoliday = countyAdministrationHoliday;
            this.Type = type;
            this.LaunchYear = launchYear;
            if (counties?.Length > 0)
            {
                this.Counties = counties;
            }
        }

        /// <summary>
        /// Add Public Holiday (fixed is false)
        /// </summary>
        /// <param name="date"></param>
        /// <param name="localName"></param>
        /// <param name="englishName"></param>
        /// <param name="countryCode">ISO 3166-1 ALPHA-2</param>
        /// <param name="launchYear"></param>
        /// <param name="counties">ISO-3166-2</param>
        /// <param name="countyOfficialHoliday"></param>
        /// <param name="countyAdministrationHoliday"></param>
        public PublicHoliday(DateTime date, string localName, string englishName, CountryCode countryCode, int? launchYear = null, string[] counties = null, bool countyOfficialHoliday = true, bool countyAdministrationHoliday = true, PublicHolidayType type = PublicHolidayType.Public)
        {
            this.Date = date;
            this.LocalName = localName;
            this.Name = englishName;
            this.CountryCode = countryCode;
            this.Fixed = false;
            this.CountyOfficialHoliday = countyOfficialHoliday;
            this.CountyAdministrationHoliday = countyAdministrationHoliday;
            this.Type = type;
            this.LaunchYear = launchYear;
            if (counties?.Length > 0)
            {
                this.Counties = counties;
            }
        }

        public override string ToString()
        {
            return $"{this.Date:yyyy-MM-dd} {this.Name}";
        }
    }
}