using System;
using System.ComponentModel;
using DesktopClock.Library;

namespace DesktopClockTests.FakeClasses
{
    /// <summary>
    /// <see cref="IDateTimeEventSource" /> のフェイク実装です。
    /// </summary>
    public class FakeDateTimeEventSource : IDateTimeEventSource, INotifyFakeMethodCalled
    {
        private const string ALREADY_SET_MESSAGE = "{0} is already set.";
        private const string TOO_SMALL_MESSAGE = "{0} is too small. (< {1})";
        private const string ALREADY_STARTED_MESSAGE = "Already started.";
        private const string NOT_RUNNING_MESSAGE = "This is not running.";
        private const int INITIAL_YEAR = -1;
        private const int INITIAL_MONTH = 99;
        private const int INITIAL_DAY = 99;
        private const int INITIAL_HOUR = 99;
        private const int INITIAL_MINUTE = 99;
        private const int INITIAL_SECOND = 99;
        private const string INITIAL_HOLIDAYNAME = null;
        private const bool INITIAL_ISHOLIDAY = false;
        private const DayOfWeek INITIAL_DAYOFWEEK = DayOfWeek.Sunday;

        /// <summary>
        /// 時刻を確認する間隔の最小値。
        /// </summary>
        public static readonly int MinimumInterval = 500;

        private bool _IsRunning;
        /// <summary>
        /// 実行中か否か。
        /// </summary>
        public bool IsRunning
        {
            get { return _IsRunning; }
            private set
            {
                if (value != _IsRunning)
                {
                    _IsRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }

        private int _Year;
        /// <summary>
        /// 年。停止中は -1。
        /// </summary>
        public int Year
        {
            get { return _Year; }
            private set
            {
                if (value != _Year)
                {
                    _Year = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Year)));
                }
            }
        }

        private int _Month;
        /// <summary>
        /// 月。停止中は 99。
        /// </summary>
        public int Month
        {
            get { return _Month; }
            private set
            {
                if (value != _Month)
                {
                    _Month = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Month)));
                }
            }
        }

        private int _Day;
        /// <summary>
        /// 日。停止中は 99。
        /// </summary>
        public int Day
        {
            get { return _Day; }
            private set
            {
                if (value != _Day)
                {
                    _Day = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Day)));
                }
            }
        }

        private int _Hour;
        /// <summary>
        /// 時。停止中は 99。
        /// </summary>
        public int Hour
        {
            get { return _Hour; }
            private set
            {
                if (value != _Hour)
                {
                    _Hour = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Hour)));
                }
            }
        }

        private int _Minute;
        /// <summary>
        /// 分。停止中は 99。
        /// </summary>
        public int Minute
        {
            get { return _Minute; }
            private set
            {
                if (value != _Minute)
                {
                    _Minute = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Minute)));
                }
            }
        }

        private int _Second;
        /// <summary>
        /// 秒。停止中は 99。
        /// </summary>
        public int Second
        {
            get { return _Second; }
            private set
            {
                if (value != _Second)
                {
                    _Second = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Second)));
                }
            }
        }

        private DayOfWeek _DayOfWeek;
        /// <summary>
        /// 曜日。
        /// </summary>
        public DayOfWeek DayOfWeek
        {
            get { return _DayOfWeek; }
            private set
            {
                _DayOfWeek = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DayOfWeek)));
            }
        }

        private bool _IsHoliday;
        /// <summary>
        /// 祝祭日かどうか。祝祭日か否かの判断は <see cref="IHolidayChecker" /> によります。
        /// </summary>
        public bool IsHoliday
        {
            get { return _IsHoliday; }
            private set
            {
                _IsHoliday = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsHoliday)));
            }
        }

        private string _HolidayName;
        /// <summary>
        /// 祝祭日名。休日でないときは null。祝祭日名は <see cref="IHolidayChecker" /> によります。
        /// </summary>
        public string HolidayName
        {
            get { return _HolidayName; }
            private set
            {
                _HolidayName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HolidayName)));
            }
        }

        private DateTime _Today;
        /// <summary>
        /// 今日を表す <see cref="DateTime" />。マルチスレッディングで一貫性のある日付を必要とするときに使用します。
        /// </summary>
        public DateTime Today
        {
            get { return _Today; }
            private set
            {
                _Today = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Today)));
            }
        }

        private DateTime _Now;
        /// <summary>
        /// 今を表す <see cref="DateTime" />。マルチスレッディングで一貫性のある時分秒を必要とするときに使用します。
        /// 秒以下は切り捨てられます。
        /// </summary>
        public DateTime Now
        {
            get { return _Now; }
            private set
            {
                _Now = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Now)));
            }
        }

        private IHolidayChecker _HolidayChecker;
        /// <summary>
        /// 休日かどうかをチェックする <see cref="IHolidayChecker" />。
        /// </summary>
        public IHolidayChecker HolidayChecker
        {
            get { return _HolidayChecker; }
            set
            {
                if (_HolidayChecker != null) throw new InvalidOperationException(String.Format(ALREADY_SET_MESSAGE, nameof(HolidayChecker)));
                if (value == null) return;
                _HolidayChecker = value;
                _HolidayChecker.HolidaySettingChanged += (object sender, HolidaySettingChangedEventArgs e) =>
                {
                    HolidaySettingChanged?.Invoke(sender, e);
                };

            }
        }

        private int _MillisecondsInterval;
        /// <summary>
        /// 時刻を確認する間隔。最少は <see cref="MinimumInterval" />。
        /// </summary>
        public int MillisecondsInterval
        {
            get { return _MillisecondsInterval; }
            private set
            {
                if (MillisecondsInterval < MinimumInterval) throw new ArgumentException(String.Format(TOO_SMALL_MESSAGE, nameof(MillisecondsInterval), MinimumInterval));
                _MillisecondsInterval = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MillisecondsInterval)));
            }
        }

        /// <summary>
        /// このオブジェクトのプロパティが変更されたときに発生するイベント。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// <see cref="INotifyHolidaySettingChanged.HolidaySettingChanged" /> のイベントを転送します。
        /// </summary>
        public event HolidaySettingChangedEventHandler HolidaySettingChanged;
        public event FakeMethodCalledEventHandler FakeMethodCalled;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public FakeDateTimeEventSource()
        {
            _MillisecondsInterval = DateTimeEventSource.MinimumInterval;
            InitializeDateTime();
        }

        /// <summary>
        /// 各値を初期化する。
        /// </summary>
        public void InitializeDateTime()
        {
            _Year = INITIAL_YEAR;
            _Month = INITIAL_MONTH;
            _Day = INITIAL_DAY;
            _Hour = INITIAL_HOUR;
            _Minute = INITIAL_MINUTE;
            _Second = INITIAL_SECOND;
            _HolidayName = INITIAL_HOLIDAYNAME;
            _IsHoliday = INITIAL_ISHOLIDAY;
            _DayOfWeek = INITIAL_DAYOFWEEK;
        }

        /// <summary>
        /// 時刻の確認を開始します。時刻に変化があった場合、<see cref="PropertyChanged" /> イベントが発生します。
        /// </summary>
        public void Start()
        {
            if (IsRunning) throw new InvalidOperationException(ALREADY_STARTED_MESSAGE);
            FakeMethodCalled?.Invoke(this, new FakeMethodCalledEventArgs(nameof(Start), null));
            IsRunning = true;
        }

        /// <summary>
        /// このフェイク オブジェクトの状態 (時刻) を変化させるためのメソッド。
        /// </summary>
        /// <param name="timeStamp">更新後の時間。</param>
        public void FakeDateTimeUpdate(DateTime timeStamp)
        {
            timeStamp = new DateTime(timeStamp.Year, timeStamp.Month, timeStamp.Day, timeStamp.Hour, timeStamp.Minute, timeStamp.Second);
            var today = new DateTime(timeStamp.Year, timeStamp.Month, timeStamp.Day);
            Year = timeStamp.Year;
            Month = timeStamp.Month;
            Day = timeStamp.Day;
            Today = today;
            Hour = timeStamp.Hour;
            Minute = timeStamp.Minute;
            Second = timeStamp.Second;
            Now = timeStamp;
        }

        /// <summary>
        /// このフェイク オブジェクトの状態 (休日判定) を変化させるためのメソッド。
        /// </summary>
        /// <param name="timeStamp">更新後の休日名。</param>
        public void FakeHolidayNameUpdate(string holidayName)
        {
            if (String.IsNullOrEmpty(holidayName))
            {
                HolidayName = holidayName;
                IsHoliday = false;
            }
            else
            {
                HolidayName = holidayName;
                IsHoliday = true;
            }
        }

        /// <summary>
        /// 時刻の確認を停止します。各値は初期値に戻ります。
        /// </summary>
        public void Stop()
        {
            if (!IsRunning) throw new InvalidOperationException(NOT_RUNNING_MESSAGE);
            FakeMethodCalled?.Invoke(this, new FakeMethodCalledEventArgs(nameof(Stop), null));
            IsRunning = false;
            InitializeDateTime();
        }
    }
}
