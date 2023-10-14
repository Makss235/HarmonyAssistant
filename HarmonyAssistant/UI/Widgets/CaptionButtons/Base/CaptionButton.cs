using HarmonyAssistant.UI.Icons.CaptionIcons;
using HarmonyAssistant.UI.Icons.CaptionIcons.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shell;

namespace HarmonyAssistant.UI.Widgets.CaptionButtons.Base
{
    /// <summary>Базовый класс кнопки заголовка.</summary>
    public abstract class CaptionButton : ButtonBase
    {
        #region Icon : DependencyProperty[CaptionIcon] - Иконка кнопки заголовка

        /// <summary>Свойство зависимостей свойства Icon.</summary>
        public static readonly DependencyProperty IconProperty;

        /// <summary>Иконка, являющаяся визуалом кнопки заголовка.</summary>
        public CaptionIcon Icon
        {
            get { return (CaptionIcon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>Метод обработки изменений свойства Icon.</summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CaptionButton captionButton = (CaptionButton)d;
            captionButton.mainBorder.Child = e.NewValue as CaptionIcon;
        }

        #endregion

        /// <summary>
        /// Border, с помощью которого меняется цвет заднего фона кнопки.
        /// </summary>
        protected Border mainBorder;

        #region Конструкторы

        /// <summary>Статический конструктор, в котором 
        /// регистрируются свойства зависимостей.</summary>
        static CaptionButton()
        {
            // Регистрация свойства зависимостей IconProperty.
            IconProperty = DependencyProperty.Register(
                        "Icon",
                        typeof(CaptionIcon),
                        typeof(CaptionButton),
                        new FrameworkPropertyMetadata(
                            null,
                            //FrameworkPropertyMetadataOptions.AffectsMeasure |
                            //FrameworkPropertyMetadataOptions.AffectsRender,
                            new PropertyChangedCallback(OnIconChanged)));
        }

        /// <summary>Инициализирует новый объект класса CaptionButton.</summary>
        public CaptionButton()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>Инициализация визуальных компонентов.</summary>
        private void InitializeComponent()
        {
            // Инициализация border.
            mainBorder = new Border()
            { Background = Brushes.Transparent };

            // Установка значения свойства Icon по умолчанию.
            Icon = new MinimizeIcon(10);
            mainBorder.Child = Icon;

            // Установка значение true свойства видимости на Chrome.
            SetValue(WindowChrome.IsHitTestVisibleInChromeProperty, true);
            Content = mainBorder;
        }
    }
}
