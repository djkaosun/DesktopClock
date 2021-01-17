using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DesktopClock.Library
{
    /// <summary>
    /// <see cref="IDateTimeEventSource" />の実装です。
    /// </summary>
    public class DateTimeEventSource : IDateTimeEventSource
    {
        /// <summary>
        /// 時刻を確認する間隔の最小値。
        /// </summary>
        public static readonly int MinimumInterval = 500;

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

        private IHolidayChecker _HolidayChecker;
        /// <summary>
        /// 休日かどうかをチェックする <see cref="IHolidayChecker" />。
        /// </summary>
        public IHolidayChecker HolidayChecker
        {
            get { return _HolidayChecker; }
            set {
                if (_HolidayChecker != null) throw new InvalidOperationException("already setted.");
                _HolidayChecker = value;
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
                if (MillisecondsInterval < MinimumInterval) throw new InvalidOperationException("MillisecondsInterval is too small. (< " + MinimumInterval + ")");
                _MillisecondsInterval = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MillisecondsInterval)));
            }
        }

        /// <summary>
        /// プロパティが変更されたときに発生するイベント。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private CancellationTokenSource tokenSource;
        
        /// <summary>
        /// コンストラクター。
        /// </summary>
        public DateTimeEventSource()
        {
            _MillisecondsInterval = DateTimeEventSource.MinimumInterval;
            InitializeDateTime();
            PropertyChanged += UpdateDateInfo;
        }

        /// <summary>
        /// Start 実行直後に PropertyChanged イベントが起きるよう、各値を初期化する。
        /// (int の初期値は 0 のため、これをしないと 0 時や 0 分の場合にイベントが発生しない。)
        /// </summary>
        private void InitializeDateTime()
        {
            _Year = -1;
            _Month = 99;
            _Day = 99;
            _Hour = 99;
            _Minute = 99;
            _Second = 99;
            _HolidayName = null;
            _IsHoliday = false;
            _DayOfWeek = DayOfWeek.Sunday;
        }

        private void UpdateDateInfo(object sender, PropertyChangedEventArgs e)
        {
            if (sender is DateTimeEventSource dtEvntSrc)
            {
                switch (e.PropertyName)
                {
                    case nameof(Day):
                        var timeStamp = DateTime.Now;
                        DayOfWeek = timeStamp.DayOfWeek;
                        HolidayName = this.HolidayChecker.GetHolidayName(Year, Month, Day);
                        IsHoliday = String.IsNullOrEmpty(HolidayName);
                        break;
                }
            }
        }

        /// <summary>
        /// 時刻の確認を開始します。時刻に変化があった場合、<see cref="PropertyChanged" /> イベントが発生します。
        /// </summary>
        public void Start()
        {
            if (tokenSource != null) throw new InvalidOperationException("Already started.");
            tokenSource = new CancellationTokenSource();
            CheckUpdate(tokenSource.Token);
        }

        private async void CheckUpdate(CancellationToken token)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    UpdateDateTime();
                    Thread.Sleep(MillisecondsInterval);

                    if (token.IsCancellationRequested) break;
                }
            });
        }

        private void UpdateDateTime()
        {
            var timeStamp = DateTime.Now;
            Year = timeStamp.Year;
            Month = timeStamp.Month;
            Day = timeStamp.Day;
            Hour = timeStamp.Hour;
            Minute = timeStamp.Minute;
            Second = timeStamp.Second;
        }

        /// <summary>
        /// 時刻の確認を停止します。各値は初期値に戻ります。
        /// </summary>
        public void Stop()
        {
            if (tokenSource == null) throw new InvalidOperationException("This is not running.");
            tokenSource.Cancel();
            tokenSource = null;
            InitializeDateTime();
        }
    }
}
