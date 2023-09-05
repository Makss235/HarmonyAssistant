using AngleSharp;
using System;
using System.Net.Http;
using System.Windows.Controls;
using System.Windows;

namespace HarmonyAssistant.Core.Skills.InternetSkill.QuickAnswer
{
    public class ParserYandex
    {
        public event Action ParseIsEnded;
        
        public string Text { get; set; }
        public object ParsePresenter { get; set; }

        private string url;

        public ParserYandex(string url)
        {
            this.url = url;

            p();
        }

        private async void p()
        {
            HttpClient client = new HttpClient();
            string page = await client.GetStringAsync(url);

            var context = BrowsingContext.New(Configuration.Default);
            var doc = await context.OpenAsync(req => req.Content(page));

            var quickAnswer = doc.GetElementsByClassName(
                "serp-item has-branding has-branding__fact has-branding_" +
                "_show-hint serp-item_card serp-item_card-extra-shadow " +
                "serp-item_card-no-padding-bottom");
            if (quickAnswer.Length != 0)
            {
                quickAnswer = quickAnswer[0].GetElementsByClassName(
                    "Fact Fact_flexSize_no Fact_answerGap_l");
                var elems = quickAnswer[0].Children;

                for (int i = 0; i < elems.Length; i++)
                {
                    if (elems[i].ClassName != "Fact-Source" &&
                        elems[i].ClassName != "ExtraActions " +
                        "Typo Typo_text_s Typo_line_m Fact-Footer")
                    {
                        var lll = elems[i].QuerySelectorAll("div");
                        //if (lll.Length != 0)
                        {
                            Text += elems[i].TextContent;
                        }
                    }
                }
            }
            ParseIsEnded?.Invoke();
        }
    }
}
