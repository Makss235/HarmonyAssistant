using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using HarmonyAssistant.UI.Icons;
using System.Windows.Resources;
using System;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Themes;
using System.Windows.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tools
{
    public enum SendButtonForm
    {
        microphone,
        plane,
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

        #region SendButtonForm

        private SendButtonForm sendButtonForm;
        public SendButtonForm _SendButtonForm
        {
            get => sendButtonForm;
            set => SetProperty(ref sendButtonForm, value);
        }

        #endregion
        public SendButton(double size)
        {
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(
                new Uri("/Data/Resources/Images/send.svg", UriKind.Relative));

            IconFromSVG iconFromSVG = new IconFromSVG(streamResourceInfo.Stream);
            iconFromSVG.Width = size;
            iconFromSVG.Height = size;
            iconFromSVG.Background = Brushes.Black;
            //ThemeManager.AddResourceReference(iconFromSVG);
            //iconFromSVG.SetResourceReference(Border.BackgroundProperty,
            //    nameof(IAppBrushes.CommonForegroundBrush));

            StreamResourceInfo streamResourceInfo2 = Application.GetResourceStream(
                new Uri("/Data/Resources/Images/send.svg", UriKind.Relative));

            IconFromSVG iconFromSVG2 = new IconFromSVG(streamResourceInfo2.Stream);
            iconFromSVG2.Width = size;
            iconFromSVG2.Height = size;
            iconFromSVG2.Background = Brushes.Yellow;
            //ThemeManager.AddResourceReference(iconFromSVG2);
            //iconFromSVG2.SetResourceReference(Border.BackgroundProperty,
            //    nameof(IAppBrushes.CommonForegroundBrush));

            Label l = new Label
            {
                Content = "plane"
            };
            Label l2 = new Label
            {
                Content = "micro"
            };

            Canvas canvas = new Canvas();
            canvas.Width = size;
            canvas.Height = size;
            //canvas.Children.Add(iconFromSVG);
            switch(sendButtonForm)
            {
                case SendButtonForm.plane:
                    canvas.Children.Clear();
                    canvas.Children.Add(l);
                    break;

                case SendButtonForm.microphone:
                    canvas.Children.Clear();
                    canvas.Children.Add(l2);
                    break;
            }
                

            Grid mainGrid = new Grid
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Children = { canvas }
            };

            Content = mainGrid;
        }

    }
}
