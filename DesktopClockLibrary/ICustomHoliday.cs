using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesktopClock.Library
{
     /// <summary>
     /// カスタム休日。
     /// </summary>
    public interface ICustomHoliday
    {
        /// <summary>
        /// カスタム休日の一覧。変更イベントを外部で処理できるよう <see cref="System.Collections.ObjectModel.ObservableCollection{T}"/> です。
        /// </summary>
        ObservableCollection<KeyValuePair<DateTime, string>> Holidays { get; set; }

        /// <summary>
        /// 年月日に対応するカスタム休日の名前を取得します。
        /// </summary>
        /// <param name="year">年。</param>
        /// <param name="month">月。</param>
        /// <param name="day">日。</param>
        /// <returns>カスタム休日名。</returns>
        public string GetHolidayName(int year, int month, int day);
    }
}
