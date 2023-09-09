using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System.Windows;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Themes.AppBrushes
{
    public class DarkBlueBrushes : IAppBrushes
    {
        public Brush CommonBackgroundBrush { get; }
        public Brush CommonForegroundBrush { get; }
        public Brush TabBackgroundBrush { get; }
        public Brush ChatMessageBrush { get; }
        public Brush HighlightingIcon { get; }

        public ResourceDictionary ResourceDictionary { get; private set; }

        #region Singleton

        private static DarkBlueBrushes instance;

        public static DarkBlueBrushes GetInstance()
        {
            if (instance == null)
                instance = new DarkBlueBrushes();
            return instance;
        }

        #endregion

        private DarkBlueBrushes()
        {
            CommonBackgroundBrush = new SolidColorBrush(new Color()
            { R = 23, G = 33, B = 42, A = 255 });

            CommonForegroundBrush = Brushes.AliceBlue;

            TabBackgroundBrush = new SolidColorBrush(new Color()
            { R = 35, G = 47, B = 61, A = 255 });

            ChatMessageBrush = new SolidColorBrush(new Color()
            { R = 43, G = 82, B = 120, A = 255 });

            HighlightingIcon = new SolidColorBrush(new Color()
            { R = 50, G = 50, B = 100, A = 255 });

            ResourceDictionary = new ResourceDictionary
            {
                { nameof(CommonBackgroundBrush), CommonBackgroundBrush },
                { nameof(CommonForegroundBrush), CommonForegroundBrush },
                { nameof(TabBackgroundBrush), TabBackgroundBrush },
                { nameof(ChatMessageBrush), ChatMessageBrush },
                { nameof(HighlightingIcon), HighlightingIcon }
            };
        }
    }
}
