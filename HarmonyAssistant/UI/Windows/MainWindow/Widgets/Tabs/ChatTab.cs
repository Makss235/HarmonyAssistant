using HarmonyAssistant.UI.Windows.MainWindow.Styles;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs
{
    public class ChatTab : Tab
    {
        public ChatTab()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Border border = new Border()
            {
                Background = Brushes.Transparent,
                BorderBrush = Brushes.AliceBlue,
                BorderThickness = new Thickness(0, 0, 0, 1)
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
            { Height = new GridLength (1, GridUnitType.Star) };
            
            RowDefinition rowDefinition1 = new RowDefinition()
            { Height = new GridLength (50, GridUnitType.Pixel) };

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
