using HarmonyAssistant.UI.Icons.CaptionIcons;
using HarmonyAssistant.UI.Icons.CaptionIcons.Base;
using HarmonyAssistant.UI.Themes.AppBrushes;
using HarmonyAssistant.UI.Widgets.CaptionButtons.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Widgets.CaptionButtons
{
    /// <summary>Кнопка максимизации окна.</summary>
    public class MaximizeButton : CaptionButton
    {
        /// <summary>Ссылка на объект класса Window.</summary>
        private readonly Window window;

        /// <summary>Иконка максимизации окна.</summary>
        private MaximizeIcon maximizeIcon;
        /// <summary>Иконка нормализации окна.</summary>
        private NormalizeIcon normalizeIcon;

        /// <summary>Инициализирует новый объект класса MaximizeButton.</summary>
        /// <param name="window">Ссылка на объект класса Window.</param>
        /// <param name="icon">Ссылка на объект класса CaptionIcon, 
        /// который является иконкой по умолчанию.</param>
        public MaximizeButton(Window window, CaptionIcon icon) : base()
        {
            // Инициализация свойств и полей.
            this.window = window;
            Icon = icon;

            // Инициализация иконок.
            maximizeIcon = new MaximizeIcon(10);
            normalizeIcon = new NormalizeIcon(10);

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
            // Если свернутое состояние окна - отображается NormalizeIcon
            // и меняется состояние окна на нормальное.
            if (window.WindowState == WindowState.Maximized)
            {
                Icon = normalizeIcon;
                window.WindowState = WindowState.Normal;
            }
            // Если нормальное состояние окна - отображается MaximizeIcon
            // и меняется состояние окна на свернутое.
            else if (window.WindowState == WindowState.Normal)
            {
                Icon = maximizeIcon;
                window.WindowState = WindowState.Maximized;
            }
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
