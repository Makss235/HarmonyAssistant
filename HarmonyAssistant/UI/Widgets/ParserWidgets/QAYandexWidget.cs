using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerYandex;
using HarmonyAssistant.UI.Styles;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Widgets.ParserWidgets
{
    public class QAYandexWidget : ContentControl
    {
        public string Text { get; set; }

        protected QAYandexParser qAYandexParser;
        protected Style HeaderTextBlockStyle;

        public QAYandexWidget(QAYandexParser qAYandexParser)
        {
            this.qAYandexParser = qAYandexParser;

            InitializeStyles();
            InitializeComponent();
        }

        protected virtual void InitializeStyles()
        {
            HeaderTextBlockStyle = new Style(
                targetType: typeof(TextBlock),
                basedOn: new CommonTextBlockStyle());
            HeaderTextBlockStyle.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.Bold));
            HeaderTextBlockStyle.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)17));
        }

        private void InitializeComponent()
        {
            if (qAYandexParser.QuickDefinition != null)
            {
                StackPanel stackPanel2 = new StackPanel();
                if (!string.IsNullOrEmpty(qAYandexParser.QuickDefinition.FactAnswer))
                {
                    TextBlock mainTextBlock = new TextBlock()
                    {
                        Text = qAYandexParser.QuickDefinition.FactAnswer,
                        Style = HeaderTextBlockStyle
                    };

                    stackPanel2.Children.Add(mainTextBlock);
                }

                if (qAYandexParser.QuickDefinition.FactFragments != null)
                {
                    StackPanel stackPanel = new StackPanel();
                    for (int i = 0; i < qAYandexParser.QuickDefinition.FactFragments.Count; i++)
                    {
                        StackPanel stackPanel1 = new StackPanel()
                        { Orientation = Orientation.Horizontal };

                        if (!string.IsNullOrEmpty(qAYandexParser.QuickDefinition.FactFragments[i].NumberInOrder))
                        {
                            TextBlock textBlock1 = new TextBlock()
                            {
                                Style = new CommonTextBlockStyle(),
                                Text = qAYandexParser.QuickDefinition.FactFragments[i].NumberInOrder,
                                Margin = new Thickness(0, 0, 5, 0)
                            };
                            stackPanel1.Children.Add(textBlock1);
                        }

                        TextBlock textBlock2 = new TextBlock()
                        {
                            Style = new CommonTextBlockStyle(),
                            Text = qAYandexParser.QuickDefinition.FactFragments[i].TextFragment
                        };
                        stackPanel1.Children.Add(textBlock2);
                        stackPanel.Children.Add(stackPanel1);
                    }

                    if (!string.IsNullOrEmpty(qAYandexParser.QuickDefinition.FactAnswer))
                        stackPanel.Margin = new Thickness(10, 0, 0, 0);
                    stackPanel2.Children.Add(stackPanel);
                }

                if (!string.IsNullOrEmpty(qAYandexParser.QuickDefinition.SiteName))
                {
                    StackPanel stackPanel = new StackPanel()
                    { Margin = new Thickness(0, 10, 0, 0) };

                    TextBlock textBlock = new TextBlock()
                    {
                        Style = new CommonTextBlockStyle(),
                        Text = qAYandexParser.QuickDefinition.SiteName,
                        FontSize = 13
                    };
                    stackPanel.Children.Add(textBlock);

                    if (!string.IsNullOrEmpty(qAYandexParser.QuickDefinition.ArticleName))
                    {
                        TextBlock textBlock1 = new TextBlock()
                        {
                            Style = new CommonTextBlockStyle(),
                            Text = qAYandexParser.QuickDefinition.ArticleName,
                            Margin = new Thickness(0, -3, 0, 0)
                        };
                        stackPanel.Children.Add(textBlock1);
                    }
                    stackPanel2.Children.Add(stackPanel);
                }

                if (stackPanel2.Children.Count > 0)
                    Content = stackPanel2;
            }
        }
    }
}
