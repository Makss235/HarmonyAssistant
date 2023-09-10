using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System.Windows;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Themes.AppBrushes
{
    public class LightTurquoiseBrushes : IAppBrushes
    {
        public Brush CommonBackgroundBrush { get; }
        public Brush CommonForegroundBrush { get; }
        public Brush TabBackgroundBrush { get; }
        public Brush ChatMessageBrush { get; }
        public Brush HighlightingIconBrush { get; }

        public ResourceDictionary ResourceDictionary { get; private set; }

        #region Singleton

        private static LightTurquoiseBrushes instance;

        public static LightTurquoiseBrushes GetInstance()
        {
            if (instance == null)
                instance = new LightTurquoiseBrushes();
            return instance;
        }

        #endregion

        private LightTurquoiseBrushes()
        {
            CommonBackgroundBrush = new SolidColorBrush(new Color()
            { R = 90, G = 220, B = 250, A = 255 });

            CommonForegroundBrush = Brushes.Black;

            TabBackgroundBrush = new SolidColorBrush(new Color()
            { R = 235, G = 235, B = 255, A = 255 });

            ChatMessageBrush = new SolidColorBrush(new Color()
            { R = 110, G = 135, B = 140, A = 255 });

            HighlightingIconBrush = new SolidColorBrush(new Color()
            { R = 110, G = 135, B = 140, A = 255 });

            ResourceDictionary = new ResourceDictionary
            {
                { nameof(CommonBackgroundBrush), CommonBackgroundBrush },
                { nameof(CommonForegroundBrush), CommonForegroundBrush },
                { nameof(TabBackgroundBrush), TabBackgroundBrush },
                { nameof(ChatMessageBrush), ChatMessageBrush },
                { nameof(HighlightingIconBrush), HighlightingIconBrush }
            };
        }
    }
}
