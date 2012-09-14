using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedResources.Utilities
{
    public class DateUtility
    {
        private static string[] MONTH_NAMES = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public static string FormatDate(DateTime date)
        {
            return date.Day + ". " + MONTH_NAMES[date.Month - 1];
        }

        public static string FormatDay(DateTime date, bool uppercase = true)
        {
            int i = 0;
            while (date.DayOfYear != DateTime.Now.AddDays((double)i).DayOfYear)
            {
                i++;
            }

            if (i == 0)
            {
                return uppercase ? "Today" : "today";
            }
            else if (i == -1)
            {
                return uppercase ? "Yesterday" : "yesterday";
            }
            else if (i == 1)
            {
                return uppercase ? "Tomorrow" : "tomorrow";
            }
            else
            {
                return uppercase ? FormatDate(date) : FormatDate(date);
            }
        }
    }
}
