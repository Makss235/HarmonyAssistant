using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Icons
{
    public class HomeIcon : ContentControl
    {
        public HomeIcon() 
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Polygon homeIcon = new Polygon()
            {
                StrokeThickness = 3,
                Stroke = Brushes.AliceBlue,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Points =
                {

                    new Point(26, 30),
                    new Point(18, 30),
                    new Point(18, 18),
                    new Point(8, 18),
                    new Point(8, 30),
                    new Point(0, 30),
                    new Point(0, 12),
                    new Point(13, 2),
                    new Point(26, 12),
                }
            };

            Grid mainGrid = new Grid()
            {
                Width = 35,
                Height = 35,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Children = { homeIcon }
            };

            Content = mainGrid;
        }
    }
}
