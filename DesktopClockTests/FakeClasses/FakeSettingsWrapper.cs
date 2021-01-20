using System;
using System.ComponentModel;
using System.Windows;
using DesktopClock.Library;

namespace DesktopClockTests.FakeClasses
{
    public class FakeSettingsWrapper : ISettingsWrapper, INotifyFakeMethodCalled
    {
        private VerticalAlignment _VerticalAlignment;
        public VerticalAlignment VerticalAlignment
        {
            get { return _VerticalAlignment; }
            set
            {
                _VerticalAlignment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerticalAlignment)));
            }
        }

        private HorizontalAlignment _HorizontalAlignment;
        public HorizontalAlignment HorizontalAlignment
        {
            get { return _HorizontalAlignment; }
            set
            {
                _HorizontalAlignment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HorizontalAlignment)));
            }
        }


        private double _VerticalMargin;
        public double VerticalMargin
        {
            get { return _VerticalMargin; }
            set
            {
                _VerticalMargin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerticalMargin)));
            }
        }



        private double _HorizontalMargin;
        public double HorizontalMargin
        {
            get { return _HorizontalMargin; }
            set
            {
                _HorizontalMargin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HorizontalMargin)));
            }
        }


        private string _CustumHolidaysString;
        public string CustumHolidaysString
        {
            get { return _CustumHolidaysString; }
            set
            {
                _CustumHolidaysString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustumHolidaysString)));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public event FakeMethodCalledEventHandler FakeMethodCalled;

        public void Save()
        {
            FakeMethodCalled?.Invoke(this, new FakeMethodCalledEventArgs(nameof(Save), null));
        }
    }
}
