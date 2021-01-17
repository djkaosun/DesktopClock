using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClock.Library
{
    public interface ICustomHoliday
    {
        ObservableCollection<KeyValuePair<DateTime, string>> Holidays { get; set; }
        public string GetHolidayName(int year, int month, int day);
    }
}
