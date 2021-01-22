using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using NUnit.Framework;
using DesktopClock.Library;
using DesktopClockTests.TestDatas;
using DesktopClockTests.FakeClasses;

namespace DesktopClockTests
{
    public class MainWindowViewModelTests
    {
        /*
        [Fact]
        public void ScreenHeight_ChangedScreenHeight_SettedNewValue()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeScreenSource = new FakePrimaryScreenSizeEventSource();
            fakeScreenSource.FakeScreenSizeUpdate(0, 0);
            viewModel.PrimaryScreenSizeEventSource = fakeScreenSource;

            // act
            fakeScreenSource.FakeScreenSizeUpdate(1, 0);

            // assert
            Assert.Equal(1, viewModel.ScreenHeight);
        }

        [Fact]
        public void ScreenHeight_ChangedScreenHeight_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeScreenSource = new FakePrimaryScreenSizeEventSource();
            fakeScreenSource.FakeScreenSizeUpdate(0, 0);

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.ScreenHeight)) actual = true;
            };

            // act
            fakeScreenSource.FakeScreenSizeUpdate(1, 0);

            // assert
            Assert.True(actual);
        }
        //*/
    }
}
