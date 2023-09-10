using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Widgets;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswer.Base
{
    public abstract class QuickAnswerParser
    {
        public abstract event Action ParsedEvent;

        public string Text { get; set; }
        public object AnswerPresenter { get; set; }

        protected string url;
        protected Style HeaderTextBlockStyle;

        public QuickAnswerParser(string url)
        {
            this.url = url;

            InitializeStyles();
        }

        public virtual void Parse() { }

        protected virtual void InitializeStyles()
        {
            HeaderTextBlockStyle = new Style(
                targetType: typeof(TextBlock),
                basedOn: TextBlockStyles.CommonTextBlockStyle);
            HeaderTextBlockStyle.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.Bold));
            HeaderTextBlockStyle.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)17));
        }
    }
}
