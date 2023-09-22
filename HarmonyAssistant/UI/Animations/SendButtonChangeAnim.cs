using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;

namespace HarmonyAssistant.UI.Animations
{
    public class SendButtonChangeAnim
    {
        private DoubleAnimation animIncrease;
        private DoubleAnimation animDecrease;
        private Storyboard sb;
        private Storyboard sb2;
        private Label fromLabel;
        private Label toLabel;
        private bool canClick;
        public SendButtonChangeAnim(Label fromLabel, Label toLabel)
        {
            canClick = true;
            this.fromLabel = fromLabel;
            this.toLabel = toLabel;
            fromLabel.RenderTransformOrigin = new Point(0.5, 0.5);
            fromLabel.RenderTransform = new ScaleTransform(1.0, 1.0);
            toLabel.RenderTransformOrigin = new Point(0.5, 0.5);
            toLabel.RenderTransform = new ScaleTransform(0, 0);

            animDecrease = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.1),
            };
            animIncrease = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.1),
            };

            sb = new Storyboard();
            sb.Children.Add(animDecrease);
            sb2 = new Storyboard();
            sb2.Children.Add(animIncrease);
            Storyboard.SetTarget(animDecrease, fromLabel);
            Storyboard.SetTarget(animIncrease, toLabel);
            sb.Completed += Sb_Completed;
            sb2.Completed += (s, e) => canClick = true;
        }
        public void StartAnim(bool canStartAnim)
        {
            if (canClick && canStartAnim)
            {
                canClick = false;
                Storyboard.SetTargetProperty(animDecrease, new PropertyPath("RenderTransform.ScaleY"));
                sb.Begin();
                Storyboard.SetTargetProperty(animDecrease, new PropertyPath("RenderTransform.ScaleX"));
                sb.Begin();
                fromLabel.BeginAnimation(Label.OpacityProperty, animDecrease);
            }
        }

        private void Sb_Completed(object sender, EventArgs e)
        {
            Storyboard.SetTargetProperty(animIncrease, new PropertyPath("RenderTransform.ScaleY"));
            sb2.Begin();
            Storyboard.SetTargetProperty(animIncrease, new PropertyPath("RenderTransform.ScaleX"));
            sb2.Begin();
            toLabel.BeginAnimation(Label.OpacityProperty, animIncrease);
        }
    }
}
