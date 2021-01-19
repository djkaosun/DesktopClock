using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace DesktopClock.Library
{
    /// <summary>
    /// 「デスクトップを表示」ボタンを押したとき、ウィンドウを最小化するかどうかを制御するためのビヘイビアを表します。
    /// </summary>
    public class ShowDesktopBehavior
    {

        #region IsEnabled 添付プロパティ
        /// <summary>
        /// IsEnabled 添付プロパティの定義
        /// </summary>
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(ShowDesktopBehavior), new PropertyMetadata(true, OnIsEnabledPropertyChanged));

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
        /// IsEnabled 添付プロパティ変更イベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行元</param>
        /// <param name="e">イベント引数</param>
        private static void OnIsEnabledPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var w = sender as Window;
            if (w == null)
                return;

            var isEnabled = (bool)e.NewValue;
            if (isEnabled)
            {
                nativeMethods.RemoveHook();
                nativeMethods.WinuserEventOccured -= WinuserEventOccuredEventHandler;
                w.SourceInitialized -= OnSourceInitialized;
            }
            else
            {
                w.SourceInitialized += OnSourceInitialized;
            }
        }
        #endregion IsEnabled 添付プロパティ

        private static readonly NativeMethodsWrapper nativeMethods = new NativeMethodsWrapper();


        /// <summary>
        /// Window クラスのウィンドウハンドルが決定する最速のイベントハンドラ
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


        /// <summary>
        /// WinuserEvent が発生した際に処理するイベント ハンドラー。
        /// </summary>
        /// <param name="winuserEvent">発生したイベントの種類</param>
        /// <param name="windowClassName">ウィンドウのクラス ネーム</param>
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