using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.ChatTab;

namespace HarmonyAssistant.UI.Animations
{
    public class ChatBubbleAppearAnim
    {
        private Storyboard appearSB;
        private DoubleAnimation anim;
        private ContentControl animControl;
        public ChatBubbleAppearAnim(ContentControl animControl)
        {
            //animControl.RenderTransformOrigin = new Point(1.0, 1.0);
            this.animControl = animControl;
            animControl.RenderTransform = new ScaleTransform(1.0, 1.0);

            anim = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(100),
            };

            appearSB = new Storyboard();
            appearSB.Children.Add(anim);
            
            Storyboard.SetTarget(anim, animControl);
        }
        public void StartAnim(SendMessageBy sendMessageBy)
        {
            if(sendMessageBy == SendMessageBy.ByMe)
                animControl.RenderTransformOrigin = new Point(1.0, 1.0);
            else if(sendMessageBy == SendMessageBy.ByBot)
                animControl.RenderTransformOrigin = new Point(0, 1.0);

            Storyboard.SetTargetProperty(anim, new PropertyPath("RenderTransform.ScaleY"));
            appearSB.Begin();
            Storyboard.SetTargetProperty(anim, new PropertyPath("RenderTransform.ScaleX"));
            appearSB.Begin();
        }
    }
}
