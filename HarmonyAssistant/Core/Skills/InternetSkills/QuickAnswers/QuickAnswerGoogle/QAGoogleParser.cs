using AngleSharp;
using AngleSharp.Dom;
using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.Base;
using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle.DataParse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle
{
    public class QAGoogleParser : QAParser
    {
        public override event Action ParsedEvent;

        public QAGoogleParser(string url) : base(url) { }

        public override void Parse()
        {
            var doc = Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent",
                        "Mozilla/5.0 (Windows NT 11.0; Win64; x64; rv:23.0) Gecko/20100101 Firefox/77.0");
                string page = await client.GetStringAsync(url);

                var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
                var doc = await context.OpenAsync(req => req.Content(page));
                return doc;
            });

            #region QuickAnswers

            var elems = doc.Result.GetElementsByClassName("V3FYCf");
            if (elems.Length != 0)
            {
                var elem = elems[0];

                #region Reference

                LinkGElement link = new LinkGElement();
                var g = elem.GetElementsByClassName("g");
                if (g.Length != 0)
                {
                    var t3 = g[0].GetElementsByClassName("yuRUbf");
                    if (t3.Length != 0)
                    {
                        var a = t3[0].GetElementsByTagName("a");
                        if (a.Length != 0)
                        {
                            link.SourceLink = a[0].GetAttribute("href");

                            var t4 = a[0].GetElementsByClassName("LC20lb MBeuO DKV0Md");
                            if (t4.Length != 0) link.ArticleTitle = t4[0].Text();

                            var t5 = a[0].GetElementsByClassName("XNo5Ab");
                            if (t5.Length != 0) link.IconSource = t5[0].GetAttribute("src");

                            var t6 = a[0].GetElementsByClassName("VuuXrf");
                            if (t6.Length != 0) link.SiteName = t6[0].Text();

                            var t7 = a[0].GetElementsByClassName("qLRx3b tjvcx GvPZzd cHaqb");
                            if (t7.Length != 0) link.ArticlePathString = t7[0].Text();
                        }
                    }
                }

                #endregion

                #region Text

                var e1 = elem.GetElementsByClassName("LGOjhe");
                if (e1.Length != 0)
                {
                    QuickAnswerText quickAnswerText = new QuickAnswerText();

                    var t2 = elem.GetElementsByClassName("hgKElc");
                    if (t2.Length != 0) quickAnswerText.Body = t2[0].Text();

                    var t23 = elem.GetElementsByClassName("kX21rb ZYHQ7e");
                    if (t23.Length != 0) quickAnswerText.Date = t23[0].Text();

                    quickAnswerText.LinkGElement = link;
                }

                #endregion

                #region List

                var e2 = elem.GetElementsByClassName("di3YZe");
                if (e2.Length != 0)
                {
                    QuickAnswerList quickAnswerList = new QuickAnswerList();

                    var ol = e2[0].GetElementsByClassName("X5LH0c");
                    if (ol.Length != 0)
                    {
                        quickAnswerList.QuickAnswerElements = new List<string>();
                        foreach (var item in ol[0].Children)
                            quickAnswerList.QuickAnswerElements.Add(item.Text());
                        quickAnswerList.LinkGElement = link;
                    }
                }

                #endregion
            }

            #endregion

            #region Definition

            var elems1 = doc.Result.GetElementsByClassName("VpH2eb vmod");
            if (elems1.Length != 0)
            {
                TermDefinition termDefinition = new TermDefinition();
                var elem = elems1[0];

                var t1 = elem.GetElementsByClassName("LWPArc");
                if (t1.Length != 0) termDefinition.Term = t1[0].Text();

                var t2 = elem.GetElementsByClassName("YrbPuc");
                if (t2.Length != 0) termDefinition.Gender = t2[0].Text();

                var tlist = elem.GetElementsByClassName("eQJLDd");
                if (tlist.Length != 0)
                {
                    termDefinition.TermDefinitionElements = new List<TermDefinitionElement>();

                    foreach (var t in tlist[0].Children)
                    {
                        var elemoflist = t.GetElementsByClassName("wHYlTd sY7ric");
                        if (elemoflist.Length != 0)
                        {
                            TermDefinitionElement termDefinitionElement = new();

                            termDefinitionElement.NumberInOrder = elemoflist[0].
                                GetElementsByTagName("div")[0].Text();

                            var t3 = t.GetElementsByClassName("mQo3nc aztjNb hsL7ld");
                            if (t3.Length != 0) termDefinitionElement.ValueType = t3[0].Text();

                            var t5 = t.GetElementsByTagName("div").Where(p =>
                            Equals(p.GetAttribute("data-dobid"), "dfn")).ToArray();
                            if (t5.Length != 0) termDefinitionElement.Definition = t5[0].Text();

                            var t6 = t.GetElementsByClassName("ZYHQ7e");
                            if (t6.Length != 0) termDefinitionElement.Example = t6[0].Text();

                            termDefinition.TermDefinitionElements.Add(termDefinitionElement);
                        }
                    }
                }
            }

            #endregion

            #region RightDefinition

            var elems2 = doc.Result.GetElementsByClassName("kp-wholepage kp-wholepage-osrp HSryR EyBRub");
            if (elems2.Length != 0)
            {
                RightTermDefinition rightTermDefinition = new RightTermDefinition();
                var elem = elems2[0];

                var t1 = elem.GetElementsByClassName("qrShPb pXs6bb PZPZlf q8U8x aTI8gc");
                if (t1.Length != 0) rightTermDefinition.Term = t1[0].Text();
                
                var t12 = elem.GetElementsByClassName("wwUB2c PZPZlf");
                if (t12.Length != 0) rightTermDefinition.SubTitle = t12[0].Text();

                var t2 = elem.GetElementsByClassName("yxjZuf");
                if (t2.Length != 0)
                {
                    rightTermDefinition.Definitions = new List<RightTermDefinitionElement>();
                    foreach (var item in t2[0].Children)
                    {
                        if (!Equals(item.GetAttribute("class"), "wDYxhc")) continue;
                        RightTermDefinitionElement rightTermDefinitionElement = new RightTermDefinitionElement();

                        var t3 = item.GetElementsByClassName("kno-rdesc");
                        if (t3.Length != 0)
                        {
                            var t4 = t3[0].Children.Where(p => Equals(p.TagName.ToLower(), "span")).ToArray();
                            if (t4.Length == 1)
                                rightTermDefinitionElement.Definition = t4[0].Text();
                            else if (t4.Length == 2)
                            {
                                rightTermDefinitionElement.Definition = t4[0].Text();
                                var t5 = t4[1].GetElementsByTagName("a");
                                if (t5.Length != 0)
                                {
                                    rightTermDefinitionElement.SourceLink = t5[0].GetAttribute("href");
                                    rightTermDefinitionElement.SourceTitle = t5[0].Text();
                                }
                            }
                        }
                        rightTermDefinition.Definitions.Add(rightTermDefinitionElement);
                    }
                }
            }

            #endregion
        }
    }
}
