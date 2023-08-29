using HarmonyAssistant.UI.Windows.MainWindow.Styles;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.ChatTab
{
    public class ChatTab : Tab
    {
        public enum SendMessageBy
        {
            ByMe,
            ByBot
        }
        public ChatTab()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ObservableCollection<Message> messageChat = new ObservableCollection<Message>();

            Message m = new Message("DADADADADAD", SendMessageBy.ByMe);
            messageChat.Add(m);

            ItemsControl ic = new ItemsControl()
            {
                VerticalContentAlignment = VerticalAlignment.Bottom,
                ItemsSource = messageChat,
                Style = new ItemsControlStyle()
            };

            Image ass = new Image()
            {
                Source = new BitmapImage(
                    new Uri("pack://application:,,,/Resources/QRDownload.png",
                    UriKind.RelativeOrAbsolute))
            };

            Border border = new Border()
            {
                Background = Brushes.Transparent,
                BorderBrush = Brushes.AliceBlue,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Child = ass,
            };
            Grid.SetColumn(border, 0);
            Grid.SetColumnSpan(border, 2);
            Grid.SetRow(border, 0);

            TextBox textBox = new TextBox()
            {
                Style = TextBlocksStyles.textBlockStyle,
                BorderThickness = new Thickness(0),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = Brushes.Transparent,
                Margin = new Thickness(20, 0, 20, 0),

            };
            Grid.SetColumn(textBox, 0);
            Grid.SetRow(textBox, 1);

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(50, GridUnitType.Pixel) };

            RowDefinition rowDefinition = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            RowDefinition rowDefinition1 = new RowDefinition()
            { Height = new GridLength(50, GridUnitType.Pixel) };

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(columnDefinition);
            grid.ColumnDefinitions.Add(columnDefinition1);
            grid.RowDefinitions.Add(rowDefinition);
            grid.RowDefinitions.Add(rowDefinition1);
            grid.Children.Add(border);
            grid.Children.Add(textBox);

            Content = grid;
        }
    }
}
