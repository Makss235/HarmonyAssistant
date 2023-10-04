using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System.Windows;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Themes.AppBrushes
{
    public class DarkGrayBrushes : IAppBrushes
    {
        public Brush CommonBackgroundBrush { get; }
        public Brush CommonForegroundBrush { get; }
        public Brush TabBackgroundBrush { get; }
        public Brush ChatMessageBrush { get; }
        public Brush HighlightingIconBrush { get; }
        public Brush EllipseInSendButtonBrush { get; }

        public ResourceDictionary ResourceDictionary { get; private set; }

        #region Singleton

        private static DarkGrayBrushes instance;

        public static DarkGrayBrushes GetInstance()
        {
            if (instance == null)
                instance = new DarkGrayBrushes();
            return instance;
        }

        #endregion

        private DarkGrayBrushes()
        {
            CommonBackgroundBrush = new SolidColorBrush(new Color()
            { R = 25, G = 25, B = 32, A = 255 });

            CommonForegroundBrush = Brushes.AliceBlue;

            TabBackgroundBrush = new SolidColorBrush(new Color()
            { R = 33, G = 33, B = 40, A = 255 });

            ChatMessageBrush = new SolidColorBrush(new Color()
            { R = 60, G = 60, B = 70, A = 255 });

            HighlightingIconBrush = new SolidColorBrush(new Color()
            { R = 50, G = 50, B = 100, A = 255 });

            EllipseInSendButtonBrush = new SolidColorBrush(new Color()
            { R = 33, G = 51, B = 223, A = 255 });

            ResourceDictionary = new ResourceDictionary
            {
                { nameof(CommonBackgroundBrush), CommonBackgroundBrush },
                { nameof(CommonForegroundBrush), CommonForegroundBrush },
                { nameof(TabBackgroundBrush), TabBackgroundBrush },
                { nameof(ChatMessageBrush), ChatMessageBrush },
                { nameof(HighlightingIconBrush), HighlightingIconBrush },
                { nameof(EllipseInSendButtonBrush), EllipseInSendButtonBrush },
            };
        }
    }
}
