using AngleSharp;
using AngleSharp.Dom;
using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerYandex.DataParse;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerYandex
{
    public class QAYandexParser
    {
        public QuickDefinition QuickDefinition { get; set; }
        public RightTermDefinition RightTermDefinition { get; set; }

        private string url;

        public QAYandexParser(string url) 
        {
            this.url = url;
        }

        public void Parse()
        {
            var doc = Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                //client.DefaultRequestHeaders.Add("User-Agent",
                //        "Mozilla/5.0 (Windows NT 11.0; Win64; x64; rv:23.0) Gecko/20100101 Firefox/77.0");
                string page = await client.GetStringAsync(url);

                var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
                var doc = await context.OpenAsync(req => req.Content(page));
                return doc;
            });

            var elems = doc.Result.GetElementsByClassName("Fact Fact_flexSize_no");
            if (elems.Length != 0)
            {
                QuickDefinition = new QuickDefinition();
                var elem = elems[0];

                var t1 = elem.Children.Where(p => p.ClassList.Contains("Typo_line_m") && 
                !p.ClassList.Contains("ExtraActions")).ToArray();
                if (t1.Length != 0) QuickDefinition.FactAnswer = t1[0].Text();

                var t2 = elem.GetElementsByClassName("Fact-ECFragment Fact-ECFragment Fact-ECFragment_typo");
                if (t2.Length != 0)
                {
                    QuickDefinition.FactFragments = new List<FactFragment>();
                    foreach (var item in t2)
                    {
                        FactFragment fragment = new FactFragment();
                        if (item.ClassName.Contains("Fact-ECFragment_marker_number"))
                            fragment.NumberInOrder = item.GetAttribute("data-position");
                        fragment.TextFragment = item.Text();

                        QuickDefinition.FactFragments.Add(fragment);
                    }
                }

                var t3 = elem.GetElementsByClassName("Link Fact-SiteSource");
                if (t3.Length != 0)
                {
                    QuickDefinition.SitePath = t3[0].GetAttribute("href");

                    var t4 = t3[0].GetElementsByClassName("Path-Item");
                    if (t4.Length != 0) QuickDefinition.SiteName = t4[0].Text();

                    var t5 = t3[0].GetElementsByClassName("Fact-HostDescription");
                    if (t5.Length != 0) QuickDefinition.SiteType = t5[0].Text();

                    var t6 = t3[0].GetElementsByClassName("OneLine Fact-Title Typo Typo_text_xm Typo_line_m");
                    if (t6.Length != 0) QuickDefinition.ArticleName = t6[0].Text();
                }
            }

            var elems1 = doc.Result.GetElementsByClassName(
                "entity-search entity-search_type_false entity-search_wiki");
            if (elems1.Length != 0)
            {
                RightTermDefinition = new RightTermDefinition();
                var elem = elems1[0];

                var t1 = elem.GetElementsByClassName("serp-title_type_supertitle");
                if (t1.Length != 0) RightTermDefinition.Term = t1[0].Text();

                var t2 = elem.GetElementsByClassName("serp-title_type_subtitle");
                if (t2.Length != 0) RightTermDefinition.SubTitle = t2[0].Text();

                var t3 = elem.GetElementsByClassName("ExtendedText-Full");
                if (t3.Length != 0)
                {
                    var t31 = t3[0].GetElementsByClassName("Description-Paragraph");

                    RightTermDefinition.DefinitionParagraphes = new List<string>();
                    foreach (var item in t31)
                        RightTermDefinition.DefinitionParagraphes.Add(item.Text());
                }

                var t4 = elem.GetElementsByClassName("EntitySearchHint Description-Source");
                if (t4.Length != 0)
                {
                    var t41 = elem.GetElementsByTagName("a");

                    RightTermDefinition.SourceLink = t41[0].GetAttribute("href");
                    RightTermDefinition.SourceTitle = t4[0].Text();
                }
            }

            #region MyRegion
            //var quickAnswer = doc.Result.GetElementsByClassName("Fact Fact_flexSize_no");
            //if (quickAnswer.Length == 0)
            //    return;

            //StackPanel stackPanel = new StackPanel();

            //var elems = quickAnswer[0].Children;
            //for (int i = 0; i < elems.Length; i++)
            //{
            //    var elem = elems[i];

            //    if (elem.ClassList.Contains("Fact-Summarize") ||
            //        elem.ClassList.Contains("Fact-ECTitle") ||
            //        elem.ClassList.Contains("Fact-Answer"))
            //    {
            //        if (!string.IsNullOrEmpty(elem.Text()))
            //        {
            //            TextBlock mainTextBlock = new TextBlock()
            //            {
            //                Style = HeaderTextBlockStyle,
            //                Text = elem.Text()
            //            };
            //            stackPanel.Children.Add(mainTextBlock);

            //            Text += elem.Text() + "\n";
            //        }
            //    }
            //    else if (elem.ClassList.Contains("Fact-ECFragment_marker_number"))
            //    {
            //        FrameworkElement element = ListItemPresenter(elem);
            //        ChechMarginElement(element, stackPanel);
            //        stackPanel.Children.Add(element);
            //    }
            //    else if (elem.ClassList.Contains("Fact-ECFragment") ||
            //             elem.ClassList.Contains("Fact-Description"))
            //    {
            //        if (elem.Children.Length > 0)
            //        {
            //            var list = elem.GetElementsByClassName("List");
            //            if (list.Length > 0)
            //            {
            //                var childrenOfList = list[0].Children;
            //                for (int j = 0; j < childrenOfList.Length; j++)
            //                {
            //                    if (childrenOfList[j].ClassList.Contains("List-Item"))
            //                    {
            //                        FrameworkElement element = ListItemPresenter(childrenOfList[j]);
            //                        ChechMarginElement(element, stackPanel);
            //                        stackPanel.Children.Add(element);
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                TextBlock mainTextBlock = new TextBlock()
            //                {
            //                    Text = elem.Text(),
            //                    Style = TextBlockStyles.CommonTextBlockStyle
            //                };
            //                ChechMarginElement(mainTextBlock, stackPanel);
            //                stackPanel.Children.Add(mainTextBlock);
            //            }
            //        }
            //        else
            //        {
            //            TextBlock mainTextBlock = new TextBlock()
            //            {
            //                Text = elem.Text(),
            //                Style = TextBlockStyles.CommonTextBlockStyle
            //            };
            //            ChechMarginElement(mainTextBlock, stackPanel);
            //            stackPanel.Children.Add(mainTextBlock);
            //        }

            //        Text += elem.Text() + "\n";
            //    }
            //}
            //AnswerPresenter = stackPanel;
            //ParsedEvent?.Invoke(); 
            #endregion
        }

        //private void ChechMarginElement(FrameworkElement element, Panel parent)
        //{
        //    if (parent.Children.Count > 0)
        //    {
        //        foreach (var child in parent.Children)
        //        {
        //            try
        //            {
        //                if ((child as FrameworkElement).Style == HeaderTextBlockStyle)
        //                {
        //                    element.Margin = new Thickness(10, 4, 10, 4);
        //                    break;
        //                }
        //                else
        //                {
        //                    element.Margin = new Thickness(0, 6, 0, 0);
        //                    break;
        //                }
        //            }
        //            catch
        //            {
        //                continue;
        //            }
        //        }
        //    }
        //}

        //private FrameworkElement ListItemPresenter(IElement element)
        //{
        //    TextBlock mainTextBlock = new TextBlock()
        //    {
        //        Text = element.Text(),
        //        Style = TextBlockStyles.CommonTextBlockStyle
        //    };
        //    Text += element.Text() + "\n";

        //    var dataPositionAttr = element.Attributes["data-position"];
        //    if (dataPositionAttr != null)
        //    {
        //        TextBlock positionTextBlock = new TextBlock()
        //        {
        //            Text = dataPositionAttr.Value,
        //            Style = TextBlockStyles.CommonTextBlockStyle,
        //            Margin = new Thickness(0, 0, 5, 0)
        //        };
        //        Grid.SetColumn(positionTextBlock, 0);

        //        mainTextBlock.Margin = new Thickness(5, 0, 0, 0);
        //        Grid.SetColumn(mainTextBlock, 1);

        //        ColumnDefinition positionColumnDefinition = new ColumnDefinition()
        //        { Width = new GridLength(1, GridUnitType.Auto) };

        //        ColumnDefinition mainColumnDefinition = new ColumnDefinition()
        //        { Width = new GridLength(1, GridUnitType.Star) };

        //        Grid grid = new Grid();
        //        grid.ColumnDefinitions.Add(positionColumnDefinition);
        //        grid.ColumnDefinitions.Add(mainColumnDefinition);
        //        grid.Children.Add(positionTextBlock);
        //        grid.Children.Add(mainTextBlock);
        //        return grid;
        //    }
        //    else return mainTextBlock;
        //}
    }
}
