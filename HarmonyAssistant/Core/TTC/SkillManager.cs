using HarmonyAssistant.Core.Skills.InternetSkills;
using HarmonyAssistant.Data.DataSerialize;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace HarmonyAssistant.Core.TTC
{
    public class SkillManager
    {
        public event Action<string> AnswerSpeakChanged;
        public event Action<object> AnswerPresenterChanged;

        private string namespaceSkills = "HarmonyAssistant.Core.Skills.";
        private string nameMethodCallingDefault = "Calling";

        #region Singleton

        private static SkillManager instance;

        public static SkillManager GetInstance()
        {
            if (instance == null)
                instance = new SkillManager();
            return instance;
        }

        #endregion

        private SkillManager()
        {
            StateManager stateManager = StateManager.GetInstance();
            stateManager.SpeechStateVerifiedEvent += DefineSkills;
        }

        private string NormalizeSentence(string text)
        {
            string[] textArray = text.Split(" ");
            for (int k = 0; k < textArray.Length; k++)
            {
                var victor = DictionaryWordsData.GetInstance().JsonObject;
                for (int i = 0; i < victor.Count; i++)
                {
                    for (int j = 1; j < victor[i].Count; j++)
                    {
                        FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                        var fuzzyResult = fuzzyString.FuzzyWord(victor[i][j], textArray[k]);
                        if (fuzzyString.FuzzyWord(victor[i][j], textArray[k]))
                        {
                            textArray[k] = victor[i][0];
                            break;
                        }
                    }
                }
            }
            return string.Join(" ", textArray);
        }

        private void DefineSkills(string cleanText)
        {
            string processedText = NormalizeSentence(cleanText);

            List<WordsObject> wordsObjectsList = new List<WordsObject>();
            for (int i = 0; i < WordsData.GetInstance().JsonObject.Count; i++)
            {
                for (int j = 0; j < WordsData.GetInstance().JsonObject[i].TriggerWords.Count; j++)
                {
                    var triggerWord = WordsData.GetInstance().JsonObject[i].TriggerWords[j];
                    FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                    var fuzzy = fuzzyString.FuzzySentence(triggerWord, processedText);

                    if (Equals(fuzzy, triggerWord))
                    {
                        processedText = fuzzyString.ReplaceFuzzyWord(
                            triggerWord, processedText);
                        wordsObjectsList.Add(WordsData.GetInstance().JsonObject[i]);
                        break;
                    }
                }
            }

            if (wordsObjectsList.Count == 0)
            {
                InternetSkill internetSkill = new InternetSkill();
                var f = internetSkill.SearchText(new ICS(processedText, cleanText));
                MessageBox.Show(f.AnswerString);
            }

            List<OCS> ocses = new List<OCS>();
            for (int i = 0; i < wordsObjectsList.Count; i++)
            {
                ICS iCS = new ICS(processedText, cleanText, wordsObjectsList[i]);
                ocses.Add(CallingSkill(iCS));
            }

            if (ocses.Count == 1)
            {
                MessageBox.Show(ocses[0].AnswerString);
            }
            else if (ocses.Count > 1)
            {
                List<bool> results = new List<bool>();
                foreach (OCS oCS in ocses) results.Add(oCS.Result);
                if (results.Contains(true))
                {
                    int count = 0;
                    OCS index = new OCS();
                    for (int i = 0; i < ocses.Count; i++)
                    {
                        if (ocses[i].Result)
                        {
                            index = ocses[i];
                            count++;
                        }
                    }
                    if (count == 1)
                        MessageBox.Show(index.AnswerString);
                    else  MessageBox.Show("Выполнено");
                }
                else MessageBox.Show("Не выполнено");
            }
        }

        private OCS CallingSkill(ICS iCS)
        {
            string className = iCS.WordsObject.Parameters.ClassName;
            Type type = Type.GetType(namespaceSkills +
                className + "Skills." + className + "Skill");
            object instance = Activator.CreateInstance(type);

            if (iCS.WordsObject.Parameters.MethodName == null)
                iCS.WordsObject.Parameters.MethodName = nameMethodCallingDefault;
            try
            {
                var methodInfo = type.GetMethod(iCS.WordsObject.Parameters.MethodName);
                return (OCS)methodInfo.Invoke(instance, new object[] { iCS });
            }
            catch
            {
                return new OCS() { Result = false };
            }
        }
    }
}
