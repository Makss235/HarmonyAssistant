using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets
{
    public class LeftPanelMenu : ContentControl
    {
        private Border border;

        private ColumnDefinition leftColumn;
        private ColumnDefinition mainColumn;
        private Grid mainGrid;

        public LeftPanelMenu() 
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Button button = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 20,
            };
            button.Click += (s, e) => border.Visibility = Visibility.Visible;

            Border leftBrder = new Border()
            {
                Background = Brushes.Black,
            };
            leftBrder.Child = button;
            Grid.SetColumn(leftBrder, 0);

            Button button1 = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Height = 20,
                Margin = new Thickness(-30, 10, 10, 10)
            };
            button1.Click += (s, e) => border.Visibility = Visibility.Collapsed;

            border = new Border()
            {
                Background = Brushes.Blue,
                Width = 200
            };
            border.Child = button1;
            Grid.SetColumn(border, 1);

            leftColumn = new ColumnDefinition()
            { Width = new GridLength(50, GridUnitType.Pixel) };

            mainColumn = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };

            mainGrid = new Grid();

            mainGrid.ColumnDefinitions.Add(leftColumn);
            mainGrid.ColumnDefinitions.Add(mainColumn);
            mainGrid.Children.Add(leftBrder);
            mainGrid.Children.Add(border);

            Content = mainGrid;
        }
    }
}
