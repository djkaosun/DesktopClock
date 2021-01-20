using System;
using System.ComponentModel;

namespace DesktopClock.Library
{
    /// <summary>
    /// <see cref="IHolidayChecker" /> の実装です。
    /// 1948 年 7 月 20 日施行の祝日法に基づきます。これ以前の日付には例外を返します。
    /// </summary>
    public class HolidayChecker : IHolidayChecker
    {
        private static readonly TimeSpan OneDayTimeSpan = TimeSpan.FromDays(1);
        private static readonly DateTime FurikaeKyuujitsuStart = new DateTime(1973, 4, 12);
        private static readonly DateTime KokuminNoKyuujitsuStart = new DateTime(1985, 12, 27);
        private static readonly DateTime FurikaeKyuujitsuChangeAt2007 = new DateTime(2007, 1, 1);

        private bool _IsAddHolidayNameToObservedHolidayName;
        /// <summary>
        /// 振替休日に元の祝祭日名を含めるか。true の場合は <see cref="GetHolidayName(DateTime)" /> や <see cref="GetHolidayName(int, int, int)" /> が振替休日を「振替休日 (元の祝祭日名)」と、false の場合は単に「振替休日」と返すようになります。
        /// </summary>
        public bool IsAddHolidayNameToObservedHolidayName
        {
            get { return _IsAddHolidayNameToObservedHolidayName; }
            set
            {
                _IsAddHolidayNameToObservedHolidayName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAddHolidayNameToObservedHolidayName)));
            }
        }

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
                if (_CustomHoliday != null) throw new InvalidOperationException("already setted.");
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
        public HolidayChecker()
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
            DateTime today = new DateTime(year, month, day);
            string holidayName = GetHolidayNameWithoutKokuminNoKyujitsu(year, month, day);

            if (today >= KokuminNoKyuujitsuStart)
            {
                // 今日が平日 (振替休日でない)、かつ、前日と翌日が祝祭日の場合、国民の休日。
                if (holidayName == null && today.DayOfWeek != DayOfWeek.Sunday
                        && GetRawHolidayName(today - OneDayTimeSpan) != null
                        && GetRawHolidayName(today + OneDayTimeSpan) != null)
                {
                    holidayName = "国民の休日";
                }
            }

            return holidayName;
        }

        /// <summary>
        /// 振替休日まで処理し、国民の休日の処理をしていない祝祭日名を取得します。
        /// 
        /// 1973 年 4 月 12 日以降、振替休日開始。
        /// 1985 年 12 月 27 日以降、2つの祝日に挟まれた平日を休日とする国民の休日を制定。
        /// 2007 年 1 月 1 日以降、振替休日の変更。連続する祝日のうち、どれか1日が日曜日と重なった場合は、最後の祝日の翌日の5月6日が振替休日となる。
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>祝祭日名。祝祭日でない場合は null。</returns>
        private string GetHolidayNameWithoutKokuminNoKyujitsu(int year, int month, int day)
        {
            DateTime today = new DateTime(year, month, day);
            string holidayName = GetRawHolidayName(year, month, day);

            if (today >= FurikaeKyuujitsuStart && today < FurikaeKyuujitsuChangeAt2007)
            {
                string yesterdayName = GetRawHolidayName(today - OneDayTimeSpan);
                // 今日が月曜で平日、かつ、前日が祝祭日なら振替休日
                if (holidayName == null && today.DayOfWeek == DayOfWeek.Monday
                        && yesterdayName != null)
                {
                    if (IsAddHolidayNameToObservedHolidayName) holidayName = "振替休日 (" + yesterdayName + ")";
                    else holidayName = "振替休日";
                }
            }
            else if (today >= FurikaeKyuujitsuChangeAt2007)
            {
                // 今日が平日、かつ、前日以前連続して祝祭日、かつ、遡った結果日曜まで至ったら振替休日
                if (holidayName == null)
                {
                    DateTime checkDate = today - OneDayTimeSpan;
                    string checkDateName = GetRawHolidayName(checkDate);
                    while (checkDateName != null)
                    {
                        if (checkDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            if (IsAddHolidayNameToObservedHolidayName) holidayName = "振替休日 (" + checkDateName + ")";
                            else holidayName = "振替休日";
                        }
                        checkDate = checkDate - OneDayTimeSpan;
                        checkDateName = GetRawHolidayName(checkDate);
                    }
                }
            }

            if (holidayName == null && CustomHoliday != null) holidayName = CustomHoliday.GetHolidayName(year, month, day);

            return holidayName;
        }

        /// <summary>
        /// 振替休日まで処理し、国民の休日の処理をしていない祝祭日名を取得します。
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime" />。日付のみが使用され、時分秒は無視されます。</param>
        /// <returns>祝祭日名。</returns>
        private string GetHolidayNameWithoutKokuminNoKyujitsu(DateTime dateTime)
        {
            return GetHolidayNameWithoutKokuminNoKyujitsu(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <summary>
        /// 振替休日および国民の休日の処理をしていない祝日名を取得します。
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime" />。日付のみが使用され、時分秒は無視されます。</param>
        /// <returns></returns>
        private static string GetRawHolidayName(DateTime dateTime)
        {
            return GetRawHolidayName(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <summary>
        /// 振替休日および国民の休日の処理をしていない祝日名を取得します。
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns></returns>
        private static string GetRawHolidayName(int year, int month, int day)
        {
            // 1948 年 7 月 20 日施行
            if (year < 1948 || year == 1948 && month < 7 || year == 1948 && month == 7 && day < 20) throw new InvalidOperationException(); 
            switch (month)
            {
                case 1:
                    switch (day)
                    {
                        case 1:
                            return "元日";
                        case 15:
                            if (year < 2000) return "成人の日";
                            break;
                    }
                    if (year >= 2000 && new DateTime(year, month, day).DayOfWeek == DayOfWeek.Monday && day > 7 && day < 15)
                    {
                        // 第 2 月曜日
                        return "成人の日";
                    }
                    break;
                case 2:
                    switch (day)
                    {
                        case 11:
                            if (year >= 1967) return "建国記念の日";
                            break;
                        case 23:
                            if (year > 2019) return "天皇誕生日";
                            break;
                        case 24:
                            if (year == 1989) return "昭和天皇の大喪の礼";
                            break;
                    }
                    break;
                case 3:
                    switch (day)
                    {

                    }
                    if (IsShunbunnoHi(year, month, day))
                    {
                        return "春分の日";
                    }
                    break;
                case 4:
                    switch (day)
                    {
                        case 10:
                            if (year == 1959) return "明仁親王の結婚の儀";
                            break;
                        case 29:
                            if (year < 1989) return "天皇誕生日";
                            else if (year < 2007) return "みどりの日";
                            else return "昭和の日";
                            break;
                    }
                    break;
                case 5:
                    switch (day)
                    {
                        case 1:
                            if (year == 2019) return "即位の日";
                            break;
                        case 3:
                            return "憲法記念日";
                        case 4:
                            if (year >= 2007) return "みどりの日";
                            break;
                        case 5:
                            return "こどもの日";
                    }
                    break;
                case 6:
                    switch (day)
                    {
                        case 9:
                            if (year == 1993) return "徳仁親王の結婚の儀";
                            break;
                    }
                    break;
                case 7:
                    switch (day)
                    {
                        case 20:
                            if (year >= 1996 && year < 2003) return "海の日";
                            break;
                        case 22:
                            if (year == 2021) return "海の日";
                            break;
                        case 23:
                            if (year == 2020) return "海の日";
                            if (year == 2021) return "スポーツの日";
                            break;
                        case 24:
                            if (year == 2020) return "スポーツの日";
                            break;
                    }
                    if (year >= 2003 && new DateTime(year, month, day).DayOfWeek == DayOfWeek.Monday && day > 14 && day < 22)
                    {
                        // 第 3 月曜日
                        if (year != 2020 && year != 2021) return "海の日";
                    }
                    break;
                case 8:
                    switch (day)
                    {
                        case 8:
                            if (year == 2021) return "山の日";
                            break;
                        case 10:
                            if (year == 2020) return "山の日";
                            break;
                        case 11:
                            if (year >= 2016)
                            {
                                if (year != 2020 && year != 2021) return "山の日";
                            }
                            break;
                    }
                    break;
                case 9:
                    switch (day)
                    {
                        case 15:
                            if (year >= 1966 && year < 2003) return "敬老の日";
                            break;
                    }
                    if (year >= 2003 && new DateTime(year, month, day).DayOfWeek == DayOfWeek.Monday && day > 14 && day < 22)
                    {
                        // 第 3 月曜日
                        return "敬老の日";
                    }
                    if (IsShuubunnoHi(year, month, day))
                    {
                        return "秋分の日";
                    }
                    break;
                case 10:
                    switch (day)
                    {
                        case 10:
                            if (year >= 1966 && year < 2000) return "体育の日";
                            break;
                        case 22:
                            if (year == 2019) return "即位礼正殿の儀";
                            break;
                    }
                    if (year >= 2000 && new DateTime(year, month, day).DayOfWeek == DayOfWeek.Monday && day > 7 && day < 15)
                    {
                        // 第 2 月曜日
                        if (year < 2020)
                        {
                            return "体育の日";
                        }
                        else
                        {
                            if (year != 2020 && year != 2021) return "スポーツの日";
                        }
                    }
                    break;
                case 11:
                    switch (day)
                    {
                        case 3:
                            return "文化の日";
                        case 12:
                            if (year == 1990) return "即位礼正殿の儀";
                            break;
                        case 23:
                            return "勤労感謝の日";
                    }
                    break;
                case 12:
                    switch (day)
                    {
                        case 23:
                            if (year >= 1989 && year < 2019) return "天皇誕生日";
                            break;
                    }
                    break;
            }
            return null;
        }

        private static bool IsShunbunnoHi(int year, int month, int day)
        {
            if (year < 1980)
            {
                return day == Math.Truncate(20.8357 + 0.242194 * (year - 1980) - (year - 1983) / 4);
            }
            else if (year < 2100)
            {
                return day == Math.Truncate(20.8431 + 0.242194 * (year - 1980) - (year - 1980) / 4);
            }
            else if (year < 2151)
            {
                return day == Math.Truncate(21.8510 + 0.242194 * (year - 1980) - (year - 1980) / 4);
            }

            throw new NotImplementedException();
        }

        private static bool IsShuubunnoHi(int year, int month, int day)
        {
            if (year < 1980)
            {
                return day == Math.Truncate(23.2588 + 0.242194 * (year - 1980) - (year - 1983) / 4);
            }
            else if (year < 2100)
            {
                return day == Math.Truncate(23.2488 + 0.242194 * (year - 1980) - (year - 1980) / 4);
            }
            else if (year < 2151)
            {
                return day == Math.Truncate(24.2488 + 0.242194 * (year - 1980) - (year - 1980) / 4);
            }

            throw new NotImplementedException();
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
