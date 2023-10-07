using HarmonyAssistant.UI.Icons.CaptionIcons;
using HarmonyAssistant.UI.Themes.AppBrushes;
using HarmonyAssistant.UI.Widgets.CaptionButtons.Base;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Widgets.CaptionButtons
{
    /// <summary>Кнопка закрытия окна.</summary>
    public class CloseButton : CaptionButton
    {
        /// <summary>Ссылка на объект класса Window.</summary>
        private readonly Window window;

        /// <summary>Инициализирует новый объект класса CloseButton.</summary>
        /// <param name="window">Ссылка на объект класса Window.</param>
        public CloseButton(Window window) : base()
        {
            // Инициализация свойств и полей.
            this.window = window;
            Icon = new CloseIcon(10, 10);

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
            // Закрытие окна.
            window.Close();
        }

        /// <summary>Обработка события предварительного нажатия на кнопку.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Изменение цвета кнопки на четверть прозрачный красный.
            mainBorder.Background = CommonBrushes.HalfTransparentRed;
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
            // Изменение цвета кнопки ярко-красный.
            mainBorder.Background = CommonBrushes.BrightRed;
        }
    }
}
