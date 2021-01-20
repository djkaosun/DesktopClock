using System;
using System.ComponentModel;
using System.Windows;

namespace DesktopClock.Library
{
    public interface ISettingsWrapper : INotifyPropertyChanged
    {
        public VerticalAlignment VerticalAlignment {  get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
        public double VerticalMargin { get; set; }
        public double HorizontalMargin { get; set; }
        public string CustumHolidaysString { get; set; }

        public void Save();
    }
}
