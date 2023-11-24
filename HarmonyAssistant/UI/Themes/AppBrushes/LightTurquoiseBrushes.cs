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
        public Brush MouseOverBrush { get; }
        public Brush EllipseInSendButtonBrush { get; }


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
            { R = 113, G = 201, B = 206, A = 255 });

            CommonForegroundBrush = new SolidColorBrush(new Color()
            { R = 25, G = 45, B = 46, A = 255 });

            TabBackgroundBrush = new SolidColorBrush(new Color()
            { R = 206, G = 230, B = 230, A = 255 });

            ChatMessageBrush = new SolidColorBrush(new Color()
            { R = 145, G = 205, B = 214, A = 255 });

            HighlightingIconBrush = new SolidColorBrush(new Color()
            { R = 40, G = 168, B = 168, A = 255 });

            MouseOverBrush = new SolidColorBrush(new Color()
            { R = 147, G = 203, B = 211, A = 230 });

            EllipseInSendButtonBrush = new SolidColorBrush(new Color()
            { R = 85, G = 182, B = 201, A = 255 });

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
