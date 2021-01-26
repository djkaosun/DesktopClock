using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using DesktopClock.Library;
using Xunit;
using DesktopClockTests.FakeClasses;
using DesktopClockTests.TestDatas;

namespace DesktopClockTests
{
    public class CustomHolidayTests
    {
        [Fact]
        public void GetHolidayName_HolidaysNotSetted_ReturnsNull()
        {
            // arrange
            var customHoliday = new CustomHoliday();

            // act
            var actual = customHoliday.GetHolidayName(2020, 1, 2);

            // assert
            Assert.Null(actual);
        }

        [Fact]
        public void GetHolidayName_HolidaysSettedButEmpty_ReturnsNull()
        {
            // arrange
            var customHoliday = new CustomHoliday() { Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>() };

            // act
            var actual = customHoliday.GetHolidayName(2020, 1, 2);

            // assert
            Assert.Null(actual);
        }

        [Fact]
        public void GetHolidayName_HolidaysSettedAndDateEqual_ReturnsHolidayName()
        {
            // arrange
            var customHoliday = new CustomHoliday() { Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>() };
            customHoliday.Holidays.Add(new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 2), "HolidayName"));

            // act
            var actual = customHoliday.GetHolidayName(2020, 1, 2);

            // assert
            Assert.Equal("HolidayName", actual);
        }

        [Fact]
        public void GetHolidayName_HolidaysSettedButDateNotEqual_ReturnsNull()
        {
            // arrange
            var customHoliday = new CustomHoliday() { Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>() };
            customHoliday.Holidays.Add(new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 3), "HolidayName"));

            // act
            var actual = customHoliday.GetHolidayName(2020, 1, 2);

            // assert
            Assert.Null(actual);
        }

        [Fact]
        public void Holidays_SetNull_ThrowsNoException()
        {
            // arrange
            var customHoliday = new CustomHoliday();

            // act
            // assert
            customHoliday.Holidays = null;

        }

        [Fact]
        public void Holidays_SetTwice_ThrowsInvalidOperaionException()
        {
            // arrange
            var customHoliday = new CustomHoliday();
            customHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            // act
            // assert
            Assert.Throws<InvalidOperationException>( () => { customHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>(); } );

        }

        [Fact]
        public void Holidays_SetNullAfterSetOnce_ThrowsInvalidOperaionException()
        {
            // arrange
            var customHoliday = new CustomHoliday();
            customHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { customHoliday.Holidays = null; });

        }

        [Fact]
        public void Holidays_SetCollection_OccursPropertyChangedEvent()
        {
            // arrange
            var customHoliday = new CustomHoliday();

            bool actual = false;
            customHoliday.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(CustomHoliday.Holidays)) actual = true;
            };

            // act
            customHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void Holidays_Setted_OccursHolidaySettingChangedChangedEvent()
        {
            // arrange
            var customHoliday = new CustomHoliday();

            bool actual = false;
            customHoliday.HolidaySettingChanged += (sender, e) => {
                if (e.PropertyName == nameof(CustomHoliday.Holidays)) {
                    if (e.OriginalEventArgs is PropertyChangedEventArgs eventArgs)
                    {
                        if (eventArgs.PropertyName == nameof(CustomHoliday.Holidays)) actual = true;
                    }
                }
            };

            // act
            customHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void Holidays_AddToCollection_OccursHolidaySettingChangedChangedEvent()
        {
            // arrange
            var customHoliday = new CustomHoliday() { Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>() };

            bool actual = false;

            customHoliday.HolidaySettingChanged += (sender, e) => {
                if (e.PropertyName == nameof(CustomHoliday.Holidays))
                {
                    if (e.OriginalEventArgs is NotifyCollectionChangedEventArgs eventArgs)
                    {
                        if (eventArgs.Action == NotifyCollectionChangedAction.Add) actual = true;
                    }
                }
            };

            // act
            customHoliday.Holidays.Add(new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 1), "HolidayName"));

            // assert
            Assert.True(actual);
        }
    }
}
