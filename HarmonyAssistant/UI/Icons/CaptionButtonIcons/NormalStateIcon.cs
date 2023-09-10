using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Icons.CaptionButtonIcons
{
    public class NormalStateIcon : ContentControl
    {
        public NormalStateIcon(double sizeRectangle)
        {
            Path normalStateIcon = new Path()
            {
                StrokeThickness = 1.5,
                Data = new GeometryGroup()
                {
                    Children =
                    {
                        new RectangleGeometry() { Rect = new Rect{ X = 0, Y = sizeRectangle / 5, Width = sizeRectangle, Height = sizeRectangle} },
                    }
                }
            };
            normalStateIcon.SetBinding(Shape.StrokeProperty, new Binding()
            {
                Source = this,
                Path = new PropertyPath("Background"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

            Margin = new Thickness(0, 0, 0, 3);
            Content = normalStateIcon;
        }
    }
}
