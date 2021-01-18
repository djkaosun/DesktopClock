using System;
using System.ComponentModel;

namespace DesktopClock.Library
{
    /// <summary>
    /// ある日付に対応する祝祭日名を返すための処理を担います。
    /// </summary>
    public interface IHolidayChecker : INotifyHolidaySettingChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// 振替休日に元の祝祭日名を含めるか。true の場合は <see cref="GetHolidayName(DateTime)" /> や <see cref="GetHolidayName(int, int, int)" /> が振替休日を「振替休日 (元の祝祭日名)」と、false の場合は単に「振替休日」と返すようになります。
        /// </summary>
        public bool IsAddHolidayNameToObservedHolidayName { get; set; }

        /// <summary>
        /// カスタム休日を処理する <see cref="ICustomHoliday" /> を格納します。
        /// </summary>
        public ICustomHoliday CustomHoliday { get; set; }

        /// <summary>
        /// 祝祭日かどうかを判断します。
        /// </summary>
        /// <param name="year">年。</param>
        /// <param name="month">月。</param>
        /// <param name="day">日。</param>
        /// <returns>祝祭日の場合は true。それ以外の場合は false。</returns>
        public bool IsHoliday(int year, int month, int day);

        /// <summary>
        /// 祝祭日かどうかを判断します。
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime" /></param>
        /// <returns>祝祭日の場合は true。それ以外の場合は false。</returns>
        public bool IsHoliday(DateTime dateTime);

        /// <summary>
        /// 祝祭日名を取得します。
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        /// <returns>祝祭日名。</returns>
        public string GetHolidayName(int year, int month, int day);

        /// <summary>
        /// 祝祭日名を取得します。
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime" /></param>
        /// <returns>祝祭日名。</returns>
        public string GetHolidayName(DateTime dateTime);
    }
}
