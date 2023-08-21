using HarmonyAssistant.UI.Windows.MainWindow.Widgets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            LeftPanelMenu leftPanelMenu = new LeftPanelMenu();
            Grid.SetColumn(leftPanelMenu, 0);
            Grid.SetRowSpan(leftPanelMenu, 2);

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };

            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            RowDefinition rowDefinition = new RowDefinition()
            { Height = new GridLength(40, GridUnitType.Pixel) };
            
            RowDefinition rowDefinition1 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(columnDefinition);
            grid.ColumnDefinitions.Add(columnDefinition1);
            grid.RowDefinitions.Add(rowDefinition);
            grid.RowDefinitions.Add(rowDefinition1);
            grid.Children.Add(leftPanelMenu);

            Content = grid;
        }
    }
}
