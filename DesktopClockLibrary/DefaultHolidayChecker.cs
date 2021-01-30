using System;
using System.ComponentModel;

namespace DesktopClock.Library
{
    /// <summary>
    /// <see cref="IHolidayChecker" /> の実装です。
    /// すべての日付に対し、常に false (休日でない) を返します。
    /// カスタム休日を設定した場合は、カスタム休日のみ true (休日である) を返します。
    /// </summary>
    public class DefaultHolidayChecker : IHolidayChecker
    {
        private const string ALREADY_SET_MESSAGE = "{0} is already set.";

        private ICustomHoliday _CustomHoliday;
        /// <summary>
        /// <see cref="ICustomHoliday" /> をセットします。
        /// </summary>
        public ICustomHoliday CustomHoliday
        {
            get
            {
                return _CustomHoliday;
            }
            set
            {
                if (_CustomHoliday != null) throw new InvalidOperationException(String.Format(ALREADY_SET_MESSAGE, nameof(CustomHoliday)));
                if (value == null) return;
                _CustomHoliday = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomHoliday)));
                _CustomHoliday.HolidaySettingChanged += (object sender, HolidaySettingChangedEventArgs e) =>
                {
                    HolidaySettingChanged?.Invoke(sender, e);
                };
            }
        }

        /// <summary>
        /// 休日関係の設定変更イベントです。
        /// </summary>
        public event HolidaySettingChangedEventHandler HolidaySettingChanged;

        /// <summary>
        /// プロパティが変更された際に発生するイベントです。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public DefaultHolidayChecker()
        {
            PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                HolidaySettingChanged?.Invoke(sender, new HolidaySettingChangedEventArgs(e.PropertyName, e));
            };
        }

        /// <summary>
        /// 祝祭日名を返します。
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime" />。日付のみが使用され、時分秒は無視されます。</param>
        /// <returns>祝祭日名。</returns>
        public string GetHolidayName(DateTime dateTime)
        {
            return GetHolidayName(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <summary>
        /// 祝祭日名を返します。
        /// </summary>
        /// <param name="year">年。</param>
        /// <param name="month">月。</param>
        /// <param name="day">日。</param>
        /// <returns>祝祭日名。</returns>
        public string GetHolidayName(int year, int month, int day)
        {
            if (CustomHoliday != null) return CustomHoliday.GetHolidayName(year, month, day);
            else return null;
        }

        /// <summary>
        /// 祝祭日かどうかを判断します。
        /// </summary>
        /// <param name="year">年。</param>
        /// <param name="month">月。</param>
        /// <param name="day">日。</param>
        /// <returns>祝祭日の場合は true。それ以外の場合は false。</returns>
        public bool IsHoliday(int year, int month, int day)
        {
            var today = new DateTime(year, month, day);
            var holidayName = GetHolidayName(year, month, day);
            return holidayName != null;
        }

        /// <summary>
        /// 祝祭日かどうかを判断します。
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime" />。日付のみが使用され、時分秒は無視されます。</param>
        /// <returns>祝祭日の場合は true。それ以外の場合は false。</returns>
        public bool IsHoliday(DateTime dateTime)
        {
            return IsHoliday(dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}
