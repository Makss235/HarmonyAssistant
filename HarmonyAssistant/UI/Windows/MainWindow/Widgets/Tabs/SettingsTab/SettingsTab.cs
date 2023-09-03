using HarmonyAssistant.UI.Windows.MainWindow.Styles;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class SettingsTab : Tab
    {
        public SettingsTab()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            //MaterialSlider slider = new MaterialSlider();

            TextBlock tb = new TextBlock()
            {
                Text = "Звук",
                Style = TextBlocksStyles.textBlockStyle,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 10, 7, 10)
            };
            Grid.SetColumn(tb, 0);
            Grid.SetRow(tb, 0);


            Slider s = new Slider()
            {
                Background = Brushes.Transparent,
                Orientation = Orientation.Horizontal,
                Width = 150,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(7, 0, 10, 0),
            };
            Grid.SetColumn(s, 1);
            Grid.SetRow(s, 0);

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };
            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            RowDefinition rowDefinition = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };
            

            Grid mainGrid = new Grid() { HorizontalAlignment = HorizontalAlignment.Stretch };
            mainGrid.ColumnDefinitions.Add(columnDefinition);
            mainGrid.ColumnDefinitions.Add(columnDefinition1);
            mainGrid.RowDefinitions.Add(rowDefinition);
            mainGrid.Children.Add(tb);
            mainGrid.Children.Add(s);

            ScrollViewer mainScrollViewer = new ScrollViewer();
            mainScrollViewer.Content = mainGrid;

            Content = mainScrollViewer;
        }
    }
}
