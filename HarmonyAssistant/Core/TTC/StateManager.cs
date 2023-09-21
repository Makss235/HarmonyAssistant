using HarmonyAssistant.Core.STT;
using HarmonyAssistant.Core.TTC.States;
using HarmonyAssistant.Core.TTC.States.Base;
using HarmonyAssistant.Data.DataSerialize;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarmonyAssistant.Core.TTC
{
    public class StateManager
    {
        public event Action<string> SpeechStateVerifiedEvent;

        private Dictionary<Type, IState> StatesMap;

        #region CurrentState

        private IState _CurrentState;
        public IState CurrentState
        {
            get => _CurrentState;
            set
            {
                if (_CurrentState == value) return;
                if (_CurrentState != null)
                    _CurrentState.Exit();

                _CurrentState = value;
                _CurrentState.Enter();
            }
        }

        #endregion
        
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
            InitStates();
            CurrentState = GetState<OpenedState>();
        }

        public IState GetState<T>() where T : IState
        {
            return StatesMap[typeof(T)];
        }

        public void InitCheckStates()
        {
            CCSTTF cCSTTF = CCSTTF.GetInstance();
            cCSTTF.FileChanged += (text) =>
            {
                if (!string.IsNullOrEmpty(text))
                    CheckStates(text);
            };
        }

        private void CheckStates(string text)
        {
            var greetingWords = GreetingWordsData.GetInstance().JsonObject;
            var triggerWords = TriggerWordsData.GetInstance().JsonObject;

            if (CurrentState == GetState<SayButtonPressedState>())
                SpeechStateVerifiedEvent?.Invoke(text);
            else if (CurrentState == GetState<OpenedState>())
            {
                for (int i = 0; i < triggerWords.Count; i++)
                {
                    if (DeleteExcessWords(ref text, triggerWords[i])) break;
                    if (i == triggerWords.Count - 1) return;
                }
                SpeechStateVerifiedEvent?.Invoke(text);
            }
            else if (CurrentState == GetState<HiddenState>())
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

            if (fuzzyString.FuzzySentence(words, text).Length == words.Length)
            {
                text = fuzzyString.ReplaceFuzzyWord(words, text);
                var g = text.ToList();
                var j = words.ToList();

                int index = text.IndexOf(words);
                if (index == -1) return false;

                g.RemoveRange(index, j.Count);
                text = string.Join("", g).Trim();
                return true;
            }
            return false;
        }

        private void InitStates()
        {
            StatesMap = new Dictionary<Type, IState>
            {
                { typeof(HiddenState), new HiddenState() },
                { typeof(OpenedState), new OpenedState() },
                { typeof(SayButtonPressedState), new SayButtonPressedState() }
            };
        }
    }
}
