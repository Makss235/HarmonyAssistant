using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace HarmonyAssistant.UI.Animations
{
    public class TabAppearAnim
    {
        private Tab tab;
        private DoubleAnimation anim;
        public TabAppearAnim(Tab tab) 
        {
            this.tab = tab;
            anim = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.2)
            };
        }
        public void StartAnim()
        {
            tab.BeginAnimation(Tab.OpacityProperty, anim);
        }
    }
}
