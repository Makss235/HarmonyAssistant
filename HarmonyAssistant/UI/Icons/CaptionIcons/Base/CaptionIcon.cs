using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Themes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Icons.CaptionIcons.Base
{
    /// <summary>Базовый класс иконки заголовка.</summary>
    public abstract class CaptionIcon : ContentControl
    {
        /// <summary>Путь для рисования иконки.</summary>
        protected Path icon_Path;

        /// <summary>Инициализация визуальных компонентов.</summary>
        protected virtual void InitializeComponent()
        {
            icon_Path = new Path();

            // Установка привязки свойства заполнения иконки и свойства Foreground.
            icon_Path.SetBinding(Shape.StrokeProperty, new Binding()
            {
                Source = this,
                Path = new PropertyPath("Foreground"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

            // Привязка свойства Foreground к CommonForegroundBrush.
            ThemeManager.AddResourceReference(this);
            SetResourceReference(ForegroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Center;
            Content = icon_Path;
        }
    }
}
