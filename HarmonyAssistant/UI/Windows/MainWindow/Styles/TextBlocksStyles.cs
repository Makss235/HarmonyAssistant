using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Styles
{
    public class TextBlocksStyles 
    {
        public static Style textBlockStyle;

        static TextBlocksStyles()
        {
            InitializeStyles();
        }

        private static void InitializeStyles()
        {
            textBlockStyle = new Style();
            textBlockStyle.Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Cambria")));
            textBlockStyle.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.Bold));
            textBlockStyle.Setters.Add(new Setter(TextBlock.ForegroundProperty, Brushes.AliceBlue));
            textBlockStyle.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)17));
        }
    }
}
