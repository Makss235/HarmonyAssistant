using HarmonyAssistant.Core.Base;

namespace HarmonyAssistant.Core.STT
{
    public class CCSTTF : CatchingChangesFile
    {
        #region Singleton

        private static CCSTTF instance;
        public static CCSTTF GetInstance()
        {
            if (instance == null)
                instance = new CCSTTF();
            return instance;
        }

        #endregion

        private CCSTTF() : base("stt\\STTF.txt") { }
    }
}
