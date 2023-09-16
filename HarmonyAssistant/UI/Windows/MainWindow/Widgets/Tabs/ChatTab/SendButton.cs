using HarmonyAssistant.UI.Icons;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Resources;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tools
{
    public enum SendButtonIcon
    {
        MicrophoneIcon,
        SendIcon
    }

    public class SendButton : ButtonBase, INotifyPropertyChanged
    {
        #region NPC

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        #endregion

        #region SendButtonIcon

        private SendButtonIcon _SendButtonIcon;
        public SendButtonIcon SendButtonIcon
        {
            get => _SendButtonIcon;
            set => SetProperty(ref _SendButtonIcon, value);
        }

        #endregion

        private Label l;
        private Label l2;

        public SendButton()
        {
            PropertyChanged += SendButton_PropertyChanged;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(
                new Uri("/Data/Resources/Images/Send.svg", UriKind.Relative));

            IconFromSVG iconFromSVG = new IconFromSVG(streamResourceInfo.Stream)
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(0, 8, 15, 8)
            };
            ThemeManager.AddResourceReference(iconFromSVG);
            iconFromSVG.SetResourceReference(Border.BackgroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            StreamResourceInfo streamResourceInfo2 = Application.GetResourceStream(
                new Uri("/Data/Resources/Images/Microphone.svg", UriKind.Relative));

            IconFromSVG iconFromSVG2 = new IconFromSVG(streamResourceInfo2.Stream)
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(0, 8, 15, 8)
            };
            ThemeManager.AddResourceReference(iconFromSVG2);
            iconFromSVG2.SetResourceReference(Border.BackgroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            l = new Label
            {
                Content = iconFromSVG,
                Visibility = Visibility.Collapsed
            };
            l2 = new Label
            {
                Content = iconFromSVG2
            };


            Grid mainGrid = new Grid
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Children = { l, l2 }
            };

            Content = mainGrid;
        }

        private void SendButton_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SendButtonIcon):
                    if (SendButtonIcon == SendButtonIcon.MicrophoneIcon)
                    {
                        l2.Visibility = Visibility.Visible;
                        l.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        l2.Visibility = Visibility.Collapsed;
                        l.Visibility = Visibility.Visible;
                    }
                    break;
            }
        }
    }
}
