using HarmonyAssistant.UI.Animations;
using HarmonyAssistant.UI.Icons;
using HarmonyAssistant.UI.Windows.MainWindow.Styles;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Resources;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.ChatTab
{
    public enum SendMessageBy
    {
        ByMe,
        ByBot
    }

    public class ChatTab : Tab
    {
        private TabAppearAnim tabAppearAnim;
        public ChatTab()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            tabAppearAnim = new TabAppearAnim(this);
            IsVisibleChanged += ChatTab_IsVisibleChanged;

            ObservableCollection<Message> messageChat = new ObservableCollection<Message>
            {
                new Message("DADADADADAD", SendMessageBy.ByMe),
                new Message("111", SendMessageBy.ByBot)
            };

            ItemsControl ic = new ItemsControl()
            {
                ItemsSource = messageChat,
                Style = new ItemsControlStyle(),
                Margin = new Thickness(12)
            };

            //StreamResourceInfo streamResourceInfo = Application.GetResourceStream(
            //    new Uri("/Data/Resources/Images/pi.svg", UriKind.Relative));

            //IconFromSVG iconFromSVG = new IconFromSVG(streamResourceInfo.Stream);
            //iconFromSVG.Width = 500;

            //Canvas canvas = new Canvas();
            ////canvas.Children.Add(iconFromSVG);

            Border border = new Border()
            {
                Background = Brushes.Transparent,
                BorderBrush = ProgramBrushes.DarkerBlue,
                BorderThickness = new Thickness(0, 0, 0, 3),
                Child = ic,
            };
            Grid.SetColumn(border, 0);
            Grid.SetColumnSpan(border, 2);
            Grid.SetRow(border, 0);

            TextBox textBox = new TextBox()
            {
                Style = TextBlocksStyles.textBlockStyle,
                BorderThickness = new Thickness(0),
                CaretBrush = Brushes.AliceBlue,
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

        private void ChatTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                tabAppearAnim.StartAnim();
            }
        }
    }
}
