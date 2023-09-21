using HarmonyAssistant.UI.Windows.MainWindow.Widgets;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Animations
{
    public class LeftPanelSlideOutAnim : DoubleAnimation
    {

        #region MyRegion
        //private Storyboard sb;
        //private PathGeometry pg;
        //public LeftPanelSlideOutAnim(FrameworkElement container, Grid border, bool startpose)
        //{
        //    NameScope.SetNameScope(container, new NameScope());
        //    TranslateTransform tt = new TranslateTransform();
        //    container.RegisterName("JoJo", tt);
        //    border.RenderTransform = tt;

        //    if (startpose)
        //    {
        //        pg = new PathGeometry
        //        {
        //            Figures =
        //        {
        //            new PathFigure
        //            {
        //                StartPoint = new Point(0, 0),
        //                Segments =
        //                {
        //                    new LineSegment { Point = new Point(100, 0)}
        //                }
        //            }
        //        }
        //        };
        //        startpose = false;
        //    }
        //    else
        //    {
        //        pg = new PathGeometry
        //        {
        //            Figures =
        //        {
        //            new PathFigure
        //            {
        //                StartPoint = new Point(0, 0),
        //                Segments =
        //                {
        //                    new LineSegment { Point = new Point(-100, 0)}
        //                }
        //            }
        //        }
        //        };
        //        startpose = true;
        //    }
        //    pg.Freeze();

        //    DoubleAnimationUsingPath anim = new DoubleAnimationUsingPath
        //    {
        //        PathGeometry = pg,
        //        Duration = TimeSpan.FromSeconds(1)
        //    };
        //    anim.Source = PathAnimationSource.X;

        //    Storyboard.SetTargetName(anim, "JoJo");
        //    Storyboard.SetTargetProperty(anim, new PropertyPath(TranslateTransform.XProperty));

        //    sb = new Storyboard();
        //    sb.Children.Add(anim);
        //    sb.Begin(container); 
        #endregion

        private LeftPanelMenu grid;
        public LeftPanelSlideOutAnim(LeftPanelMenu grid)
        {
            this.grid = grid;

            this.Duration = TimeSpan.FromSeconds(0.1);
            //this.DecelerationRatio = 1;
        }
        public void StartAnim(double actualWidth, double nextWidth)
        {
            this.From = actualWidth;
            this.To = nextWidth;
            grid.BeginAnimation(Grid.WidthProperty, this);
        }
    
    }
}
