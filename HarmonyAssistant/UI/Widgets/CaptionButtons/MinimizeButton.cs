using HarmonyAssistant.UI.Icons.CaptionIcons;
using HarmonyAssistant.UI.Themes.AppBrushes;
using HarmonyAssistant.UI.Widgets.CaptionButtons.Base;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Widgets.CaptionButtons
{
    /// <summary>Кнопка минимизации окна.</summary>
    public class MinimizeButton : CaptionButton
    {
        /// <summary>Ссылка на объект класса Window.</summary>
        private readonly Window window;

        /// <summary>Инициализирует новый объект класса MinimizeButton.</summary>
        /// <param name="window">Ссылка на объект класса Window.</param>
        public MinimizeButton(Window window) : base()
        {
            // Инициализация свойств и полей.
            this.window = window;
            Icon = new MinimizeIcon(10);

            // Обработка событий.
            Click += Button_Click;
            PreviewMouseLeftButtonDown += Button_PreviewMouseLeftButtonDown;
            MouseEnter += Button_MouseEnter;
            MouseLeave += Button_MouseLeave;
        }

        /// <summary>Обработка события нажатия на кнопку.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Изменение состояния окна на свернутый.
            window.WindowState = WindowState.Minimized;
        }

        /// <summary>Обработка события предварительного нажатия на кнопку.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Изменение цвета кнопки на четверть прозрачный.
            mainBorder.Background = CommonBrushes.QuarterTransparentDarkGray;
        }

        /// <summary>Обработка события выхода курсора за границу кнопки.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            // Изменение цвета кнопки на прозрачный.
            mainBorder.Background = Brushes.Transparent;
        }

        /// <summary>Обработка события вхождения курсора в границу кнопки.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            // Изменение цвета кнопки на полупрозрачный.
            mainBorder.Background = CommonBrushes.HalfTransparentDarkGray;
        }
    }
}
