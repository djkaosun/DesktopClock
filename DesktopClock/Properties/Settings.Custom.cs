using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DesktopClock.Library;

namespace DesktopClock.Properties
{


    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {
        [System.Configuration.UserScopedSetting()]
        [System.Diagnostics.DebuggerNonUserCode()]
        [System.Configuration.DefaultSettingValue("0")]
        public System.Windows.VerticalAlignment VerticalAlignment
        {
            get
            {
                return ((System.Windows.VerticalAlignment)(this[nameof(VerticalAlignment)]));
            }
            set
            {
                this[nameof(VerticalAlignment)] = value;
            }
        }

        [System.Configuration.UserScopedSetting()]
        [System.Diagnostics.DebuggerNonUserCode()]
        [System.Configuration.DefaultSettingValue("2")]
        public System.Windows.HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return ((System.Windows.HorizontalAlignment)(this[nameof(HorizontalAlignment)]));
            }
            set
            {
                this[nameof(HorizontalAlignment)] = value;
            }
        }

    }
}
