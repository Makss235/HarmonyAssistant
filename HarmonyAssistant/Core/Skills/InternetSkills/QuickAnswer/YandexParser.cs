using AngleSharp;
using AngleSharp.Dom;
using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswer.Base;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HarmonyAssistant.Core.Skills.InternetSkill.QuickAnswer
{
    public class YandexParser : QuickAnswerParser
    {
        public override event Action ParsedEvent;

        public YandexParser(string url) : base(url) { }

        public override void ParseAsync()
        {
            var doc = Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                string page = await client.GetStringAsync(url);

                var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
                var doc = await context.OpenAsync(req => req.Content(page));
                return doc;
            });

            var quickAnswer = doc.Result.GetElementsByClassName("Fact Fact_flexSize_no");
            if (quickAnswer.Length == 0)
                return;

            StackPanel stackPanel = new StackPanel();

            var elems = quickAnswer[0].Children;
            for (int i = 0; i < elems.Length; i++)
            {
                var elem = elems[i];

                if (elem.ClassList.Contains("Fact-Summarize") ||
                    elem.ClassList.Contains("Fact-ECTitle") ||
                    elem.ClassList.Contains("Fact-Answer"))
                {
                    TextBlock mainTextBlock = new TextBlock()
                    {
                        Style = TextBlockStyle,
                        Text = elem.Text(),
                        FontSize = 17,
                        FontWeight = FontWeights.Bold
                    };
                    stackPanel.Children.Add(mainTextBlock);

                    Text += elem.Text() + "\n";
                }
                else if (elem.ClassList.Contains("Fact-ECFragment_marker_number"))
                {
                    stackPanel.Children.Add(ListItemPresenter(elem));
                }
                else if (elem.ClassList.Contains("Fact-ECFragment") ||
                         elem.ClassList.Contains("Fact-Description"))
                {
                    if (elem.Children.Length > 0)
                    {
                        var list = elem.GetElementsByClassName("List");
                        if (list.Length > 0)
                        {
                            var childrenOfList = list[0].Children;
                            for (int j = 0; j < childrenOfList.Length; j++)
                            {
                                if (childrenOfList[j].ClassList.Contains("List-Item"))
                                {
                                    stackPanel.Children.Add(ListItemPresenter(childrenOfList[j]));
                                }
                            }
                        }
                    }
                    else
                    {
                        TextBlock mainTextBlock = new TextBlock()
                        {
                            Style = TextBlockStyle,
                            Margin = new Thickness(10, 4, 10, 4),
                            Text = elem.Text()
                        };
                        stackPanel.Children.Add(mainTextBlock);
                    }

                    Text += elem.Text() + "\n";
                }
            }
            AnswerPresenter = stackPanel;
            ParsedEvent?.Invoke();
        }

        private UIElement ListItemPresenter(IElement element)
        {
            TextBlock mainTextBlock = new TextBlock()
            {
                Style = TextBlockStyle,
                Text = element.Text()
            };
            Text += element.Text() + "\n";

            var dataPositionAttr = element.Attributes["data-position"];
            if (dataPositionAttr != null)
            {
                TextBlock positionTextBlock = new TextBlock()
                {
                    Text = dataPositionAttr.Value,
                    Style = TextBlockStyle,
                    Margin = new Thickness(0, 0, 5, 0)
                };
                Grid.SetColumn(positionTextBlock, 0);

                mainTextBlock.Margin = new Thickness(5, 0, 0, 0);
                Grid.SetColumn(mainTextBlock, 1);

                ColumnDefinition positionColumnDefinition = new ColumnDefinition()
                { Width = new GridLength(1, GridUnitType.Auto) };

                ColumnDefinition mainColumnDefinition = new ColumnDefinition()
                { Width = new GridLength(1, GridUnitType.Star) };

                Grid grid = new Grid()
                { Margin = new Thickness(10, 4, 10, 4) };
                grid.ColumnDefinitions.Add(positionColumnDefinition);
                grid.ColumnDefinitions.Add(mainColumnDefinition);
                grid.Children.Add(positionTextBlock);
                grid.Children.Add(mainTextBlock);
                return grid;
            }
            else
            {
                mainTextBlock.Margin = new Thickness(10, 4, 10, 4);
                return mainTextBlock;
            }
        }
    }
}
