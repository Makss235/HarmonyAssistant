using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Styles
{
    public class CommonTextBlockStyle : Style
    {
        public CommonTextBlockStyle()
        {
            InitializeStyle();
        }

        private void InitializeStyle()
        {
            Setters.Add(new Setter(TextBlock.ForegroundProperty,
                new DynamicResourceExtension(nameof(IAppBrushes.CommonForegroundBrush))));
            Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Segoe UI")));
            Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.SemiBold));
            Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
            Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)16));
        }
    }
}
