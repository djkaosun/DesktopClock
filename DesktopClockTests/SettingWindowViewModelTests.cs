using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using NUnit.Framework;
using DesktopClock.Library;
using DesktopClockTests.FakeClasses;
using DesktopClockTests.TestDatas;

namespace DesktopClockTests
{
    public class SettingWindowViewModelTests
    {
        /*
        [Fact]
        public void ISettingWrapper_Set_LoadsSettings()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper() {
                VerticalAlignment = 0,
                HorizontalAlignment = 0,
                VerticalMargin = 1,
                HorizontalMargin = 2,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.Equal("1", viewModel.VerticalMarginString);
            Assert.Equal("2", viewModel.HorizontalMarginString);
            Assert.Contains(new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 2), "HolidayName"), viewModel.CustomHolidaysDictionary);
        }
        //*/
    }
}
