using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.ChatTab
{
    public class Message : ContentControl
    {
        public Message(object messageObject, SendMessageBy sendMessageBy)
        {
            ContentPresenter content = new ContentPresenter
            {
                Content = messageObject,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(5),
            };
            InitializeComponent(content, sendMessageBy);
        }
        public Message(string messageString, SendMessageBy sendMessageBy)
        {
            TextBlock content = new TextBlock
            {
                Text = messageString,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = Brushes.Transparent,
                Margin = new Thickness(5),
                Foreground = Brushes.AliceBlue,
            };
            InitializeComponent(content, sendMessageBy);
        }
        private void InitializeComponent(UIElement childControl, SendMessageBy sendMessageBy)
        {


            Border b = new Border()
            {
                Background = new SolidColorBrush(new Color()
                { R = 30, G = 30, B = 50, A = 255 }),
                CornerRadius = new CornerRadius(5),
                Child = childControl,
                MaxWidth = 500,
                MaxHeight = 1000,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 3, 0, 3)
            };



            if (sendMessageBy == SendMessageBy.ByMe)
            {
                HorizontalAlignment = HorizontalAlignment.Right;
            }
            else if (sendMessageBy == SendMessageBy.ByBot)
            {
                HorizontalAlignment = HorizontalAlignment.Left;
            }

            Margin = new Thickness(0, 3, 0, 3);
            FontSize = 17;

            Content = b;
        }
    }
}
