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
    public class HolidayCheckerTests
    {
        [Theory]
        [ClassData(typeof(HolidayData))]
        public void GetHolidayName_HolidayDateTime_ReturnsCorrectlyName(DateTime date, string expectedHolidayName)
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP() { IsAddHolidayNameToObservedHolidayName = false };

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
            var hCheker = new HolidayChecker_ja_JP();

            // act
            var actual = hCheker.GetHolidayName(date);

            // assert
            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(ObservedHolidayData))]
        public void GetHolidayName_IsNotAddHolidayNameToObservedHolidayName_ReturnsNotAddedName(DateTime date, string addedName)
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP() { IsAddHolidayNameToObservedHolidayName = false };

            // act
            var actual = hCheker.GetHolidayName(date);

            // assert
            Assert.Equal("振替休日", actual);
        }

        [Theory]
        [ClassData(typeof(ObservedHolidayData))]
        public void GetHolidayName_IsAddHolidayNameToObservedHolidayName_ReturnsAddedName(DateTime date, string addedName)
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP() { IsAddHolidayNameToObservedHolidayName = true };

            // act
            var actual = hCheker.GetHolidayName(date);

            // assert
            Assert.Equal(addedName, actual);
        }

        [Fact]
        public void GetHolidayName_IfNomalDayAndCustomHoliday_RerturnsCustomHolidayName()
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP();
            hCheker.CustomHoliday = new CustomHoliday();
            hCheker.CustomHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            var targetDate = new DateTime(2020, 1, 2);
            var defaultName = hCheker.GetHolidayName(targetDate);

            hCheker.CustomHoliday.Holidays.Add(new KeyValuePair<DateTime, string>(targetDate, "HolidayName"));


            // act
            var actual = hCheker.GetHolidayName(targetDate);

            // assert
            Assert.Null(defaultName);
            Assert.Equal("HolidayName", actual);
        }

        [Fact]
        public void IsAddHolidayNameToObservedHolidayName_SetValue_OccursPropertyChangedEvent()
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP() { IsAddHolidayNameToObservedHolidayName = false };

            bool actual = false;
            hCheker.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(HolidayChecker_ja_JP.IsAddHolidayNameToObservedHolidayName)) actual = true;
            };

            // act
            hCheker.IsAddHolidayNameToObservedHolidayName = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void IsAddHolidayNameToObservedHolidayName_SetValue_OccursHolidaySettingChangedEvent()
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP() { IsAddHolidayNameToObservedHolidayName = false };

            bool actual = false;
            hCheker.HolidaySettingChanged += (sender, e) => {
                if (e.PropertyName == nameof(HolidayChecker_ja_JP.IsAddHolidayNameToObservedHolidayName))
                {
                    if (e.OriginalEventArgs is PropertyChangedEventArgs eventArgs)
                    {
                        if (eventArgs.PropertyName == nameof(HolidayChecker_ja_JP.IsAddHolidayNameToObservedHolidayName)) actual = true;
                    }
                }
            };

            // act
            hCheker.IsAddHolidayNameToObservedHolidayName = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CustomHoliday_SetNull_ThrowsNoException()
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP();

            // act
            // assert
            hCheker.CustomHoliday = null;

        }

        [Fact]
        public void CustomHoliday_SetTwice_ThrowsInvalidOperaionException()
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP();
            hCheker.CustomHoliday = new CustomHoliday();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { hCheker.CustomHoliday = new CustomHoliday(); });
        }

        [Fact]
        public void CustomHoliday_SetNullAfterSetOnce_ThrowsInvalidOperaionException()
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP();
            hCheker.CustomHoliday = new CustomHoliday();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { hCheker.CustomHoliday = null; });
        }

        [Fact]
        public void CustomHoliday_SetCustomHoliday_OccursPropertyChangedEvent()
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP();

            bool actual = false;
            hCheker.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(HolidayChecker_ja_JP.CustomHoliday)) actual = true;
            };

            // act
            hCheker.CustomHoliday = new CustomHoliday();

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CustomHoliday_SetCustomHoliday_OccursHolidaySettingChangedEvent()
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP();

            bool actual = false;
            hCheker.HolidaySettingChanged += (sender, e) => {
                if (e.PropertyName == nameof(HolidayChecker_ja_JP.CustomHoliday))
                {
                    if (e.OriginalEventArgs is PropertyChangedEventArgs eventArgs)
                    {
                        if (eventArgs.PropertyName == nameof(HolidayChecker_ja_JP.CustomHoliday)) actual = true;
                    }
                }
            };

            // act
            hCheker.CustomHoliday = new CustomHoliday();

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CustomHoliday_OccuredHolidaySettingChangedEventOnCustomHolidayObject_OccursHolidaySettingChangedEvent()
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP();
            var customHoliday = new CustomHoliday();
            hCheker.CustomHoliday = customHoliday;

            bool actual = false;
            hCheker.HolidaySettingChanged += (sender, e) => {
                if (e.PropertyName == nameof(CustomHoliday.Holidays))
                {
                    if (e.OriginalEventArgs is PropertyChangedEventArgs eventArgs)
                    {
                        if (sender == customHoliday && eventArgs.PropertyName == nameof(CustomHoliday.Holidays))
                        {
                            actual = true;
                        }
                    }
                }
            };

            // act
            hCheker.CustomHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CustomHoliday_AddCustomHoliday_OccursHolidaySettingChangedEvent()
        {
            // arrange
            var hCheker = new HolidayChecker_ja_JP();
            hCheker.CustomHoliday = new CustomHoliday();
            hCheker.CustomHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            bool actual = false;
            hCheker.HolidaySettingChanged += (sender, e) => {
                if (e.PropertyName == nameof(CustomHoliday.Holidays))
                {
                    if (e.OriginalEventArgs is NotifyCollectionChangedEventArgs eventArgs)
                    {
                        if (eventArgs.Action == NotifyCollectionChangedAction.Add) actual = true;
                    }
                }
            };

            // act
            hCheker.CustomHoliday.Holidays.Add(new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 1), "HolidayName"));

            // assert
            Assert.True(actual);
        }
    }
}
