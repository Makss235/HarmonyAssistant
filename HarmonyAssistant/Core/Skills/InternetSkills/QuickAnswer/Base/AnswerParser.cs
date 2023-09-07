using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswer.Base
{
    public abstract class AnswerParser
    {
        public abstract event Action ParseIsEnded;

        public string Text { get; set; }
        public object AnswerPresenter { get; set; }

        protected string url;
        protected Style TextBlockStyle;

        public AnswerParser(string url)
        {
            this.url = url;
            Text = "";
        }

        protected virtual void InitializeStyles()
        {
            TextBlockStyle = new Style(typeof(TextBlock));
            TextBlockStyle.Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Segoe UI")));
            TextBlockStyle.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.SemiBold));
            TextBlockStyle.Setters.Add(new Setter(TextBlock.ForegroundProperty, Brushes.AliceBlue));
            TextBlockStyle.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
            TextBlockStyle.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)16));
        }
    }
}
