using System;
using System.Collections.Generic;
using System.Windows;
using DesktopClock.Library;
using Xunit;
using DesktopClockTests.FakeClasses;
using DesktopClockTests.TestDatas;

namespace DesktopClockTests
{
    public class SettingWindowViewModelTests
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

        [Fact]
        public void SettingWrapper_Set_LoadsSettings()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper() {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 1,
                IsPercentVertical = true,
                HorizontalMarginNumber = 2,
                IsPercentHorizontal = true,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.True(viewModel.AlignmentLeftTop);
            Assert.Equal("1", viewModel.VerticalMarginString);
            Assert.True(viewModel.VerticalMarginPercent);
            Assert.False(viewModel.VerticalMarginPixel);
            Assert.Equal("2", viewModel.HorizontalMarginString);
            Assert.True(viewModel.HorizontalMarginPercent);
            Assert.False(viewModel.HorizontalMarginPixel);
            Assert.Contains(new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 2), "HolidayName"), viewModel.CustomHolidaysDictionary);
        }

        [Fact]
        public void SettingWrapper_SetOnceAfterSetNull_ThrowsNoException()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            viewModel.SettingsWrapper = null;

            // act
            // assert
            viewModel.SettingsWrapper = new FakeSettingsWrapper();

        }

        [Fact]
        public void SettingWrapper_SetTwice_ThrowsInvalidOperaionException()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            viewModel.SettingsWrapper = new FakeSettingsWrapper();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { viewModel.SettingsWrapper = new FakeSettingsWrapper(); });
        }

        [Fact]
        public void SettingWrapper_SetNullAfterSetOnce_ThrowsInvalidOperaionException()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            viewModel.SettingsWrapper = new FakeSettingsWrapper();

            // act
            // assert
            Assert.Throws<InvalidOperationException>(() => { viewModel.SettingsWrapper = null; });
        }

        #endregion

        #region Alignment

        #region Occurs PropertyChanged

        [Fact]
        public void VerticalMarginString_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.VerticalMarginString)) actual = true;
            };

            // act
            viewModel.VerticalMarginString = "0";

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void VerticalMarginPercent_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.VerticalMarginPercent)) actual = true;
            };

            // act
            viewModel.VerticalMarginPercent = false;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void VerticalMarginPixel_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.VerticalMarginPixel)) actual = true;
            };

            // act
            viewModel.VerticalMarginPixel = false;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void HorizontalMarginString_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.HorizontalMarginString)) actual = true;
            };

            // act
            viewModel.HorizontalMarginString = "0";

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void HorizontalMarginPercent_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.HorizontalMarginPercent)) actual = true;
            };

            // act
            viewModel.HorizontalMarginPercent = false;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void HorizontalMarginPixel_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.HorizontalMarginPixel)) actual = true;
            };

            // act
            viewModel.HorizontalMarginPixel = false;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void AlignmentLeftTop_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.AlignmentLeftTop)) actual = true;
            };

            // act
            viewModel.AlignmentLeftTop = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void AlignmentCenterTop_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.AlignmentCenterTop)) actual = true;
            };

            // act
            viewModel.AlignmentCenterTop = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void AlignmentRightTop_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.AlignmentRightTop)) actual = true;
            };

            // act
            viewModel.AlignmentRightTop = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void AlignmentLeftCenter_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.AlignmentLeftCenter)) actual = true;
            };

            // act
            viewModel.AlignmentLeftCenter = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void AlignmentCenterCenter_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.AlignmentCenterCenter)) actual = true;
            };

            // act
            viewModel.AlignmentCenterCenter = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void AlignmentRightCenter_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.AlignmentRightCenter)) actual = true;
            };

            // act
            viewModel.AlignmentRightCenter = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void AlignmentLeftBottom_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.AlignmentLeftBottom)) actual = true;
            };

            // act
            viewModel.AlignmentLeftBottom = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void AlignmentCenterBottom_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.AlignmentCenterBottom)) actual = true;
            };

            // act
            viewModel.AlignmentCenterBottom = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void AlignmentRightBottom_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.AlignmentRightBottom)) actual = true;
            };

            // act
            viewModel.AlignmentRightBottom = true;

            // assert
            Assert.True(actual);
        }

        #endregion

        #region Load Alignment Properties
        /*
        [Fact]
        public void VerticalMargin_LoadedSetting_ReturnsSameValue()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalMargin = 1
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.Equal("1", viewModel.VerticalMarginString);
        }

        [Fact]
        public void HorizontalMargin_LoadedSetting_ReturnsSameValue()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                HorizontalMargin = 1
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.Equal("1", viewModel.HorizontalMarginString);
        }
        */
        [Fact]
        public void Alignment_LoadedLeftTopSetting_ReturnsLeftTop()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.True(viewModel.AlignmentLeftTop);
            Assert.False(viewModel.AlignmentCenterTop);
            Assert.False(viewModel.AlignmentRightTop);
            Assert.False(viewModel.AlignmentLeftCenter);
            Assert.False(viewModel.AlignmentCenterCenter);
            Assert.False(viewModel.AlignmentRightCenter);
            Assert.False(viewModel.AlignmentLeftBottom);
            Assert.False(viewModel.AlignmentCenterBottom);
            Assert.False(viewModel.AlignmentRightBottom);
        }

        [Fact]
        public void Alignment_LoadedCenterTopSetting_ReturnsCenterTop()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_CENTER
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.False(viewModel.AlignmentLeftTop);
            Assert.True(viewModel.AlignmentCenterTop);
            Assert.False(viewModel.AlignmentRightTop);
            Assert.False(viewModel.AlignmentLeftCenter);
            Assert.False(viewModel.AlignmentCenterCenter);
            Assert.False(viewModel.AlignmentRightCenter);
            Assert.False(viewModel.AlignmentLeftBottom);
            Assert.False(viewModel.AlignmentCenterBottom);
            Assert.False(viewModel.AlignmentRightBottom);
        }

        [Fact]
        public void Alignment_LoadedRightTopSetting_ReturnsRightTop()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_RIGHT
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.False(viewModel.AlignmentLeftTop);
            Assert.False(viewModel.AlignmentCenterTop);
            Assert.True(viewModel.AlignmentRightTop);
            Assert.False(viewModel.AlignmentLeftCenter);
            Assert.False(viewModel.AlignmentCenterCenter);
            Assert.False(viewModel.AlignmentRightCenter);
            Assert.False(viewModel.AlignmentLeftBottom);
            Assert.False(viewModel.AlignmentCenterBottom);
            Assert.False(viewModel.AlignmentRightBottom);
        }

        [Fact]
        public void Alignment_LoadedLeftCenterSetting_ReturnsLeftCenter()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_CENTER,
                HorizontalAlignment = HALIGN_LEFT
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.False(viewModel.AlignmentLeftTop);
            Assert.False(viewModel.AlignmentCenterTop);
            Assert.False(viewModel.AlignmentRightTop);
            Assert.True(viewModel.AlignmentLeftCenter);
            Assert.False(viewModel.AlignmentCenterCenter);
            Assert.False(viewModel.AlignmentRightCenter);
            Assert.False(viewModel.AlignmentLeftBottom);
            Assert.False(viewModel.AlignmentCenterBottom);
            Assert.False(viewModel.AlignmentRightBottom);
        }

        [Fact]
        public void Alignment_LoadedCenterCenterSetting_ReturnsCenterCenter()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_CENTER,
                HorizontalAlignment = HALIGN_CENTER
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.False(viewModel.AlignmentLeftTop);
            Assert.False(viewModel.AlignmentCenterTop);
            Assert.False(viewModel.AlignmentRightTop);
            Assert.False(viewModel.AlignmentLeftCenter);
            Assert.True(viewModel.AlignmentCenterCenter);
            Assert.False(viewModel.AlignmentRightCenter);
            Assert.False(viewModel.AlignmentLeftBottom);
            Assert.False(viewModel.AlignmentCenterBottom);
            Assert.False(viewModel.AlignmentRightBottom);
        }

        [Fact]
        public void Alignment_LoadedRightCenterSetting_ReturnsRightCenter()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_CENTER,
                HorizontalAlignment = HALIGN_RIGHT
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.False(viewModel.AlignmentLeftTop);
            Assert.False(viewModel.AlignmentCenterTop);
            Assert.False(viewModel.AlignmentRightTop);
            Assert.False(viewModel.AlignmentLeftCenter);
            Assert.False(viewModel.AlignmentCenterCenter);
            Assert.True(viewModel.AlignmentRightCenter);
            Assert.False(viewModel.AlignmentLeftBottom);
            Assert.False(viewModel.AlignmentCenterBottom);
            Assert.False(viewModel.AlignmentRightBottom);
        }

        [Fact]
        public void Alignment_LoadedLeftBottomSetting_ReturnsLeftBottom()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_BOTTOM,
                HorizontalAlignment = HALIGN_LEFT
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.False(viewModel.AlignmentLeftTop);
            Assert.False(viewModel.AlignmentCenterTop);
            Assert.False(viewModel.AlignmentRightTop);
            Assert.False(viewModel.AlignmentLeftCenter);
            Assert.False(viewModel.AlignmentCenterCenter);
            Assert.False(viewModel.AlignmentRightCenter);
            Assert.True(viewModel.AlignmentLeftBottom);
            Assert.False(viewModel.AlignmentCenterBottom);
            Assert.False(viewModel.AlignmentRightBottom);
        }

        [Fact]
        public void Alignment_LoadedCenterBottomSetting_ReturnsCenterBottom()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_BOTTOM,
                HorizontalAlignment = HALIGN_CENTER
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.False(viewModel.AlignmentLeftTop);
            Assert.False(viewModel.AlignmentCenterTop);
            Assert.False(viewModel.AlignmentRightTop);
            Assert.False(viewModel.AlignmentLeftCenter);
            Assert.False(viewModel.AlignmentCenterCenter);
            Assert.False(viewModel.AlignmentRightCenter);
            Assert.False(viewModel.AlignmentLeftBottom);
            Assert.True(viewModel.AlignmentCenterBottom);
            Assert.False(viewModel.AlignmentRightBottom);
        }

        [Fact]
        public void Alignment_LoadedRightBottomSetting_ReturnsRightBottom()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_BOTTOM,
                HorizontalAlignment = HALIGN_RIGHT
            };

            // act
            viewModel.SettingsWrapper = fakeSettings;

            // assert
            Assert.False(viewModel.AlignmentLeftTop);
            Assert.False(viewModel.AlignmentCenterTop);
            Assert.False(viewModel.AlignmentRightTop);
            Assert.False(viewModel.AlignmentLeftCenter);
            Assert.False(viewModel.AlignmentCenterCenter);
            Assert.False(viewModel.AlignmentRightCenter);
            Assert.False(viewModel.AlignmentLeftBottom);
            Assert.False(viewModel.AlignmentCenterBottom);
            Assert.True(viewModel.AlignmentRightBottom);
        }

        #endregion

        #endregion

        #region Custom Holiday Properties

        [Fact]
        public void CustomHolidayDate_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.CustomHolidayDate)) actual = true;
            };

            // act
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 1);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void CustomHolidayName_Set_OccursPropertyChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            var actual = false;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == nameof(SettingWindowViewModel.CustomHolidayName)) actual = true;
            };

            // act
            viewModel.CustomHolidayName = "HolidayName";

            // assert
            Assert.True(actual);
        }

        #endregion

        #region OK / Cancel / Apply Command 

        #region Cancel

        [Fact]
        public void CloseWindowCommand_Always_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            // act
            var actual = viewModel.CloseWindowCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        #endregion

        #region Apply

        #region CanExecute

        [Fact]
        public void ApplySettingsCommand_SettingsIsNoChanged_CanNotExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper() {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void ApplySettingsCommand_VerticalMarginSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.VerticalMarginString = "1";
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_VerticalMarginPercentSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.VerticalMarginPercent = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_VerticalMarginPixelSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.VerticalMarginPixel= false;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_HorizontalMarginSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.HorizontalMarginString = "1";
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_HorizontalMarginPercentSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.HorizontalMarginPercent = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_HorizontalMarginPixelSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.HorizontalMarginPixel = false;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_AlignmentLeftTopSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_CENTER,
                HorizontalAlignment = HALIGN_CENTER,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentLeftTop = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_AlignmentCenterTopSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentCenterTop = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_AlignmentRightTopSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentRightTop = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_AlignmentLeftCenterSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentLeftCenter = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_AlignmentCenterCenterSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentCenterCenter = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_AlignmentRightCenterSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentRightCenter = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_AlignmentLeftBottomSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentLeftBottom = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_AlignmentCenterBottomSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentCenterBottom = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_AlignmentRightBottomSettingsIsChanged_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentRightBottom = true;
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_AddCustomHoliday_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.CustomHolidaysDictionary.Add(new DateTime(2020, 1, 3), "HolidayName");
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_UpdateCustomHoliday_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.CustomHolidaysDictionary.Update(new DateTime(2020, 1, 2), "NewHolidayName");
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_RemoveCustomHoliday_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.CustomHolidaysDictionary.Remove(new DateTime(2020, 1, 2));
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_Executed_CanNotExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.VerticalMarginString = "1";

            // act
            viewModel.ApplySettingsCommand.Execute(null);
            var actual = viewModel.ApplySettingsCommand.CanExecute(null);

            // assert
            Assert.False(actual);
        }

        #endregion

        #region Execute

        [Fact]
        public void ApplySettingsCommand_Executed_InvokeSave()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            var actual = false;
            fakeSettings.FakeMethodCalled += (sender, e) => {
                if (e.MethodName == nameof(FakeSettingsWrapper.Save)) actual = true;
                return null;
            };

            // act
            viewModel.VerticalMarginString = "0";
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingsCommand_BeforeExecuted_ValuesNotChanged()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.VerticalMarginString = "1";
            viewModel.VerticalMarginPercent = true;
            viewModel.VerticalMarginPixel = false;
            viewModel.HorizontalMarginString = "2";
            viewModel.HorizontalMarginPercent = true;
            viewModel.HorizontalMarginPixel = false;
            viewModel.CustomHolidaysDictionary.Remove(new DateTime(2020, 1, 2));
            //viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(0, fakeSettings.VerticalMarginNumber);
            Assert.False(fakeSettings.IsPercentVertical);
            Assert.Equal(0, fakeSettings.HorizontalMarginNumber);
            Assert.False(fakeSettings.IsPercentHorizontal);
            Assert.Equal("{\"2020-01-02\":\"HolidayName\"}", fakeSettings.CustumHolidaysString);
        }

        [Fact]
        public void ApplySettingsCommand_Executed_ValuesChanged()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                IsPercentVertical = false,
                HorizontalMarginNumber = 0,
                IsPercentHorizontal = false,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.VerticalMarginString = "1";
            viewModel.VerticalMarginPercent = true;
            viewModel.VerticalMarginPixel = false;
            viewModel.HorizontalMarginString = "2";
            viewModel.HorizontalMarginPercent = true;
            viewModel.HorizontalMarginPixel = false;
            viewModel.CustomHolidaysDictionary.Remove(new DateTime(2020, 1, 2));
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(1, fakeSettings.VerticalMarginNumber);
            Assert.True(fakeSettings.IsPercentVertical);
            Assert.Equal(2, fakeSettings.HorizontalMarginNumber);
            Assert.True(fakeSettings.IsPercentHorizontal);
            Assert.Equal("{}", fakeSettings.CustumHolidaysString);
        }

        [Fact]
        public void ApplySettingsCommand_ExecutedWhenAlignmentLeftTop_SettingsIsLeftTop()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_CENTER,
                HorizontalAlignment = HALIGN_CENTER
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentCenterCenter = false;
            viewModel.AlignmentLeftTop = true;
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(VALIGN_TOP, fakeSettings.VerticalAlignment);
            Assert.Equal(HALIGN_LEFT, fakeSettings.HorizontalAlignment);
            Assert.Equal("{}", fakeSettings.CustumHolidaysString);
        }

        [Fact]
        public void ApplySettingsCommand_ExecutedWhenAlignmentCenterTop_SettingsIsCenterTop()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_CENTER,
                HorizontalAlignment = HALIGN_LEFT
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentLeftCenter = false;
            viewModel.AlignmentCenterTop = true;
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(VALIGN_TOP, fakeSettings.VerticalAlignment);
            Assert.Equal(HALIGN_CENTER, fakeSettings.HorizontalAlignment);
            Assert.Equal("{}", fakeSettings.CustumHolidaysString);
        }

        [Fact]
        public void ApplySettingsCommand_ExecutedWhenAlignmentRightTop_SettingsIsRightTop()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_CENTER,
                HorizontalAlignment = HALIGN_LEFT
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentLeftCenter = false;
            viewModel.AlignmentRightTop = true;
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(VALIGN_TOP, fakeSettings.VerticalAlignment);
            Assert.Equal(HALIGN_RIGHT, fakeSettings.HorizontalAlignment);
            Assert.Equal("{}", fakeSettings.CustumHolidaysString);
        }

        [Fact]
        public void ApplySettingsCommand_ExecutedWhenAlignmentLeftCenter_SettingsIsLeftCenter()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_CENTER
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentCenterTop = false;
            viewModel.AlignmentLeftCenter = true;
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(VALIGN_CENTER, fakeSettings.VerticalAlignment);
            Assert.Equal(HALIGN_LEFT, fakeSettings.HorizontalAlignment);
            Assert.Equal("{}", fakeSettings.CustumHolidaysString);
        }

        [Fact]
        public void ApplySettingsCommand_ExecutedWhenAlignmentCenterCenter_SettingsIsCenterCenter()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentCenterCenter = true;
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(VALIGN_CENTER, fakeSettings.VerticalAlignment);
            Assert.Equal(HALIGN_CENTER, fakeSettings.HorizontalAlignment);
            Assert.Equal("{}", fakeSettings.CustumHolidaysString);
        }

        [Fact]
        public void ApplySettingsCommand_ExecutedWhenAlignmentRightCenter_SettingsIsRightCenter()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentRightCenter = true;
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(VALIGN_CENTER, fakeSettings.VerticalAlignment);
            Assert.Equal(HALIGN_RIGHT, fakeSettings.HorizontalAlignment);
            Assert.Equal("{}", fakeSettings.CustumHolidaysString);
        }

        [Fact]
        public void ApplySettingsCommand_ExecutedWhenAlignmentLeftBottom_SettingsIsLeftBottom()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_CENTER
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentCenterTop = false;
            viewModel.AlignmentLeftBottom = true;
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(VALIGN_BOTTOM, fakeSettings.VerticalAlignment);
            Assert.Equal(HALIGN_LEFT, fakeSettings.HorizontalAlignment);
            Assert.Equal("{}", fakeSettings.CustumHolidaysString);
        }

        [Fact]
        public void ApplySettingsCommand_ExecutedWhenAlignmentCenterBottom_SettingsIsCenterBottom()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentCenterBottom = true;
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(VALIGN_BOTTOM, fakeSettings.VerticalAlignment);
            Assert.Equal(HALIGN_CENTER, fakeSettings.HorizontalAlignment);
            Assert.Equal("{}", fakeSettings.CustumHolidaysString);
        }

        [Fact]
        public void ApplySettingsCommand_ExecutedWhenAlignmentRightBottom_SettingsIsRightBottom()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT
            };
            viewModel.SettingsWrapper = fakeSettings;

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentRightBottom = true;
            viewModel.ApplySettingsCommand.Execute(null);

            // assert
            Assert.Equal(VALIGN_BOTTOM, fakeSettings.VerticalAlignment);
            Assert.Equal(HALIGN_RIGHT, fakeSettings.HorizontalAlignment);
            Assert.Equal("{}", fakeSettings.CustumHolidaysString);
        }

        #endregion

        #region CanExecuteChanged

        [Fact]
        public void ApplySettingCommand_ChangedVerticalMargin_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.VerticalMarginString = "1";

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_ChangedHorizontalMargin_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.HorizontalMarginString = "1";

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_ChangedAlignmentToLeftTop_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_CENTER,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.AlignmentCenterTop = false;
            viewModel.AlignmentLeftTop = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_ChangedAlignmentToCenterTop_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentCenterTop = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_ChangedAlignmentToRightTop_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentRightTop = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_ChangedAlignmentToLeftCenter_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentLeftCenter = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_ChangedAlignmentToCenterCenter_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentCenterCenter = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_ChangedAlignmentToRightCenter_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentRightCenter = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_ChangedAlignmentToLeftBottom_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentLeftBottom = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_ChangedAlignmentToCenterBottom_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentCenterBottom = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_ChangedAlignmentToRightBottom_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.AlignmentLeftTop = false;
            viewModel.AlignmentRightBottom = true;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_AddedCustomHoliday_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.CustomHolidaysDictionary.Add(new DateTime(2020, 1, 3), "HolidayName");

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_UpdatedCustomHolidayName_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.CustomHolidaysDictionary.Update(new DateTime(2020, 1, 2), "NewHolidayName");

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void ApplySettingCommand_RemovedCustomHoliday_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                VerticalAlignment = VALIGN_TOP,
                HorizontalAlignment = HALIGN_LEFT,
                VerticalMarginNumber = 0,
                HorizontalMarginNumber = 0,
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;

            bool actual = false;
            viewModel.ApplySettingsCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.CustomHolidaysDictionary.Remove(new DateTime(2020, 1, 2));

            // assert
            Assert.True(actual);
        }

        #endregion

        #endregion

        #region OK

        [Fact]
        public void ApplyAndCloseCommand_Always_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();

            // act
            var actual = viewModel.ApplyAndCloseCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        #endregion

        #endregion

        #region Add / Update / Remove Command

        #region Add

        #region CanExecute

        [Fact]
        public void AddHolidayCommand_DuplicateDateTime_CanNotExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper() {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "HolidayName";

            // act
            var actual = viewModel.AddHolidayCommand.CanExecute(null);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void AddHolidayCommand_HolidayNameIsEmpty_CanNotExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 3);
            viewModel.CustomHolidayName = String.Empty;

            // act
            var actual = viewModel.AddHolidayCommand.CanExecute(null);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void AddHolidayCommand_DateTimeIsDefault_CanNotExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = default;
            viewModel.CustomHolidayName = "HolidayName";

            // act
            var actual = viewModel.AddHolidayCommand.CanExecute(null);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void AddHolidayCommand_InOtherCase_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 3);
            viewModel.CustomHolidayName = "HolidayName";

            // act
            var actual = viewModel.AddHolidayCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        #endregion

        #region Execute

        [Fact]
        public void AddHolidayCommand_Executed_AddsHoliday()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 3);
            viewModel.CustomHolidayName = "HolidayName";

            // act
            viewModel.AddHolidayCommand.Execute(null);

            // assert
            Assert.Contains(
                    new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 3), "HolidayName"),
                    viewModel.CustomHolidaysDictionary);
        }

        #endregion

        #region CanExecuteChanged

        [Fact]
        public void AddHolidayCommand_ChangeDateTime_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 3);
            viewModel.CustomHolidayName = "NewHolidayName";

            bool actual = false;
            viewModel.AddHolidayCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.CustomHolidayDate = default;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void AddHolidayCommand_ChangeHolidayName_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 3);
            viewModel.CustomHolidayName = "NewHolidayName";

            bool actual = false;
            viewModel.AddHolidayCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.CustomHolidayName = String.Empty;

            // assert
            Assert.True(actual);
        }

        #endregion

        #endregion

        #region Update

        #region CanExecute

        [Fact]
        public void UpdateHolidayCommand_NotContainsDateTime_CanNotExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 3);
            viewModel.CustomHolidayName = "NewHolidayName";

            // act
            var actual = viewModel.UpdateHolidayCommand.CanExecute(null);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void UpdateHolidayCommand_HolidayNameIsEmpty_CanNotExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = String.Empty;

            // act
            var actual = viewModel.UpdateHolidayCommand.CanExecute(null);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void UpdateHolidayCommand_HolidayNameIsNotDifferent_CanNotExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "HolidayName";

            // act
            var actual = viewModel.UpdateHolidayCommand.CanExecute(null);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void UpdateHolidayCommand_InOtherCase_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "NewHolidayName";

            // act
            var actual = viewModel.UpdateHolidayCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        #endregion

        #region Execute

        [Fact]
        public void UpdateHolidayCommand_Executed_UpdatesHoliday()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "NewHolidayName";

            // act
            viewModel.UpdateHolidayCommand.Execute(null);

            // assert
            Assert.DoesNotContain(
                    new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 2), "HolidayName"),
                    viewModel.CustomHolidaysDictionary);
            Assert.Contains(
                    new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 2), "NewHolidayName"),
                    viewModel.CustomHolidaysDictionary);
        }

        #endregion

        #region CanExecuteChanged

        [Fact]
        public void UpdateHolidayCommand_ChangeDateTime_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "NewHolidayName";

            bool actual = false;
            viewModel.UpdateHolidayCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.CustomHolidayDate = default;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void UpdateHolidayCommand_ChangeHolidayName_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "NewHolidayName";

            bool actual = false;
            viewModel.UpdateHolidayCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.CustomHolidayName = String.Empty;

            // assert
            Assert.True(actual);
        }

        #endregion

        #endregion

        #region Remove

        #region CanExecute

        [Fact]
        public void RemoveHolidayCommand_NotContainsDateTime_CanNotExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 3);
            viewModel.CustomHolidayName = "HolidayName";

            // act
            var actual = viewModel.RemoveHolidayCommand.CanExecute(null);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void RemoveHolidayCommand_HolidayNameIsNotEqual_CanNotExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "OtherHolidayName";

            // act
            var actual = viewModel.RemoveHolidayCommand.CanExecute(null);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void RemoveHolidayCommand_InOtherCase_CanExecute()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "HolidayName";

            // act
            var actual = viewModel.RemoveHolidayCommand.CanExecute(null);

            // assert
            Assert.True(actual);
        }

        #endregion

        #region Execute

        [Fact]
        public void RemoveHolidayCommand_Executed_RemovesHoliday()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "HolidayName";

            // act
            viewModel.RemoveHolidayCommand.Execute(null);

            // assert
            Assert.DoesNotContain(
                    new KeyValuePair<DateTime, string>(new DateTime(2020, 1, 2), "HolidayName"),
                    viewModel.CustomHolidaysDictionary);
        }

        #endregion

        #region CanExecuteChanged

        [Fact]
        public void RemoveHolidayCommand_ChangeDateTime_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "HolidayName";

            bool actual = false;
            viewModel.RemoveHolidayCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.CustomHolidayDate = default;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void RemoveHolidayCommand_ChangeHolidayName_OccursCanExecuteChangedEvent()
        {
            // arrange
            var viewModel = new SettingWindowViewModel();
            var fakeSettings = new FakeSettingsWrapper()
            {
                CustumHolidaysString = "{\"2020-01-02\":\"HolidayName\"}"
            };
            viewModel.SettingsWrapper = fakeSettings;
            viewModel.CustomHolidayDate = new DateTime(2020, 1, 2);
            viewModel.CustomHolidayName = "HolidayName";

            bool actual = false;
            viewModel.RemoveHolidayCommand.CanExecuteChanged += (sender, e) => {
                actual = true;
            };

            // act
            viewModel.CustomHolidayName = String.Empty;

            // assert
            Assert.True(actual);
        }

        #endregion

        #endregion

        #endregion
    }
}
