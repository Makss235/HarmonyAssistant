using System.Windows.Media;

namespace HarmonyAssistant.UI.Themes.AppBrushes
{
    public static class CommonBrushes
    {
        //public static Brush DarkerBlue { get; set; }
        //public static Brush LessDarkBlue { get; set; }
        //public static Brush MediumBlue { get; set; }
        public static Brush MediumGray { get; set; }
        public static Brush QuarterTransparentDarkGray { get; set; }
        public static Brush HalfTransparentDarkGray { get; set; }
        public static Brush HalfTransparentRed { get; set; }
        public static Brush BrightRed { get; set; }

        static CommonBrushes()
        {
            //DarkerBlue = new SolidColorBrush(new Color()
            //{ R = 25, G = 25, B = 32, A = 255 });

            //LessDarkBlue = new SolidColorBrush(new Color()
            //{ R = 33, G = 33, B = 40, A = 255 });

            //MediumBlue = new SolidColorBrush(new Color()
            //{ R = 50, G = 50, B = 100, A = 255 });

            MediumGray = new SolidColorBrush(new Color()
            { R = 60, G = 60, B = 70, A = 255 });

            QuarterTransparentDarkGray = new SolidColorBrush(new Color()
            { R = 70, G = 70, B = 70, A = 70 });

            HalfTransparentDarkGray = new SolidColorBrush(new Color()
            { R = 70, G = 70, B = 70, A = 100 });

            HalfTransparentRed = new SolidColorBrush(new Color()
            { R = 255, G = 0, B = 0, A = 150 });

            BrightRed = new SolidColorBrush(new Color()
            { R = 255, G = 0, B = 0, A = 200 });
        }
    }
}
