using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DesktopClock.Library
{
    /// <summary>
    /// カスタム休日。
    /// </summary>
    public class CustomHoliday : ICustomHoliday
    {
        private ObservableCollection<KeyValuePair<DateTime, string>> _Holidays;
        /// <summary>
        /// カスタム休日の一覧。
        /// 1 回しかセットできません。2 回以上セットしようとすると、<see cref="InvalidOperationException"/> がスローされます。
        /// </summary>
        public ObservableCollection<KeyValuePair<DateTime, string>> Holidays
        {
            get { return _Holidays; }
            set
            {
                if (_Holidays != null) throw new InvalidOperationException("already set.");
                if (value == null) return;

                _Holidays = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Holidays)));

                _Holidays.CollectionChanged += (object sender ,NotifyCollectionChangedEventArgs e) =>
                {
                    HolidaySettingChanged?.Invoke(sender, new HolidaySettingChangedEventArgs(nameof(Holidays), e));
                };
            }
        }

        /// <summary>
        /// 休日関係の設定が変更された際に発生するイベントです。
        /// </summary>
        public event HolidaySettingChangedEventHandler HolidaySettingChanged;

        /// <summary>
        /// プロパティが変更された際に発生するイベントです。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public CustomHoliday()
        {
            PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                HolidaySettingChanged?.Invoke(sender, new HolidaySettingChangedEventArgs(e.PropertyName, e));
            };
        }

        /// <summary>
        /// 年月日に対応するカスタム休日の名前を取得します。
        /// </summary>
        /// <param name="year">年。</param>
        /// <param name="month">月。</param>
        /// <param name="day">日。</param>
        /// <returns>カスタム休日名。</returns>
        public string GetHolidayName(int year, int month, int day)
        {
            if (Holidays == null) return null;

            var today = new DateTime(year, month, day);
            string holidayName = null;
            if (Holidays.ContainsKey(today))
            {
                holidayName = Holidays.GetValue(today);
            }
            return holidayName;
        }
    }
}
