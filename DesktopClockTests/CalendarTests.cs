using System;
using DesktopClock.Library;
using Xunit;
using DesktopClockTests.FakeClasses;
using DesktopClockTests.TestDatas;

namespace DesktopClockTests
{
    public class CalendarTests
    {
        [Theory]
        [ClassData(typeof(CalendarData_ja_JP))]
        public void GetCalendar_YearAndMonthArgs_CollectCalendar(int year, int month, int[,] days, bool[,] isHoliday, bool[,] isThisMonth, int lastRow)
        {
            // arrange

            // act
            Calendar.GetCalendar(year, month, HolidayChecker.GetHolidayChecker("ja-JP"), out int[,] actualDays, out bool[,] actualIsHoliday, out bool[,] actualIsThisMonth, out int actualLastRow);

            // assert
            Assert.Equal(days, actualDays);
            Assert.Equal(isHoliday, actualIsHoliday);
            Assert.Equal(isThisMonth, actualIsThisMonth);
            Assert.Equal(lastRow, actualLastRow);
        }
    }
}
