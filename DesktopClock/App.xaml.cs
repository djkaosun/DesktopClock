using System;
using System.Windows;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace DesktopClock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Semaphore semaphore;
        private static readonly string SemaphoreName = "TkmrAkhs.DesktopClock";

        /// <summary>
        /// タスクトレイに表示するアイコン
        /// </summary>
        private NotifyIconWrapper notifyIcon;

        /// <summary>
        /// System.Windows.Application.Startup イベント を発生させます。
        /// </summary>
        /// <param name="e">イベントデータ を格納している StartupEventArgs</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Semaphoreクラスのインスタンスを生成し、アプリケーション終了まで保持する
            App.semaphore = new System.Threading.Semaphore(1, 1, App.SemaphoreName, out bool createdNew);
            {
                if (!createdNew)
                {
                    // 他のプロセスが先にセマフォを作っていた
                    MessageBox.Show("すでに起動しています", SemaphoreName,
                                    MessageBoxButton.OK, MessageBoxImage.Hand);
                    System.Windows.Application.Current.Shutdown(); // プログラム終了
                }
                else
                {
                    var dictionary = new ResourceDictionary()
                    {
                        Source = StringResourceResolver.Resolve(CultureInfo.CurrentUICulture)
                    };
                    // リソースの再設定
                    this.Resources.MergedDictionaries.Clear();
                    this.Resources.MergedDictionaries.Add(dictionary);

                    // アプリケーション起動
                    base.OnStartup(e);
                    this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                    this.notifyIcon = new NotifyIconWrapper();
                }
            }
        }

        /// <summary>
        /// System.Windows.Application.Exit イベント を発生させます。
        /// </summary>
        /// <param name="e">イベントデータ を格納している ExitEventArgs</param>
        protected override void OnExit(ExitEventArgs e)
        {
            App.semaphore.Dispose(); // Semaphoreクラスのインスタンスを破棄
            App.semaphore = null;
            base.OnExit(e);
            this.notifyIcon?.Dispose();
        }
    }
}
