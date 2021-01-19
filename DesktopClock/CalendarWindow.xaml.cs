using System;
using System.Windows;
using DesktopClock.Library;

namespace DesktopClock
{
    /// <summary>
    /// CalendarWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CalendarWindow : Window
    {

        public CalendarWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            NativeMethodsWrapper.SetAsBottomMost(this);
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            NativeMethodsWrapper.SetAsBottomMost(this);
        }
    }
}
