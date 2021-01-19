using System;
using System.Windows;

namespace DesktopClock.Library
{
    class BottomMostDependencyProperty : DependencyObject
    {
        public bool BottomMost
        {
            get { return (bool)GetValue(BottomMostProperty); }
            set { SetValue(BottomMostProperty, value); }
        }

        public static readonly DependencyProperty BottomMostProperty =
                DependencyProperty.Register("BottomMost", typeof(bool), typeof(BottomMostDependencyProperty), new UIPropertyMetadata(false));
    }
}
