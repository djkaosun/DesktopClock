using System;
using System.ComponentModel;
using System.Windows.Input;
using DesktopClock.Library;

namespace DesktopClock.Library
{
    /// <summary>
    /// 時計ウィンドウ、および、カレンダー ウィンドウで使用する VeiwModel です。
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private const string ALREADY_SET_MESSAGE = "{0} is already set.";

        #region Properties for Binding

        private string _IndicatorString;
        /// <summary>
        /// テスト用。
        /// </summary>
        public string IndicatorString
        {
            get { return _IndicatorString; }
            set
            {
                _IndicatorString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IndicatorString)));
            }
        }

        #region Primary Screen Size

        private double _ScreenHeight;
        /// <summary>
        /// スクリーンの高さ。
        /// </summary>
        public double ScreenHeight
        {
            get { return _ScreenHeight; }
            private set
            {
                _ScreenHeight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScreenHeight)));
            }
        }

        private double _ScreenWidth;
        /// <summary>
        /// スクリーンの幅。
        /// </summary>
        public double ScreenWidth
        {
            get { return _ScreenWidth; }
            private set
            {
                _ScreenWidth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScreenWidth)));
            }
        }

        #endregion

        #region Window Alignment Settings

        private System.Windows.VerticalAlignment _VerticalAlignment;
        /// <summary>
        /// 時計ウィンドウの垂直方向の位置。Stretch の場合、Top として扱われます。
        /// </summary>
        public System.Windows.VerticalAlignment VerticalAlignment
        {
            get { return _VerticalAlignment; }
            set
            {
                _VerticalAlignment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerticalAlignment)));
            }
        }

        private System.Windows.HorizontalAlignment _HorizontalAlignment;
        /// <summary>
        /// 時計ウィンドウの水平方向の位置。Stretch の場合、Right として扱われます。
        /// </summary>
        public System.Windows.HorizontalAlignment HorizontalAlignment
        {
            get { return _HorizontalAlignment; }
            set
            {
                _HorizontalAlignment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HorizontalAlignment)));
            }
        }

        private double _VerticalMargin;
        /// <summary>
        /// 垂直方向のマージン。
        /// </summary>
        public double VerticalMargin
        {
            get { return _VerticalMargin; }
            set
            {
                _VerticalMargin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerticalMargin)));
            }
        }

        private double _HorizontalMargin;
        /// <summary>
        /// 水平方向のマージン。
        /// </summary>
        public double HorizontalMargin
        {
            get { return _HorizontalMargin; }
            set
            {
                _HorizontalMargin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HorizontalMargin)));
            }
        }

        #endregion

        #region MainWindow's Size and Position

        private double _WindowHeight;
        /// <summary>
        /// 時計ウィンドウの高さ。
        /// </summary>
        public double WindowHeight
        {
            get { return _WindowHeight; }
            set
            {
                _WindowHeight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WindowHeight)));
            }
        }

        private double _WindowWidth;
        /// <summary>
        /// 時計ウィンドウの幅。
        /// </summary>
        public double WindowWidth
        {
            get { return _WindowWidth; }
            set
            {
                _WindowWidth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WindowWidth)));
            }
        }

        private double _WindowTop;
        /// <summary>
        /// 時計ウィンドウの上端の位置。
        /// </summary>
        public double WindowTop
        {
            get { return _WindowTop; }
            set
            {
                _WindowTop = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WindowTop)));
            }
        }

        private double _WindowLeft;
        /// <summary>
        /// 時計ウィンドウの左端の位置。
        /// </summary>
        public double WindowLeft
        {
            get { return _WindowLeft; }
            set
            {
                _WindowLeft = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WindowLeft)));
            }
        }

        #endregion

        #region CalendarWindow's Size and Position

        private double _CalendarWindowHeight;
        /// <summary>
        /// カレンダー ウィンドウの高さ。
        /// </summary>
        public double CalendarWindowHeight
        {
            get { return _CalendarWindowHeight; }
            set
            {
                _CalendarWindowHeight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CalendarWindowHeight)));
            }
        }

        private double _CalendarWindowWidth;
        /// <summary>
        /// カレンダー ウィンドウの幅。
        /// </summary>
        public double CalendarWindowWidth
        {
            get { return _CalendarWindowWidth; }
            set
            {
                _CalendarWindowWidth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CalendarWindowWidth)));
            }
        }

        private double _CalendarWindowTop;
        /// <summary>
        /// カレンダー ウィンドウの上端の位置。
        /// </summary>
        public double CalendarWindowTop
        {
            get { return _CalendarWindowTop; }
            set
            {
                _CalendarWindowTop = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CalendarWindowTop)));
            }
        }

        private double _CalendarWindowLeft;
        /// <summary>
        /// カレンダー ウィンドウの左端の位置。
        /// </summary>
        public double CalendarWindowLeft
        {
            get { return _CalendarWindowLeft; }
            set
            {
                _CalendarWindowLeft = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CalendarWindowLeft)));
            }
        }

        #endregion

        #region DateTime Information String 

        private string _Date;
        /// <summary>
        /// 日付を示す文字列。「yyyy 年 MM 月 dd 日」
        /// </summary>
        public string Date
        {
            get { return _Date; }
            private set
            {
                _Date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date)));
            }
        }

        private string _DayOfWeek;
        /// <summary>
        /// 曜日を示す文字列。「□曜日」
        /// </summary>
        public string DayOfWeek
        {
            get { return _DayOfWeek; }
            private set
            {
                _DayOfWeek = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DayOfWeek)));
            }
        }

        private string _Hour0;
        /// <summary>
        /// 時の十の位。
        /// </summary>
        public string Hour0
        {
            get { return _Hour0; }
            private set
            {
                _Hour0 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Hour0)));
            }
        }

        private string _Hour1;
        /// <summary>
        /// 時の一の位。
        /// </summary>
        public string Hour1
        {
            get { return _Hour1; }
            private set
            {
                _Hour1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Hour1)));
            }
        }

        private string _Minute0;
        /// <summary>
        /// 分の十の位。
        /// </summary>
        public string Minute0
        {
            get { return _Minute0; }
            private set
            {
                _Minute0 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Minute0)));
            }
        }

        private string _Minute1;
        /// <summary>
        /// 分の一の位。
        /// </summary>
        public string Minute1
        {
            get { return _Minute1; }
            private set
            {
                _Minute1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Minute1)));
            }
        }

        private string _HolidayNameOfToday;
        /// <summary>
        /// 本日の休日名。
        /// </summary>
        public string HolidayNameOfToday
        {
            get { return _HolidayNameOfToday; }
            private set
            {
                _HolidayNameOfToday = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HolidayNameOfToday)));
            }
        }

        private string _HolidayNameOfTommorow;
        /// <summary>
        /// 明日の休日名。
        /// </summary>
        public string HolidayNameOfTommorow
        {
            get { return _HolidayNameOfTommorow; }
            private set
            {
                _HolidayNameOfTommorow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HolidayNameOfTommorow)));
            }
        }

        #endregion

        #region Information Visibilities

        private System.Windows.Visibility _VisibilityOfToday;
        /// <summary>
        /// 今日の情報の表示有無。
        /// </summary>
        public System.Windows.Visibility VisibilityOfToday
        {
            get { return _VisibilityOfToday; }
            private set
            {
                _VisibilityOfToday = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibilityOfToday)));
            }
        }

        private System.Windows.Visibility _VisibilityOfTommorow;
        /// <summary>
        /// 明日の情報の表示有無。
        /// </summary>
        public System.Windows.Visibility VisibilityOfTommorow
        {
            get { return _VisibilityOfTommorow; }
            private set
            {
                _VisibilityOfTommorow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibilityOfTommorow)));
            }
        }

        private string _ConsecutiveHolidaysMessage;
        /// <summary>
        /// 連休情報。
        /// </summary>
        public string ConsecutiveHolidaysMessage
        {
            get { return _ConsecutiveHolidaysMessage; }
            set
            {
                _ConsecutiveHolidaysMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConsecutiveHolidaysMessage)));
            }
        }
        private System.Windows.Visibility _VisibilityOfConsecutiveHolidays;
        /// <summary>
        /// 連休情報の表示有無。
        /// </summary>
        public System.Windows.Visibility VisibilityOfConsecutiveHolidays
        {
            get { return _VisibilityOfConsecutiveHolidays; }
            set
            {
                _VisibilityOfConsecutiveHolidays = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibilityOfConsecutiveHolidays)));
            }
        }

        #endregion

        #region Color of Today and Tommorw

        private System.Windows.Media.Brush _ColorOfToday;
        /// <summary>
        /// 今日の色。
        /// </summary>
        public System.Windows.Media.Brush ColorOfToday
        {
            get { return _ColorOfToday; }
            private set
            {
                _ColorOfToday = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorOfToday)));
            }
        }

        private System.Windows.Media.Brush _ColorOfTommorow;
        /// <summary>
        /// 明日の色。
        /// </summary>
        public System.Windows.Media.Brush ColorOfTommorow
        {
            get { return _ColorOfTommorow; }
            private set
            {
                _ColorOfTommorow = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorOfTommorow)));
            }
        }

        #endregion

        #region Date Properties for CalendarWindow

        private string _CalendarYearAndMonth;
        /// <summary>
        /// カレンダーに表示する年と月を表す文字列。
        /// </summary>
        public string CalendarYearAndMonth
        {
            get
            {
                return _CalendarYearAndMonth;
            }
            set
            {
                _CalendarYearAndMonth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CalendarYearAndMonth)));
            }
        }


        #region Number
        private string[,] _CalendarNumbers = new string[6,7];

        /// <summary>カレンダーに表示する日付。(以下略)</summary>
        public string CalendarR0C0Number { get { return _CalendarNumbers[0, 0]; } }
        /// <summary></summary>
        public string CalendarR0C1Number { get { return _CalendarNumbers[0, 1]; } }
        /// <summary></summary>
        public string CalendarR0C2Number { get { return _CalendarNumbers[0, 2]; } }
        /// <summary></summary>
        public string CalendarR0C3Number { get { return _CalendarNumbers[0, 3]; } }
        /// <summary></summary>
        public string CalendarR0C4Number { get { return _CalendarNumbers[0, 4]; } }
        /// <summary></summary>
        public string CalendarR0C5Number { get { return _CalendarNumbers[0, 5]; } }
        /// <summary></summary>
        public string CalendarR0C6Number { get { return _CalendarNumbers[0, 6]; } }
        /// <summary></summary>
        public string CalendarR1C0Number { get { return _CalendarNumbers[1, 0]; } }
        /// <summary></summary>
        public string CalendarR1C1Number { get { return _CalendarNumbers[1, 1]; } }
        /// <summary></summary>
        public string CalendarR1C2Number { get { return _CalendarNumbers[1, 2]; } }
        /// <summary></summary>
        public string CalendarR1C3Number { get { return _CalendarNumbers[1, 3]; } }
        /// <summary></summary>
        public string CalendarR1C4Number { get { return _CalendarNumbers[1, 4]; } }
        /// <summary></summary>
        public string CalendarR1C5Number { get { return _CalendarNumbers[1, 5]; } }
        /// <summary></summary>
        public string CalendarR1C6Number { get { return _CalendarNumbers[1, 6]; } }
        /// <summary></summary>
        public string CalendarR2C0Number { get { return _CalendarNumbers[2, 0]; } }
        /// <summary></summary>
        public string CalendarR2C1Number { get { return _CalendarNumbers[2, 1]; } }
        /// <summary></summary>
        public string CalendarR2C2Number { get { return _CalendarNumbers[2, 2]; } }
        /// <summary></summary>
        public string CalendarR2C3Number { get { return _CalendarNumbers[2, 3]; } }
        /// <summary></summary>
        public string CalendarR2C4Number { get { return _CalendarNumbers[2, 4]; } }
        /// <summary></summary>
        public string CalendarR2C5Number { get { return _CalendarNumbers[2, 5]; } }
        /// <summary></summary>
        public string CalendarR2C6Number { get { return _CalendarNumbers[2, 6]; } }
        /// <summary></summary>
        public string CalendarR3C0Number { get { return _CalendarNumbers[3, 0]; } }
        /// <summary></summary>
        public string CalendarR3C1Number { get { return _CalendarNumbers[3, 1]; } }
        /// <summary></summary>
        public string CalendarR3C2Number { get { return _CalendarNumbers[3, 2]; } }
        /// <summary></summary>
        public string CalendarR3C3Number { get { return _CalendarNumbers[3, 3]; } }
        /// <summary></summary>
        public string CalendarR3C4Number { get { return _CalendarNumbers[3, 4]; } }
        /// <summary></summary>
        public string CalendarR3C5Number { get { return _CalendarNumbers[3, 5]; } }
        /// <summary></summary>
        public string CalendarR3C6Number { get { return _CalendarNumbers[3, 6]; } }
        /// <summary></summary>
        public string CalendarR4C0Number { get { return _CalendarNumbers[4, 0]; } }
        /// <summary></summary>
        public string CalendarR4C1Number { get { return _CalendarNumbers[4, 1]; } }
        /// <summary></summary>
        public string CalendarR4C2Number { get { return _CalendarNumbers[4, 2]; } }
        /// <summary></summary>
        public string CalendarR4C3Number { get { return _CalendarNumbers[4, 3]; } }
        /// <summary></summary>
        public string CalendarR4C4Number { get { return _CalendarNumbers[4, 4]; } }
        /// <summary></summary>
        public string CalendarR4C5Number { get { return _CalendarNumbers[4, 5]; } }
        /// <summary></summary>
        public string CalendarR4C6Number { get { return _CalendarNumbers[4, 6]; } }
        /// <summary></summary>
        public string CalendarR5C0Number { get { return _CalendarNumbers[5, 0]; } }
        /// <summary></summary>
        public string CalendarR5C1Number { get { return _CalendarNumbers[5, 1]; } }
        /// <summary></summary>
        public string CalendarR5C2Number { get { return _CalendarNumbers[5, 2]; } }
        /// <summary></summary>
        public string CalendarR5C3Number { get { return _CalendarNumbers[5, 3]; } }
        /// <summary></summary>
        public string CalendarR5C4Number { get { return _CalendarNumbers[5, 4]; } }
        /// <summary></summary>
        public string CalendarR5C5Number { get { return _CalendarNumbers[5, 5]; } }
        /// <summary></summary>
        public string CalendarR5C6Number { get { return _CalendarNumbers[5, 6]; } }
        #endregion
        #region Foreground
        private System.Windows.Media.Brush[,] _CalendarForegrounds = new System.Windows.Media.Brush[6, 7];

        /// <summary>カレンダーに表示する日付のフォント色。(以下略)</summary>
        public System.Windows.Media.Brush CalendarR0C0Foreground { get { return _CalendarForegrounds[0, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C1Foreground { get { return _CalendarForegrounds[0, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C2Foreground { get { return _CalendarForegrounds[0, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C3Foreground { get { return _CalendarForegrounds[0, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C4Foreground { get { return _CalendarForegrounds[0, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C5Foreground { get { return _CalendarForegrounds[0, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C6Foreground { get { return _CalendarForegrounds[0, 6]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C0Foreground { get { return _CalendarForegrounds[1, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C1Foreground { get { return _CalendarForegrounds[1, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C2Foreground { get { return _CalendarForegrounds[1, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C3Foreground { get { return _CalendarForegrounds[1, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C4Foreground { get { return _CalendarForegrounds[1, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C5Foreground { get { return _CalendarForegrounds[1, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C6Foreground { get { return _CalendarForegrounds[1, 6]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C0Foreground { get { return _CalendarForegrounds[2, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C1Foreground { get { return _CalendarForegrounds[2, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C2Foreground { get { return _CalendarForegrounds[2, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C3Foreground { get { return _CalendarForegrounds[2, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C4Foreground { get { return _CalendarForegrounds[2, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C5Foreground { get { return _CalendarForegrounds[2, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C6Foreground { get { return _CalendarForegrounds[2, 6]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C0Foreground { get { return _CalendarForegrounds[3, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C1Foreground { get { return _CalendarForegrounds[3, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C2Foreground { get { return _CalendarForegrounds[3, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C3Foreground { get { return _CalendarForegrounds[3, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C4Foreground { get { return _CalendarForegrounds[3, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C5Foreground { get { return _CalendarForegrounds[3, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C6Foreground { get { return _CalendarForegrounds[3, 6]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C0Foreground { get { return _CalendarForegrounds[4, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C1Foreground { get { return _CalendarForegrounds[4, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C2Foreground { get { return _CalendarForegrounds[4, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C3Foreground { get { return _CalendarForegrounds[4, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C4Foreground { get { return _CalendarForegrounds[4, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C5Foreground { get { return _CalendarForegrounds[4, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C6Foreground { get { return _CalendarForegrounds[4, 6]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C0Foreground { get { return _CalendarForegrounds[5, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C1Foreground { get { return _CalendarForegrounds[5, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C2Foreground { get { return _CalendarForegrounds[5, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C3Foreground { get { return _CalendarForegrounds[5, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C4Foreground { get { return _CalendarForegrounds[5, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C5Foreground { get { return _CalendarForegrounds[5, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C6Foreground { get { return _CalendarForegrounds[5, 6]; } }
        #endregion
        #region Background
        private System.Windows.Media.Brush[,] _CalendarBackgrounds = new System.Windows.Media.Brush[6, 7];

        /// <summary>カレンダーに表示する日付の背景色。(以下略)</summary>
        public System.Windows.Media.Brush CalendarR0C0Background { get { return _CalendarBackgrounds[0, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C1Background { get { return _CalendarBackgrounds[0, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C2Background { get { return _CalendarBackgrounds[0, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C3Background { get { return _CalendarBackgrounds[0, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C4Background { get { return _CalendarBackgrounds[0, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C5Background { get { return _CalendarBackgrounds[0, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR0C6Background { get { return _CalendarBackgrounds[0, 6]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C0Background { get { return _CalendarBackgrounds[1, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C1Background { get { return _CalendarBackgrounds[1, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C2Background { get { return _CalendarBackgrounds[1, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C3Background { get { return _CalendarBackgrounds[1, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C4Background { get { return _CalendarBackgrounds[1, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C5Background { get { return _CalendarBackgrounds[1, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR1C6Background { get { return _CalendarBackgrounds[1, 6]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C0Background { get { return _CalendarBackgrounds[2, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C1Background { get { return _CalendarBackgrounds[2, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C2Background { get { return _CalendarBackgrounds[2, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C3Background { get { return _CalendarBackgrounds[2, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C4Background { get { return _CalendarBackgrounds[2, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C5Background { get { return _CalendarBackgrounds[2, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR2C6Background { get { return _CalendarBackgrounds[2, 6]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C0Background { get { return _CalendarBackgrounds[3, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C1Background { get { return _CalendarBackgrounds[3, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C2Background { get { return _CalendarBackgrounds[3, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C3Background { get { return _CalendarBackgrounds[3, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C4Background { get { return _CalendarBackgrounds[3, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C5Background { get { return _CalendarBackgrounds[3, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR3C6Background { get { return _CalendarBackgrounds[3, 6]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C0Background { get { return _CalendarBackgrounds[4, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C1Background { get { return _CalendarBackgrounds[4, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C2Background { get { return _CalendarBackgrounds[4, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C3Background { get { return _CalendarBackgrounds[4, 3]; } }
        /// <summary></summary>
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C4Background { get { return _CalendarBackgrounds[4, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C5Background { get { return _CalendarBackgrounds[4, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR4C6Background { get { return _CalendarBackgrounds[4, 6]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C0Background { get { return _CalendarBackgrounds[5, 0]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C1Background { get { return _CalendarBackgrounds[5, 1]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C2Background { get { return _CalendarBackgrounds[5, 2]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C3Background { get { return _CalendarBackgrounds[5, 3]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C4Background { get { return _CalendarBackgrounds[5, 4]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C5Background { get { return _CalendarBackgrounds[5, 5]; } }
        /// <summary></summary>
        public System.Windows.Media.Brush CalendarR5C6Background { get { return _CalendarBackgrounds[5, 6]; } }
        #endregion
        #region Opacity
        private double[,] _CalendarOpacities = new double[6,7];

        /// <summary>カレンダーに表示する日付の不透明度。(以下略)</summary>
        public double CalendarR0C0Opacity { get { return _CalendarOpacities[0, 0]; } }
        /// <summary></summary>
        public double CalendarR0C1Opacity { get { return _CalendarOpacities[0, 1]; } }
        /// <summary></summary>
        public double CalendarR0C2Opacity { get { return _CalendarOpacities[0, 2]; } }
        /// <summary></summary>
        public double CalendarR0C3Opacity { get { return _CalendarOpacities[0, 3]; } }
        /// <summary></summary>
        public double CalendarR0C4Opacity { get { return _CalendarOpacities[0, 4]; } }
        /// <summary></summary>
        public double CalendarR0C5Opacity { get { return _CalendarOpacities[0, 5]; } }
        /// <summary></summary>
        public double CalendarR0C6Opacity { get { return _CalendarOpacities[0, 6]; } }
        /// <summary></summary>
        public double CalendarR1C0Opacity { get { return _CalendarOpacities[1, 0]; } }
        /// <summary></summary>
        public double CalendarR1C1Opacity { get { return _CalendarOpacities[1, 1]; } }
        /// <summary></summary>
        public double CalendarR1C2Opacity { get { return _CalendarOpacities[1, 2]; } }
        /// <summary></summary>
        public double CalendarR1C3Opacity { get { return _CalendarOpacities[1, 3]; } }
        /// <summary></summary>
        public double CalendarR1C4Opacity { get { return _CalendarOpacities[1, 4]; } }
        /// <summary></summary>
        public double CalendarR1C5Opacity { get { return _CalendarOpacities[1, 5]; } }
        /// <summary></summary>
        public double CalendarR1C6Opacity { get { return _CalendarOpacities[1, 6]; } }
        /// <summary></summary>
        public double CalendarR2C0Opacity { get { return _CalendarOpacities[2, 0]; } }
        /// <summary></summary>
        public double CalendarR2C1Opacity { get { return _CalendarOpacities[2, 1]; } }
        /// <summary></summary>
        public double CalendarR2C2Opacity { get { return _CalendarOpacities[2, 2]; } }
        /// <summary></summary>
        public double CalendarR2C3Opacity { get { return _CalendarOpacities[2, 3]; } }
        /// <summary></summary>
        public double CalendarR2C4Opacity { get { return _CalendarOpacities[2, 4]; } }
        /// <summary></summary>
        public double CalendarR2C5Opacity { get { return _CalendarOpacities[2, 5]; } }
        /// <summary></summary>
        public double CalendarR2C6Opacity { get { return _CalendarOpacities[2, 6]; } }
        /// <summary></summary>
        public double CalendarR3C0Opacity { get { return _CalendarOpacities[3, 0]; } }
        /// <summary></summary>
        public double CalendarR3C1Opacity { get { return _CalendarOpacities[3, 1]; } }
        /// <summary></summary>
        public double CalendarR3C2Opacity { get { return _CalendarOpacities[3, 2]; } }
        /// <summary></summary>
        public double CalendarR3C3Opacity { get { return _CalendarOpacities[3, 3]; } }
        /// <summary></summary>
        public double CalendarR3C4Opacity { get { return _CalendarOpacities[3, 4]; } }
        /// <summary></summary>
        public double CalendarR3C5Opacity { get { return _CalendarOpacities[3, 5]; } }
        /// <summary></summary>
        public double CalendarR3C6Opacity { get { return _CalendarOpacities[3, 6]; } }
        /// <summary></summary>
        public double CalendarR4C0Opacity { get { return _CalendarOpacities[4, 0]; } }
        /// <summary></summary>
        public double CalendarR4C1Opacity { get { return _CalendarOpacities[4, 1]; } }
        /// <summary></summary>
        public double CalendarR4C2Opacity { get { return _CalendarOpacities[4, 2]; } }
        /// <summary></summary>
        public double CalendarR4C3Opacity { get { return _CalendarOpacities[4, 3]; } }
        /// <summary></summary>
        public double CalendarR4C4Opacity { get { return _CalendarOpacities[4, 4]; } }
        /// <summary></summary>
        public double CalendarR4C5Opacity { get { return _CalendarOpacities[4, 5]; } }
        /// <summary></summary>
        public double CalendarR4C6Opacity { get { return _CalendarOpacities[4, 6]; } }
        /// <summary></summary>
        public double CalendarR5C0Opacity { get { return _CalendarOpacities[5, 0]; } }
        /// <summary></summary>
        public double CalendarR5C1Opacity { get { return _CalendarOpacities[5, 1]; } }
        /// <summary></summary>
        public double CalendarR5C2Opacity { get { return _CalendarOpacities[5, 2]; } }
        /// <summary></summary>
        public double CalendarR5C3Opacity { get { return _CalendarOpacities[5, 3]; } }
        /// <summary></summary>
        public double CalendarR5C4Opacity { get { return _CalendarOpacities[5, 4]; } }
        /// <summary></summary>
        public double CalendarR5C5Opacity { get { return _CalendarOpacities[5, 5]; } }
        /// <summary></summary>
        public double CalendarR5C6Opacity { get { return _CalendarOpacities[5, 6]; } }
        #endregion

        #endregion

        #endregion

        #region Color Settings

        /// <summary>
        /// 休日の色。
        /// </summary>
        public System.Windows.Media.Brush HolidayColor
        {
            get { return System.Windows.Media.Brushes.PaleVioletRed; }
        }

        /// <summary>
        /// 土曜日の色。
        /// </summary>
        public System.Windows.Media.Brush SaturdayColor
        {
            get { return System.Windows.Media.Brushes.SkyBlue; }
        }

        /// <summary>
        /// 平日の色。
        /// </summary>
        public System.Windows.Media.Brush NormalColor
        {
            get { return System.Windows.Media.Brushes.White; }
        }

        #endregion

        #region Commands

        /// <summary>
        /// 先月に戻るコマンド。
        /// </summary>
        public ICommand PreviousMonthCommand { get; private set; }
        private class PreviousMonthCommandImpl : ICommand
        {
            private MainWindowViewModel viewModel;
            public PreviousMonthCommandImpl(MainWindowViewModel viewModel)
            {
                this.viewModel = viewModel;
                viewModel.PropertyChanged += OnViewModelPropertyChangedEventHandler;
            }

            private void OnViewModelPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case nameof(viewModel.CalendarYear):
                    case nameof(viewModel.CalendarMonth):
                        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                        break;
                }
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                if (viewModel.CalendarYear == 0 || viewModel.CalendarMonth == 0) return false;

                // HolidayChecker が祝日法の施行 (1948 年 7 月 20 日) 以降にのみ対応のため、
                // カレンダー表示は1948 年 8 月 まで。
                var year = viewModel.CalendarYear;
                var month = viewModel.CalendarMonth;
                return (year > 1948 || year == 1948 && month > 7);
            }

            public void Execute(object parameter)
            {
                var month = viewModel.CalendarMonth;
                if (month == 1)
                {
                    var year = viewModel.CalendarYear;
                    viewModel.CalendarYear = year - 1;
                    viewModel.CalendarMonth = 12;
                }
                else
                {
                    viewModel.CalendarMonth = month - 1;
                }
            }
        }

        /// <summary>
        /// 来月に進むコマンド。
        /// </summary>
        public ICommand NextMonthCommand { get; private set; }
        private class NextMonthCommandImpl : ICommand
        {
            private MainWindowViewModel viewModel;
            public NextMonthCommandImpl(MainWindowViewModel viewModel)
            {
                this.viewModel = viewModel;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                var month = viewModel.CalendarMonth;
                if (month == 12)
                {
                    var year = viewModel.CalendarYear;
                    viewModel.CalendarYear = year + 1;
                    viewModel.CalendarMonth = 1;
                }
                else
                {
                    viewModel.CalendarMonth = month + 1;
                }
            }
        }

        /// <summary>
        /// 今月に飛ぶコマンド。
        /// </summary>
        public ICommand ThisMonthCommand { get; private set; }
        private class ThisMonthCommandImpl : ICommand
        {
            private MainWindowViewModel viewModel;
            public ThisMonthCommandImpl(MainWindowViewModel viewModel)
            {
                this.viewModel = viewModel;
                viewModel.PropertyChanged += OnViewModelPropertyChangedEventHandler;
            }

            private void OnViewModelPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case nameof(viewModel.CalendarYear):
                    case nameof(viewModel.CalendarMonth):
                        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                        break;
                }
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                if (viewModel.CalendarYear == 0 || viewModel.CalendarMonth == 0) return false;

                var today = DateTime.Today;
                return today.Year != viewModel.CalendarYear
                        || today.Month != viewModel.CalendarMonth;
            }

            public void Execute(object parameter)
            {
                var timestamp = DateTime.Now;
                viewModel.CalendarYear = timestamp.Year;
                viewModel.CalendarMonth =timestamp.Month;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// プロパティが変更された際に発生するイベント。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Dependency Injection

        /// <summary>
        /// <see cref="DateTimeEventSource" /> の持つ <see cref="IDateTimeEventSource.HolidayChecker" /> が返ります。
        /// このプロパティからの set はできません。
        /// </summary>
        public IHolidayChecker HolidayChecker { get { return _DateTimeEventSource?.HolidayChecker; } }

        private IDateTimeEventSource _DateTimeEventSource;
        /// <summary>
        /// <see cref="IDateTimeEventSource" />
        /// </summary>
        public IDateTimeEventSource DateTimeEventSource
        {
            get { return _DateTimeEventSource; }
            set
            {
                if (_DateTimeEventSource != null) throw new InvalidOperationException(String.Format(ALREADY_SET_MESSAGE, nameof(DateTimeEventSource)));
                if (value == null) return;
                _DateTimeEventSource = value;
                _DateTimeEventSource.PropertyChanged += DateTimeChangedEventHandler;
                _DateTimeEventSource.HolidaySettingChanged += HolidaySettingChangedEventHandler;


            }
        }

        private IPrimaryScreenSizeEventSource _PrimaryScreenSizeEventSource;
        /// <summary>
        /// <see cref="IPrimaryScreenSizeEventSource" />
        /// </summary>
        public IPrimaryScreenSizeEventSource PrimaryScreenSizeEventSource
        {
            get { return _PrimaryScreenSizeEventSource; }
            set
            {
                if (_PrimaryScreenSizeEventSource != null) throw new InvalidOperationException(String.Format(ALREADY_SET_MESSAGE, nameof(PrimaryScreenSizeEventSource)));
                if (value == null) return;
                _PrimaryScreenSizeEventSource = value;
                _PrimaryScreenSizeEventSource.PropertyChanged += PrimaryScreenSizeChangedEventHandler;
            }
        }

        private ISettingsWrapper _SettingsWrapper;
        /// <summary>
        /// Properties.Settings.Default をラップしたラッパー。
        /// </summary>
        public ISettingsWrapper SettingsWrapper
        {
            get { return _SettingsWrapper; }
            set
            {
                if (_SettingsWrapper != null) throw new InvalidOperationException(String.Format(ALREADY_SET_MESSAGE, nameof(SettingsWrapper)));
                if (value == null) return;
                _SettingsWrapper = value;
                _SettingsWrapper.PropertyChanged += PropertiesSettingsChangedEventHandler;
            }
        }

        #endregion

        private int _CalendarYear;
        /// <summary>
        /// カレンダーに表示する年。
        /// </summary>
        public int CalendarYear
        {
            get
            {
                return _CalendarYear;
            }
            set
            {
                _CalendarYear = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CalendarYear)));
            }
        }

        private int _CalendarMonth;
        /// <summary>
        /// カレンダーに表示する月。
        /// </summary>
        public int CalendarMonth
        {
            get
            {
                return _CalendarMonth;
            }
            set
            {
                _CalendarMonth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CalendarMonth)));
            }
        }

        private System.Windows.Threading.Dispatcher MainWindowDispatcher;
        private System.Windows.Threading.Dispatcher CalendarWindowDispatcher;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MainWindowViewModel(System.Windows.Threading.Dispatcher mainDispatcher, System.Windows.Threading.Dispatcher calendarDispatcher)
        {
            MainWindowDispatcher = mainDispatcher;
            CalendarWindowDispatcher = calendarDispatcher;

            // コマンドの初期化
            NextMonthCommand = new NextMonthCommandImpl(this);
            PreviousMonthCommand = new PreviousMonthCommandImpl(this);
            ThisMonthCommand = new ThisMonthCommandImpl(this);


            // イベント ハンドラーの設定
            this.PropertyChanged += WindowPositionEventHandler;
            this.PropertyChanged += CalendarMonthChangedEventHandler;
        }

        #region Event Handlers

        /// <summary>
        /// <see cref="IDateTimeEventSource" /> の <see cref="INotifyPropertyChanged.PropertyChanged" /> イベントを処理するためのイベント ハンドラー。
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベント引数</param>
        private void DateTimeChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            if (sender is IDateTimeEventSource dateTimeEventSource)
            {
                switch (e.PropertyName)
                {
                    case nameof(IDateTimeEventSource.Day):
                        ChangeDate();
                        break;
                    case nameof(IDateTimeEventSource.Hour):
                        ChangeHour();
                        break;
                    case nameof(IDateTimeEventSource.Minute):
                        ChangeMinute();
                        break;
                    case nameof(IDateTimeEventSource.DayOfWeek):
                        ChangeDayOfWeek();
                        break;
                    case nameof(IDateTimeEventSource.HolidayName):
                        ChangeHolidayName();
                        break;
                }
            }
        }

        /// <summary>
        /// <see cref="IPrimaryScreenSizeEventSource" /> の <see cref="INotifyPropertyChanged.PropertyChanged" /> イベントを処理するためのイベント ハンドラー。
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベント引数</param>
        private void PrimaryScreenSizeChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            if (sender is IPrimaryScreenSizeEventSource screenSizeEventSource)
            {
                switch (e.PropertyName)
                {
                    case nameof(IPrimaryScreenSizeEventSource.Height):
                        ScreenHeight = screenSizeEventSource.Height;
                        break;
                    case nameof(IPrimaryScreenSizeEventSource.Width):
                        ScreenWidth = screenSizeEventSource.Width;
                        break;
                }
            }
        }

        /// <summary>
        /// アプリケーションのプロパティが変更された際のイベントを処理するイベント ハンドラー。
        /// 設定画面での変更をメイン ウィンドウに反映する。
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベント引数</param>
        private void PropertiesSettingsChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
                //IndicatorString = (settings == Properties.Settings.Default).ToString();
                switch (e.PropertyName)
                {
                    case nameof(SettingsWrapper.VerticalAlignment):
                        VerticalAlignment = (System.Windows.VerticalAlignment)SettingsWrapper.VerticalAlignment;
                        break;
                    case nameof(SettingsWrapper.HorizontalAlignment):
                        HorizontalAlignment = (System.Windows.HorizontalAlignment)SettingsWrapper.HorizontalAlignment;
                        break;
                    case nameof(SettingsWrapper.VerticalMargin):
                        VerticalMargin = SettingsWrapper.VerticalMargin;
                        break;
                    case nameof(SettingsWrapper.HorizontalMargin):
                        HorizontalMargin = SettingsWrapper.HorizontalMargin;
                        break;
                    case nameof(SettingsWrapper.CustumHolidaysString):
                        CustomHolidaysParser.Deserialize(SettingsWrapper.CustumHolidaysString, HolidayChecker.CustomHoliday.Holidays);
                        break;
                }
        }

        /// <summary>
        /// カスタム休日が変更など、休日関係の設定が変更された際のイベントを処理するイベントハンドラー。
        /// 日付変更時の処理を走らせる。
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベント引数</param>
        private void HolidaySettingChangedEventHandler(object sender, HolidaySettingChangedEventArgs e)
        {
            ChangeDate(); 
        }

        #endregion

        #region Private Methods

        #region DateTime

        /// <summary>
        /// 祝祭日関連の変更が発生した際の処理。
        /// </summary>
        private void ChangeHolidayName()
        {
            HolidayNameOfToday = DateTimeEventSource.HolidayName;
        }

        private readonly string SundayName = (DateTime.MinValue + TimeSpan.FromDays(6)).ToString("dddd");
        private readonly string MondayName = DateTime.MinValue.ToString("dddd");
        private readonly string TuesdayName = (DateTime.MinValue + TimeSpan.FromDays(1)).ToString("dddd");
        private readonly string WednesdayName = (DateTime.MinValue + TimeSpan.FromDays(2)).ToString("dddd");
        private readonly string ThursdayName = (DateTime.MinValue + TimeSpan.FromDays(3)).ToString("dddd");
        private readonly string FridayName = (DateTime.MinValue + TimeSpan.FromDays(4)).ToString("dddd");
        private readonly string SaturdayName = (DateTime.MinValue + TimeSpan.FromDays(5)).ToString("dddd");
        /// <summary>
        /// 曜日が変更された際の処理。
        /// </summary>
        private void ChangeDayOfWeek()
        {
            switch (DateTimeEventSource.DayOfWeek)
            {
                case System.DayOfWeek.Sunday:
                    DayOfWeek = SundayName;
                    break;
                case System.DayOfWeek.Monday:
                    DayOfWeek = MondayName;
                    break;
                case System.DayOfWeek.Tuesday:
                    DayOfWeek = TuesdayName;
                    break;
                case System.DayOfWeek.Wednesday:
                    DayOfWeek = WednesdayName;
                    break;
                case System.DayOfWeek.Thursday:
                    DayOfWeek = ThursdayName;
                    break;
                case System.DayOfWeek.Friday:
                    DayOfWeek = FridayName;
                    break;
                case System.DayOfWeek.Saturday:
                    DayOfWeek = SaturdayName;
                    break;
            }
        }

        /// <summary>
        /// 年月日が変更された際の処理。
        /// </summary>
        private void ChangeDate()
        {
            Date = DateTimeEventSource.Year + " 年 "
                    + DateTimeEventSource.Month.ToString("00") + " 月 "
                    + DateTimeEventSource.Day.ToString("00") + " 日";

            var today = new DateTime(DateTimeEventSource.Year, DateTimeEventSource.Month, DateTimeEventSource.Day);
            var oneday = TimeSpan.FromDays(1);
            var tommorow = today + oneday;
            var holidayCount = GetConsecutiveHolidaysCount(tommorow);
            var dayAfterTommorow = tommorow + oneday;
            var holidayCountTommorow = GetConsecutiveHolidaysCount(dayAfterTommorow);

            string holidayNameOfToday = null;
            string holidayNameOfTommorow = null;
            bool todayIsHoliday = false;
            bool tommorowIsHoliday = false;
            if (HolidayChecker != null)
            {
                holidayNameOfToday = HolidayChecker.GetHolidayName(DateTimeEventSource.Year, DateTimeEventSource.Month, DateTimeEventSource.Day);
                holidayNameOfTommorow = HolidayChecker.GetHolidayName(tommorow);
                todayIsHoliday = !String.IsNullOrEmpty(holidayNameOfToday);
                tommorowIsHoliday = !String.IsNullOrEmpty(holidayNameOfTommorow);
            }

            // HolidayNameOfToday は別のハンドラーでも処理。無駄になるかもしれないが、害もない。
            HolidayNameOfToday = holidayNameOfToday;
            HolidayNameOfTommorow = holidayNameOfTommorow;
            
            // 本日の色設定および土日の追加
            if (todayIsHoliday)
            {
                ColorOfToday = HolidayColor;
            }
            else if (today.DayOfWeek == System.DayOfWeek.Sunday)
            {
                ColorOfToday = HolidayColor;
                HolidayNameOfToday = SundayName;
            }
            else if (today.DayOfWeek == System.DayOfWeek.Saturday)
            {
                ColorOfToday = SaturdayColor;
                HolidayNameOfToday = SaturdayName;
            }
            else
            {
                ColorOfToday = NormalColor;
            }

            // 本日の情報表示
            if (todayIsHoliday)
            {
                VisibilityOfToday = System.Windows.Visibility.Visible;
            }
            else
            {
                VisibilityOfToday = System.Windows.Visibility.Collapsed;
            }
            
            // 明日の色設定および土日の追加
            if (tommorowIsHoliday)
            {
                ColorOfTommorow = HolidayColor;
            }
            else if (tommorow.DayOfWeek == System.DayOfWeek.Sunday)
            {
                ColorOfTommorow = HolidayColor;
                HolidayNameOfTommorow = SundayName;
            }
            else if (tommorow.DayOfWeek == System.DayOfWeek.Saturday)
            {
                ColorOfTommorow = SaturdayColor;
                HolidayNameOfTommorow = SaturdayName;
            }
            else
            {
                ColorOfTommorow = NormalColor;
            }

            // 明日の情報表示
            if (tommorowIsHoliday
                    && today.DayOfWeek != System.DayOfWeek.Saturday
                    && tommorow.DayOfWeek != System.DayOfWeek.Saturday
                    && tommorow.DayOfWeek != System.DayOfWeek.Sunday)
            {
                VisibilityOfToday = System.Windows.Visibility.Visible;
            }
            else
            {
                VisibilityOfTommorow = System.Windows.Visibility.Collapsed;
            }

            VisibilityOfConsecutiveHolidays = System.Windows.Visibility.Collapsed;
            // 連休の情報表示
            if (holidayCount > 1 && todayIsHoliday || holidayCount > 1 && tommorowIsHoliday || holidayCount > 2)
            {
                ConsecutiveHolidaysMessage = "明日以降、" + holidayCount + " 日の連休です。";
                VisibilityOfConsecutiveHolidays = System.Windows.Visibility.Visible;
            }
            else if (holidayCountTommorow > 2 && !todayIsHoliday)
            {
                ConsecutiveHolidaysMessage = "明後日から、" + holidayCountTommorow + " 日の連休です。";
                VisibilityOfConsecutiveHolidays = System.Windows.Visibility.Visible;
            }
            else
            {
                VisibilityOfConsecutiveHolidays = System.Windows.Visibility.Collapsed;
            }

            // カレンダーの表示変更
            // ##################### Dispatcher 経由じゃないとエラーになる。 #####################
            // ################ タイミングの問題なら、他の操作も潜在的にバグ持ち？ ###############
            if (CalendarWindowDispatcher != null)
            {
                CalendarWindowDispatcher.Invoke(new Action(() =>
                {
                    CalendarYear = today.Year;
                    CalendarMonth = today.Month;
                }));
                UpdateCalender();
            }
        }

        private int GetConsecutiveHolidaysCount(DateTime dateTime)
        {
            var oneday = TimeSpan.FromDays(1);
            int count = 0;
            while (dateTime.DayOfWeek == System.DayOfWeek.Saturday || dateTime.DayOfWeek == System.DayOfWeek.Sunday || (HolidayChecker != null && HolidayChecker.IsHoliday(dateTime)))
            {
                count++;
                dateTime += oneday;
            }
            return count;
        }

        /// <summary>
        /// 時が変更された際の処理。
        /// </summary>
        private void ChangeHour()
        {
            string hourStr = DateTimeEventSource.Hour.ToString("00");
            Hour0 = hourStr.Substring(0, 1);
            Hour1 = hourStr.Substring(1, 1);
        }

        /// <summary>
        /// 分が変更された際の処理。
        /// </summary>
        private void ChangeMinute()
        {
            string minuteStr = DateTimeEventSource.Minute.ToString("00");
            Minute0 = minuteStr.Substring(0, 1);
            Minute1 = minuteStr.Substring(1, 1);
        }

        #endregion

        #region Calendar

        private void CalendarMonthChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            if (sender is MainWindowViewModel viewModel)
            {
                switch (e.PropertyName)
                {
                    case nameof(CalendarMonth):
                    case nameof(CalendarYear):
                        UpdateCalender();
                        break;
                }
            }
        }

        /// <summary>
        /// カレンダーを更新。
        /// <see cref="ChangeDate"/> の中でも呼ばれる。
        /// 内部的に <see cref="PropertyChanged"/> を発生させる。
        /// </summary>
        private void UpdateCalender()
        {
            if (CalendarYear == 0 || CalendarMonth == 0) return;

            CalendarYearAndMonth =
                StringShaper.InsertSpaceInZenkakuHankaku(new DateTime(CalendarYear, CalendarMonth, 1).ToString("Y"));

            var year = _CalendarYear;
            var month = _CalendarMonth;

            var todayYear = DateTimeEventSource.Year;
            var todayMonth = DateTimeEventSource.Month;
            var todayDay = DateTimeEventSource.Day;
            var monthContainsToday = (year == todayYear && month == todayMonth);

            Calendar.GetCalendar(year, month, DateTimeEventSource.HolidayChecker, out int[,] days, out bool[,] isHoliday, out bool[,] isThisMonth, out int lastRow);

            for (int i = 0; i < _CalendarNumbers.GetLength(0); i++)
            {
                for (int j = 0; j < _CalendarNumbers.GetLength(1); j++)
                {
                    if (i <= lastRow)
                    {
                        _CalendarNumbers[i, j] = days[i, j].ToString();
                        if (isThisMonth[i, j])
                        {
                            var isToday = (monthContainsToday && days[i, j] == todayDay);

                            if (isToday)
                            {
                                if (j == 0 || isHoliday[i, j])
                                {
                                    _CalendarForegrounds[i, j] = System.Windows.Media.Brushes.Black;
                                    _CalendarBackgrounds[i, j] = HolidayColor;
                                    _CalendarOpacities[i, j] = 0.9;
                                }
                                else if (j == 6)
                                {
                                    _CalendarForegrounds[i, j] = System.Windows.Media.Brushes.Black;
                                    _CalendarBackgrounds[i, j] = SaturdayColor;
                                    _CalendarOpacities[i, j] = 0.9;
                                }
                                else
                                {
                                    _CalendarForegrounds[i, j] = System.Windows.Media.Brushes.Black;
                                    _CalendarBackgrounds[i, j] = NormalColor;
                                    _CalendarOpacities[i, j] = 0.9;
                                }
                            }
                            else
                            {
                                if (j == 0 || isHoliday[i, j])
                                {
                                    _CalendarForegrounds[i, j] = HolidayColor;
                                    _CalendarBackgrounds[i, j] = System.Windows.Media.Brushes.Transparent;
                                    _CalendarOpacities[i, j] = 1;
                                }
                                else if (j == 6)
                                {
                                    _CalendarForegrounds[i, j] = SaturdayColor;
                                    _CalendarBackgrounds[i, j] = System.Windows.Media.Brushes.Transparent;
                                    _CalendarOpacities[i, j] = 1;
                                }
                                else
                                {
                                    _CalendarForegrounds[i, j] = NormalColor;
                                    _CalendarBackgrounds[i, j] = System.Windows.Media.Brushes.Transparent;
                                    _CalendarOpacities[i, j] = 1;
                                }
                            }
                        }
                        else
                        {
                            if (j == 0 || isHoliday[i, j])
                            {
                                _CalendarForegrounds[i, j] = HolidayColor;
                                _CalendarBackgrounds[i, j] = System.Windows.Media.Brushes.Transparent;
                                _CalendarOpacities[i, j] = 0.3;
                            }
                            else if (j == 6)
                            {
                                _CalendarForegrounds[i, j] = SaturdayColor;
                                _CalendarBackgrounds[i, j] = System.Windows.Media.Brushes.Transparent;
                                _CalendarOpacities[i, j] = 0.3;
                            }
                            else
                            {
                                _CalendarForegrounds[i, j] = NormalColor;
                                _CalendarBackgrounds[i, j] = System.Windows.Media.Brushes.Transparent;
                                _CalendarOpacities[i, j] = 0.3;
                            }
                        }
                    }
                    else
                    {
                        _CalendarNumbers[i, j] = String.Empty;
                    }
                }
            }

            // PropertyChanged イベントの発生
            if (PropertyChanged != null)
            {
                for (int i = 0; i < _CalendarNumbers.GetLength(0); i++)
                {
                    for (int j = 0; j < _CalendarNumbers.GetLength(1); j++)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("CalendarR" + i + "C" + j + "Number"));
                        PropertyChanged(this, new PropertyChangedEventArgs("CalendarR" + i + "C" + j + "Foreground"));
                        PropertyChanged(this, new PropertyChangedEventArgs("CalendarR" + i + "C" + j + "Background"));
                        PropertyChanged(this, new PropertyChangedEventArgs("CalendarR" + i + "C" + j + "Opacity"));
                    }
                }
            }
        }

        #endregion

        #region Window Position

        /// <summary>
        /// ウィンドウ位置関連の変更イベントを処理するためのイベントハンドラー。コンストラクターによって、このクラスのインスタンスの <see cref="PropertyChanged" /> にセットされる。
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">イベント引数</param>
        private void WindowPositionEventHandler(object sender, PropertyChangedEventArgs e)
        {
            if (sender is MainWindowViewModel mainWindowViewModel)
            {
                switch (e.PropertyName)
                {
                    case nameof(WindowWidth):
                        CalendarWindowWidth = WindowWidth;
                        ChangeWindowPosition();
                        break;
                    case nameof(ScreenHeight):
                    case nameof(ScreenWidth):
                    case nameof(WindowHeight):
                    case nameof(CalendarWindowHeight):
                    case nameof(VerticalAlignment):
                    case nameof(HorizontalAlignment):
                    case nameof(VerticalMargin):
                    case nameof(HorizontalMargin):
                        ChangeWindowPosition();
                        break;
                }
            }
        }

        /// <summary>
        /// ウィンドウの位置を変更する処理。
        /// <see cref="WindowTop" />、<see cref="WindowLeft" />、<see cref="CalendarWindowTop" />、および、<see cref="CalendarWindowLeft" /> が変更されます。
        /// </summary>
        private void ChangeWindowPosition()
        {
            switch (VerticalAlignment)
            {
                case System.Windows.VerticalAlignment.Center:
                    WindowTop = (ScreenHeight - WindowHeight - 35) / 2;
                    CalendarWindowTop = WindowTop + WindowHeight - 31;
                    break;
                case System.Windows.VerticalAlignment.Bottom:
                    WindowTop = ScreenHeight - VerticalMargin - WindowHeight - 35;
                    CalendarWindowTop = WindowTop - CalendarWindowHeight + 31;
                    break;
                case System.Windows.VerticalAlignment.Top:
                default:
                    WindowTop = VerticalMargin;
                    CalendarWindowTop = WindowTop + WindowHeight - 31;
                    break;
            }

            switch (HorizontalAlignment)
            {
                case System.Windows.HorizontalAlignment.Center:
                    WindowLeft = (ScreenWidth - WindowWidth) / 2;
                    CalendarWindowLeft = WindowLeft;
                    break;
                case System.Windows.HorizontalAlignment.Left:
                    WindowLeft = HorizontalMargin + 35;
                    CalendarWindowLeft = WindowLeft;
                    break;
                case System.Windows.HorizontalAlignment.Right:
                default:
                    WindowLeft = ScreenWidth - HorizontalMargin - WindowWidth - 35;
                    CalendarWindowLeft = WindowLeft;
                    break;
            }
        }

        #endregion

        #endregion
    }
}
