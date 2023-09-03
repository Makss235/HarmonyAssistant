using System.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using HarmonyAssistant.Data.DataSerialize.SerilizeObjects;
using HarmonyAssistant.Data.DataSerialize;

namespace HarmonyAssistant.Core.TTC
{
    public class SkillManager
    {
        private string namespaceSkills = "HarmonyAssistant.Core.Skills.";
        private string nameMethodCallingDefault = "Calling";

        public event Action<string> AnswerSpeakChanged;
        public event Action<FrameworkElement> AnswerPresenterChanged;

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
            stateManager.SpeechStateVerifiedEvent += NormalizeSentence;
        }

        private void NormalizeSentence(string text)
        {
            string[] textArray = text.Split(" ");
            for (int k = 0; k < textArray.Length; k++)
            {
                var victor = DictionaryWordsData.JsonObject;
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
            text = string.Join(" ", textArray);
            DefineSkills(text);
        }

        private void DefineSkills(string text)
        {
            Thread.Sleep(10);
            List<WordsObject> wordsObjectsList = new List<WordsObject>();
            for (int i = 0; i < WordsData.JsonObject.Count; i++)
            {
                for (int j = 0; j < WordsData.JsonObject[i].TriggerWords.Count; j++)
                {
                    var triggerWord = WordsData.JsonObject[i].TriggerWords[j];
                    FuzzyString.FuzzyString fuzzyString = new FuzzyString.FuzzyString();
                    var fuzzy = fuzzyString.FuzzySentence(triggerWord, text);

                    if (Equals(fuzzy, triggerWord))
                    {
                        text = fuzzyString.ReplaceFuzzyWord(triggerWord, text);
                        wordsObjectsList.Add(WordsData.JsonObject[i]);
                        break;
                    }
                }
            }

            for (int i = 0; i < wordsObjectsList.Count; i++)
            {
                CallingSkill(text, wordsObjectsList[i]);
            }
        }

        private OCS CallingSkill(string text, WordsObject wordsObject)
        {
            Type type = Type.GetType(namespaceSkills + wordsObject.Parameters.ClassName + "Skill");
            object instance = Activator.CreateInstance(type);

            if (wordsObject.Parameters.MethodName == null)
                wordsObject.Parameters.MethodName = nameMethodCallingDefault;

            ICS inputCallingSkills = new ICS(text, wordsObject);

            try
            {
                var methodInfo = type.GetMethod(wordsObject.Parameters.MethodName);
                return (OCS)methodInfo.Invoke(instance, new object[]
                { inputCallingSkills });
            }
            catch
            {
                return new OCS() { Result = false };
            }
        }
    }
}
