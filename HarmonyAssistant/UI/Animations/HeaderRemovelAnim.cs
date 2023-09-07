using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HarmonyAssistant.UI.Animations
{
    public class HeaderRemovelAnim
    {
        private Storyboard sb;
        private PathGeometry pg;
        public HeaderRemovelAnim(FrameworkElement container, Border border, bool isClosed)
        {
            NameScope.SetNameScope(container, new NameScope());
            TranslateTransform tt = new TranslateTransform();
            container.RegisterName("JoJo", tt);
            border.RenderTransform = tt;

            if (isClosed)
            {
                pg = new PathGeometry
                {
                    Figures =
                {
                    new PathFigure
                    {
                        StartPoint = new Point(0, 0),
                        Segments =
                        {
                            new LineSegment { Point = new Point(0, 100)}
                        }
                    }
                }
                };
                isClosed = false;
            }
            else
            {
                pg = new PathGeometry
                {
                    Figures =
                    {
                    new PathFigure
                    {
                        StartPoint = new Point(0, 0),
                        Segments =
                        {
                            new LineSegment { Point = new Point(0, -100)}
                        }
                    }
                    }
                };
                isClosed = true;
            }
            pg.Freeze();

            DoubleAnimationUsingPath anim = new DoubleAnimationUsingPath
            {
                PathGeometry = pg,
                Duration = TimeSpan.FromSeconds(1)
            };
            anim.Source = PathAnimationSource.X;

            Storyboard.SetTargetName(anim, "JoJo");
            Storyboard.SetTargetProperty(anim, new PropertyPath(TranslateTransform.XProperty));

            sb = new Storyboard();
            sb.Children.Add(anim);
            sb.Begin(container);
        }
    }
}
