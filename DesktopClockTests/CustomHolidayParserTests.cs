using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DesktopClock.Library;
using Xunit;
using DesktopClockTests.FakeClasses;
using DesktopClockTests.TestDatas;

namespace DesktopClockTests
{
    public class CustomHolidayParserTests
    {
        [Fact]
        public void Serialize_Invoked_ReturnsString()
        {
            // arrange
            var customHolidays = new ObservableCollection<KeyValuePair<DateTime, string>>();
            customHolidays.Add(new DateTime(2020,1,2), "HolidayName");

            // act
            var actual = CustomHolidaysParser.Serialize(customHolidays);

            // assert
            Assert.IsType<string>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        public void Serialize2_Invoked_ReturnsString()
        {
            // arrange
            var customHolidays = new ObservableCollection<KeyValuePair<DateTime, string>>();
            customHolidays.Add(new DateTime(2020, 1, 2), "HolidayName");

            // act
            CustomHolidaysParser.Serialize(customHolidays, out string actual);

            // assert
            Assert.IsType<string>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        public void Deserialize_PassedSerializedString_ReturnsDesirializedCollection()
        {
            // arrange
            var customHolidays = new ObservableCollection<KeyValuePair<DateTime, string>>();
            customHolidays.Add(new DateTime(2020, 1, 2), "HolidayName");

            // act
            var actual = CustomHolidaysParser.Deserialize(CustomHolidaysParser.Serialize(customHolidays));

            // assert
            Assert.Equal(customHolidays, actual);
            Assert.NotSame(customHolidays, actual);
        }

        [Fact]
        public void Deserialize2_PassedSerializedString_ReturnsDesirializedCollection()
        {
            // arrange
            var customHolidays = new ObservableCollection<KeyValuePair<DateTime, string>>();
            customHolidays.Add(new DateTime(2020, 1, 2), "HolidayName");

            // act
            var actual = CustomHolidaysParser.Deserialize(CustomHolidaysParser.Serialize(customHolidays), customHolidays);

            // assert
            Assert.Equal(customHolidays, actual);
            Assert.Same(customHolidays, actual);
        }
    }
}
