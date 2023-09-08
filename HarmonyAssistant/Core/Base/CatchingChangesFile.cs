using System;
using System.IO;
using System.Threading;

namespace HarmonyAssistant.Core.Base
{
    public class CatchingChangesFile
    {
        public Thread CCFThread { get; set; }
        public event Action<string> FileChanged;

        #region TextFile

        private string _TextFile = "";

        public string TextFile
        {
            get => _TextFile;
            set
            {
                _TextFile = value;
                FileChanged?.Invoke(TextFile);
            }
        }

        #endregion

        private string fileName;
        private bool canClose = false;

        public CatchingChangesFile(string fileName)
        {
            this.fileName = fileName;
            CCFThread = new Thread(() => CatchChangeDateFile());
        }

        public void Start() => CCFThread.Start();
        public void Stop() => canClose = true;

        private void CatchChangeDateFile()
        {
            DateTime currentWritingTime = File.GetLastWriteTime(fileName);
            DateTime previousWritingTime = File.GetLastWriteTime(fileName);

            while (!canClose)
            {
                string text = "";
                currentWritingTime = File.GetLastWriteTime(fileName);
                if (currentWritingTime == previousWritingTime)
                {
                    Thread.Sleep(100);
                    continue;
                }
                else if (currentWritingTime > previousWritingTime)
                {
                    text = OpenFile(fileName);
                    previousWritingTime = currentWritingTime;
                }

                if (Equals(text, String.Empty) ||
                    Equals(text, null)) continue;
                else TextFile = text;
                Thread.Sleep(30);
            }
        }

        private string OpenFile(string STTF)
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
