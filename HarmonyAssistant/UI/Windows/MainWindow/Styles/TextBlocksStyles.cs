using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Styles
{
    public class TextBlocksStyles 
    {
        public static Style TextBlockStyle;

        static TextBlocksStyles()
        {
            InitializeStyles();
        }

        private static void InitializeStyles()
        {
            TextBlockStyle = new Style(/*targetType: typeof(TextBlock)*/);
            TextBlockStyle.Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Segoe UI")));
            TextBlockStyle.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.SemiBold));
            TextBlockStyle.Setters.Add(new Setter(TextBlock.ForegroundProperty, Brushes.AliceBlue));
            TextBlockStyle.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
            TextBlockStyle.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)16));
        }
    }
}
