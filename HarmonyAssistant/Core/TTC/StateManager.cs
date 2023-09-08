using HarmonyAssistant.Core.STT;
using HarmonyAssistant.Data.DataSerialize;
using System;
using System.Linq;

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
        public delegate void HH(string text);

        public event Action<AppSpeechStates> SpeechStateChangedEvent;
        public event HH SpeechStateVerifiedEvent;

        private AppSpeechStates _CurrentSpeechState = AppSpeechStates.Hided;
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
            var greetingWords = GreetingWordsData.GetInstance().JsonObject;
            var triggerWords = TriggerWordsData.GetInstance().JsonObject;

            if (CurrentSpeechState == AppSpeechStates.SayButtonPressed)
                SpeechStateVerifiedEvent?.Invoke(text);
            else if (CurrentSpeechState == AppSpeechStates.Opened)
            {
                for (int i = 0; i < triggerWords.Count; i++)
                {
                    if (DeleteExcessWords(ref text, triggerWords[i])) break;
                    if (i == triggerWords.Count - 1) return;
                }
                SpeechStateVerifiedEvent?.Invoke(text);
            }
            else if (CurrentSpeechState == AppSpeechStates.Hided)
            {
                for (int i = 0; i < greetingWords.Count; i++)
                {
                    if (DeleteExcessWords(ref text, greetingWords[i])) break;
                    if (i == greetingWords.Count - 1) return;
                }

                for (int i = 0; i < triggerWords.Count; i++)
                {
                    if (DeleteExcessWords(ref text, triggerWords[i])) break;
                    if (i == triggerWords.Count - 1) return;
                }
                if (!string.IsNullOrEmpty(text.Trim()))
                    SpeechStateVerifiedEvent?.Invoke(text);
            }
        }

        private bool DeleteExcessWords(ref string text, string words)
        {
            var fuzzyString = new FuzzyString.FuzzyString();
            if (fuzzyString.FuzzySentence(text, words).Length == words.Length)
            {
                text = fuzzyString.ReplaceFuzzyWord(words, text);
                var g = text.Split(" ").ToList();
                var j = words.Split(" ").ToList();
                g.RemoveRange(0, j.Count);
                text = string.Join(" ", g);
                return true;
            }
            return false;
        }
    }
}
