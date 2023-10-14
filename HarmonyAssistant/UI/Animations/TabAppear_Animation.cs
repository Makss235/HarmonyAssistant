using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using System;
using System.Windows.Media.Animation;

namespace HarmonyAssistant.UI.Animations
{
    /// <summary>
    /// Анимация при появлении Tab.
    /// </summary>
    public class TabAppear_Animation : DoubleAnimation
    {
        //Анимируемый Tab.
        private Tab tab;

        /// <summary>
        /// Анимация при изменинии видимости вкладки на .
        /// </summary>
        /// <param name="tab">Анимируемый Tab.</param>
        public TabAppear_Animation(Tab tab) 
        {
            this.tab = tab;
            InitializeAnimation();
        }
        /// <summary>
        /// Инициализация анмации.
        /// </summary>
        private void InitializeAnimation()
        {
            From = 0;
            To = 1;
            Duration = TimeSpan.FromSeconds(0.2);
        }
        /// <summary>
        /// Метод начала анимации.
        /// </summary>
        public void StartAnim()
        {
            tab.BeginAnimation(Tab.OpacityProperty, this);
        }
    }
}
