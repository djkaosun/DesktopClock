using System;
using System.ComponentModel;
using System.Windows;
using DesktopClock.Library;

namespace DesktopClock
{
    public class SettingsWrapper : ISettingsWrapper
    {
        private const string ALREADY_SET_MESSAGE = "{0} is already set.";

        private Properties.Settings _Settings;

        public int VerticalAlignment { get => _Settings.VerticalAlignment; set => _Settings.VerticalAlignment = value; }
        public int HorizontalAlignment { get => _Settings.HorizontalAlignment; set => _Settings.HorizontalAlignment = value; }
        public double VerticalMarginNumber { get => _Settings.VerticalMarginNumber; set => _Settings.VerticalMarginNumber = value; }
        public bool IsPercentVertical { get => _Settings.IsPercentVertical; set => _Settings.IsPercentVertical = value; }
        public double HorizontalMarginNumber { get => _Settings.HorizontalMarginNumber; set => _Settings.HorizontalMarginNumber = value; }
        public bool IsPercentHorizontal { get => _Settings.IsPercentHorizontal; set => _Settings.IsPercentHorizontal = value; }
        public string CustumHolidaysString { get => _Settings.CustumHolidaysString; set => _Settings.CustumHolidaysString = value; }

        internal Properties.Settings Settings
        {
            get { return _Settings; }
            set
            {
                if (_Settings != null) throw new InvalidOperationException(String.Format(ALREADY_SET_MESSAGE, nameof(Settings)));
                if (value == null) return;
                _Settings = value;
                _Settings.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
                {
                    PropertyChanged?.Invoke(sender, e);
                };
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Save()
        {
            _Settings.Save();
        }
    }
}
