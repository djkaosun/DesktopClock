using System;
using Xunit;
using DesktopClock.Library;
using DesktopClockTests.TestDatas;

namespace DesktopClockTests
{
    public class HolidayChekerTests
    {
        [Theory]
        [ClassData(typeof(HolidayData))]
        public void GetHolidayName_HolidayDateTime_ReturnsCorrectlyName(DateTime date, string expectedHolidayName)
        {
            // arrange
            var hCheker = new HolidayChecker();

            // act
            var actualHolidayName = hCheker.GetHolidayName(date);

            // assert
            Assert.Equal(expectedHolidayName, actualHolidayName);
        }

        [Theory]
        [ClassData(typeof(NotHolidayData))]
        public void GetHolidayName_NotHolidayDateTime_ReturnsNull(DateTime date)
        {
            // arrange
            var hCheker = new HolidayChecker();

            // act
            var actual = hCheker.GetHolidayName(date);

            // assert
            Assert.Null(actual);
        }
    }
}
