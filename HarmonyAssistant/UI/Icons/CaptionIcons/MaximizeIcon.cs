using HarmonyAssistant.UI.Icons.CaptionIcons.Base;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Icons.CaptionIcons
{
    /// <summary>Иконка максимизации окна.</summary>
    public class MaximizeIcon : CaptionIcon
    {
        /// <summary>Размер квадрата для иконки максимизации окна.</summary>
        private readonly double squareSize;

        /// <summary>Инициализирует новый объект класса MaximizeIcon.</summary>
        /// <param name="squareSize">Размер квадрата 
        /// для иконки максимизации окна.</param>
        public MaximizeIcon(double squareSize)
        {
            this.squareSize = squareSize;

            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            base.InitializeComponent();

            // Создание иконки в виде квадрата и двух линий.
            icon_Path.StrokeThickness = 2;
            icon_Path.Data = new GeometryGroup()
            {
                Children =
                {
                    new RectangleGeometry() { Rect = new Rect{ X = 0, Y = squareSize / 5,
                            Width = squareSize, Height = squareSize} },

                    new LineGeometry() { StartPoint = new Point(squareSize / 5, 0),
                        EndPoint = new Point(squareSize + squareSize / 5, 0) },

                    new LineGeometry() { StartPoint = new Point(squareSize + squareSize / 5, 0),
                        EndPoint = new Point(squareSize + squareSize / 5, squareSize) }
                }
            };
        }
    }
}
