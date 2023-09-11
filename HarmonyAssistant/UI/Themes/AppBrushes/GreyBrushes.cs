using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System.Windows;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Themes.AppBrushes
{
    public class GreyBrushes : IAppBrushes
    {
        public Brush CommonBackgroundBrush { get; }
        public Brush CommonForegroundBrush { get; }
        public Brush TabBackgroundBrush { get; }
        public Brush ChatMessageBrush { get; }
        public Brush HighlightingIconBrush { get; }

        public ResourceDictionary ResourceDictionary { get; private set; }

        #region Singleton

        private static GreyBrushes instance;

        public static GreyBrushes GetInstance()
        {
            if (instance == null)
                instance = new GreyBrushes();
            return instance;
        }

        #endregion

        private GreyBrushes()
        {
            CommonBackgroundBrush = new SolidColorBrush(new Color()
            { R = 32, G = 32, B = 32, A = 255 });

            CommonForegroundBrush = Brushes.AliceBlue;

            TabBackgroundBrush = new SolidColorBrush(new Color()
            { R = 39, G = 39, B = 39, A = 255 });

            ChatMessageBrush = new SolidColorBrush(new Color()
            { R = 64, G = 64, B = 66, A = 255 });

            HighlightingIconBrush = new SolidColorBrush(new Color()
            { R = 64, G = 64, B = 66, A = 255 });

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
