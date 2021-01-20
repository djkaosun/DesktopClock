using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClockTests
{
    class NotHolidayData : IEnumerable<object[]>
    {
        private List<object[]> _testData = new List<object[]>();

        public NotHolidayData()
        {
            var holidayData = new HolidayData();
            var dateTime = new DateTime(1948, 7, 20);
            var endDateTime = new DateTime(2026, 1, 1);
            var oneDaySpan = TimeSpan.FromDays(1);
            for (; dateTime < endDateTime; dateTime += oneDaySpan)
            {
               if(!holidayData.HolidayDateTimeList.Contains(dateTime)) _testData.Add(new object[] { dateTime });
            }
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return ((IEnumerable<object[]>)_testData).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_testData).GetEnumerator();
        }
    }
}
