using System;
using System.Windows;
using System.Windows.Data;
using DesktopClock.Library;

namespace DesktopClock
{
    /// <summary>
    /// SettingWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingWindow : Window
    {
        private readonly SettingWindowViewModel viewModel;
        public SettingWindow()
        {
            InitializeComponent();
            viewModel = new SettingWindowViewModel()
            {
                SettingsWrapper = new SettingsWrapper() { Settings = Properties.Settings.Default }
            };
            this.DataContext = viewModel;
        }

        private void DataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            viewModel.CustomHolidaysSelectionChangedEventHandler(this.CustomHolidaysDataGrid.CurrentItem);
        }
    }
}
