﻿using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Windows.Input;
using XSharpPowerTools.Helpers;

namespace XSharpPowerTools.View.Windows
{
    public abstract class BaseWindow : DialogWindow
    {
        public XSModel XSModel { get; set; }
        public abstract string SearchTerm { set; }
        protected bool AllowReturn;

        public BaseWindow() 
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            PreviewKeyDown += BaseWindow_PreviewKeyDown;
            Loaded += BaseWindow_Loaded;
        }

        private void BaseWindow_Loaded(object sender, System.Windows.RoutedEventArgs e) 
        {
            var wpfScreen = WpfScreen.GetScreenFrom(this);
            Left = wpfScreen.DeviceBounds.Left + (wpfScreen.DeviceBounds.Width - ActualWidth) / 2;
            Top = wpfScreen.DeviceBounds.Top + (wpfScreen.DeviceBounds.Height - ActualHeight) / 3;
        }

        private void BaseWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            try
            {
                //Close();
            }
            catch (InvalidOperationException)
            { }
        }

        protected abstract void OnTextChanged();
    }
}
