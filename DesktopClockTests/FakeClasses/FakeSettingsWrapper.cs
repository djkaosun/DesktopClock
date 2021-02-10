using System;
using System.ComponentModel;
using DesktopClock.Library;

namespace DesktopClockTests.FakeClasses
{
    public class FakeSettingsWrapper : ISettingsWrapper, INotifyFakeMethodCalled
    {
        private int _VerticalAlignment;
        public int VerticalAlignment
        {
            get { return _VerticalAlignment; }
            set
            {
                _VerticalAlignment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerticalAlignment)));
            }
        }

        private int _HorizontalAlignment;
        public int HorizontalAlignment
        {
            get { return _HorizontalAlignment; }
            set
            {
                _HorizontalAlignment = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HorizontalAlignment)));
            }
        }


        private double _VerticalMarginNumber;
        public double VerticalMarginNumber
        {
            get { return _VerticalMarginNumber; }
            set
            {
                _VerticalMarginNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerticalMarginNumber)));
            }
        }

        private bool _IsPercentVertical;
        public bool IsPercentVertical
        {
            get { return _IsPercentVertical; }
            set
            {
                _IsPercentVertical = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPercentVertical)));
            }
        }


        private double _HorizontalMarginNumber;
        public double HorizontalMarginNumber
        {
            get { return _HorizontalMarginNumber; }
            set
            {
                _HorizontalMarginNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HorizontalMarginNumber)));
            }
        }

        private bool _IsPercentHorizontal;
        public bool IsPercentHorizontal
        {
            get { return _IsPercentHorizontal; }
            set
            {
                _IsPercentHorizontal = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPercentHorizontal)));
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
