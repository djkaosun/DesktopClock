﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DesktopClock.Library;

namespace DesktopClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;
        /// <summary>
        /// MainWindow のコンストラクター。
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();


            var customHoliday = new CustomHoliday();
            customHoliday.Holidays = CustomHolidaysParser.Deserialize(Properties.Settings.Default.CustumHolidaysString);

            var dtEvtSrc = new DateTimeEventSource()
            {
                HolidayChecker = HolidayChecker.GetHolidayChecker()
            };
            dtEvtSrc.HolidayChecker.CustomHoliday = customHoliday;
            if (dtEvtSrc.HolidayChecker is HolidayChecker_ja_JP hc_ja_JP)
            {
                hc_ja_JP.IsAddHolidayNameToObservedHolidayName = true;
            }

            // カレンダー ウィンドウの生成
            var calendarWindow = new CalendarWindow();

            viewModel = new MainWindowViewModel(this.Dispatcher, calendarWindow.Dispatcher)
            {
                DateTimeEventSource = dtEvtSrc,
                PrimaryScreenSizeEventSource = new PrimaryScreenSizeEventSource(),
                SettingsWrapper = new SettingsWrapper() { Settings = Properties.Settings.Default }
            };

            viewModel.VerticalAlignment = (VerticalAlignment)Properties.Settings.Default.VerticalAlignment;
            viewModel.HorizontalAlignment = (HorizontalAlignment)Properties.Settings.Default.HorizontalAlignment;
            viewModel.VerticalMarginNumber = Properties.Settings.Default.VerticalMarginNumber;
            viewModel.IsPercentVertical = Properties.Settings.Default.IsPercentVertical;
            viewModel.HorizontalMarginNumber = Properties.Settings.Default.HorizontalMarginNumber;
            viewModel.IsPercentHorizontal = Properties.Settings.Default.IsPercentHorizontal;
            viewModel.ConsecutiveHolidaysMessageFormat = (string)Application.Current.FindResource("CONSECTIVE_HOLIDAYS_MESSAGE_TOMMOROW");
            viewModel.ConsecutiveHolidaysMessageDATFormat = (string)Application.Current.FindResource("CONSECTIVE_HOLIDAYS_MESSAGE_DAT");

            this.DataContext = viewModel;

            // カレンダー ウィンドウの表示
            calendarWindow.DataContext = viewModel;
            calendarWindow.Show();
        }

        /// <summary>
        /// MainWindows で MouseEnter イベントが発生した際のイベント ハンドラー
        /// マウス ホバー時にウィンドウを消す。
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">マウス イベント引数</param>
        private async void MainWindow_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var winPosSize = new WindowPosAndSize()
            {
                Left = this.Left,
                Top = this.Top,
                Width = this.Width,
                Height = this.Height
            };

            var task = new Task<Visibility>((x) => {
                WaitMouseLeave(x);
                return Visibility.Visible;
            }, winPosSize);
            task.Start();


            this.Visibility = await task;
            
            return;
        }

        /// <summary>
        /// MainWindows で MouseEnter イベントが発生した際のイベント ハンドラー
        /// MouseEnter と同じ処理をする。
        /// </summary>
        /// <param name="sender">イベントの発生元</param>
        /// <param name="e">ドラッグ イベント引数</param>
        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            MainWindow_MouseEnter(sender, null);
        }

        /// <summary>
        /// ウィンドウ上からマウスが出るのを待機する。
        /// </summary>
        /// <param name="winPosSizeObject">ウィンドウ位置およびサイズ</param>
        private static void WaitMouseLeave(object winPosSizeObject)
        {
            if (winPosSizeObject is WindowPosAndSize winPosSize)
            {
                System.Drawing.Point cursorPos;
                do
                {
                    cursorPos = System.Windows.Forms.Cursor.Position;
                    System.Threading.Thread.Sleep(500);
                } while (OnWindow(cursorPos, winPosSize));
            }
        }

        /// <summary>
        /// マウス カーソルの位置とウィンドウ位置およびサイズとを比較し、マウス カーソルがウィンドウ上にあるかを判断する。
        /// </summary>
        /// <param name="cursorPos">マウス カーソル位置</param>
        /// <param name="winPosSize">ウィンドウ位置およびサイズ</param>
        /// <returns>ウィンドウ上なら true。それ以外の場合は false。</returns>
        private static bool OnWindow(System.Drawing.Point cursorPos, WindowPosAndSize winPosSize)
        {
            return !(
                cursorPos.X < winPosSize.Left
                || cursorPos.Y < winPosSize.Top
                || cursorPos.X > winPosSize.Left + winPosSize.Width
                || cursorPos.Y > winPosSize.Top + winPosSize.Height);
        }

        /// <summary>
        /// ウィンドウの位置およびサイズを格納する構造体。
        /// </summary>
        private struct WindowPosAndSize
        {
            internal double Left;
            internal double Top;
            internal double Width;
            internal double Height;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            viewModel.DateTimeEventSource.Start();
            viewModel.PrimaryScreenSizeEventSource.Start();

            // for test
            //this.Indicator.Visibility = Visibility.Visible;
        }
    }
}
