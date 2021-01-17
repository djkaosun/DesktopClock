using System;
using System.Windows;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace DesktopClock
{
    /// <summary>
    /// CalendarWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CalendarWindow : Window
    {
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
                    int X, int Y,
                    int cx, int cy,
                    int uFlags);

        public CalendarWindow()
        {
            InitializeComponent();
        }

        public static void SetAsBottomMost(Window wnd)
        {
            //  Get the handle to the specified window 
            IntPtr hWnd = new WindowInteropHelper(wnd).Handle;

            // Set the window position to HWND_BOTTOM 
            SetWindowPos(hWnd, new IntPtr(1), 0, 0, 0, 0,
               SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            SetAsBottomMost(this);
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            SetAsBottomMost(this);
        }
    }
}
