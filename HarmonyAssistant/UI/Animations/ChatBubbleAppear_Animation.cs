using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.ChatTab;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace HarmonyAssistant.UI.Animations
{
    /// <summary>
    /// Анимация появления пузырей в чате.
    /// </summary>
    public class ChatBubbleAppear_Animation : DoubleAnimation
    {
        //Storyboard для анимации.
        private Storyboard storyboard;
        //Анимируемый Control.
        private ContentControl animControl;

        /// <summary>
        /// Анимация появления пузырей в чате.
        /// </summary>
        /// <param name="animControl">Анимируемый Control.</param>
        public ChatBubbleAppear_Animation(ContentControl animControl)
        {
            this.animControl = animControl;
            InitializeAnimation();
        }
        /// <summary>
        /// Инициализация анимации.
        /// </summary>
        private void InitializeAnimation()
        {
            From = 0;
            To = 1;
            Duration = TimeSpan.FromMilliseconds(100);

            animControl.RenderTransform = new ScaleTransform(1.0, 1.0);

            storyboard = new Storyboard();
            storyboard.Children.Add(this);

            Storyboard.SetTarget(this, animControl);
        }
        /// <summary>
        /// Метод начала анимации.
        /// </summary>
        /// <param name="sendMessageBy">Значение перечисления SendMessageBy:
        /// тот, кто отправил сообщение(пользователь, либо бот).
        /// </param>
        public void StartAnim(SendMessageBy sendMessageBy)
        {
            //Выбор начальной точки появления анмации.
            if(sendMessageBy == SendMessageBy.ByMe)
                animControl.RenderTransformOrigin = new Point(1.0, 1.0);
            else if(sendMessageBy == SendMessageBy.ByBot)
                animControl.RenderTransformOrigin = new Point(0, 1.0);

            //Два раза вызывается начало storyboard для анимации свойств
            //ScaleY и ScaleX одновременно.
            Storyboard.SetTargetProperty(this, new PropertyPath("RenderTransform.ScaleY"));
            storyboard.Begin();
            Storyboard.SetTargetProperty(this, new PropertyPath("RenderTransform.ScaleX"));
            storyboard.Begin();
        }
    }
}
