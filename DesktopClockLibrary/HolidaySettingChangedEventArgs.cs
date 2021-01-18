using System;

namespace DesktopClock.Library
{
    /// <summary>
    /// 休日関係のイベント ハンドラーに渡される引数。
    /// </summary>
    public class HolidaySettingChangedEventArgs : EventArgs
    {
        /// <summary>
        /// どのプロパティが変更されたかを示します。
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// 他のイベントを <see cref="INotifyHolidaySettingChanged.HolidaySettingChanged" /> に変換して伝播した際、
        /// 元のイベントから渡された <see cref="EventArgs" /> が入ります。
        /// 元のイベントがない場合は null です。
        /// </summary>
        public EventArgs OriginalEventArgs { get; private set; }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="propertyName">プロパティ名。</param>
        /// <param name="originalEventArgs">元イベントの引数</param>
        public HolidaySettingChangedEventArgs(string propertyName, EventArgs originalEventArgs)
        {
            PropertyName = propertyName;
            OriginalEventArgs = originalEventArgs;
        }
    }
}
