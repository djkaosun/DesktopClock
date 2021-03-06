﻿using System;
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
        private const string TOO_SMALL_MESSAGE = "{0} is too small. (< {1})";
        private const string ALREADY_STARTED_MESSAGE = "Already started.";
        private const string NOT_RUNNING_MESSAGE = "This is not running.";
        private const double INITIAL_HEIGHT = 0;
        private const double INITIAL_WIDTH = 0;

        /// <summary>
        /// スクリーン サイズを確認する間隔の最小値。
        /// </summary>
        public static readonly int MinimumInterval = 200;

        private bool _IsRunning;
        /// <summary>
        /// 実行中か否か。
        /// </summary>
        public bool IsRunning
        {
            get { return _IsRunning; }
            private set
            {
                if (value != _IsRunning)
                {
                    _IsRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }

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
                if (MillisecondsInterval < MinimumInterval) throw new ArgumentException(String.Format(TOO_SMALL_MESSAGE, nameof(MillisecondsInterval), MinimumInterval));
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
            _Height = INITIAL_HEIGHT;
            _Width = INITIAL_WIDTH;
        }

        /// <summary>
        /// スクリーン サイズの確認を開始します。時刻に変化があった場合、<see cref="PropertyChanged" /> イベントが発生します。
        /// </summary>
        public void Start()
        {
            if (IsRunning) throw new InvalidOperationException(ALREADY_STARTED_MESSAGE);
            tokenSource = new CancellationTokenSource();
            IsRunning = true;
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
            if (!IsRunning) throw new InvalidOperationException(NOT_RUNNING_MESSAGE);
            tokenSource.Cancel();
            tokenSource = null;
            IsRunning = false;
            InitializeScreenSize();
        }
    }
}
