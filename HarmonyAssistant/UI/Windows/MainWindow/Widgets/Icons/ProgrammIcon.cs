using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Icons
{
    public class ProgrammIcon : ContentControl
    {
        public ProgrammIcon()
        {
            Path programmIcon = new Path
            {
                Stroke = Brushes.Green,
                StrokeThickness = 1,
                Fill = Brushes.Green,
                VerticalAlignment = VerticalAlignment.Center,
                //HorizontalAlignment = HorizontalAlignment.Center,
                Data = new GeometryGroup
                {
                    Children =
                    {
                        new EllipseGeometry(){ Center = new Point(13, 13), RadiusX = 13, RadiusY = 13 },
                    }
                }
            };

            Grid mainGrid = new Grid()
            {
                Width = 28,
                Height = 28,
                //HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Children = { programmIcon }
            };

            Content = mainGrid;
        }

    }
}
