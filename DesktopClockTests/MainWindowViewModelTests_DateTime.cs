using System;
using System.Windows;
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
    public class MainWindowViewModelTests_DateTime
    {
        #region Dependency Injection
        /*
        [Fact]
        public void DateTimeEventSource_SetEventSource_StartEventSource()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeTimeSource = new FakeDateTimeEventSource();

            // act
            viewModel.DateTimeEventSource = fakeTimeSource;

            // assert
            Assert.True(fakeTimeSource.IsRunning);
        }
        */
        [Fact]
        public void DateTimeEventSource_SetOnceAfterSetNull_ThrowsNoException()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.DateTimeEventSource = null;

            // act
            // assert
            viewModel.DateTimeEventSource = new FakeDateTimeEventSource();

        }

        [Fact]
        public void DateTimeEventSource_SetTwice_ThrowsInvalidOperaionException()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.DateTimeEventSource = new FakeDateTimeEventSource();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { viewModel.DateTimeEventSource = new FakeDateTimeEventSource(); });
        }

        [Fact]
        public void DateTimeEventSource_SetNullAfterSetOnce_ThrowsInvalidOperaionException()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.DateTimeEventSource = new FakeDateTimeEventSource();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { viewModel.DateTimeEventSource = null; });
        }

        #endregion

        /*
        [Fact]
        public void Date_ChangeDay_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeTimeSource = new FakeDateTimeEventSource();
            fakeTimeSource.FakeDateTimeUpdate(new DateTime(2020, 1, 1));
            viewModel.DateTimeEventSource = fakeTimeSource;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.Date)) actual = true;
            };

            // act
            fakeTimeSource.FakeDateTimeUpdate(new DateTime(2020, 1, 2));

            // assert
            Assert.True(actual);
        }
        */
    }
}
