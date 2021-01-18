using System;

namespace DesktopClock.Library
{
    public class NotifyHolidaySettingChangedEventArgs : EventArgs
    {
        public string PropertyName { get; private set; }
        public EventArgs OriginalEventArgs { get; private set; }
        public NotifyHolidaySettingChangedEventArgs(string propertyName, EventArgs originalEventArgs = null)
        {
            PropertyName = propertyName;
            OriginalEventArgs = originalEventArgs;
        }
    }
}
