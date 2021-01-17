using System;
using System.Windows;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace DesktopClock
{
    /// <summary>
    /// 私が知る限り、この権利を行うにはP/Invokeする必要があります。 
    /// SetWindowPos functionに電話をかけ、ウィンドウのハンドルとHWND_BOTTOMフラグを指定します。
    ///これは、ウィンドウをZオーダーの下に移動し、他のウィンドウを隠すのを防ぎます。
    /// https://stackoverrun.com/ja/q/1223603
    /// </summary>
    public static class BottomMost
    {
        private const int SWP_NOSIZE = 0x1;
        private const int SWP_NOMOVE = 0x2;
        private const int SWP_NOACTIVATE = 0x10;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
                    int X, int Y,
                    int cx, int cy,
                    int uFlags);

        public static void SetAsBottomMost(Window wnd) {
            //  Get the handle to the specified window 
            IntPtr hWnd = new WindowInteropHelper(wnd).Handle;

            // Set the window position to HWND_BOTTOM 
            SetWindowPos(hWnd, new IntPtr(1), 0, 0, 0, 0,
               SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
        }
    }
}
