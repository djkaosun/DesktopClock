using System;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DesktopClock.Library
{
    /// <summary>
    /// <see cref="IPrimaryScreenSizeEventSource" />の実装です。
    /// </summary>
    public class PrimaryScreenSizeEventSource : IPrimaryScreenSizeEventSource
    {
        /// <summary>
        /// スクリーン サイズを確認する間隔の最小値。
        /// </summary>
        public static readonly int MinimumInterval = 200;

        private double _Height;
        /// <summary>
        /// スクリーンの高さ。
        /// </summary>
        public double Height
        {
            get
            {
                return _Height;
            }
            private set
            {
                if (_Height != value)
                {
                    _Height = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Height)));
                }
            }
        }

        private double _Width;
        /// <summary>
        /// スクリーンの幅。
        /// </summary>
        public double Width
        {
            get
            {
                return _Width;
            }
            private set
            {
                if (_Width != value)
                {
                    _Width = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Width)));
                }
            }
        }

        private int _MillisecondsInterval;
        /// <summary>
        /// スクリーン サイズを確認する間隔。最少は <see cref="MinimumInterval" />。
        /// </summary>
        public int MillisecondsInterval
        {
            get { return _MillisecondsInterval; }
            set
            {
                if (MillisecondsInterval < MinimumInterval) throw new ArgumentException("MillisecondsInterval is too small. (< " + MinimumInterval + ")");
                _MillisecondsInterval = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MillisecondsInterval)));
            }
        }

        /// <summary>
        /// プロパティが変更されたときに発生するイベント。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private CancellationTokenSource tokenSource;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public PrimaryScreenSizeEventSource()
        {
            _MillisecondsInterval = DateTimeEventSource.MinimumInterval;
            InitializeScreenSize();
        }

        /// <summary>
        /// Start 実行直後に PropertyChanged イベントが起きるよう、各値を初期化する。
        /// </summary>
        private void InitializeScreenSize()
        {
            _Height = 0;
            _Width = 0;
        }

        /// <summary>
        /// スクリーン サイズの確認を開始します。時刻に変化があった場合、<see cref="PropertyChanged" /> イベントが発生します。
        /// </summary>
        public void Start()
        {
            if (tokenSource != null) throw new InvalidOperationException("Already started.");
            tokenSource = new CancellationTokenSource();
            CheckUpdate(tokenSource.Token);
        }

        private async void CheckUpdate(CancellationToken token)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    UpdateScreenSize();
                    Thread.Sleep(MillisecondsInterval);

                    if (token.IsCancellationRequested) break;
                }
            });
        }

        private void UpdateScreenSize()
        {
            Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            Width = System.Windows.SystemParameters.PrimaryScreenWidth;
        }

        /// <summary>
        /// スクリーン サイズの確認を停止します。各値は初期値に戻ります。
        /// </summary>
        public void Stop()
        {
            if (tokenSource == null) throw new InvalidOperationException("This is not running.");
            tokenSource.Cancel();
            tokenSource = null;
            InitializeScreenSize();
        }
    }
}
