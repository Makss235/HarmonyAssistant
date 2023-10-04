using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace HarmonyAssistant.UI.Animations
{
    public class SendBtnEllipseAnim
    {
        Storyboard increaseSB;
        Storyboard wiggleSB;
        Storyboard toEndSB;
        Storyboard decreaseSB;
        DoubleAnimation animIncrease;
        DoubleAnimation animWiggle;
        DoubleAnimation animToEnd;
        DoubleAnimation animDecrease;
        public SendBtnEllipseAnim(Ellipse el)
        {
            el.RenderTransformOrigin = new Point(0.5, 0.5);
            el.RenderTransform = new ScaleTransform(0, 0);

            animIncrease = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.2),
            };
            animWiggle = new DoubleAnimation
            {
                From = 1,
                To = 0.8,
                Duration = TimeSpan.FromSeconds(0.4),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };
            animToEnd = new DoubleAnimation
            {
                To = 1,
                Duration = TimeSpan.FromSeconds(0.2)
            };
            animDecrease = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            increaseSB = new Storyboard();
            increaseSB.Children.Add(animIncrease);
            Storyboard.SetTarget(animIncrease, el);
            increaseSB.Completed += IncreaseSB_Completed;

            wiggleSB = new Storyboard();
            wiggleSB.Children.Add(animWiggle);
            Storyboard.SetTarget(animWiggle, el);

            toEndSB = new Storyboard();
            toEndSB.Children.Add(animToEnd);
            Storyboard.SetTarget(animToEnd, el);
            toEndSB.Completed += ToEndSB_Completed;

            decreaseSB = new Storyboard();
            decreaseSB.Children.Add(animDecrease);
            Storyboard.SetTarget(animDecrease, el);

        }

        public void StartAnim()
        {
            Storyboard.SetTargetProperty(animIncrease, new PropertyPath("RenderTransform.ScaleY"));
            increaseSB.Begin();
            Storyboard.SetTargetProperty(animIncrease, new PropertyPath("RenderTransform.ScaleX"));
            increaseSB.Begin();
        }
        public void StopAnim()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Storyboard.SetTargetProperty(animToEnd, new PropertyPath("RenderTransform.ScaleY"));
                toEndSB.Begin();
                Storyboard.SetTargetProperty(animToEnd, new PropertyPath("RenderTransform.ScaleX"));
                toEndSB.Begin();
            });
        }
        private void IncreaseSB_Completed(object sender, EventArgs e)
        {
            Storyboard.SetTargetProperty(animWiggle, new PropertyPath("RenderTransform.ScaleY"));
            wiggleSB.Begin();
            Storyboard.SetTargetProperty(animWiggle, new PropertyPath("RenderTransform.ScaleX"));
            wiggleSB.Begin();
        }
        private void ToEndSB_Completed(object sender, EventArgs e)
        {
            Storyboard.SetTargetProperty(animDecrease, new PropertyPath("RenderTransform.ScaleY"));
            decreaseSB.Begin();
            Storyboard.SetTargetProperty(animDecrease, new PropertyPath("RenderTransform.ScaleX"));
            decreaseSB.Begin();
        }
    }
}
