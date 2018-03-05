using System;

namespace Nager.Date.Contract
{
    public interface ICountryCalendarProvider : IPublicHolidayProvider
    {
        DayOfWeek FirstDayOfWeek { get; }

        bool IsWeekend(DateTime date);
    }
}