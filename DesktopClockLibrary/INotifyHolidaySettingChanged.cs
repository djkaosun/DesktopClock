using System;

namespace DesktopClock.Library
{
    /// <summary>
    /// 休日関係の設定が変更されたことを示すイベントを発生しうることを示します。
    /// </summary>
    public interface INotifyHolidaySettingChanged
    {
        /// <summary>
        /// 休日関係の設定が変更されたことを示すイベントです。
        /// </summary>
        public event HolidaySettingChangedEventHandler HolidaySettingChanged;
    }

    /// <summary>
    /// 休日関係の設定が変更されたことを示すイベントに対する、イベント ハンドラーです。
    /// </summary>
    /// <param name="sender">イベントの発生元。</param>
    /// <param name="e">イベントの引数。</param>
    public delegate void HolidaySettingChangedEventHandler(object sender, HolidaySettingChangedEventArgs e);
}
