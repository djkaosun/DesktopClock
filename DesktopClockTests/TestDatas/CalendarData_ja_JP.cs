using System;
using System.Collections;
using System.Collections.Generic;

namespace DesktopClockTests.TestDatas
{
    public class CalendarData_ja_JP : IEnumerable<object[]>
    {
        private List<object[]> _testData = new List<object[]>();

        public CalendarData_ja_JP()
        {
            {
                _testData.Add(new object[] {
                    2020,
                    1,
                    new int[,] {
                        { 29, 30, 31, 1, 2, 3, 4 },
                        { 5, 6, 7, 8, 9, 10, 11 },
                        { 12, 13, 14, 15, 16, 17, 18 },
                        { 19, 20, 21, 22, 23, 24, 25 },
                        { 26, 27, 28, 29, 30, 31, 1 },
                        { -1, -1, -1, -1, -1, -1, -1 }
                    },
                    new bool[,] {
                        { false, false, false, true, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, true, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, false, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, false },
                        { false, false, false, false, false, false, false }
                    },
                    4
                });

                _testData.Add(new object[] {
                    2020,
                    2,
                    new int[,] {
                        { 26, 27, 28, 29, 30, 31, 1 },
                        { 2, 3, 4, 5, 6, 7, 8 },
                        { 9, 10, 11, 12, 13, 14, 15 },
                        { 16, 17, 18, 19, 20, 21, 22 },
                        { 23, 24, 25, 26, 27, 28, 29 },
                        { 1, 2, 3, 4, 5, 6, 7 }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, true, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { true, true, false, false, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { false, false, false, false, false, false, false }
                    },
                    5
                });

                _testData.Add(new object[] {
                    2020,
                    3,
                    new int[,] {
                        { 23, 24, 25, 26, 27, 28, 29 },
                        { 1, 2, 3, 4, 5, 6, 7 },
                        { 8, 9, 10, 11, 12, 13, 14 },
                        { 15, 16, 17, 18, 19, 20, 21 },
                        { 22, 23, 24, 25, 26, 27, 28 },
                        { 29, 30, 31, 1, 2, 3, 4 }
                    },
                    new bool[,] {
                        { true, true, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, true, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, false, false, false, false }
                    },
                    5
                });

                _testData.Add(new object[] {
                    2020,
                    4,
                    new int[,] {
                        { 29, 30, 31, 1, 2, 3, 4 },
                        { 5, 6, 7, 8, 9, 10, 11 },
                        { 12, 13, 14, 15, 16, 17, 18 },
                        { 19, 20, 21, 22, 23, 24, 25 },
                        { 26, 27, 28, 29, 30, 1, 2 },
                        { -1, -1, -1, -1, -1, -1, -1 }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, true, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, false, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    4
                });

                _testData.Add(new object[] {
                    2020,
                    5,
                    new int[,] {
                        { 26, 27, 28, 29, 30, 1, 2 },
                        { 3, 4, 5, 6, 7, 8, 9 },
                        { 10, 11, 12, 13, 14, 15, 16 },
                        { 17, 18, 19, 20, 21, 22, 23 },
                        { 24, 25, 26, 27, 28, 29, 30 },
                        { 31, 1, 2, 3, 4, 5, 6 }
                    },
                    new bool[,] {
                        { false, false, false, true, false, false, false },
                        { true, true, true, true, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, false, false, false, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, false, false, false, false, false, false }
                    },
                    5
                });

                _testData.Add(new object[] {
                    2020,
                    6,
                    new int[,] {
                        { 31, 1, 2, 3, 4, 5, 6 },
                        { 7, 8, 9, 10, 11, 12, 13 },
                        { 14, 15, 16, 17, 18, 19, 20 },
                        { 21, 22, 23, 24, 25, 26, 27 },
                        { 28, 29, 30, 1, 2, 3, 4 },
                        { -1, -1, -1, -1, -1, -1, -1 }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, false, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    4
                });

                _testData.Add(new object[] {
                    2020,
                    7,
                    new int[,] {
                        { 28, 29, 30, 1, 2, 3, 4 },
                        { 5, 6, 7, 8, 9, 10, 11 },
                        { 12, 13, 14, 15, 16, 17, 18 },
                        { 19, 20, 21, 22, 23, 24, 25 },
                        { 26, 27, 28, 29, 30, 31, 1 },
                        { -1, -1, -1, -1, -1, -1, -1 }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, true, true, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, false, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, false },
                        { false, false, false, false, false, false, false }
                    },
                    4
                });

                _testData.Add(new object[] {
                    2020,
                    8,
                    new int[,] {
                        { 26, 27, 28, 29, 30, 31, 1 },
                        { 2, 3, 4, 5, 6, 7, 8 },
                        { 9, 10, 11, 12, 13, 14, 15 },
                        { 16, 17, 18, 19, 20, 21, 22 },
                        { 23, 24, 25, 26, 27, 28, 29 },
                        { 30, 31, 1, 2, 3, 4, 5 }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, true, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, false, false, false, false, false }
                    },
                    5
                });

                _testData.Add(new object[] {
                    2020,
                    9,
                    new int[,] {
                        { 30, 31, 1, 2, 3, 4, 5 },
                        { 6, 7, 8, 9, 10, 11, 12 },
                        { 13, 14, 15, 16, 17, 18, 19 },
                        { 20, 21, 22, 23, 24, 25, 26 },
                        { 27, 28, 29, 30, 1, 2, 3 },
                        { -1, -1, -1, -1, -1, -1, -1 }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, true, true, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    4
                });

                _testData.Add(new object[] {
                    2020,
                    10,
                    new int[,] {
                        { 27, 28, 29, 30, 1, 2, 3 },
                        { 4, 5, 6, 7, 8, 9, 10 },
                        { 11, 12, 13, 14, 15, 16, 17 },
                        { 18, 19, 20, 21, 22, 23, 24 },
                        { 25, 26, 27, 28, 29, 30, 31 },
                        { 1, 2, 3, 4, 5, 6, 7 }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, true, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, false, false, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { false, false, false, false, false, false, false }
                    },
                    5
                });

                _testData.Add(new object[] {
                    2020,
                    11,
                    new int[,] {
                        { 25, 26, 27, 28, 29, 30, 31 },
                        { 1, 2, 3, 4, 5, 6, 7 },
                        { 8, 9, 10, 11, 12, 13, 14 },
                        { 15, 16, 17, 18, 19, 20, 21 },
                        { 22, 23, 24, 25, 26, 27, 28 },
                        { 29, 30, 1, 2, 3, 4, 5 }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { false, false, true, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, true, false, false, false, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, false, false, false, false, false }
                    },
                    5
                });

                _testData.Add(new object[] {
                    2020,
                    12,
                    new int[,] {
                        { 29, 30, 1, 2, 3, 4, 5 },
                        { 6, 7, 8, 9, 10, 11, 12 },
                        { 13, 14, 15, 16, 17, 18, 19 },
                        { 20, 21, 22, 23, 24, 25, 26 },
                        { 27, 28, 29, 30, 31, 1, 2 },
                        { -1, -1, -1, -1, -1, -1, -1 }
                    },
                    new bool[,] {
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, false, false },
                        { false, false, false, false, false, true, false },
                        { false, false, false, false, false, false, false }
                    },
                    new bool[,] {
                        { false, false, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, true, true },
                        { true, true, true, true, true, false, false },
                        { false, false, false, false, false, false, false }
                    },
                    4
                });

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
