using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Widgets.Icons.CaptionButtonIcons
{
    public class BackSizeIcon : ContentControl
    {
        public BackSizeIcon(double sizeRectangle)
        {
            Path backSizeIcon = new Path()
            {
                Stroke = Brushes.AliceBlue,
                StrokeThickness = 2,
                Data = new GeometryGroup()
                {
                    Children =
                    {
                        new RectangleGeometry() { Rect = new Rect{ X = 0, Y = sizeRectangle / 5, Width = sizeRectangle, Height = sizeRectangle} },
                    }
                }
            };

            Content = backSizeIcon;
        }
    }
}
