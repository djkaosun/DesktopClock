using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopClock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static System.Threading.Semaphore semaphore;
        private static string SemaphoreName = "TkmrAkhs.DesktopClock";

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
            bool createdNew;
            
            // Semaphoreクラスのインスタンスを生成し、アプリケーション終了まで保持する
            App.semaphore = new System.Threading.Semaphore(1, 1, App.SemaphoreName, out createdNew);
            {
                if (!createdNew)
                {
                    // 他のプロセスが先にセマフォを作っていた
                    MessageBox.Show("すでに起動しています", "TkmrAkhs.DesktopClock",
                                    MessageBoxButton.OK, MessageBoxImage.Hand);
                    System.Windows.Application.Current.Shutdown(); // プログラム終了
                }

                // アプリケーション起動
                base.OnStartup(e);
                this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
                this.notifyIcon = new NotifyIconWrapper();
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
            this.notifyIcon.Dispose();
        }
    }
}
