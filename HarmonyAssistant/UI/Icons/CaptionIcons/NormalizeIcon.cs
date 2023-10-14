using HarmonyAssistant.UI.Icons.CaptionIcons.Base;
using System.Windows;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Icons.CaptionIcons
{
    /// <summary>Иконка нормализации окна.</summary>
    public class NormalizeIcon : CaptionIcon
    {
        /// <summary>Размер квадрата для иконки нормализации окна.</summary>
        private readonly double squareSize;

        /// <summary>Инициализирует новый объект класса NormalizeIcon.</summary>
        /// <param name="squareSize">Размер квадрата 
        /// для иконки нормализации окна.</param>
        public NormalizeIcon(double squareSize)
        {
            this.squareSize = squareSize;

            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            base.InitializeComponent();

            // Создание иконки в виде квадрата.
            icon_Path.StrokeThickness = 2;
            icon_Path.Data = new GeometryGroup()
            {
                Children =
                {
                    new RectangleGeometry() { Rect = new Rect{ X = 0, Y = squareSize / 5,
                            Width = squareSize, Height = squareSize} }
                }
            };

            Margin = new Thickness(0, 0, 0, 3);
        }
    }
}
