using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            // 最終的には設定ファイルから読み取り
            //Properties.Settings.Default.VerticalMargin = 90;
            //Properties.Settings.Default.HorizontalMargin = 115;

            customHoliday.Holidays = CustomHolidaysParser.Deserialize(Properties.Settings.Default.CustumHolidaysString);

            var dtEvtSrc = new DateTimeEventSource()
            {
                HolidayChecker = new HolidayChecker()
                {
                    IsAddHolidayNameToObservedHolidayName = true,
                    CustomHoliday = customHoliday
                }
            };

            /*
            // 最終的には設定ファイルから読み取り
            customHoliday.Holidays.Add(new DateTime(2021, 4, 30), "休日");
            customHoliday.Holidays.Add(new DateTime(2021, 12, 29), "休日");
            customHoliday.Holidays.Add(new DateTime(2021, 12, 30), "休日");
            customHoliday.Holidays.Add(new DateTime(2021, 12, 31), "休日");
            customHoliday.Holidays.Add(new DateTime(2022, 1, 3), "休日");
            //*/

            // ここマジアブナイ。
            viewModel = new MainWindowViewModel
            {
                DateTimeEventSource = dtEvtSrc,
                PrimaryScreenSizeEventSource = new PrimaryScreenSizeEventSource()
            };

            viewModel.VerticalAlignment = Properties.Settings.Default.VerticalAlignment;
            viewModel.HorizontalAlignment = Properties.Settings.Default.HorizontalAlignment;
            viewModel.MarginPadding = Properties.Settings.Default.VerticalMargin;
            viewModel.HorizontalMargin = Properties.Settings.Default.HorizontalMargin;

            this.DataContext = viewModel;
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
