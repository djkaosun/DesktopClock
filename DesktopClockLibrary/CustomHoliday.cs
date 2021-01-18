using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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
                if (_Holidays != null) throw new InvalidOperationException("already setted.");

                _Holidays = value;
                HolidaySettingChanged?.Invoke(this, new NotifyHolidaySettingChangedEventArgs(nameof(Holidays)));

                _Holidays.CollectionChanged += (object sender ,NotifyCollectionChangedEventArgs e) =>
                {
                    HolidaySettingChanged?.Invoke(sender, new NotifyHolidaySettingChangedEventArgs(nameof(Holidays), e));
                };
            }
        }

        public event HolidaySettingChangedEventHandler HolidaySettingChanged;

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
