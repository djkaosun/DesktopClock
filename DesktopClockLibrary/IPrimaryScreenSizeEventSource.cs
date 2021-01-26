using System;
using System.ComponentModel;

namespace DesktopClock.Library
{
    /// <summary>
    /// プライマリ スクリーンのサイズが変わった際に各プロパティに対応した <see cref="INotifyPropertyChanged.PropertyChanged" /> イベントを発生させます。
    /// </summary>
    public interface IPrimaryScreenSizeEventSource : INotifyPropertyChanged
    {
        /// <summary>
        /// 実行中か否か。
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// スクリーンの高さ。
        /// </summary>
        double Height { get; }

        /// <summary>
        /// スクリーンの幅。
        /// </summary>
        double Width { get; }

        /// <summary>
        /// スクリーン サイズの確認を開始します。時刻に変化があった場合、<see cref="INotifyPropertyChanged.PropertyChanged" /> イベントが発生します。
        /// </summary>
        public void Start();

        /// <summary>
        /// スクリーン サイズの確認を停止します。
        /// </summary>
        public void Stop();
    }
}
