using HarmonyAssistant.UI.Icons.CaptionIcons.Base;
using System.Windows;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Icons.CaptionIcons
{
    /// <summary>Иконка минимизации окна.</summary>
    public class MinimizeIcon : CaptionIcon
    {
        /// <summary>Размер линии для иконки минимизации окна.</summary>
        private readonly double lineLength;

        /// <summary>Инициализирует новый объект класса MinimizeIcon.</summary>
        /// <param name="lineLength">Размер линии 
        /// для иконки минимизации окна.</param>
        public MinimizeIcon(double lineLength)
        {
            this.lineLength = lineLength;

            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            base.InitializeComponent();

            // Создание иконки в виде линии.
            icon_Path.StrokeThickness = 2;
            icon_Path.Data = new GeometryGroup()
            {
                Children =
                {
                    new LineGeometry() { StartPoint = new Point(0, 0),
                            EndPoint = new Point(lineLength, 0) }
                }
            };
        }
    }
}
