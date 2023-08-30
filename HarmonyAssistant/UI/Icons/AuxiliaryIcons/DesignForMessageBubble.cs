using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace HarmonyAssistant.UI.Icons.AuxiliaryIcons
{
    public class DesignForMessageBubble : ContentControl
    {
        public DesignForMessageBubble(double height)
        {
            Path auxiliaryToChatBubble = new Path()
            {
                Stroke = Brushes.AliceBlue,
                Fill = Brushes.AliceBlue,
                StrokeThickness = 2,
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

            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;

            Width = height - height / 10;
            Height = height - height / 10;
            Content = auxiliaryToChatBubble;
        }

    }
}
