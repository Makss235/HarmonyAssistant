using HarmonyAssistant.UI.Windows.MainWindow.Widgets;
using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace HarmonyAssistant.UI.Animations
{
    /// <summary>
    /// Анимация выдвижения левой панели.
    /// </summary>
    public class LeftPanelSlideOut_Animation : DoubleAnimation
    {
        //анимируемый Grid.
        private LeftPanelMenu grid;

        /// <summary>
        /// Анимация выдвижения левой панели.
        /// </summary>
        /// <param name="grid">анимируемый Grid.</param>
        public LeftPanelSlideOut_Animation(LeftPanelMenu grid)
        {
            this.grid = grid;
            Duration = TimeSpan.FromSeconds(0.1);
        }
        /// <summary>
        /// Метод начала анимации.
        /// </summary>
        /// <param name="actualWidth">Начальное значение анимации.</param>
        /// <param name="nextWidth">Конечное значение анимации.</param>
        public void StartAnim(double actualWidth, double nextWidth)
        {
            this.From = actualWidth;
            this.To = nextWidth;
            grid.BeginAnimation(Grid.WidthProperty, this);
        }
    }
}
