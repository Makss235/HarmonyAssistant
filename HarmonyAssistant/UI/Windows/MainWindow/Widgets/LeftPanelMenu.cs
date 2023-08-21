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

        private ColumnDefinition leftColumn;
        private ColumnDefinition mainColumn;
        private Grid mainGrid;
        public LeftPanelMenu() 
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Border leftBrder = new Border()
            {
                Background = Brushes.Black,
            };
            Grid.SetColumn(leftBrder, 2);

            leftColumn = new ColumnDefinition()
            { Width = new GridLength(40, GridUnitType.Pixel) };
            mainColumn = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            mainGrid = new Grid()
            {
                
            };

            mainGrid.ColumnDefinitions.Add(leftColumn);
            mainGrid.ColumnDefinitions.Add(mainColumn);
            mainGrid.Children.Add(leftBrder);

            Content = mainGrid;
        }
    }
}
