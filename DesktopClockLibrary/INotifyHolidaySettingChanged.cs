using System;

namespace DesktopClock.Library
{
    public interface INotifyHolidaySettingChanged
    {
        public event HolidaySettingChangedEventHandler HolidaySettingChanged;
    }

    public delegate void HolidaySettingChangedEventHandler(object sender, NotifyHolidaySettingChangedEventArgs e);
}
