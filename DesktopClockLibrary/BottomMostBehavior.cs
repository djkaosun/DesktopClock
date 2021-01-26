using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace DesktopClock.Library
{
    /// <summary>
    /// BottomMost を実現するビヘイビア。IsEnabled を true にすると、以下の挙動を行います。
    /// <list>
    /// <item><description>あらゆるウィンドウの下に表示されます。</description></item>
    /// <item><description>Win+D などでデスクトップを表示したとき、ウィンドウを隠しません。</description></item>
    /// </list>
    /// </summary>
    public class BottomMostBehavior
    {

        #region IsEnabled 添付プロパティ
        /// <summary>
        /// IsEnabled 添付プロパティの定義。
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(BottomMostBehavior), new PropertyMetadata(false, OnIsEnabledPropertyChanged));

        /// <summary>
        /// IsEnabled 添付プロパティを取得します。
        /// </summary>
        /// <param name="target">対象とする DependencyObject を指定します。</param>
        /// <returns>取得した値を返します。</returns>
        public static bool GetIsEnabled(DependencyObject target)
        {
            return (bool)target.GetValue(IsEnabledProperty);
        }

        /// <summary>
        /// IsEnabled 添付プロパティを設定します。
        /// </summary>
        /// <param name="target">対象とする DependencyObject を指定します。</param>
        /// <param name="value">設定する値を指定します。</param>
        public static void SetIsEnabled(DependencyObject target, bool value)
        {
            target.SetValue(IsEnabledProperty, value);
        }

        /// <summary>
        /// IsEnabled 添付プロパティ変更イベント ハンドラー。
        /// </summary>
        /// <param name="sender">イベント発行元。</param>
        /// <param name="e">イベント引数。</param>
        private static void OnIsEnabledPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var w = sender as Window;
            if (w == null) return;

            var isEnabled = (bool)e.NewValue;
            if (isEnabled)
            {
                w.Activated += SetWindowToBottom;
                w.ContentRendered += SetWindowToBottom;
                w.SourceInitialized += OnSourceInitialized;
            }
            else
            {
                nativeMethods.RemoveHook();
                nativeMethods.WinuserEventOccured -= WinuserEventOccuredEventHandler;
                w.SourceInitialized -= OnSourceInitialized;
                w.Activated -= SetWindowToBottom;
                w.ContentRendered -= SetWindowToBottom;
            }
        }
        #endregion IsEnabled 添付プロパティ

        private static readonly NativeMethodsWrapper nativeMethods = new NativeMethodsWrapper();

        /// <summary>
        /// Window クラスのウィンドウ ハンドルが決定する最速のイベント ハンドラー。
        /// </summary>
        /// <param name="sender">イベント発行元</param>
        /// <param name="e">イベント引数</param>
        private static void OnSourceInitialized(object sender, EventArgs e)
        {
            var w = sender as Window;
            nativeMethods.Window = w;
            nativeMethods.WinuserEventOccured += WinuserEventOccuredEventHandler;
            nativeMethods.AddHook(WinuserEvent.SystemForeground);
        }

        private static void SetWindowToBottom(object sender, EventArgs e)
        {
            var w = sender as Window;
            NativeMethodsWrapper.SetAsBottomMost(w);
        }


        /// <summary>
        /// WinuserEvent が発生した際に処理するイベント ハンドラー。
        /// </summary>
        /// <param name="winuserEvent">発生したイベントの種類。</param>
        /// <param name="windowClassName">クラス名。</param>
        private static void WinuserEventOccuredEventHandler(WinuserEvent winuserEvent, string windowClassName)
        {
            if (winuserEvent == WinuserEvent.SystemForeground)
            {
                // WorkerW はデスクトップ
                if (string.Equals(windowClassName, "WorkerW", StringComparison.Ordinal) /*|| string.Equals(windowClassName, "Progman", StringComparison.Ordinal)*/ )
                {
                    nativeMethods.Window.Topmost = true;
                }
                else
                {
                    nativeMethods.Window.Topmost = false;
                }
            }
        }
    }
}