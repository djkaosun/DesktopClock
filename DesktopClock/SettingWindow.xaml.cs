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

        /*
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 既定のビューを取り出してセットする
            var view = CollectionViewSource.GetDefaultView(viewModel.CustomHolidaysDictionary);
            this.RootGrid.DataContext = view;

            // 既定のビューにソートを指定する
            view.SortDescriptions.Add(
              new System.ComponentModel.SortDescription(
                    "Key",
                    System.ComponentModel.ListSortDirection.Ascending)
                  );

            // DataGridコントロールのヘッダーにソートの印（三角のマーク）を表示する
            //this.CustomHolidaysDataGrid.Columns[1].SortDirection = System.ComponentModel.ListSortDirection.Ascending;
            // ここまでが、ベースとなるプログラムの記述

            // LiveShapingを有効にする
            // viewの実体が分からないときは、ICollectionViewLiveShapingインターフェースが実装されていることと、
            // CanChangeLiveSortingプロパティの値がtrueであるかをチェックしてから有効にすること
            var liveShaping = view as System.ComponentModel.ICollectionViewLiveShaping;
            if (liveShaping != null && liveShaping.CanChangeLiveSorting)
                liveShaping.IsLiveSorting = true;
            // IsLiveSortingプロパティをtrueに変更できることが確定しているなら、次の1行で済む
            //(view as System.ComponentModel.ICollectionViewLiveShaping).IsLiveSorting = true;
        }//*/
    }
}
