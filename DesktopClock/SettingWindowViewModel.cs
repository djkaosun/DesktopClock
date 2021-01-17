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
    public class SettingWindowViewModel : INotifyPropertyChanged
    {

        #region Properties for Binding

        private ObservableCollection<KeyValuePair<DateTime, string>> _CustomHolidaysDictionary;
        public ObservableCollection<KeyValuePair<DateTime, string>> CustomHolidaysDictionary
        {
            get { return _CustomHolidaysDictionary; }
            set
            {
                _CustomHolidaysDictionary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomHolidaysDictionary)));
            }
        }

        private DateTime _CustomHolidayDate;
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
        public string VerticalMarginString
        {
            get { return _VerticalMarginString; }
            set
            {
                _VerticalMarginString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerticalMarginString)));
            }
        }

        private string _HorizontalMarginString;
        public string HorizontalMarginString
        {
            get { return _HorizontalMarginString; }
            set
            {
                _HorizontalMarginString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VerticalMarginString)));
            }
        }


        private bool _AlignmentLeftTop;
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

            // Properties.Settings からの読み出し
            SetAlignmentToRadioButton(Properties.Settings.Default.VerticalAlignment,
                    Properties.Settings.Default.HorizontalAlignment);
            VerticalMarginString = Properties.Settings.Default.VerticalMargin.ToString();
            HorizontalMarginString = Properties.Settings.Default.HorizontalMargin.ToString();
            CustomHolidaysDictionary = CustomHolidaysParser.Deserialize(Properties.Settings.Default.CustumHolidaysString);

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
            if (sender == CustomHolidaysDictionary)
            {

            }
        }

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

        private void ApplyAndSaveSettings()
        {
            SetAlignmentFromRadioButton(out VerticalAlignment verticalAlignment, out HorizontalAlignment horizontalAlignment);
            Properties.Settings.Default.VerticalAlignment = verticalAlignment;
            Properties.Settings.Default.HorizontalAlignment = horizontalAlignment;
            Properties.Settings.Default.VerticalMargin = Double.Parse(VerticalMarginString);
            Properties.Settings.Default.HorizontalMargin = Double.Parse(HorizontalMarginString);
            Properties.Settings.Default.CustumHolidaysString = CustomHolidaysParser.Serialize(CustomHolidaysDictionary);

            System.Diagnostics.Debug.WriteLine(AlignmentCenterBottom);
            System.Diagnostics.Debug.WriteLine(verticalAlignment);
            System.Diagnostics.Debug.WriteLine(horizontalAlignment);
            // 設定の保存
            Properties.Settings.Default.Save();
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

        /*
        private bool CheckAlignment(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(AlignmentLeftTop):
                    return VerticalAlignment == VerticalAlignment.Top
                        && HorizontalAlignment == HorizontalAlignment.Left;
                case nameof(AlignmentCenterTop):
                    return VerticalAlignment == VerticalAlignment.Top
                        && HorizontalAlignment == HorizontalAlignment.Center;
                case nameof(AlignmentLeftCenter):
                    return VerticalAlignment == VerticalAlignment.Center
                        && HorizontalAlignment == HorizontalAlignment.Left;
                case nameof(AlignmentCenterCenter):
                    return VerticalAlignment == VerticalAlignment.Center
                        && HorizontalAlignment == HorizontalAlignment.Center;
                case nameof(AlignmentRightCenter):
                    return VerticalAlignment == VerticalAlignment.Center
                        && HorizontalAlignment == HorizontalAlignment.Right;
                case nameof(AlignmentLeftBottom):
                    return VerticalAlignment == VerticalAlignment.Bottom
                        && HorizontalAlignment == HorizontalAlignment.Left;
                case nameof(AlignmentCenterBottom):
                    return VerticalAlignment == VerticalAlignment.Bottom
                        && HorizontalAlignment == HorizontalAlignment.Center;
                case nameof(AlignmentRightBottom):
                    return VerticalAlignment == VerticalAlignment.Bottom
                        && HorizontalAlignment == HorizontalAlignment.Right;
                default:
                    // 右上
                    return VerticalAlignment == VerticalAlignment.Top
                        && HorizontalAlignment == HorizontalAlignment.Right;
            }
        }//*/

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

        /*
        private void SetRadioButtonValue(string propertyName)
        {
            //if (AlignmentLeftTop) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentLeftTop)));
            //if (AlignmentCenterTop) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentCenterTop)));
            //if (AlignmentRightTop) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentRightTop)));
            //if (AlignmentLeftCenter) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentLeftCenter)));
            //if (AlignmentCenterCenter) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentCenterCenter)));
            //if (AlignmentRightCenter) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentRightCenter)));
            //if (AlignmentLeftBottom) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentLeftBottom)));
            //if (AlignmentCenterBottom) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentCenterBottom)));
            //if (AlignmentRightBottom) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentRightBottom)));


            if (String.IsNullOrEmpty(propertyName))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
            }


            if (VerticalAlignment == VerticalAlignment.Top
                        && HorizontalAlignment == HorizontalAlignment.Left)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentLeftTop)));

            }
            else if (VerticalAlignment == VerticalAlignment.Top
                 && HorizontalAlignment == HorizontalAlignment.Center)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentCenterTop)));
            }
            else if (VerticalAlignment == VerticalAlignment.Center
                 && HorizontalAlignment == HorizontalAlignment.Left)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentLeftCenter)));
            }
            else if (VerticalAlignment == VerticalAlignment.Center
                 && HorizontalAlignment == HorizontalAlignment.Center)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentCenterCenter)));
            }
            else if (VerticalAlignment == VerticalAlignment.Center
                 && HorizontalAlignment == HorizontalAlignment.Right)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentRightCenter)));
            }
            else if (VerticalAlignment == VerticalAlignment.Bottom
                 && HorizontalAlignment == HorizontalAlignment.Left)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentLeftBottom)));
            }
            else if (VerticalAlignment == VerticalAlignment.Bottom
                 && HorizontalAlignment == HorizontalAlignment.Center)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentCenterBottom)));
            }
            else if (VerticalAlignment == VerticalAlignment.Bottom
                && HorizontalAlignment == HorizontalAlignment.Right)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentRightBottom)));
            }
            else
            {
                // 右上
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlignmentRightTop)));
            }

        }//*/

        #endregion

        #endregion
    }
}
