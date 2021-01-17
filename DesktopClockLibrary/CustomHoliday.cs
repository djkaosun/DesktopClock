using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClock.Library
{
    public class CustomHoliday : ICustomHoliday
    {
        private ObservableCollection<KeyValuePair<DateTime, string>> _Holidays;
        public ObservableCollection<KeyValuePair<DateTime, string>> Holidays
        {
            get { return _Holidays; }
            set
            {
                if (_Holidays != null) throw new InvalidOperationException("already setted.");

                _Holidays = value;
            }
        }

        public string GetHolidayName(int year, int month, int day)
        {
            if (Holidays == null) return null;

            var today = new DateTime(year, month, day);
            string holidayName = null;
            if (Holidays.ContainsKey(today))
            {
                holidayName = Holidays.GetValue(today);
            }
            return holidayName;
        }
    }
}
