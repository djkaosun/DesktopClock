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
    public class HolidayChecker_ja_JP_Tests
    {
        [Theory]
        [ClassData(typeof(HolidayData))]
        public void GetHolidayName_HolidayDateTime_ReturnsCorrectlyName(DateTime date, string expectedHolidayName)
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");
            hChecker.IsAddHolidayNameToObservedHolidayName = false;

            // act
            var actualHolidayName = hChecker.GetHolidayName(date);

            // assert
            Assert.Equal(expectedHolidayName, actualHolidayName);
        }

        [Theory]
        [ClassData(typeof(NotHolidayData))]
        public void GetHolidayName_NotHolidayDateTime_ReturnsNull(DateTime date)
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");

            // act
            var actual = hChecker.GetHolidayName(date);

            // assert
            Assert.Null(actual);
        }

        [Theory]
        [ClassData(typeof(ObservedHolidayData))]
        public void GetHolidayName_IsNotAddHolidayNameToObservedHolidayName_ReturnsNotAddedName(DateTime date, string addedName)
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");
            hChecker.IsAddHolidayNameToObservedHolidayName = false;

            // act
            var actual = hChecker.GetHolidayName(date);

            // assert
            Assert.Equal("振替休日", actual);
        }

        [Theory]
        [ClassData(typeof(ObservedHolidayData))]
        public void GetHolidayName_IsAddHolidayNameToObservedHolidayName_ReturnsAddedName(DateTime date, string addedName)
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");
            hChecker.IsAddHolidayNameToObservedHolidayName = true;

            // act
            var actual = hChecker.GetHolidayName(date);

            // assert
            Assert.Equal(addedName, actual);
        }

        [Fact]
        public void GetHolidayName_IfNomalDayAndCustomHoliday_RerturnsCustomHolidayName()
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");
            hChecker.CustomHoliday = new CustomHoliday();
            hChecker.CustomHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            var targetDate = new DateTime(2020, 1, 2);
            var defaultName = hChecker.GetHolidayName(targetDate);

            hChecker.CustomHoliday.Holidays.Add(new KeyValuePair<DateTime, string>(targetDate, "HolidayName"));


            // act
            var actual = hChecker.GetHolidayName(targetDate);

            // assert
            Assert.Null(defaultName);
            Assert.Equal("HolidayName", actual);
        }

        [Fact]
        public void IsAddHolidayNameToObservedHolidayName_SetValue_OccursPropertyChangedEvent()
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");
            hChecker.IsAddHolidayNameToObservedHolidayName = false;

            bool actual = false;
            hChecker.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(HolidayChecker_ja_JP.IsAddHolidayNameToObservedHolidayName)) actual = true;
            };

            // act
            hChecker.IsAddHolidayNameToObservedHolidayName = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void IsAddHolidayNameToObservedHolidayName_SetValue_OccursHolidaySettingChangedEvent()
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");
            hChecker.IsAddHolidayNameToObservedHolidayName = false;

            bool actual = false;
            hChecker.HolidaySettingChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(HolidayChecker_ja_JP.IsAddHolidayNameToObservedHolidayName))
                {
                    if (e.OriginalEventArgs is PropertyChangedEventArgs eventArgs)
                    {
                        if (eventArgs.PropertyName == nameof(HolidayChecker_ja_JP.IsAddHolidayNameToObservedHolidayName)) actual = true;
                    }
                }
            };

            // act
            hChecker.IsAddHolidayNameToObservedHolidayName = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CustomHoliday_SetNull_ThrowsNoException()
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");

            // act
            // assert
            hChecker.CustomHoliday = null;

        }

        [Fact]
        public void CustomHoliday_SetTwice_ThrowsInvalidOperaionException()
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");
            hChecker.CustomHoliday = new CustomHoliday();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { hChecker.CustomHoliday = new CustomHoliday(); });
        }

        [Fact]
        public void CustomHoliday_SetNullAfterSetOnce_ThrowsInvalidOperaionException()
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");
            hChecker.CustomHoliday = new CustomHoliday();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { hChecker.CustomHoliday = null; });
        }

        [Fact]
        public void CustomHoliday_SetCustomHoliday_OccursPropertyChangedEvent()
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");

            bool actual = false;
            hChecker.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(HolidayChecker_ja_JP.CustomHoliday)) actual = true;
            };

            // act
            hChecker.CustomHoliday = new CustomHoliday();

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CustomHoliday_SetCustomHoliday_OccursHolidaySettingChangedEvent()
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");

            bool actual = false;
            hChecker.HolidaySettingChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(HolidayChecker_ja_JP.CustomHoliday))
                {
                    if (e.OriginalEventArgs is PropertyChangedEventArgs eventArgs)
                    {
                        if (eventArgs.PropertyName == nameof(HolidayChecker_ja_JP.CustomHoliday)) actual = true;
                    }
                }
            };

            // act
            hChecker.CustomHoliday = new CustomHoliday();

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CustomHoliday_OccuredHolidaySettingChangedEventOnCustomHolidayObject_OccursHolidaySettingChangedEvent()
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");
            var customHoliday = new CustomHoliday();
            hChecker.CustomHoliday = customHoliday;

            bool actual = false;
            hChecker.HolidaySettingChanged += (sender, e) =>
            {
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
            hChecker.CustomHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CustomHoliday_AddCustomHoliday_OccursHolidaySettingChangedEvent()
        {
            // arrange
            var hChecker = (HolidayChecker_ja_JP)HolidayChecker.GetHolidayChecker("ja-JP");
            hChecker.CustomHoliday = new CustomHoliday();
            hChecker.CustomHoliday.Holidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            bool actual = false;
            hChecker.HolidaySettingChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(CustomHoliday.Holidays))
                {
                    if (e.OriginalEventArgs is NotifyCollectionChangedEventArgs eventArgs)
                    {
                        if (eventArgs.Action == NotifyCollectionChangedAction.Add) actual = true;
                    }
                }
            };

            // act
            hChecker.CustomHoliday.Holidays.Add(new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 1), "HolidayName"));

            // assert
            Assert.True(actual);
        }
    }
}
