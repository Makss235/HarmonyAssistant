using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Icons.CaptionButtonIcons
{
    public class CloseIcon : ContentControl
    {
        public CloseIcon(double width, double height)
        {
            Path crossIcon = new Path()
            {
                StrokeThickness = 2,
                Data = new GeometryGroup()
                {
                    Children =
                    {
                        new LineGeometry() { StartPoint = new Point(0, 0), EndPoint = new Point(width, height) } ,
                        new LineGeometry() { StartPoint = new Point(0, height), EndPoint = new Point(width, 0) }
                    }
                }
            };
            crossIcon.SetBinding(Shape.StrokeProperty, new Binding()
            {
                Source = this,
                Path = new PropertyPath("Background"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

            Content = crossIcon;
        }
    }
}
