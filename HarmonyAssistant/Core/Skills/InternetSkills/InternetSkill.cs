using HarmonyAssistant.Core.Skills.Base;
using HarmonyAssistant.Core.Skills.InternetSkill.QuickAnswer;
using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.Data.DataSerialize;
using System.Collections.Generic;
using System.Threading.Tasks;
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
                        YandexParser parseYandex = new YandexParser(url);
                        parseYandex.Parse();

                        oCS.AnswerPresenter = parseYandex.AnswerPresenter;
                        oCS.AnswerString = parseYandex.Text;
                    });

                    if (oCS.AnswerPresenter == null)
                    {
                        System.Diagnostics.Process.Start(
                            @"C:\Program Files\Internet Explorer\iexplore.exe",
                            "https://yandex.ru/search/?text=" + string.Join("", charArraySearch));
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
            string url = "https://yandex.ru/search/?text=" + string.Join("", iCS.CleanText);

            Application.Current.Dispatcher.Invoke(() =>
            {
                YandexParser parseYandex = new YandexParser(url);
                parseYandex.Parse();

                oCS.AnswerPresenter = parseYandex.AnswerPresenter;
                oCS.AnswerString = parseYandex.Text;
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
                            System.Diagnostics.Process.Start(
                                @"C:\Program Files\Internet Explorer\iexplore.exe",
                                siteObject.Url);
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
