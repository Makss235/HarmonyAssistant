using HarmonyAssistant.Core.Skills.Base;
using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle;
using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.Data.DataSerialize;
using HarmonyAssistant.UI.Widgets.ParserWidgets;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace HarmonyAssistant.Core.Skills.InternetSkills
{
    public class InternetSkill : Skill
    {
        public OCS Search(ICS iCS)
        {
            OCS oCS = new OCS();
            oCS.Result = false;
            oCS.AnswerString = NegativeAnswer(iCS);

            foreach (var requestString in iCS.WordsObject.TriggerWords)
            {
                int indexOfSearch = iCS.ProcessedText.IndexOf(requestString);
                if (indexOfSearch == -1) continue;
                try
                {
                    char[] charArraySearch = iCS.ProcessedText.ToCharArray()
                    [(indexOfSearch + requestString.Length + 1)..iCS.ProcessedText.Length];

                    string url = "https://yandex.ru/search/?text=" + string.Join("", charArraySearch);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        QAGoogleParser parseYandex = new QAGoogleParser(url);
                        parseYandex.Parse();

                        QAGoogleWidget qAYandexWidget = new QAGoogleWidget(parseYandex);

                        oCS.AnswerPresenter = qAYandexWidget.Content;
                        oCS.AnswerString = qAYandexWidget.Text;
                    });

                    if (oCS.AnswerPresenter == null)
                    {
                        Process.Start(new ProcessStartInfo("https://www.google.ru/search?q=" + 
                            string.Join("", charArraySearch)) { UseShellExecute = true });
                        oCS.AnswerString = PositiveAnswer(iCS);
                    }
                    oCS.Result = true;
                    return oCS;
                }
                catch
                {
                    oCS.Result = false;
                    oCS.AnswerString = NegativeAnswer(iCS);
                    return oCS;
                }
            }
            return oCS;
        }

        public OCS SearchText(ICS iCS)
        {
            OCS oCS = new OCS();
            string url = "https://www.google.ru/search?q=" + string.Join("", iCS.CleanText);

            Application.Current.Dispatcher.Invoke(() =>
            {
                QAGoogleParser parseYandex = new QAGoogleParser(url);
                parseYandex.Parse();

                QAGoogleWidget qAYandexWidget = new QAGoogleWidget(parseYandex);

                oCS.AnswerPresenter = qAYandexWidget.Content;
                oCS.AnswerString = qAYandexWidget.Text;
            });

            oCS.Result = true;
            return oCS;
        }

        public OCS OpenSite(ICS iCS)
        {
            List<bool> results = new List<bool>();

            for (int i = 0; i < SitesData.GetInstance().JsonObject.Count; i++)
            {
                var siteObject = SitesData.GetInstance().JsonObject[i];
                for (int j = 0; j < siteObject.Names.Count; j++)
                {
                    FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                    var fuzzy = fuzzyString.FuzzySentence(siteObject.Names[j], iCS.CleanText);
                    if (fuzzy.Length == siteObject.Names[j].Length)
                    {
                        try
                        {
                            Process.Start(new ProcessStartInfo(siteObject.Path) 
                            { UseShellExecute = true });
                            results.Add(true);
                            break;
                        }
                        catch
                        {
                            results.Add(false);
                            break;
                        }
                    }
                }
            }
            OCS oCS = new OCS();
            if (results.Contains(true))
            {
                oCS.Result = true;
                oCS.AnswerString = PositiveAnswer(iCS);
            }
            else
            {
                oCS.Result = false;
                oCS.AnswerString = NegativeAnswer(iCS);
            }
            return oCS;
        }
    }
}
