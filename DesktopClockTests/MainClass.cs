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
        }
    }
}
