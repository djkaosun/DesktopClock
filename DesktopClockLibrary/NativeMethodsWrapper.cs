using System;
using System.Windows;
using System.Windows.Interop;
using System.Text;

namespace DesktopClock.Library
{
    /// <summary>
    /// ネイティブ メソッドのラッパークラスです。
    /// </summary>
    public class NativeMethodsWrapper
    {
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint WINEVENT_OUTOFCONTEXT = 0x0000;

        /// <summary>
        /// フック済みかどうかを取得します。
        /// </summary>
        public static bool IsHooked { get; private set; }

        /// <summary>
        /// フックの対象とするウィンドウをセットします。
        /// </summary>
        public Window Window { get; set; }

        private static IntPtr? _hookIntPtr { get; set; }

        private static WinEventDelegate _delegate { get; set; }

        /// <summary>
        /// WinuserEvent に連動して発生するイベント。
        /// </summary>
        public WinuserEventDelegate WinuserEventOccured;

        /// <summary>
        /// ウィンドウを最背面にします。
        /// </summary>
        /// <param name="wnd">対象のウィンドウ</param>
        public  static void SetAsBottomMost(Window wnd)
        {
            //  Get the handle to the specified window 
            IntPtr hWnd = new WindowInteropHelper(wnd).Handle;

            // Set the window position to HWND_BOTTOM 
            NativeMethods.SetWindowPos(hWnd, new IntPtr(1), 0, 0, 0, 0,
               SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
        }

        /// <summary>
        /// フックを開始します。
        /// </summary>
        /// <param name="winuserEvent">フック対象のイベント。</param>
        public void AddHook(WinuserEvent winuserEvent)
        {
            if (Window == null) throw new InvalidOperationException("Window is not set.");
            if (IsHooked) return;

            IsHooked = true;

            _delegate = new WinEventDelegate(WinEventHook);
            _hookIntPtr = NativeMethods.SetWinEventHook((uint)winuserEvent, (uint)winuserEvent, IntPtr.Zero, _delegate, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        /// <summary>
        /// フックを解除します。
        /// </summary>
        public void RemoveHook()
        {
            if (!IsHooked) return;

            IsHooked = false;

            NativeMethods.UnhookWinEvent(_hookIntPtr.Value);

            _delegate = null;
            _hookIntPtr = null;
        }

        private static string GetWindowClass(IntPtr hwnd)
        {
            // 32 文字の容量を持つ StringBuilder
            StringBuilder _sb = new StringBuilder(32);
            NativeMethods.GetClassName(hwnd, _sb, _sb.Capacity);
            return _sb.ToString();
        }

        /// <summary>
        /// イベント フック関数。
        /// </summary>
        /// <param name="hWinEventHook">イベントフック関数のハンドル。
        /// この値は、フック関数がインストールされたときにSetWinEventHookによって返され、フック関数の各インスタンスに固有の値です。</param>
        /// <param name="eventType">発生したイベントを指定します。この値は<a href="https://docs.microsoft.com/en-us/windows/win32/winauto/event-constants">イベント定数</a>の一つです。</param>
        /// <param name="hwnd">イベントを生成するウィンドウへのハンドル、またはイベントに関連するウィンドウがない場合はNULL。
        /// 例えば、マウスポインタはウィンドウに関連付けられていません。</param>
        /// <param name="idObject">イベントに関連付けられたオブジェクトを識別します。
        /// これは、オブジェクト識別子またはカスタムオブジェクトIDのいずれかです。</param>
        /// <param name="idChild">イベントがオブジェクトによってトリガされたのか、オブジェクトの子要素によってトリガされたのかを識別します。
        /// この値がCHILDID_SELFの場合、イベントはオブジェクトによってトリガされ、そうでない場合、この値はイベントをトリガした要素の子IDとなります。</param>
        /// <param name="dwEventThread"></param>
        /// <param name="dwmsEventTime">イベントが生成された時間をミリ秒単位で指定します。</param>
        private void WinEventHook(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            string windowClassName = GetWindowClass(hwnd);
            WinuserEventOccured?.Invoke((WinuserEvent)eventType, windowClassName);
        }
    }

    /// <summary>
    /// WinuserEvent を処理するハンドラーのデリゲート。
    /// </summary>
    /// <param name="winuserEvent"><see cref="WinuserEvent" /></param>
    /// <param name="windowClassName">クラス名。</param>
    public delegate void WinuserEventDelegate(WinuserEvent winuserEvent, string windowClassName);
}
