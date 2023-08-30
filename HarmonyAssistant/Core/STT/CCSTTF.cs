using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HarmonyAssistant.Core.STT
{
    /// <summary>
    /// CCSTTF - catching changes STT (speech to text) file
    /// </summary>
    public class CCSTTF
    {
        public Action<string> ChangingTextSTTFEvent;

        #region TextSTTF

        private string _TextSTTF = "";

        public string TextSTTF
        {
            get => _TextSTTF;
            set
            {
                _TextSTTF = value;
                ChangingTextSTTFEvent?.Invoke(TextSTTF);
            }
        }

        #endregion

        private string STTF;
        private Thread CCSTTF_Thread;
        private bool canClose = false;

        #region Singleton
        private static CCSTTF instance;
        public static CCSTTF GetInstance()
        {
            if (instance == null)
                instance = new CCSTTF();
            return instance;
        }
        #endregion

        private CCSTTF()
        {
            STTF = "stt\\STTF.txt";
            CCSTTF_Thread = new Thread(() => CChangeDateSTTF());
        }

        public void Start() => CCSTTF_Thread.Start();
        public void Stop() => canClose = true;

        private void CChangeDateSTTF()
        {
            DateTime currentWritingTime = File.GetLastWriteTime(STTF);
            DateTime previousWritingTime = File.GetLastWriteTime(STTF);

            while (!canClose)
            {
                string text = "";
                currentWritingTime = File.GetLastWriteTime(STTF);
                if (currentWritingTime == previousWritingTime)
                {
                    Thread.Sleep(100);
                    continue;
                }
                else if (currentWritingTime > previousWritingTime)
                {
                    text = OpenSTT(STTF);
                    previousWritingTime = currentWritingTime;
                }

                if (Equals(text, String.Empty) ||
                    Equals(text, null)) continue;
                else TextSTTF = text;
                Thread.Sleep(100);
            }
        }

        private string OpenSTT(string STTF)
        {
            while (!canClose)
            {
                try
                {
                    return File.ReadAllText(STTF);
                }
                catch (IOException)
                {
                    Thread.Sleep(1);
                    continue;
                }
            }
            return "";
        }
    }
}
