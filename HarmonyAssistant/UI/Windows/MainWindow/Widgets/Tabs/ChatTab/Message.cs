using HarmonyAssistant.UI.Animations;
using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Widgets;
using System.Reflection;
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
                MaxWidth = 500,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            ThemeManager.AddResourceReference(b);
            b.SetResourceReference(Border.BackgroundProperty,
                nameof(IAppBrushes.ChatMessageBrush));

            if (contentObject.GetType() == typeof(string))
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = contentObject.ToString(),
                    Style = new CommonTextBlockStyle(),
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
                VerticalAlignment = VerticalAlignment.Bottom
            };

            ThemeManager.AddResourceReference(designForMessageBubble);
            designForMessageBubble.SetResourceReference(BackgroundProperty,
                nameof(IAppBrushes.ChatMessageBrush));

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

            ChatBubbleAppearAnim appearAnim = new ChatBubbleAppearAnim(this);
            this.Loaded += (s, e) => appearAnim.StartAnim(sendMessageBy);

            Margin = new Thickness(0, 5, 0, 5);
            Content = g;

        }
    }
}
