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
    /// 時刻が変わった際に各プロパティに対応した <see cref="INotifyPropertyChanged.PropertyChanged" /> イベントを発生させます。
    /// </summary>
    public interface IDateTimeEventSource : INotifyPropertyChanged
    {
        /// <summary>
        /// 年。
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// 月。
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// 日。
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// 時。
        /// </summary>
        public int Hour { get; }

        /// <summary>
        /// 分。
        /// </summary>
        public int Minute { get; }

        /// <summary>
        /// 秒。
        /// </summary>
        public int Second { get; }

        /// <summary>
        /// 曜日。
        /// </summary>
        public DayOfWeek DayOfWeek { get; }

        /// <summary>
        /// 祝祭日かどうか。
        /// </summary>
        public bool IsHoliday { get; }

        /// <summary>
        /// 祝祭日名。
        /// </summary>
        public string HolidayName { get; }

        /// <summary>
        /// 祝祭日かを判断するための <see cref="IHolidayChecker" />。
        /// </summary>
        public IHolidayChecker HolidayChecker { get; set; }

        /// <summary>
        /// 時刻の確認を開始します。時刻に変化があった場合、<see cref="INotifyPropertyChanged.PropertyChanged" /> イベントが発生します。
        /// </summary>
        public void Start();

        /// <summary>
        /// 時刻の確認を停止します。
        /// </summary>
        public void Stop();
    }
}
