using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DesktopClock.Library;

namespace DesktopClockTests
{
    class MainClass
    {/*
        static void Main(string[] args)
        {
            var holidaysCollection = new ObservableCollection<KeyValuePair<DateTime, string>>();
            holidaysCollection.Add(new DateTime(2020, 1, 2), "HolidayName");
            Console.WriteLine(CustomHolidaysParser.Serialize(holidaysCollection));

            for (int i = 1; i <= 12; i++)
            {
                Console.WriteLine("_testData.Add(new object[] {");

                Calendar.GetCalendar(2020, i, new HolidayChecker(), out int[,] days, out bool[,] isHoliday, out bool[,] isThisMonth, out int lastRow);

                // year
                Console.WriteLine("    2020,");

                // month
                Console.WriteLine("    " + i + ",");

                // days
                Console.WriteLine("    new int[,] {");
                for (int row = 0; row < days.GetLength(0); row++)
                {
                    if (row == 0)
                    {
                        Console.Write("        { ");
                        for (int col = 0; col < days.GetLength(1); col++)
                        {
                            if (col == 0) Console.Write(days[row, col]);
                            else Console.Write(", " + days[row, col]);
                        }
                        Console.Write(" }");
                    }
                    else
                    {
                        Console.WriteLine(",");
                        Console.Write("        { ");
                        for (int col = 0; col < days.GetLength(1); col++)
                        {
                            if (col == 0) Console.Write(days[row, col]);
                            else Console.Write(", " + days[row, col]);
                        }
                        Console.Write(" }");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("    },");

                // isHoliday
                Console.WriteLine("    new bool[,] {");
                for (int row = 0; row < isHoliday.GetLength(0); row++)
                {
                    if (row == 0)
                    {
                        Console.Write("        { ");
                        for (int col = 0; col < isHoliday.GetLength(1); col++)
                        {
                            if (col == 0) Console.Write(isHoliday[row, col].ToString().ToLower());
                            else Console.Write(", " + isHoliday[row, col].ToString().ToLower());
                        }
                        Console.Write(" }");
                    }
                    else
                    {
                        Console.WriteLine(",");
                        Console.Write("        { ");
                        for (int col = 0; col < isHoliday.GetLength(1); col++)
                        {
                            if (col == 0) Console.Write(isHoliday[row, col].ToString().ToLower());
                            else Console.Write(", " + isHoliday[row, col].ToString().ToLower());
                        }
                        Console.Write(" }");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("    },");

                // isThisMonth
                Console.WriteLine("    new bool[,] {");
                for (int row = 0; row < isThisMonth.GetLength(0); row++)
                {
                    if (row == 0)
                    {
                        Console.Write("        { ");
                        for (int col = 0; col < isThisMonth.GetLength(1); col++)
                        {
                            if (col == 0) Console.Write(isThisMonth[row, col].ToString().ToLower());
                            else Console.Write(", " + isThisMonth[row, col].ToString().ToLower());
                        }
                        Console.Write(" }");
                    }
                    else
                    {
                        Console.WriteLine(",");
                        Console.Write("        { ");
                        for (int col = 0; col < isThisMonth.GetLength(1); col++)
                        {
                            if (col == 0) Console.Write(isThisMonth[row, col].ToString().ToLower());
                            else Console.Write(", " + isThisMonth[row, col].ToString().ToLower());
                        }
                        Console.Write(" }");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("    },");

                // lastRow
                Console.WriteLine("    " + lastRow);
                Console.WriteLine("});");
                Console.WriteLine();


                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                var holidayCheker = new HolidayChecker() { IsAddHolidayNameToObservedHolidayName = true };
                var dateTime = new DateTime(1948, 7, 20);
                var endDateTime = new DateTime(2026, 1, 1);
                var oneDaySpan = TimeSpan.FromDays(1);
                for (; dateTime < endDateTime; dateTime += oneDaySpan)
                {
                    var holidayName = holidayCheker.GetHolidayName(dateTime);
                    if (holidayName != null && holidayName.Contains("振替休日"))
                    {
                        Console.Write("_testData.Add(new object[] { ");
                        Console.Write("new DateTime({0}, {1}, {2}), ", dateTime.Year, dateTime.Month, dateTime.Day);
                        Console.Write("\"{0}\"", holidayName);
                        Console.WriteLine(" });");
                    }
                }
            }


            var dtes = new DateTimeEventSource();
            dtes.PropertyChanged += (object item, PropertyChangedEventArgs e) => { Console.WriteLine(e.PropertyName); };
            dtes.Start();
            Console.WriteLine("---- test1 ----");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("---- test2 ----");
            System.Threading.Thread.Sleep(5000);
            dtes.Stop();
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("---- test3 ----");
            Console.WriteLine("");

        }//*/
    }
}
