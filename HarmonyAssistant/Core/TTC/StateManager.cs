using FuzzyString;
using HarmonyAssistant.Core.STT;
using HarmonyAssistant.Data.DataSerialize;
using System;

namespace HarmonyAssistant.Core.TTC
{
    public enum AppSpeechStates
    {
        /// <summary>Программа находится в трее</summary>
        Hided,
        /// <summary>Программа открыта на панели задач</summary>
        Opened,
        /// <summary>Нажата кнопка "говорить"</summary>
        SayButtonPressed
    }

    public class StateManager
    {
        public event Action<AppSpeechStates> SpeechStateChangedEvent;
        public event Action<string> SpeechStateVerifiedEvent;

        private AppSpeechStates _CurrentSpeechState = AppSpeechStates.SayButtonPressed;
        public AppSpeechStates CurrentSpeechState
        {
            get => _CurrentSpeechState;
            set
            {
                _CurrentSpeechState = value;
                SpeechStateChangedEvent?.Invoke(_CurrentSpeechState);
            }
        }

        #region Singleton

        private static StateManager instance;

        public static StateManager GetInstance()
        {
            if (instance == null)
                instance = new StateManager();
            return instance;
        }

        #endregion

        private StateManager()
        {
            CCSTTF cCSTTF = CCSTTF.GetInstance();
            cCSTTF.ChangingTextSTTFEvent += (text) =>
            {
                if (!string.IsNullOrEmpty(text))
                    CheckStates(text);
            };
        }

        private void CheckStates(string text)
        {
            var triggerWords = TriggerWordsData.JsonObject;
            var greetingWords = GreetingWordsData.JsonObject;

            if (CurrentSpeechState == AppSpeechStates.SayButtonPressed)
                SpeechStateVerifiedEvent?.Invoke(text);
            else if (CurrentSpeechState == AppSpeechStates.Opened)
            {
                for (int i = 0; i < triggerWords.Count; i++)
                {
                    var fuzzyString = new FuzzyString.FuzzyString();
                    if (fuzzyString.FuzzySentence(text, triggerWords[i]).Length
                        == triggerWords[i].Length)
                    {
                        SpeechStateVerifiedEvent?.Invoke(text);
                        break;
                    }
                }
            }
            else if (CurrentSpeechState == AppSpeechStates.Hided)
            {
                int quantity = 0;
                for (int i = 0; i < triggerWords.Count; i++)
                {
                    var fuzzyString = new FuzzyString.FuzzyString();
                    if (fuzzyString.FuzzySentence(text, triggerWords[i]).Length
                        == triggerWords[i].Length)
                    {
                        quantity += triggerWords[i].Split(' ').Length;
                        break;
                    }
                }
                for (int i = 0; i < greetingWords.Count; i++)
                {
                    var fuzzyString = new FuzzyString.FuzzyString();
                    if (fuzzyString.FuzzySentence(text, greetingWords[i]).Length
                        == greetingWords[i].Length)
                    {
                        quantity += greetingWords[i].Split(' ').Length;
                        break;
                    }
                }

                //if (quantity == textRequest.Split(' ').Length)
                //{
                //    dataSpeech.TextAnswer = "Я Вас внимательно слушаю";
                //    ServiceTTS.SpeechSynthesizer.SpeakAsync(dataSpeech.TextAnswer);
                //}
                //else
                SpeechStateVerifiedEvent?.Invoke(text);
            }
        }
    }
}
