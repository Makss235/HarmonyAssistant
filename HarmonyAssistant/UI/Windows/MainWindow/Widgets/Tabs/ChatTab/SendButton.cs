using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.Core.TTC.States;
using HarmonyAssistant.UI.Animations;
using HarmonyAssistant.UI.Icons;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Resources;
using System.Windows.Shapes;

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

        private Label planeLabel;
        private Label microphoneLabel;

        private SendButtonChangeAnim toPlaneAnim;
        private SendButtonChangeAnim toMicroAnim;
        private SendBtnEllipseAnim ellipseAnim;

        public SendButton()
        {
            PropertyChanged += SendButton_PropertyChanged;

            var sm = StateManager.GetInstance();
            sm.GetState<SayButtonPressedState>().StateEnter += SendButton_StateEnter;
            sm.GetState<SayButtonPressedState>().StateExit += SendButton_StateExit;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Ellipse el = new Ellipse
            {
                Fill = Brushes.Blue,
                Width = 45,
                Height = 45,
                //Margin = new Thickness(0, 8, 15, 8)
            };
            ThemeManager.AddResourceReference(el);
            el.SetResourceReference(Ellipse.FillProperty,
                nameof(IAppBrushes.EllipseInSendButtonBrush));

            StreamResourceInfo streamPlaneResInfo = Application.GetResourceStream(
                new Uri("/Data/Resources/Images/Send.svg", UriKind.Relative));

            IconFromSVG planeIcon = new IconFromSVG(streamPlaneResInfo.Stream)
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(5, 8, 0, 8)
            };
            ThemeManager.AddResourceReference(planeIcon);
            planeIcon.SetResourceReference(Border.BackgroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            StreamResourceInfo streamMicroResInfo = Application.GetResourceStream(
                new Uri("/Data/Resources/Images/Microphone.svg", UriKind.Relative));

            IconFromSVG microIcon = new IconFromSVG(streamMicroResInfo.Stream)
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(10.2, 8, 0, 8)
            };
            ThemeManager.AddResourceReference(microIcon);
            microIcon.SetResourceReference(Border.BackgroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            planeLabel = new Label
            {
                Content = planeIcon,
            };
            planeLabel.MouseEnter += (s, e) => planeLabel.Opacity = 0.7;
            planeLabel.MouseLeave += (s, e) => planeLabel.Opacity = 1;

            microphoneLabel = new Label
            {
                Content = microIcon,
            };
            microphoneLabel.MouseEnter += (s, e) => microphoneLabel.Opacity = 0.7;
            microphoneLabel.MouseLeave += (s, e) => microphoneLabel.Opacity = 1;

            toMicroAnim = new SendButtonChangeAnim(planeLabel, microphoneLabel);
            toPlaneAnim = new SendButtonChangeAnim(microphoneLabel, planeLabel);
            ellipseAnim = new SendBtnEllipseAnim(el);

            Grid mainGrid = new Grid
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Children = { el, planeLabel, microphoneLabel },
            };

            Content = mainGrid;
        }

        private void SendButton_StateExit()
        {
            ellipseAnim.StopAnim();
        }

        private void SendButton_StateEnter()
        {
            ellipseAnim.StartAnim();
        }

        private void SendButton_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SendButtonIcon):
                    if (SendButtonIcon == SendButtonIcon.MicrophoneIcon)
                    {
                        toMicroAnim.StartAnim(true);
                        toPlaneAnim.StartAnim(false);
                    }
                    else
                    {
                        toPlaneAnim.StartAnim(true);
                        toMicroAnim.StartAnim(false);
                    }
                    break;
            }
        }
    }
}
