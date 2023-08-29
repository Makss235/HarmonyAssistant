using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Icons.CaptionButtonIcons
{
    public class MaximizeIcon : ContentControl
    {
        public MaximizeIcon(double sizeRectangle)
        {
            Path maximizeIcon = new Path()
            {
                Stroke = Brushes.AliceBlue,
                StrokeThickness = 1.5,
                Data = new GeometryGroup()
                {
                    Children =
                    {
                        new RectangleGeometry() { Rect = new Rect{ X = 0, Y = sizeRectangle / 5, Width = sizeRectangle, Height = sizeRectangle} },
                        new LineGeometry() { StartPoint = new Point(sizeRectangle / 5, 0), EndPoint = new Point(sizeRectangle + sizeRectangle / 5, 0) },
                        new LineGeometry() { StartPoint = new Point(sizeRectangle + sizeRectangle / 5, 0), EndPoint = new Point(sizeRectangle + sizeRectangle / 5, sizeRectangle) }
                    }
                }
            };

            Content = maximizeIcon;
        }
    }
}
