using HarmonyAssistant.Core.TTC.States.Base;
using System;

namespace HarmonyAssistant.Core.TTC.States
{
    public class OpenedState : IState
    {
        public event Action StateEnter;
        public event Action StateExit;

        public void Enter()
        {
            StateEnter?.Invoke();
        }

        public void Exit()
        {
            StateExit?.Invoke();
        }
    }
}
