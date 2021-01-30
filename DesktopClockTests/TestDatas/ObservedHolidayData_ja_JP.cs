using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClockTests.TestDatas
{
    public class ObservedHolidayData_ja_JP : IEnumerable<object[]>    {

        private List<object[]> _testData = new List<object[]>();

        public ObservedHolidayData_ja_JP()
        {
            _testData.Add(new object[] { new DateTime(1973, 4, 30), "振替休日 (天皇誕生日)" });
            _testData.Add(new object[] { new DateTime(1973, 9, 24), "振替休日 (秋分の日)" });
            _testData.Add(new object[] { new DateTime(1974, 5, 6), "振替休日 (こどもの日)" });
            _testData.Add(new object[] { new DateTime(1974, 9, 16), "振替休日 (敬老の日)" });
            _testData.Add(new object[] { new DateTime(1974, 11, 4), "振替休日 (文化の日)" });
            _testData.Add(new object[] { new DateTime(1975, 11, 24), "振替休日 (勤労感謝の日)" });
            _testData.Add(new object[] { new DateTime(1976, 10, 11), "振替休日 (体育の日)" });
            _testData.Add(new object[] { new DateTime(1978, 1, 2), "振替休日 (元日)" });
            _testData.Add(new object[] { new DateTime(1978, 1, 16), "振替休日 (成人の日)" });
            _testData.Add(new object[] { new DateTime(1979, 2, 12), "振替休日 (建国記念の日)" });
            _testData.Add(new object[] { new DateTime(1979, 4, 30), "振替休日 (天皇誕生日)" });
            _testData.Add(new object[] { new DateTime(1980, 11, 24), "振替休日 (勤労感謝の日)" });
            _testData.Add(new object[] { new DateTime(1981, 5, 4), "振替休日 (憲法記念日)" });
            _testData.Add(new object[] { new DateTime(1982, 3, 22), "振替休日 (春分の日)" });
            _testData.Add(new object[] { new DateTime(1982, 10, 11), "振替休日 (体育の日)" });
            _testData.Add(new object[] { new DateTime(1984, 1, 2), "振替休日 (元日)" });
            _testData.Add(new object[] { new DateTime(1984, 1, 16), "振替休日 (成人の日)" });
            _testData.Add(new object[] { new DateTime(1984, 4, 30), "振替休日 (天皇誕生日)" });
            _testData.Add(new object[] { new DateTime(1984, 9, 24), "振替休日 (秋分の日)" });
            _testData.Add(new object[] { new DateTime(1985, 5, 6), "振替休日 (こどもの日)" });
            _testData.Add(new object[] { new DateTime(1985, 9, 16), "振替休日 (敬老の日)" });
            _testData.Add(new object[] { new DateTime(1985, 11, 4), "振替休日 (文化の日)" });
            _testData.Add(new object[] { new DateTime(1986, 11, 24), "振替休日 (勤労感謝の日)" });
            _testData.Add(new object[] { new DateTime(1987, 5, 4), "振替休日 (憲法記念日)" });
            _testData.Add(new object[] { new DateTime(1988, 3, 21), "振替休日 (春分の日)" });
            _testData.Add(new object[] { new DateTime(1989, 1, 2), "振替休日 (元日)" });
            _testData.Add(new object[] { new DateTime(1989, 1, 16), "振替休日 (成人の日)" });
            _testData.Add(new object[] { new DateTime(1990, 2, 12), "振替休日 (建国記念の日)" });
            _testData.Add(new object[] { new DateTime(1990, 4, 30), "振替休日 (みどりの日)" });
            _testData.Add(new object[] { new DateTime(1990, 9, 24), "振替休日 (秋分の日)" });
            _testData.Add(new object[] { new DateTime(1990, 12, 24), "振替休日 (天皇誕生日)" });
            _testData.Add(new object[] { new DateTime(1991, 5, 6), "振替休日 (こどもの日)" });
            _testData.Add(new object[] { new DateTime(1991, 9, 16), "振替休日 (敬老の日)" });
            _testData.Add(new object[] { new DateTime(1991, 11, 4), "振替休日 (文化の日)" });
            _testData.Add(new object[] { new DateTime(1992, 5, 4), "振替休日 (憲法記念日)" });
            _testData.Add(new object[] { new DateTime(1993, 10, 11), "振替休日 (体育の日)" });
            _testData.Add(new object[] { new DateTime(1995, 1, 2), "振替休日 (元日)" });
            _testData.Add(new object[] { new DateTime(1995, 1, 16), "振替休日 (成人の日)" });
            _testData.Add(new object[] { new DateTime(1996, 2, 12), "振替休日 (建国記念の日)" });
            _testData.Add(new object[] { new DateTime(1996, 5, 6), "振替休日 (こどもの日)" });
            _testData.Add(new object[] { new DateTime(1996, 9, 16), "振替休日 (敬老の日)" });
            _testData.Add(new object[] { new DateTime(1996, 11, 4), "振替休日 (文化の日)" });
            _testData.Add(new object[] { new DateTime(1997, 7, 21), "振替休日 (海の日)" });
            _testData.Add(new object[] { new DateTime(1997, 11, 24), "振替休日 (勤労感謝の日)" });
            _testData.Add(new object[] { new DateTime(1998, 5, 4), "振替休日 (憲法記念日)" });
            _testData.Add(new object[] { new DateTime(1999, 3, 22), "振替休日 (春分の日)" });
            _testData.Add(new object[] { new DateTime(1999, 10, 11), "振替休日 (体育の日)" });
            _testData.Add(new object[] { new DateTime(2001, 2, 12), "振替休日 (建国記念の日)" });
            _testData.Add(new object[] { new DateTime(2001, 4, 30), "振替休日 (みどりの日)" });
            _testData.Add(new object[] { new DateTime(2001, 9, 24), "振替休日 (秋分の日)" });
            _testData.Add(new object[] { new DateTime(2001, 12, 24), "振替休日 (天皇誕生日)" });
            _testData.Add(new object[] { new DateTime(2002, 5, 6), "振替休日 (こどもの日)" });
            _testData.Add(new object[] { new DateTime(2002, 9, 16), "振替休日 (敬老の日)" });
            _testData.Add(new object[] { new DateTime(2002, 11, 4), "振替休日 (文化の日)" });
            _testData.Add(new object[] { new DateTime(2003, 11, 24), "振替休日 (勤労感謝の日)" });
            _testData.Add(new object[] { new DateTime(2005, 3, 21), "振替休日 (春分の日)" });
            _testData.Add(new object[] { new DateTime(2006, 1, 2), "振替休日 (元日)" });
            _testData.Add(new object[] { new DateTime(2007, 2, 12), "振替休日 (建国記念の日)" });
            _testData.Add(new object[] { new DateTime(2007, 4, 30), "振替休日 (昭和の日)" });
            _testData.Add(new object[] { new DateTime(2007, 9, 24), "振替休日 (秋分の日)" });
            _testData.Add(new object[] { new DateTime(2007, 12, 24), "振替休日 (天皇誕生日)" });
            _testData.Add(new object[] { new DateTime(2008, 5, 6), "振替休日 (みどりの日)" });
            _testData.Add(new object[] { new DateTime(2008, 11, 24), "振替休日 (勤労感謝の日)" });
            _testData.Add(new object[] { new DateTime(2009, 5, 6), "振替休日 (憲法記念日)" });
            _testData.Add(new object[] { new DateTime(2010, 3, 22), "振替休日 (春分の日)" });
            _testData.Add(new object[] { new DateTime(2012, 1, 2), "振替休日 (元日)" });
            _testData.Add(new object[] { new DateTime(2012, 4, 30), "振替休日 (昭和の日)" });
            _testData.Add(new object[] { new DateTime(2012, 12, 24), "振替休日 (天皇誕生日)" });
            _testData.Add(new object[] { new DateTime(2013, 5, 6), "振替休日 (こどもの日)" });
            _testData.Add(new object[] { new DateTime(2013, 11, 4), "振替休日 (文化の日)" });
            _testData.Add(new object[] { new DateTime(2014, 5, 6), "振替休日 (みどりの日)" });
            _testData.Add(new object[] { new DateTime(2014, 11, 24), "振替休日 (勤労感謝の日)" });
            _testData.Add(new object[] { new DateTime(2015, 5, 6), "振替休日 (憲法記念日)" });
            _testData.Add(new object[] { new DateTime(2016, 3, 21), "振替休日 (春分の日)" });
            _testData.Add(new object[] { new DateTime(2017, 1, 2), "振替休日 (元日)" });
            _testData.Add(new object[] { new DateTime(2018, 2, 12), "振替休日 (建国記念の日)" });
            _testData.Add(new object[] { new DateTime(2018, 4, 30), "振替休日 (昭和の日)" });
            _testData.Add(new object[] { new DateTime(2018, 9, 24), "振替休日 (秋分の日)" });
            _testData.Add(new object[] { new DateTime(2018, 12, 24), "振替休日 (天皇誕生日)" });
            _testData.Add(new object[] { new DateTime(2019, 5, 6), "振替休日 (こどもの日)" });
            _testData.Add(new object[] { new DateTime(2019, 8, 12), "振替休日 (山の日)" });
            _testData.Add(new object[] { new DateTime(2019, 11, 4), "振替休日 (文化の日)" });
            _testData.Add(new object[] { new DateTime(2020, 2, 24), "振替休日 (天皇誕生日)" });
            _testData.Add(new object[] { new DateTime(2020, 5, 6), "振替休日 (憲法記念日)" });
            _testData.Add(new object[] { new DateTime(2021, 8, 9), "振替休日 (山の日)" });
            _testData.Add(new object[] { new DateTime(2023, 1, 2), "振替休日 (元日)" });
            _testData.Add(new object[] { new DateTime(2024, 2, 12), "振替休日 (建国記念の日)" });
            _testData.Add(new object[] { new DateTime(2024, 5, 6), "振替休日 (こどもの日)" });
            _testData.Add(new object[] { new DateTime(2024, 8, 12), "振替休日 (山の日)" });
            _testData.Add(new object[] { new DateTime(2024, 9, 23), "振替休日 (秋分の日)" });
            _testData.Add(new object[] { new DateTime(2024, 11, 4), "振替休日 (文化の日)" });
            _testData.Add(new object[] { new DateTime(2025, 2, 24), "振替休日 (天皇誕生日)" });
            _testData.Add(new object[] { new DateTime(2025, 5, 6), "振替休日 (みどりの日)" });
            _testData.Add(new object[] { new DateTime(2025, 11, 24), "振替休日 (勤労感謝の日)" });
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
