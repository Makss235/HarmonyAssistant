using System.Diagnostics;

namespace HarmonyAssistant.Core.STT
{
    public class STT
    {
        #region Singleton

        private static STT instance;
        public static STT GetInstance()
        {
            if (instance == null)
                instance = new STT();
            return instance;
        }

        #endregion

        public Process SPSProcess { get; private set; }

        public void Start()
        {
            SPSProcess = Process.Start(new ProcessStartInfo("stt.exe")
            { UseShellExecute = true });
        }
        public void Stop()
        {
            Process[] stts = Process.GetProcessesByName("stt");
            if (stts.Length > 0)
                for (int i = 0; i < stts.Length; i++)
                    stts[i].Kill();
        }
    }
}
