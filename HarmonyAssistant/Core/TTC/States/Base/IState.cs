using System;

namespace HarmonyAssistant.Core.TTC.States.Base
{
    public interface IState
    {
        public event Action StateEnter; 
        public event Action StateExit; 

        public void Enter();
        public void Exit();
    }
}
