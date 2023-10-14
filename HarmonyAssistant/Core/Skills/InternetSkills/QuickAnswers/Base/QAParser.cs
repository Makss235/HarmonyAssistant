using HarmonyAssistant.UI.Styles;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.Base
{
    public abstract class QAParser
    {
        public abstract event Action ParsedEvent;

        public string Text { get; set; }
        public object AnswerPresenter { get; set; }

        protected string url;
        protected Style HeaderTextBlockStyle;

        public QAParser(string url)
        {
            this.url = url;

            InitializeStyles();
        }

        public virtual void Parse() { }

        protected virtual void InitializeStyles()
        {
            HeaderTextBlockStyle = new Style(
                targetType: typeof(TextBlock),
                basedOn: new CommonTextBlockStyle());
            HeaderTextBlockStyle.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.Bold));
            HeaderTextBlockStyle.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)17));
        }
    }
}
