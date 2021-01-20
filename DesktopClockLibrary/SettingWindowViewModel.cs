using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DesktopClock.Library;
using System.Collections.Specialized;
using System.Windows;

namespace DesktopClock
{
    /// <summary>
    /// 設定ウィンドウ (SettingWindow) 用の ViewModel クラスです。
    /// </summary>
    public class SettingWindowViewModel : INotifyPropertyChanged
    {

        #region Properties for Binding

        private ObservableCollection<KeyValuePair<DateTime, string>> _CustomHolidays;
        /// <summary>
        /// カスタム休日を格納するコレクション。
        /// </summary>
        public ObservableCollection<KeyValuePair<DateTime, string>> CustomHolidaysDictionary
        {
            get { return _CustomHolidays; }
            set
            {
                _CustomHolidays = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomHolidaysDictionary)));
            }
        }

        private DateTime _CustomHolidayDate;
        /// <summary>
        /// 追加、もしくは、削除するカスタム休日の日付。
        /// </summary>
        public DateTime CustomHolidayDate
        {
            get { return _CustomHolidayDate; }
            set
            {
                _CustomHolidayDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomHolidayDate)));
            }
        }

        private string _CustomHolidayName;
        /// <summary>
        /// 追加、もしくは、削除するカスタム休日の名前。
        /// </summary>
        public string CustomHolidayName
        {
            get { return _CustomHolidayName; }
            set
            {
                _CustomHolidayName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomHolidayName)));
            }
        }

        private string _VerticalMarginString;
        /// <summary>
        /// 垂直方向のマージンを示す文字列。(double にパースできる文字列)
        /// </summary>
        public string VerticalMarginString
        {
            get { return _VerticalMarginString; }
            set
            {
                _VerticalMarginString = value;
                Double.Parse(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerticalMarginString)));
            }
        }

        private string _HorizontalMarginString;
        /// <summary>
        /// 水平方向のマージンを示す文字列。(double にパースできる文字列)
        /// </summary>
        public string HorizontalMarginString
        {
            get { return _HorizontalMarginString; }
            set
            {
                _HorizontalMarginString = value;
                Double.Parse(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerticalMarginString)));
            }
        }

        private bool _AlignmentLeftTop;
        /// <summary>
        /// ウィンドウが左上配置か。
        /// </summary>
        public bool AlignmentLeftTop
        {
            get { return _AlignmentLeftTop; }
            set
            {
                _AlignmentLeftTop = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentLeftTop)));
            }
        }

        private bool _AlignmentCenterTop;
        /// <summary>
        /// ウィンドウが上配置か。
        /// </summary>
        public bool AlignmentCenterTop
        {
            get { return _AlignmentCenterTop; }
            set
            {
                _AlignmentCenterTop = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentCenterTop)));
            }
        }

        private bool _AlignmentRightTop;
        /// <summary>
        /// ウィンドウが右上配置か。
        /// </summary>
        public bool AlignmentRightTop
        {
            get { return _AlignmentRightTop; }
            set
            {
                _AlignmentRightTop = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentRightTop)));
            }
        }

        private bool _AlignmentLeftCenter;
        /// <summary>
        /// ウィンドウが左配置か。
        /// </summary>
        public bool AlignmentLeftCenter
        {
            get { return _AlignmentLeftCenter; }
            set
            {
                _AlignmentLeftCenter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentLeftCenter)));
            }
        }

        private bool _AlignmentCenterCenter;
        /// <summary>
        /// ウィンドウが中央配置か。
        /// </summary>
        public bool AlignmentCenterCenter
        {
            get { return _AlignmentCenterCenter; }
            set
            {
                _AlignmentCenterCenter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentCenterCenter)));
            }
        }

        private bool _AlignmentRightCenter;
        /// <summary>
        /// ウィンドウが右配置か。
        /// </summary>
        public bool AlignmentRightCenter
        {
            get { return _AlignmentRightCenter; }
            set
            {
                _AlignmentRightCenter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentRightCenter)));
            }
        }

        private bool _AlignmentLeftBottom;
        /// <summary>
        /// ウィンドウが左下配置か。
        /// </summary>
        public bool AlignmentLeftBottom
        {
            get { return _AlignmentLeftBottom; }
            set
            {
                _AlignmentLeftBottom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentLeftBottom)));
            }
        }

        private bool _AlignmentCenterBottom;
        /// <summary>
        /// ウィンドウが下配置か。
        /// </summary>
        public bool AlignmentCenterBottom
        {
            get { return _AlignmentCenterBottom; }
            set
            {
                _AlignmentCenterBottom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentCenterBottom)));
            }
        }

        private bool _AlignmentRightBottom;
        /// <summary>
        /// ウィンドウが右下配置か。
        /// </summary>
        public bool AlignmentRightBottom
        {
            get { return _AlignmentRightBottom; }
            set
            {
                _AlignmentRightBottom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentRightBottom)));
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// 設定を適用するコマンド
        /// </summary>
        public ICommand ApplySettingsCommand { get; private set; }
        private class ApplySettingsCommandImpl : ICommand
        {
            private SettingWindowViewModel viewModel;
            public ApplySettingsCommandImpl(SettingWindowViewModel viewModel)
            {
                this.viewModel = viewModel;
                viewModel.PropertyChanged += OnViewModelPropertyChangedEventHandler;
            }

            private void OnViewModelPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case nameof(viewModel.SettingIsChanged):
                        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                        break;
                }
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return viewModel.SettingIsChanged;
            }

            public void Execute(object parameter)
            {
                viewModel.ApplyAndSaveSettings();
                viewModel.SettingIsChanged = false;
            }
        }

        /// <summary>
        /// ウィンドウを閉じるコマンド (キャンセル)
        /// </summary>
        public ICommand CloseWindowCommand { get; private set; }
        private class CloseWindowCommandImpl : ICommand
        {
            private SettingWindowViewModel viewModel;
            public CloseWindowCommandImpl(SettingWindowViewModel viewModel)
            {
                this.viewModel = viewModel;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                if (parameter is System.Windows.Window window)
                {
                    window.Close();
                }
            }
        }

        /// <summary>
        /// 設定を保存してウィンドウを閉じるコマンド (OK)
        /// </summary>
        public ICommand ApplyAndCloseCommand { get; private set; }
        private class ApplyAndCloseCommandImpl : ICommand
        {
            private SettingWindowViewModel viewModel;
            public ApplyAndCloseCommandImpl(SettingWindowViewModel viewModel)
            {
                this.viewModel = viewModel;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                if (viewModel.SettingIsChanged)
                {
                    viewModel.ApplyAndSaveSettings();
                }
                if (parameter is System.Windows.Window window)
                {
                    window.Close();
                }
            }
        }

        /// <summary>
        /// カスタム休日を追加するコマンド
        /// </summary>
        public ICommand AddHolidayCommand { get; private set; }
        private class AddHolidayCommandImpl : ICommand
        {
            private SettingWindowViewModel viewModel;
            public AddHolidayCommandImpl(SettingWindowViewModel viewModel)
            {
                this.viewModel = viewModel;
                viewModel.PropertyChanged += OnViewModelPropertyChangedEventHandler;
                viewModel.CustomHolidaysDictionary.CollectionChanged += OnCustomHolidaysDictionaryChangedEventHandler;
            }

            private void OnCustomHolidaysDictionaryChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }

            private void OnViewModelPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case nameof(viewModel.CustomHolidayDate):
                    case nameof(viewModel.CustomHolidayName):
                        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                        break;
                }
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return viewModel.CustomHolidayDate != default
                        && !String.IsNullOrEmpty(viewModel.CustomHolidayName)
                        && !viewModel.CustomHolidaysDictionary.ContainsKey(viewModel.CustomHolidayDate);
            }

            public void Execute(object parameter)
            {
                viewModel.CustomHolidaysDictionary.Add(
                        viewModel.CustomHolidayDate,
                        viewModel.CustomHolidayName);
                viewModel.CustomHolidayDate = DateTime.Today;
                viewModel.CustomHolidayName = String.Empty;
                viewModel.SettingIsChanged = true;
            }
        }

        /// <summary>
        /// カスタム休日を削除するコマンド
        /// </summary>
        public ICommand RemoveHolidayCommand { get; private set; }
        private class RemoveHolidayCommandImpl : ICommand
        {
            private SettingWindowViewModel viewModel;
            public RemoveHolidayCommandImpl(SettingWindowViewModel viewModel)
            {
                this.viewModel = viewModel;
                viewModel.PropertyChanged += OnViewModelPropertyChangedEventHandler;
                viewModel.CustomHolidaysDictionary.CollectionChanged += OnCustomHolidaysDictionaryChangedEventHandler;
            }

            private void OnCustomHolidaysDictionaryChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }

            private void OnViewModelPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case nameof(viewModel.CustomHolidayDate):
                    case nameof(viewModel.CustomHolidayName):
                        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                        break;
                }
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return viewModel.CustomHolidaysDictionary.ContainsKey(viewModel.CustomHolidayDate)
                        && viewModel.CustomHolidaysDictionary.ContainsValue(viewModel.CustomHolidayName);
            }

            public void Execute(object parameter)
            {
                viewModel.CustomHolidaysDictionary.Remove(viewModel.CustomHolidayDate);
                viewModel.CustomHolidayDate = DateTime.Today;
                viewModel.CustomHolidayName = String.Empty;
                viewModel.SettingIsChanged = true;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// プロパティが変更された際に発生するイベント。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Dependency Injection

        private ISettingsWrapper _SettingsWrapper;
        /// <summary>
        /// Properties.Settings.Default をラップしたラッパー。
        /// </summary>
        public ISettingsWrapper SettingsWrapper
        {
            get { return _SettingsWrapper; }
            set
            {
                if (_SettingsWrapper != null) throw new InvalidOperationException("already setted");
                if (value == null) return;
                _SettingsWrapper = value;
                LoadSettings();
                _SettingsWrapper.PropertyChanged += PropertiesSettingsChangedEventHandler;
            }
        }


        #endregion

        private bool _SettingIsChanged;
        private bool SettingIsChanged
        {
            get { return _SettingIsChanged; }
            set
            {
                _SettingIsChanged = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SettingIsChanged)));
            }
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public SettingWindowViewModel()
        {
            CustomHolidayDate = DateTime.Today;
            CustomHolidayName = String.Empty;
            CustomHolidaysDictionary = new ObservableCollection<KeyValuePair<DateTime, string>>();

            // コマンドの初期化
            ApplySettingsCommand = new ApplySettingsCommandImpl(this);
            CloseWindowCommand = new CloseWindowCommandImpl(this);
            ApplyAndCloseCommand = new ApplyAndCloseCommandImpl(this);
            AddHolidayCommand = new AddHolidayCommandImpl(this);
            RemoveHolidayCommand = new RemoveHolidayCommandImpl(this);

            // イベントハンドラーの登録
            CustomHolidaysDictionary.CollectionChanged += CustomHolidaysChangedEventHandler;
            PropertyChanged += SettingsChangedEventHandler;
        }

        #region Event Handlers

        private void SettingsChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            if (sender == this)
            {
                switch (e.PropertyName)
                {
                    case nameof(VerticalMarginString):
                    case nameof(HorizontalMarginString):
                    case nameof(VerticalAlignment):
                    case nameof(HorizontalAlignment):
                    case nameof(AlignmentLeftTop):
                    case nameof(AlignmentCenterTop):
                    case nameof(AlignmentRightTop):
                    case nameof(AlignmentLeftCenter):
                    case nameof(AlignmentCenterCenter):
                    case nameof(AlignmentRightCenter):
                    case nameof(AlignmentLeftBottom):
                    case nameof(AlignmentCenterBottom):
                    case nameof(AlignmentRightBottom):
                        SettingIsChanged = true;
                        break;
                }
            }
        }

        private void CustomHolidaysChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
        {

        }

        private void PropertiesSettingsChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// DataGrid の CurrentCellChanged イベントに応じて、
        /// コードビハインドから呼び出される。
        /// </summary>
        /// <param name="currentItem">現在選択中の列のアイテム</param>
        public void CustomHolidaysSelectionChangedEventHandler(object currentItem)
        {
            if (currentItem is KeyValuePair<DateTime, string> item)
            {
                CustomHolidayDate = item.Key;
                CustomHolidayName = item.Value;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 設定をロードします。
        /// </summary>
        private void LoadSettings()
        {
            if (SettingsWrapper == null) throw new InvalidOperationException("SettingWrapper is null.");

            // Properties.Settings からの読み出し
            SetAlignmentToRadioButton(SettingsWrapper.VerticalAlignment,
                    SettingsWrapper.HorizontalAlignment);
            VerticalMarginString = SettingsWrapper.VerticalMargin.ToString();
            HorizontalMarginString = SettingsWrapper.HorizontalMargin.ToString();
            CustomHolidaysDictionary = CustomHolidaysParser.Deserialize(SettingsWrapper.CustumHolidaysString);
        }

        /// <summary>
        /// 設定を動作に反映し、保存します。
        /// </summary>
        private void ApplyAndSaveSettings()
        {
            if (SettingsWrapper == null) throw new InvalidOperationException("SettingWrapper is null.");

            SetAlignmentFromRadioButton(out VerticalAlignment verticalAlignment, out HorizontalAlignment horizontalAlignment);
            SettingsWrapper.VerticalAlignment = verticalAlignment;
            SettingsWrapper.HorizontalAlignment = horizontalAlignment;
            SettingsWrapper.VerticalMargin = Double.Parse(VerticalMarginString);
            SettingsWrapper.HorizontalMargin = Double.Parse(HorizontalMarginString);
            SettingsWrapper.CustumHolidaysString = CustomHolidaysParser.Serialize(CustomHolidaysDictionary);
            // 設定の保存
            SettingsWrapper.Save();
        }

        #region Alignment
        private void SetAlignmentFromRadioButton(out VerticalAlignment verticalAlignment, out HorizontalAlignment horizontalAlignment)
        {
            if (AlignmentLeftTop)
            {
                verticalAlignment = VerticalAlignment.Top;
                horizontalAlignment = HorizontalAlignment.Left;
            }
            else if (AlignmentCenterTop)
            {
                verticalAlignment = VerticalAlignment.Top;
                horizontalAlignment = HorizontalAlignment.Center;
            }
            else if (AlignmentLeftCenter)
            {
                verticalAlignment = VerticalAlignment.Center;
                horizontalAlignment = HorizontalAlignment.Left;
            }
            else if (AlignmentCenterCenter)
            {
                verticalAlignment = VerticalAlignment.Center;
                horizontalAlignment = HorizontalAlignment.Center;
            }
            else if (AlignmentRightCenter)
            {
                verticalAlignment = VerticalAlignment.Center;
                horizontalAlignment = HorizontalAlignment.Right;
            }
            else if (AlignmentLeftBottom)
            {
                verticalAlignment = VerticalAlignment.Bottom;
                horizontalAlignment = HorizontalAlignment.Left;
            }
            else if (AlignmentCenterBottom)
            {
                verticalAlignment = VerticalAlignment.Bottom;
                horizontalAlignment = HorizontalAlignment.Center;
            }
            else if (AlignmentRightBottom)
            {
                verticalAlignment = VerticalAlignment.Bottom;
                horizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                // 右上
                verticalAlignment = VerticalAlignment.Top;
                horizontalAlignment = HorizontalAlignment.Right;
            }
        }

        private void SetAlignmentToRadioButton(VerticalAlignment verticalAlignment, HorizontalAlignment horizontalAlignment)
        {
            _AlignmentLeftTop = false;
            _AlignmentCenterTop = false;
            _AlignmentRightTop = false;
            _AlignmentLeftCenter = false;
            _AlignmentCenterCenter = false;
            _AlignmentRightCenter = false;
            _AlignmentLeftBottom = false;
            _AlignmentCenterBottom = false;
            _AlignmentRightBottom = false;

            if (verticalAlignment == VerticalAlignment.Top
                    && horizontalAlignment == HorizontalAlignment.Left)
            {
                _AlignmentLeftTop = true;

            }
            else if (verticalAlignment == VerticalAlignment.Top
                 && horizontalAlignment == HorizontalAlignment.Center)
            {
                _AlignmentCenterTop = true;
            }
            else if (verticalAlignment == VerticalAlignment.Center
                 && horizontalAlignment == HorizontalAlignment.Left)
            {
                _AlignmentLeftCenter = true;
            }
            else if (verticalAlignment == VerticalAlignment.Center
                 && horizontalAlignment == HorizontalAlignment.Center)
            {
                _AlignmentCenterCenter = true;
            }
            else if (verticalAlignment == VerticalAlignment.Center
                 && horizontalAlignment == HorizontalAlignment.Right)
            {
                _AlignmentRightCenter = true;
            }
            else if (verticalAlignment == VerticalAlignment.Bottom
                 && horizontalAlignment == HorizontalAlignment.Left)
            {
                _AlignmentLeftBottom = true;
            }
            else if (verticalAlignment == VerticalAlignment.Bottom
                 && horizontalAlignment == HorizontalAlignment.Center)
            {
                _AlignmentCenterBottom = true;
            }
            else if (verticalAlignment == VerticalAlignment.Bottom
                && horizontalAlignment == HorizontalAlignment.Right)
            {
                _AlignmentRightBottom = true;
            }
            else
            {
                _AlignmentRightTop = true;
            }
        }

        #endregion

        #endregion
    }
}
