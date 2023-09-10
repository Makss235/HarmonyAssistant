using HarmonyAssistant.Core.Base;
using System.Windows;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Themes.AppBrushes.Base
{
    public interface IAppBrushes
    {
        public Brush CommonBackgroundBrush { get; }
        public Brush CommonForegroundBrush { get; }
        public Brush TabBackgroundBrush { get; }
        public Brush ChatMessageBrush { get; }
        public Brush HighlightingIconBrush { get; }

        public ResourceDictionary ResourceDictionary { get; }
    }
}
