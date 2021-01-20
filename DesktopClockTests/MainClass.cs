using System;
using System.ComponentModel;
using DesktopClock.Library;

namespace DesktopClockTests
{
    class MainClass
    {
        static void Main(string[] args)
        {
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
            }
        }
    }
}
