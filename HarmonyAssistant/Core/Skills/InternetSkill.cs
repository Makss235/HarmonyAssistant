using HarmonyAssistant.Core.Skills.Base;
using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.Data.DataSerialize;
using System;
using System.Collections.Generic;

namespace HarmonyAssistant.Core.Skills
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
                if (indexOfSearch != -1)
                {
                    try
                    {
                        char[] charArraySearch = iCS.ProcessedText.ToCharArray()
                        [(indexOfSearch + requestString.Length + 1)..iCS.ProcessedText.Length];
                        System.Diagnostics.Process.Start(
                            @"C:\Program Files\Internet Explorer\iexplore.exe",
                            "https://yandex.ru/search/?text=" + string.Join("", charArraySearch));

                        //Parce parce = new Parce();
                        //oCS.AnswerPresenter = parce;

                        oCS.Result = true;
                        oCS.AnswerString = PositiveAnswer(iCS);
                        return oCS;
                    }
                    catch
                    {
                        oCS.Result = false;
                        oCS.AnswerString = NegativeAnswer(iCS);
                        return oCS;
                    }
                }
            }
            return oCS;
        }

        public OCS OpenSite(ICS iCS)
        {
            List<bool> results = new List<bool>();

            for (int i = 0; i < SitesData.JsonObject.Count; i++)
            {
                var siteObject = SitesData.JsonObject[i];
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
                        }
                        catch
                        {
                            results.Add(false);
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
