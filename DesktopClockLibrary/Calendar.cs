using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClock.Library
{
    public static class Calendar
    {
        public static void GetCalendar(int year, int month, IHolidayChecker holidayChecker, out int[,] days, out bool[,] isHoliday, out bool[,] isThisMonth, out int lastRow)
        {
            days = new int[6, 7];
            isHoliday = new bool[6, 7];
            isThisMonth = new bool[6, 7];

            var beginDayOfWeek = (int)(new DateTime(year, month, 1).DayOfWeek);


            int endDay;
            if (month == 12)
            {
                endDay = (new DateTime(year + 1, 1, 1) - TimeSpan.FromDays(1)).Day;
            }
            else
            {
                endDay = (new DateTime(year, month + 1, 1) - TimeSpan.FromDays(1)).Day;
            }

            int endDayOfPrev = (new DateTime(year, month, 1) - TimeSpan.FromDays(1)).Day;

            int day = 1;
            int startRow = 0;
            if (beginDayOfWeek == 0) startRow = 1;
            int prevDay = endDayOfPrev - beginDayOfWeek + 1;
            if (beginDayOfWeek == 0) prevDay -= 7;
            int nextDay = 1;
            lastRow = -1;
            for (int i = 0; i < days.GetLength(0); i++)
            {
                for (int j = 0; j < days.GetLength(1); j++)
                {

                    if (i < startRow || i == startRow && j < beginDayOfWeek)
                    {
                        days[i, j] = prevDay;
                        isThisMonth[i, j] = false;

                        if (month == 1)
                        {
                            isHoliday[i, j] = holidayChecker.IsHoliday(year - 1, 12, prevDay);
                        }
                        else
                        {
                            isHoliday[i, j] = holidayChecker.IsHoliday(year, month - 1, prevDay);
                        }

                        prevDay++;
                    }
                    else if (day <= endDay)
                    {
                        days[i, j] = day;
                        isThisMonth[i, j] = true;

                        isHoliday[i, j] = holidayChecker.IsHoliday(year, month, day);

                        day++;
                    }
                    else
                    {
                        if (lastRow < 0) lastRow = i;
                        if (lastRow == i)
                        {
                            days[i, j] = nextDay;
                            isThisMonth[i, j] = false;

                            if (month == 12)
                            {
                                isHoliday[i, j] = holidayChecker.IsHoliday(year + 1, 1, nextDay);
                            }
                            else
                            {
                                isHoliday[i, j] = holidayChecker.IsHoliday(year, month + 1, nextDay);
                            }

                            nextDay++;
                        }
                        else
                        {
                            days[i, j] = -1;
                            isThisMonth[i, j] = false;
                            isHoliday[i, j] = false;
                        }
                    }
                }
            }

        }
    }
}
