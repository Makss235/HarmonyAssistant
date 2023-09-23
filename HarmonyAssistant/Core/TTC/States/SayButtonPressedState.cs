using HarmonyAssistant.Core.TTC.States.Base;
using System;
using System.Timers;

namespace HarmonyAssistant.Core.TTC.States
{
    public class SayButtonPressedState : IState
    {
        public event Action StateEnter;
        public event Action StateExit;

        private Timer aTimer;

        public void Enter()
        {
            StateEnter?.Invoke();

            aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10000;
            aTimer.Enabled = true;
        }

        public void Exit()
        {
            StateExit?.Invoke();

            aTimer?.Stop();
        }

        private void OnTimedEvent(object? sender, ElapsedEventArgs e)
        {
            var sm = StateManager.GetInstance();
            sm.CurrentState = sm.GetState<OpenedState>();
        }
    }
}
