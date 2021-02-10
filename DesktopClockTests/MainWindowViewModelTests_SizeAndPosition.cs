using System;
using System.Windows;
using DesktopClock.Library;
using Xunit;
using DesktopClockTests.FakeClasses;
using DesktopClockTests.TestDatas;

namespace DesktopClockTests
{
    public class MainWindowViewModelTests_SizeAndPosition
    {
        private const int VALIGN_TOP = (int)VerticalAlignment.Top; // 0
        private const int VALIGN_CENTER = (int)VerticalAlignment.Center; // 1
        private const int VALIGN_BOTTOM = (int)VerticalAlignment.Bottom; // 2
        private const int VALIGN_STRETCH = (int)VerticalAlignment.Stretch; // 3
        private const int HALIGN_LEFT = (int)HorizontalAlignment.Left; // 0
        private const int HALIGN_CENTER = (int)HorizontalAlignment.Center; // 1
        private const int HALIGN_RIGHT = (int)HorizontalAlignment.Right; // 2
        private const int HALIGN_STRETCH = (int)HorizontalAlignment.Stretch; // 3

        #region Dependency Injection
        /*
        [Fact]
        public void PrimaryScreenSizeEventSource_SetEventSource_StartEventSource()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeScreenSource = new FakePrimaryScreenSizeEventSource();

            // act
            viewModel.PrimaryScreenSizeEventSource = fakeScreenSource;

            // assert
            Assert.True(fakeScreenSource.IsRunning);
        }
        */
        [Fact]
        public void PrimaryScreenSizeEventSource_SetOnceAfterSetNull_ThrowsNoException()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.PrimaryScreenSizeEventSource = null;

            // act
            // assert
            viewModel.PrimaryScreenSizeEventSource = new FakePrimaryScreenSizeEventSource ();

        }

        [Fact]
        public void PrimaryScreenSizeEventSource_SetTwice_ThrowsInvalidOperaionException()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.PrimaryScreenSizeEventSource = new FakePrimaryScreenSizeEventSource();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { viewModel.PrimaryScreenSizeEventSource = new FakePrimaryScreenSizeEventSource(); });
        }

        [Fact]
        public void PrimaryScreenSizeEventSource_SetNullAfterSetOnce_ThrowsInvalidOperaionException()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.PrimaryScreenSizeEventSource = new FakePrimaryScreenSizeEventSource();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { viewModel.PrimaryScreenSizeEventSource = null; });
        }

        #endregion

        #region ScreenSize

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
            viewModel.PrimaryScreenSizeEventSource = fakeScreenSource;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.ScreenHeight)) actual = true;
            };

            // act
            fakeScreenSource.FakeScreenSizeUpdate(1, 0);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ScreenWidth_ChangedScreenWidth_SettedNewValue()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeScreenSource = new FakePrimaryScreenSizeEventSource();
            fakeScreenSource.FakeScreenSizeUpdate(0, 0);
            viewModel.PrimaryScreenSizeEventSource = fakeScreenSource;

            // act
            fakeScreenSource.FakeScreenSizeUpdate(0, 1);

            // assert
            Assert.Equal(1, viewModel.ScreenWidth);
        }

        [Fact]
        public void ScreenWidth_ChangedScreenWidth_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeScreenSource = new FakePrimaryScreenSizeEventSource();
            fakeScreenSource.FakeScreenSizeUpdate(0, 0);
            viewModel.PrimaryScreenSizeEventSource = fakeScreenSource;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.ScreenWidth)) actual = true;
            };

            // act
            fakeScreenSource.FakeScreenSizeUpdate(0, 1);
            
            // assert
            Assert.True(actual);
        }

        #endregion

        #region Alignment

        #region VerticalAlignment

        [Fact]
        public void VerticalAlignment_ChangedVerticalAlignmentSettingToTop_SettedTop()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.VerticalAlignment = VALIGN_CENTER;
            viewModel.SettingsWrapper = fakeSettings;

            // act
            fakeSettings.VerticalAlignment = VALIGN_TOP;


            // assert
            Assert.Equal(VerticalAlignment.Top, viewModel.VerticalAlignment);
        }

        [Fact]
        public void VerticalAlignment_ChangedVerticalAlignmentSettingToCenter_SettedCenter()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.VerticalAlignment = VALIGN_TOP;
            viewModel.SettingsWrapper = fakeSettings;

            // act
            fakeSettings.VerticalAlignment = VALIGN_CENTER;


            // assert
            Assert.Equal(VerticalAlignment.Center, viewModel.VerticalAlignment);
        }

        [Fact]
        public void VerticalAlignment_ChangedVerticalAlignmentSettingToBottom_SettedBottom()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.VerticalAlignment = VALIGN_TOP;
            viewModel.SettingsWrapper = fakeSettings;

            // act
            fakeSettings.VerticalAlignment = VALIGN_BOTTOM;


            // assert
            Assert.Equal(VerticalAlignment.Bottom, viewModel.VerticalAlignment);
        }

        [Fact]
        public void VerticalAlignment_ChangedVerticalAlignmentSetting_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.VerticalAlignment = VALIGN_TOP;
            viewModel.SettingsWrapper = fakeSettings;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.VerticalAlignment)) actual = true;
            };

            // act
            fakeSettings.VerticalAlignment = VALIGN_CENTER;

            // assert
            Assert.True(actual);
        }

        #endregion

        #region HorizontalAlignment

        [Fact]
        public void HorizontalAlignment_ChangedHorizontalAlignmentSettingToLeft_SettedTop()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.HorizontalAlignment = HALIGN_CENTER;
            viewModel.SettingsWrapper = fakeSettings;

            // act
            fakeSettings.HorizontalAlignment = HALIGN_LEFT;


            // assert
            Assert.Equal(HorizontalAlignment.Left, viewModel.HorizontalAlignment);
        }

        [Fact]
        public void HorizontalAlignment_ChangedHorizontalAlignmentSettingToCenter_SettedCenter()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.HorizontalAlignment = HALIGN_LEFT;
            viewModel.SettingsWrapper = fakeSettings;

            // act
            fakeSettings.HorizontalAlignment = HALIGN_CENTER;


            // assert
            Assert.Equal(HorizontalAlignment.Center, viewModel.HorizontalAlignment);
        }

        [Fact]
        public void HorizontalAlignment_ChangedHorizontalAlignmentSettingToRight_SettedBottom()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.HorizontalAlignment = HALIGN_LEFT;
            viewModel.SettingsWrapper = fakeSettings;

            // act
            fakeSettings.HorizontalAlignment = HALIGN_RIGHT;


            // assert
            Assert.Equal(HorizontalAlignment.Right, viewModel.HorizontalAlignment);
        }

        [Fact]
        public void HorizontalAlignment_ChangedHorizontalAlignmentSetting_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.HorizontalAlignment = HALIGN_LEFT;
            viewModel.SettingsWrapper = fakeSettings;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.HorizontalAlignment)) actual = true;
            };

            // act
            fakeSettings.HorizontalAlignment = HALIGN_CENTER;

            // assert
            Assert.True(actual);
        }

        #endregion
        
        #endregion

        #region Margin

        [Fact]
        public void VerticalMargin_ChangedVerticalMarginSetting_SettedValue()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.VerticalMarginNumber = 0;
            viewModel.SettingsWrapper = fakeSettings;

            // act
            fakeSettings.VerticalMarginNumber = 1;


            // assert
            Assert.Equal(1, viewModel.VerticalMargin);
        }

        [Fact]
        public void VerticalMargin_ChangedVerticalMarginSetting_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.VerticalMarginNumber = 0;
            viewModel.SettingsWrapper = fakeSettings;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.VerticalMargin)) actual = true;
            };

            // act
            fakeSettings.VerticalMarginNumber = 1;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void HorizontalMargin_ChangedHorizontalMarginSetting_SettedValue()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.HorizontalMarginNumber = 0;
            viewModel.SettingsWrapper = fakeSettings;

            // act
            fakeSettings.HorizontalMarginNumber = 1;


            // assert
            Assert.Equal(1, viewModel.HorizontalMargin);
        }

        [Fact]
        public void HorizontalMargin_ChangedHorizontalMarginSetting_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            var fakeSettings = new FakeSettingsWrapper();
            fakeSettings.HorizontalMarginNumber = 0;
            viewModel.SettingsWrapper = fakeSettings;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.HorizontalMargin)) actual = true;
            };

            // act
            fakeSettings.HorizontalMarginNumber = 1;

            // assert
            Assert.True(actual);
        }

        #endregion

        #region Size of Window

        #region Size of MainWindow

        [Fact]
        public void WindowHeight_ChangedWindowHeight_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.WindowHeight = 0;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.WindowHeight)) actual = true;
            };

            // act
            viewModel.WindowHeight = 1;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void WindowWidth_ChangedWindowWidth_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.WindowWidth = 0;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.WindowWidth)) actual = true;
            };

            // act
            viewModel.WindowWidth = 1;

            // assert
            Assert.True(actual);
        }

        #endregion

        #region Size of CalendarWindow

        [Fact]
        public void CalendarWindowHeight_ChangedCalendarWindowHeight_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.CalendarWindowHeight = 0;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.CalendarWindowHeight)) actual = true;
            };

            // act
            viewModel.CalendarWindowHeight = 1;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CalendarWindowWidth_ChangedCalendarWindowWidth_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.CalendarWindowWidth = 0;

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.CalendarWindowWidth)) actual = true;
            };

            // act
            viewModel.CalendarWindowWidth = 1;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CalendarWindowWidth_ChangedMainWindowWidth_EqualMainWindowWidth()
        {
            // arrange
            var viewModel = new MainWindowViewModel(null, null);
            viewModel.WindowWidth = 0;
            viewModel.CalendarWindowWidth = 0;

            // act
            viewModel.WindowWidth = 1;

            // assert
            Assert.Equal(1, viewModel.CalendarWindowWidth);
        }
        #endregion

        #endregion

        #region Position of Window

        /// <summary>
        /// スクリーン サイズ 1024x768、右下配置、垂直方向の余白 90、水平方向の余白 110 で初期化します。
        /// </summary>
        /// <param name="viewModel"><see cref="MainWindowViewModel" /></param>
        /// <param name="fakeScreenSource"><see cref="FakePrimaryScreenSizeEventSource" /></param>
        /// <param name="fakeSettings"><see cref="FakeSettingsWrapper" /></param>
        private static void WindowPositionTestSetting(out MainWindowViewModel viewModel, out FakePrimaryScreenSizeEventSource fakeScreenSource, out FakeSettingsWrapper fakeSettings)
        {
            viewModel = new MainWindowViewModel(null, null);
            fakeScreenSource = new FakePrimaryScreenSizeEventSource();
            fakeSettings = new FakeSettingsWrapper();
            viewModel.PrimaryScreenSizeEventSource = fakeScreenSource;
            viewModel.SettingsWrapper = fakeSettings;

            fakeScreenSource.FakeScreenSizeUpdate(768, 1024);

            fakeSettings.VerticalAlignment = VALIGN_BOTTOM;
            fakeSettings.HorizontalAlignment = HALIGN_RIGHT;
            fakeSettings.VerticalMarginNumber = 95;
            fakeSettings.IsPercentVertical = false;
            fakeSettings.HorizontalMarginNumber = 110;
            fakeSettings.IsPercentHorizontal = false;
        }

        [Fact]
        public void WindowTop_SetActualSizeAndSettings_ReturnsExpectedPosition()
        {
            // arrange
            // act
            WindowPositionTestSetting(out MainWindowViewModel viewModel, out FakePrimaryScreenSizeEventSource fakeScreenSource, out FakeSettingsWrapper fakeSettings);

            // assert
            Assert.Equal(638, viewModel.WindowTop);
            Assert.Equal(669, viewModel.CalendarWindowTop);
            Assert.Equal(879, viewModel.WindowLeft);
            Assert.Equal(879, viewModel.CalendarWindowLeft);
        }

        [Fact]
        public void WindowTop_SetActualSizeAndPercentSettings_ReturnsExpectedPosition()
        {
            // arrange
            // act
            WindowPositionTestSetting(out MainWindowViewModel viewModel, out FakePrimaryScreenSizeEventSource fakeScreenSource, out FakeSettingsWrapper fakeSettings);
            fakeSettings.VerticalMarginNumber = 6.25;
            fakeSettings.IsPercentVertical = true;
            fakeSettings.HorizontalMarginNumber = 4.5;
            fakeSettings.IsPercentHorizontal = true;

            // assert
            Assert.Equal(685, viewModel.WindowTop);
            Assert.Equal(716, viewModel.CalendarWindowTop);
            Assert.Equal(942.92, viewModel.WindowLeft);
            Assert.Equal(942.92, viewModel.CalendarWindowLeft);
        }

        [Fact]
        public void WindowTop_ChangedScreenHeight_OccursPropertyChangedEvent()
        {
            // arrange
            WindowPositionTestSetting(out MainWindowViewModel viewModel, out FakePrimaryScreenSizeEventSource fakeScreenSource, out FakeSettingsWrapper fakeSettings);

            var actual1 = false;
            var actual2 = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.WindowTop)) actual1 = true;
                if (e.PropertyName == nameof(MainWindowViewModel.CalendarWindowTop)) actual2 = true;
            };

            // act
            fakeScreenSource.FakeScreenSizeUpdate(768 ,1920);

            // assert
            Assert.True(actual1);
            Assert.True(actual2);
        }

        [Fact]
        public void WindowTop_ChangedVerticalAlignmentSetting_OccursPropertyChangedEvent()
        {
            // arrange
            WindowPositionTestSetting(out MainWindowViewModel viewModel, out FakePrimaryScreenSizeEventSource fakeScreenSource, out FakeSettingsWrapper fakeSettings);

            var actual1 = false;
            var actual2 = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.WindowTop)) actual1 = true;
                if (e.PropertyName == nameof(MainWindowViewModel.CalendarWindowTop)) actual2 = true;
            };

            // act
            fakeSettings.VerticalAlignment = VALIGN_TOP;

            // assert
            Assert.True(actual1);
            Assert.True(actual2);
        }

        [Fact]
        public void WindowTop_ChangedVerticalMarginSetting_OccursPropertyChangedEvent()
        {
            // arrange
            WindowPositionTestSetting(out MainWindowViewModel viewModel, out FakePrimaryScreenSizeEventSource fakeScreenSource, out FakeSettingsWrapper fakeSettings);

            var actual1 = false;
            var actual2 = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.WindowTop)) actual1 = true;
                if (e.PropertyName == nameof(MainWindowViewModel.CalendarWindowTop)) actual2 = true;
            };

            // act
            fakeSettings.VerticalMarginNumber = 91;

            // assert
            Assert.True(actual1);
            Assert.True(actual2);
        }

        [Fact]
        public void WindowLeft_SetActualSizeAndSettings_ReturnsExpectedPosition()
        {
            // arrange
            // act
            WindowPositionTestSetting(out MainWindowViewModel viewModel, out FakePrimaryScreenSizeEventSource fakeScreenSource, out FakeSettingsWrapper fakeSettings);

            // assert
            Assert.Equal(879, viewModel.WindowLeft);
            Assert.Equal(879, viewModel.CalendarWindowLeft);
        }

        [Fact]
        public void WindowLeft_ChangedScreenWidth_OccursPropertyChangedEvent()
        {
            // arrange
            WindowPositionTestSetting(out MainWindowViewModel viewModel, out FakePrimaryScreenSizeEventSource fakeScreenSource, out FakeSettingsWrapper fakeSettings);

            var actual1 = false;
            var actual2 = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.WindowLeft)) actual1 = true;
                if (e.PropertyName == nameof(MainWindowViewModel.CalendarWindowTop)) actual2 = true;
            };

            // act
            fakeScreenSource.FakeScreenSizeUpdate(1080, 1024);

            // assert
            Assert.True(actual1);
            Assert.True(actual2);
        }

        [Fact]
        public void WindowTop_ChangedHorizontalAlignmentSetting_OccursPropertyChangedEvent()
        {
            // arrange
            WindowPositionTestSetting(out MainWindowViewModel viewModel, out FakePrimaryScreenSizeEventSource fakeScreenSource, out FakeSettingsWrapper fakeSettings);

            var actual1 = false;
            var actual2 = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.WindowLeft)) actual1 = true;
                if (e.PropertyName == nameof(MainWindowViewModel.CalendarWindowTop)) actual2 = true;
            };

            // act
            fakeSettings.HorizontalAlignment = HALIGN_RIGHT;

            // assert
            Assert.True(actual1);
            Assert.True(actual2);
        }

        [Fact]
        public void WindowTop_ChangedHorizontalMarginSetting_OccursPropertyChangedEvent()
        {
            // arrange
            WindowPositionTestSetting(out MainWindowViewModel viewModel, out FakePrimaryScreenSizeEventSource fakeScreenSource, out FakeSettingsWrapper fakeSettings);

            var actual1 = false;
            var actual2 = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(MainWindowViewModel.WindowLeft)) actual1 = true;
                if (e.PropertyName == nameof(MainWindowViewModel.CalendarWindowTop)) actual2 = true;
            };

            // act
            fakeSettings.HorizontalMarginNumber = 91;

            // assert
            Assert.True(actual1);
            Assert.True(actual2);
        }

        #endregion
    }
}
