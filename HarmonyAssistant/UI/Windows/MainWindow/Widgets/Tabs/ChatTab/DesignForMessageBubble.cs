using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.ChatTab
{
    public class DesignForMessageBubble : ContentControl
    {
        private Path path;

        public DesignForMessageBubble(double height)
        {
            path = new Path()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Data = new PathGeometry()
                {
                    Figures = { new PathFigure
                    {
                        StartPoint = new Point(0, 0),
                        Segments =
                        {
                            new ArcSegment { Point = new Point(height, height), Size = new Size(height, height), SweepDirection = SweepDirection.Counterclockwise },
                            new LineSegment { Point = new Point(0, height) },
                            new LineSegment { Point = new Point(0, 0) }
                        }
                    }}
                    
                }
            };
            path.SetBinding(Path.FillProperty, new Binding()
            {
                Source = this,
                Path = new PropertyPath("Background"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

            Width = height - height / 10;
            Height = height - height / 10;
            Content = path;
        }
    }
}
