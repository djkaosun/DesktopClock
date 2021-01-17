using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            viewModel = new SettingWindowViewModel();
            this.DataContext = viewModel;
        }

        private void DataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            viewModel.CustomHolidaysSelectionChangedEventHandler(this.CustomHolidaysDataGrid.CurrentItem);

        }
    }
}
