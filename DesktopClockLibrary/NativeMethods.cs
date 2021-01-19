using System;
using System.Windows;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Text;

namespace DesktopClock.Library
{
    internal static class NativeMethods
    {
        /// <summary>
        /// 子ウィンドウ、ポップアップ ウィンドウ、トップレベル ウィンドウのサイズ、位置、および Z オーダーを変更します。
        /// これらのウィンドウは、スクリーン上での外観に応じて順番に並べられています。
        /// 一番上のウィンドウが最も高いランクを受け取り、Z オーダーの最初のウィンドウとなります。
        /// </summary>
        /// <param name="hWnd">ウィンドウへのハンドル。</param>
        /// <param name="hWndInsertAfter">   Z オーダーを決めるためのウィンドウハンドルを指定します。
        /// hWnd で指定したウインドウは、このパラメータで指定したウィンドウの後ろに置かれます。
        /// このパラメータは、ウィンドウのハンドル、または以下の値のいずれかでなければなりません。
        /// <list type="table">
        /// <item>
        /// <term>HWND_BOTTOM (HWND)1</term>
        /// <description>ウィンドウを Z オーダーの一番下に配置します。
        /// hWndパラメータが topmost ウィンドウを特定した場合、ウィンドウは topmost の状態を失い、他のすべてのウィンドウの最下段に配置されます。</description>
        /// </item>
        /// <item>
        /// <term>HWND_NOTOPMOST (HWND)-2</term>
        /// <description>ウィンドウを non-topmost ウィンドウの上に配置します (つまり、topmost のウィンドウの後ろに配置します)。
        /// このフラグは、ウィンドウが既に non-topmost ウィンドウである場合には何の効果もありません。</description>
        /// </item>
        /// <item>
        /// <term>HWND_TOP (HWND)0</term>
        /// <description>ウィンドウを Z オーダーの先頭に配置します。</description>
        /// </item>
        /// <item>
        /// <term>HWND_TOPMOST (HWND)-1</term>
        /// <description>ウィンドウを non-topmost なすべてのウィンドウの上に配置します。ウィンドウが無効化されていても、ウィンドウは最上段の位置を維持します。</description>
        /// </item>
        /// </list>
        /// このパラメータの使用方法の詳細については、以下を参照してください。
        ///  https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowpos </param>
        /// <param name="X">ウィンドウの左側の新しい位置をクライアント座標で指定します。</param>
        /// <param name="Y">ウィンドウの上部の新しい位置をクライアント座標で指定します。</param>
        /// <param name="cx">ウィンドウの新しい幅をピクセル単位で指定します。</param>
        /// <param name="cy">ウィンドウの新しい高さをピクセル単位で指定します。</param>
        /// <param name="uFlags">ウィンドウのサイズと位置を指定するフラグです。このパラメータは、以下の値を組み合わせて使用することができます。
        /// <list type="table">
        /// <item>
        /// <term>SWP_ASYNCWINDOWPOS 0x4000</term>
        /// <description>呼び出し元のスレッドとウィンドウを所有するスレッドが異なる入力キューにアタッチされている場合、システムはウィンドウを所有するスレッドにリクエストをポストします。
        /// これにより、他のスレッドがリクエストを処理している間、呼び出し側のスレッドがその実行をブロックすることを防ぎます。</description>
        /// </item>
        /// <item>
        /// <term>SWP_DEFERERASE 0x2000</term>
        /// <description>WM_SYNCPAINTメッセージの生成を防ぎます。</description>
        /// </item>
        /// <item>
        /// <term>SWP_DRAWFRAME 0x0020</term>
        /// <description>ウィンドウの周りにフレーム (ウィンドウのクラス説明で定義されている) を描画します。</description>
        /// </item>
        /// <item>
        /// <term>SWP_FRAMECHANGED 0x0020</term>
        /// <description>SetWindowLong関数を使用して設定した新しいフレーム・スタイルを適用します。ウィンドウのサイズが変更されていなくても、WM_NCCALCSIZEメッセージをウィンドウに送信します。
        /// このフラグが指定されていない場合、WM_NCCALCSIZEはウィンドウのサイズが変更されたときにのみ送信されます。</description>
        /// </item>
        /// <item>
        /// <term>SWP_HIDEWINDOW 0x0080</term>
        /// <description>Hides the window.</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOACTIVATE 0x0010</term>
        /// <description>ウィンドウをアクティブにしません。
        /// このフラグが設定されていない場合、ウィンドウは活性化され、最上段または非最上段のグループのいずれかの最上段に移動します（hWndInsertAfterパラメータの設定に依存します）。</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOCOPYBITS 0x0100</term>
        /// <description>クライアント領域のすべての内容を破棄します。
        /// このフラグが指定されていない場合、クライアント領域の有効な内容は保存され、ウィンドウのサイズ変更や再配置が行われた後にクライアント領域にコピーされます。</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOMOVE 0x0002</term>
        /// <description>現在の位置を保持します（X と Y パラメータは無視します）。</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOOWNERZORDER 0x0200</term>
        /// <description>オーナー ウィンドウの Z オーダー位置を変更しません。</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOREDRAW 0x0008</term>
        /// <description>変更を再描画しません。
        /// このフラグが設定されている場合、いかなる種類の再描画も行われません。
        /// これは、クライアント領域、非クライアント領域（タイトルバーやスクロールバーを含む）、およびウィンドウが移動された結果、親ウィンドウのすべての部分がカバーされていない場合に適用されます。
        /// このフラグが設定されている場合、アプリケーションはウィンドウと親ウィンドウの再描画が必要な部分を明示的に無効にするか、再描画しなければなりません。</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOREPOSITION 0x0200</term>
        /// <description>SWP_NOOWNERZORDERフラグと同じ。</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOSENDCHANGING 0x0400</term>
        /// <description>WM_WINDOWPOSCHANGINGメッセージをウィンドウが受信できないようにします。</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOSIZE 0x0001</term>
        /// <description>現在のサイズを保持します（cxとcyパラメータは無視されます）。</description>
        /// </item>
        /// <item>
        /// <term>SWP_NOZORDER 0x0004</term>
        /// <description>現在の Z オーダーを保持します（hWndInsertAfterパラメータを無視します）。</description>
        /// </item>
        /// <item>
        /// <term>SWP_SHOWWINDOW 0x0040</term>
        /// <description>ウィンドウを表示します。</description>
        /// </item>
        /// </list></param>
        /// <returns>関数が成功した場合、戻り値は0以外の値になります。
        /// 拡張エラー情報を取得するには、GetLastError を呼び出します。</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        /// <summary>
        /// 範囲内に含まれるイベントに対するイベント フック関数をセットします。
        /// https://docs.microsoft.com/en-us/windows/win32/winauto/event-constants
        /// </summary>
        /// <param name="eventMin">フック関数が処理するイベントの範囲内で最も低いイベント値のイベント定数を指定します。
        /// このパラメータを EVENT_MIN に設定することで、可能な限り低いイベント値を示すことができます。</param>
        /// <param name="eventMax">フック関数が処理するイベントの範囲内で最も高いイベント値のイベント定数を指定します。
        /// このパラメータをEVENT_MAXに設定することで、可能な限り最大のイベント値を示すことができます。</param>
        /// <param name="hmodWinEventProc">dwFlagsパラメータにWINEVENT_INCONTEXTフラグが指定されている場合、lpffnWinEventProcのフック関数を含むDLLへのハンドル。
        /// フック関数がDLLにない場合、またはWINEVENT_OUTOFCONTEXTフラグが指定されている場合、このパラメータはNULLです。</param>
        /// <param name="lpfnWinEventProc">イベント フック関数へのポインタ。この関数の詳細については、WinEventProc を参照してください。
        /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-wineventproc </param>
        /// <param name="idProcess">フック関数がイベントを受信するプロセスのIDを指定します。
        /// 現在のデスクトップ上のすべてのプロセスからイベントを受信するには、ゼロ (0) を指定します。</param>
        /// <param name="idThread">フック関数がイベントを受信するスレッドのIDを指定します。
        /// このパラメータがゼロの場合、フック関数は現在のデスクトップ上のすべての既存のスレッドに関連付けられます。</param>
        /// <param name="dwFlags">フック関数の位置とスキップするイベントの位置を指定するフラグの値。以下のフラグが有効です。:
        /// <list type="table">
        /// <item>
        /// <term>WINEVENT_INCONTEXT</term>
        /// <description>コールバック関数を含む DLL は、イベントを生成するプロセスのアドレス空間にマッピングされます。
        /// このフラグを設定すると、システムはイベント通知をコールバック関数に送信します。
        /// このフラグが指定された場合、フック関数は DLL 内になければなりません。
        /// このフラグは、呼び出しプロセスと生成プロセスの両方が32ビットまたは64ビットプロセスでない場合、または生成プロセスがコンソール・アプリケーションである場合には効果がありません。
        /// 詳細は、「In-Context Hook Functions」を参照してください。</description>
        /// </item>
        /// <item>
        /// <term>WINEVENT_OUTOFCONTEXT</term>
        /// <description>コールバック関数は、イベントを生成するプロセスのアドレス空間にマッピングされません。
        /// フック関数はプロセスの境界を越えて呼び出されるため、システムはイベントをキューに入れなければなりません。
        /// このメソッドは非同期ではありますが、イベントの順序はシーケンシャルであることが保証されています。
        /// 詳細は、「Out-of-Context Hook Functions」を参照してください。</description>
        /// </item>
        /// <item>
        /// <term>WINEVENT_SKIPOWNPROCESS</term>
        /// <description>このプロセスのスレッドによって生成されたイベントを、フックのこのインスタンスが受信することを防ぎます。
        /// このフラグは、スレッドがイベントを生成することを防ぎません。</description>
        /// </item>
        /// <item>
        /// <term>WINEVENT_SKIPOWNTHREAD</term>
        /// <description>このフックのインスタンスが、このフックを登録しているスレッドが生成したイベントを受信しないようにします。</description>
        /// </item>
        /// </list>
        /// 以下のフラグの組み合わせが有効です。:
        /// <list type="bullet">
        /// <item><description>WINEVENT_INCONTEXT | WINEVENT_SKIPOWNPROCESS</description></item>
        /// <item><description>WINEVENT_INCONTEXT | WINEVENT_SKIPOWNTHREAD</description></item>
        /// <item><description>WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS</description></item>
        /// <item><description>WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNTHREAD</description></item>
        /// </list>
        /// さらに、クライアント アプリケーションは、WINEVENT_INCONTEXT または WINEVENT_OUTOFCONTEXT を単独で指定することができます。
        /// Windows Store App 開発については、備考欄を参照してください。</param>
        /// <returns>成功した場合、このイベントフックのインスタンスを識別する HWINEVENTHOOK 値を返します。アプリケーションはこの戻り値を保存して、<see cref="UnhookWinEvent"/> 関数で使用します。
        /// 失敗した場合は、ゼロを返します。</returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        /// <summary>
        /// 以前の <see cref="SetWinEventHook"/> 呼び出しで作成されたイベントフック関数を削除します。
        /// </summary>
        /// <param name="hWinEventHook">以前の <see cref="SetWinEventHook"/> 呼び出しで返された、イベント フックへのハンドル。</param>
        /// <returns>成功した場合は TRUE を返し、そうでない場合は FALSE を返します。
        /// この関数が失敗する原因は、3 つの一般的なエラーです。:
        /// <list type="bullet">
        /// <item><description>hWinEventHook パラメータが NULL または有効でない。</description></item>
        /// <item><description>hWinEventHookで指定したイベントフックは既に削除されていた。</description></item>
        /// <item><description>UnhookWinEventが、<see cref="SetWinEventHook"/> への呼び出し元とは異なるスレッドから呼び出された。</description></item>
        /// </list></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        /// <summary>
        /// 指定したウィンドウが属するクラスの名前を取得します。
        /// </summary>
        /// <param name="hwnd">ウィンドウへのハンドルと、間接的にはウィンドウが属するクラス。</param>
        /// <param name="name">クラス名の文字列。</param>
        /// <param name="count">name 引数のバッファの長さを文字数で指定します。バッファは、終端のヌル文字を含むのに十分な大きさでなければなりません。そうでなければ、クラス名文字列は nMaxCount-1 文字に切り詰められます。</param>
        /// <returns>この関数が成功した場合、バッファにコピーされた文字数が戻り値となります。
        /// 関数が失敗した場合、戻り値はゼロになります。拡張エラー情報を取得するには、GetLastError関数を呼び出します。</returns>
        [DllImport("user32.dll")]
        internal static extern int GetClassName(IntPtr hwnd, StringBuilder name, int count);
    }

    /// <summary>
    /// アクセス可能なオブジェクトによって生成されたイベントに応答してシステムが呼び出すアプリケーション定義のコールバック (またはフック) 関数。
    /// フック機能は、必要に応じてイベント通知を処理します。
    /// クライアントはフック機能をインストールし、SetWinEventHookを呼び出すことで特定のタイプのイベント通知を要求します。
    ///
    /// WINEVENTPROC型は、このコールバック関数へのポインタを定義します。
    /// WinEventProc は、アプリケーション定義の関数名のプレースホルダです。
    /// </summary>
    /// <param name="hWinEventHook">イベントフック関数のハンドル。
    /// この値は、フック関数がインストールされたときにSetWinEventHookによって返され、フック関数の各インスタンスに固有の値です。</param>
    /// <param name="eventType">発生したイベントを指定します。この値はイベント定数の一つです。
    /// https://docs.microsoft.com/en-us/windows/win32/winauto/event-constants </param>
    /// <param name="hwnd">イベントを生成するウィンドウへのハンドル、またはイベントに関連するウィンドウがない場合はNULL。
    /// 例えば、マウスポインタはウィンドウに関連付けられていません。</param>
    /// <param name="idObject">イベントに関連付けられたオブジェクトを識別します。
    /// これは、オブジェクト識別子またはカスタムオブジェクトIDのいずれかです。</param>
    /// <param name="idChild">イベントがオブジェクトによってトリガされたのか、オブジェクトの子要素によってトリガされたのかを識別します。
    /// この値がCHILDID_SELFの場合、イベントはオブジェクトによってトリガされ、そうでない場合、この値はイベントをトリガした要素の子IDとなります。</param>
    /// <param name="dwEventThread"></param>
    /// <param name="dwmsEventTime">イベントが生成された時間をミリ秒単位で指定します。</param>
    internal delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
}
