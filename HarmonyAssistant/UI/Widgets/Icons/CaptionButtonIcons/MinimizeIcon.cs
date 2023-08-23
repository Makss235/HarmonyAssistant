using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Widgets.Icons.CaptionButtonIcons
{
    public class MinimizeIcon : ContentControl
    {
        public MinimizeIcon(double lineLength) 
        {
            Path minimizeIcon = new Path()
            {
                Stroke = Brushes.AliceBlue,
                StrokeThickness = 2,
                Height = 2,
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
