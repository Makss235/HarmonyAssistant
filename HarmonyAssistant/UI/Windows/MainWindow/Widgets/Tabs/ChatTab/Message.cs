using HarmonyAssistant.UI.Windows.MainWindow.Styles;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.ChatTab
{
    public class Message : ContentControl
    {
        private object contentObject;
        private SendMessageBy sendMessageBy;

        public Message(object contentObject, SendMessageBy sendMessageBy)
        {
            this.contentObject = contentObject;
            this.sendMessageBy = sendMessageBy;

            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            Border b = new Border()
            {
                Background = ProgramBrushes.MediumGray,
                MaxWidth = 500,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            if (contentObject.GetType() == typeof(string))
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = contentObject.ToString(),
                    Style = TextBlocksStyles.textBlockStyle,
                    Margin = new Thickness(12, 7, 12, 7)
                };
                b.Child = textBlock;
            }
            else
            {
                ContentPresenter contentPresenter = new ContentPresenter()
                {
                    Content = contentObject,
                    Margin = new Thickness(12, 7, 12, 7)
                };
                b.Child = contentPresenter;
            }

            DesignForMessageBubble designForMessageBubble = new DesignForMessageBubble(10)
            {
                Background = b.Background,
                VerticalAlignment = VerticalAlignment.Bottom
            };

            if (sendMessageBy == SendMessageBy.ByMe)
            {
                HorizontalAlignment = HorizontalAlignment.Right;
                b.CornerRadius = new CornerRadius(7, 7, 0, 7);
                designForMessageBubble.HorizontalAlignment = HorizontalAlignment.Right;
                designForMessageBubble.Margin = new Thickness(0, 0, -9, 0);
            }
            else if (sendMessageBy == SendMessageBy.ByBot)
            {
                HorizontalAlignment = HorizontalAlignment.Left;
                b.CornerRadius = new CornerRadius(7, 7, 7, 0);
                designForMessageBubble.HorizontalAlignment = HorizontalAlignment.Left;
                designForMessageBubble.RenderTransform = new ScaleTransform(-1, 1);
            }

            Grid g = new Grid() 
            {
                Margin = new Thickness(9, 0, 11, 0)
            };
            g.Children.Add(b);
            g.Children.Add(designForMessageBubble);

            Margin = new Thickness(0, 5, 0, 5);
            Content = g;
        }
    }
}
