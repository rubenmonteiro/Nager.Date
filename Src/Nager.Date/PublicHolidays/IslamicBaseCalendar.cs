using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.PublicHolidays
{
    public abstract class IslamicBaseCalendar : ICountryCalendarProvider
    {
        public virtual DayOfWeek FirstDayOfWeek => DayOfWeek.Sunday;

        public abstract IEnumerable<PublicHoliday> Get(int year);

        public virtual bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
