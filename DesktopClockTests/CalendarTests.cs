using System;
using Xunit;
using DesktopClock.Library;
using DesktopClockTests.TestDatas;

namespace DesktopClockTests
{
    public class CalendarTests
    {
        [Theory]
        [ClassData(typeof(CalendarData))]
        public void GetCalendar_YearAndMonthArgs_CollectCalendar(int year, int month, int[,] days, bool[,] isHoliday, bool[,] isThisMonth, int lastRow)
        {
            // arrange

            // act
            Calendar.GetCalendar(year, month, new HolidayChecker(), out int[,] actualDays, out bool[,] actualIsHoliday, out bool[,] actualIsThisMonth, out int actualLastRow);

            // assert
            Assert.Equal(days, actualDays);
            Assert.Equal(isHoliday, actualIsHoliday);
            Assert.Equal(isThisMonth, actualIsThisMonth);
            Assert.Equal(lastRow, actualLastRow);
        }
    }
}
