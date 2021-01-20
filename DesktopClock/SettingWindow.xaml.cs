using System;
using System.Windows;
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
            viewModel.LoadSettings();
            this.DataContext = viewModel;
        }

        private void DataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            viewModel.CustomHolidaysSelectionChangedEventHandler(this.CustomHolidaysDataGrid.CurrentItem);

        }
    }
}
