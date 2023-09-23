using HarmonyAssistant.Core.Base;
using HarmonyAssistant.Core.Skills.InternetSkills;
using HarmonyAssistant.Core.TTC.States;
using HarmonyAssistant.Data.DataSerialize;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HarmonyAssistant.Core.TTC
{
    public class SkillManager
    {
        public event Action<string> AnswerStringChanged;
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
            StateManager.GetInstance().SpeechStateVerifiedEvent += DefineSkills;
            //AnswerStringChanged += (s) => TTS.TTS.GetInstance().Speak(s);
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

        public async void DefineSkills(string cleanText)
        {
            var sm = StateManager.GetInstance();
            if (sm.CurrentState == sm.GetState<SayButtonPressedState>())
                sm.CurrentState = sm.GetState<OpenedState>();

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
                OCS oCS = internetSkill.SearchText(new ICS(processedText, cleanText));
                if (oCS.AnswerPresenter == null)
                {
                    if (!string.IsNullOrEmpty(oCS.AnswerString))
                        AnswerPresenterChanged?.Invoke(oCS.AnswerString);
                    else
                    {
                        File.WriteAllText("IGPTF.txt", cleanText);

                        CatchingChangesFile catchingChangesFile = new CatchingChangesFile("OGPTF.txt");
                        catchingChangesFile.FileChanged += (s) =>
                        {
                            AnswerPresenterChanged?.Invoke(s);
                            AnswerStringChanged?.Invoke(s);
                            catchingChangesFile.Stop();
                        };
                        catchingChangesFile.Start();

                        Process.Start("gpt.exe");
                        return;
                    }
                }
                else AnswerPresenterChanged?.Invoke(oCS.AnswerPresenter);
                AnswerStringChanged?.Invoke(oCS.AnswerString);
            }

            List<OCS> ocses = new List<OCS>();
            for (int i = 0; i < wordsObjectsList.Count; i++)
            {
                ICS iCS = new ICS(processedText, cleanText, wordsObjectsList[i]);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ocses.Add(CallingSkill(iCS));
                });
            }

            if (ocses.Count == 1)
            {
                if (ocses[0].AnswerPresenter != null)
                    AnswerPresenterChanged?.Invoke(ocses[0].AnswerPresenter);
                AnswerStringChanged?.Invoke(ocses[0].AnswerString);
            }
            else if (ocses.Count > 1)
            {
                List<bool> results = new List<bool>();
                foreach (OCS oCS in ocses) results.Add(oCS.Result);
                if (results.Contains(true))
                {
                    int count = 0;
                    OCS oCSTrue = new OCS();
                    for (int i = 0; i < ocses.Count; i++)
                    {
                        if (ocses[i].Result)
                        {
                            oCSTrue = ocses[i];
                            count++;
                        }
                    }
                    if (count == 1)
                        AnswerStringChanged?.Invoke(oCSTrue.AnswerString);
                    else AnswerStringChanged?.Invoke("Выполнено");
                }
                else AnswerStringChanged?.Invoke("Не выполнено");
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
