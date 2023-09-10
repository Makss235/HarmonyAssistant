using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Styles
{
    public class TextBlockStyles
    {
        public static Style CommonTextBlockStyle { get; private set; }

        static TextBlockStyles()
        {
            InitializeStyles();
        }

        private static void InitializeStyles()
        {
            CommonTextBlockStyle = new Style();
            CommonTextBlockStyle.Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Segoe UI")));
            CommonTextBlockStyle.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.SemiBold));
            CommonTextBlockStyle.Setters.Add(new Setter(TextBlock.ForegroundProperty,
                new DynamicResourceExtension(nameof(IAppBrushes.CommonForegroundBrush))));
            CommonTextBlockStyle.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
            CommonTextBlockStyle.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)16));
        }
    }
}
