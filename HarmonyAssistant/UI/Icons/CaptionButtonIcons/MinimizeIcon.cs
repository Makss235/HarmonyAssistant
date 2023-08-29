using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Icons.CaptionButtonIcons
{
    public class MinimizeIcon : ContentControl
    {
        public MinimizeIcon(double lineLength)
        {
            Path minimizeIcon = new Path()
            {
                Stroke = Brushes.AliceBlue,
                StrokeThickness = 2,
                Data = new GeometryGroup()
                {
                    Children =
                    {
                        new LineGeometry() { StartPoint = new Point(0, 0) , EndPoint = new Point(lineLength, 0)},
                    }
                }
            };
            Content = minimizeIcon;
        }
    }
}
