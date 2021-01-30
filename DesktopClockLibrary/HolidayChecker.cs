using System;
using System.Globalization;
using System.Threading;

namespace DesktopClock.Library
{
    /// <summary>
    /// カルチャーに対応した <see cref="IHolidayChecker" /> を返します。
    /// </summary>
    public static class HolidayChecker
    {
        /// <summary>
        /// カルチャーに対応した <see cref="IHolidayChecker" /> を返します。
        /// </summary>
        /// <param name="cultureName">カルチャーを示す文字列。</param>
        /// <returns></returns>
        public static IHolidayChecker GetHolidayChecker(string cultureName)
        {
            switch (cultureName)
            {
                case "ja-JP":
                    return new HolidayChecker_ja_JP();
                default:
                    return new DefaultHolidayChecker();
            }
        }

        /// <summary>
        /// カルチャーに対応した <see cref="IHolidayChecker" /> を返します。
        /// </summary>
        /// <param name="culture"><see cref="CultureInfo" /></param>
        /// <returns></returns>
        public static IHolidayChecker GetHolidayChecker(CultureInfo culture)
        {
            return GetHolidayChecker(culture.Name);
        }

        /// <summary>
        /// スレッドの現在のカルチャーに対応した <see cref="IHolidayChecker" /> を返します。
        /// </summary>
        public static IHolidayChecker GetHolidayChecker()
        {
            return GetHolidayChecker(Thread.CurrentThread.CurrentCulture);
        }
    }
}
