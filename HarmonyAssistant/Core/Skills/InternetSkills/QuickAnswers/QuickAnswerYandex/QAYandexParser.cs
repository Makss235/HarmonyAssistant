using AngleSharp;
using AngleSharp.Dom;
using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.Base;
using HarmonyAssistant.UI.Styles;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerYandex
{
    public class QAYandexParser : QAParser
    {
        public override event Action ParsedEvent;

        public QAYandexParser(string url) : base(url) { }

        public override void Parse()
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
                    if (!string.IsNullOrEmpty(elem.Text()))
                    {
                        TextBlock mainTextBlock = new TextBlock()
                        {
                            Style = HeaderTextBlockStyle,
                            Text = elem.Text()
                        };
                        stackPanel.Children.Add(mainTextBlock);

                        Text += elem.Text() + "\n";
                    }
                }
                else if (elem.ClassList.Contains("Fact-ECFragment_marker_number"))
                {
                    FrameworkElement element = ListItemPresenter(elem);
                    ChechMarginElement(element, stackPanel);
                    stackPanel.Children.Add(element);
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
                                    FrameworkElement element = ListItemPresenter(childrenOfList[j]);
                                    ChechMarginElement(element, stackPanel);
                                    stackPanel.Children.Add(element);
                                }
                            }
                        }
                        else
                        {
                            TextBlock mainTextBlock = new TextBlock()
                            {
                                Text = elem.Text(),
                                Style = TextBlockStyles.CommonTextBlockStyle
                            };
                            ChechMarginElement(mainTextBlock, stackPanel);
                            stackPanel.Children.Add(mainTextBlock);
                        }
                    }
                    else
                    {
                        TextBlock mainTextBlock = new TextBlock()
                        {
                            Text = elem.Text(),
                            Style = TextBlockStyles.CommonTextBlockStyle
                        };
                        ChechMarginElement(mainTextBlock, stackPanel);
                        stackPanel.Children.Add(mainTextBlock);
                    }

                    Text += elem.Text() + "\n";
                }
            }
            AnswerPresenter = stackPanel;
            ParsedEvent?.Invoke();
        }

        private void ChechMarginElement(FrameworkElement element, Panel parent)
        {
            if (parent.Children.Count > 0)
            {
                foreach (var child in parent.Children)
                {
                    try
                    {
                        if ((child as FrameworkElement).Style == HeaderTextBlockStyle)
                        {
                            element.Margin = new Thickness(10, 4, 10, 4);
                            break;
                        }
                        else
                        {
                            element.Margin = new Thickness(0, 6, 0, 0);
                            break;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private FrameworkElement ListItemPresenter(IElement element)
        {
            TextBlock mainTextBlock = new TextBlock()
            {
                Text = element.Text(),
                Style = TextBlockStyles.CommonTextBlockStyle
            };
            Text += element.Text() + "\n";

            var dataPositionAttr = element.Attributes["data-position"];
            if (dataPositionAttr != null)
            {
                TextBlock positionTextBlock = new TextBlock()
                {
                    Text = dataPositionAttr.Value,
                    Style = TextBlockStyles.CommonTextBlockStyle,
                    Margin = new Thickness(0, 0, 5, 0)
                };
                Grid.SetColumn(positionTextBlock, 0);

                mainTextBlock.Margin = new Thickness(5, 0, 0, 0);
                Grid.SetColumn(mainTextBlock, 1);

                ColumnDefinition positionColumnDefinition = new ColumnDefinition()
                { Width = new GridLength(1, GridUnitType.Auto) };

                ColumnDefinition mainColumnDefinition = new ColumnDefinition()
                { Width = new GridLength(1, GridUnitType.Star) };

                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(positionColumnDefinition);
                grid.ColumnDefinitions.Add(mainColumnDefinition);
                grid.Children.Add(positionTextBlock);
                grid.Children.Add(mainTextBlock);
                return grid;
            }
            else return mainTextBlock;
        }
    }
}
