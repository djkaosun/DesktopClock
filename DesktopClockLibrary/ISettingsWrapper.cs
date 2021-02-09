using System;
using System.ComponentModel;
using System.Windows;

namespace DesktopClock.Library
{
    /// <summary>
    /// Properties.Settings.Default をラップするラッパー。
    /// </summary>
    public interface ISettingsWrapper : INotifyPropertyChanged
    {
        /// <summary>
        /// 垂直方向の位置設定を取得、適用します。
        /// </summary>
        public int VerticalAlignment {  get; set; }

        /// <summary>
        /// 水平方向の位置設定を取得、適用します。
        /// </summary>
        public int HorizontalAlignment { get; set; }

        /// <summary>
        /// 垂直方向のマージン設定を取得、適用します。
        /// </summary>
        public double VerticalMargin { get; set; }

        /// <summary>
        /// 垂直方向のマージンの単位がパーセントであるかどうかを取得、適用します。
        /// </summary>
        public bool IsPercentVertical { get; set; }

        /// <summary>
        /// 水平方向のマージン設定を取得、適用します。
        /// </summary>
        public double HorizontalMargin { get; set; }

        /// <summary>
        /// 水平方向のマージンの単位がパーセントであるかどうかを取得、適用します。
        /// </summary>
        public bool IsPercentHorizontal { get; set; }

        /// <summary>
        /// カスタム休日設定を取得、適用します。<see cref="CustomHolidaysParser" /> で変換する必要があります。
        /// </summary>
        public string CustumHolidaysString { get; set; }

        /// <summary>
        /// 設定を保存します。
        /// </summary>
        public void Save();
    }
}
