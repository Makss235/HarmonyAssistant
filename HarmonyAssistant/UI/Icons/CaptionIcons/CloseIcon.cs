using HarmonyAssistant.UI.Icons.CaptionIcons.Base;
using System.Windows;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Icons.CaptionIcons
{
    /// <summary>Иконка закрытия окна.</summary>
    public class CloseIcon : CaptionIcon
    {
        /// <summary>Ширина иконки.</summary>
        private readonly double width;
        /// <summary>Высота иконки.</summary>
        private readonly double height;

        /// <summary>Инициализирует новый объект класса CloseIcon.</summary>
        /// <param name="width">Ширина иконки.</param>
        /// <param name="height">Высота иконки.</param>
        public CloseIcon(double width, double height)
        {
            this.width = width;
            this.height = height;

            InitializeComponent();
        }

        protected override void InitializeComponent()
        {
            base.InitializeComponent();

            // Создание иконки вида "х".
            icon_Path.StrokeThickness = 2;
            icon_Path.Data = new GeometryGroup()
            {
                Children =
                {
                    new LineGeometry() { StartPoint = new Point(0, 0),
                        EndPoint = new Point(width, height) },

                    new LineGeometry() { StartPoint = new Point(0, height),
                        EndPoint = new Point(width, 0) }
                }
            };
        }
    }
}
