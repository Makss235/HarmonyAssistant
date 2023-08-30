using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace HarmonyAssistant.Core.STT
{
    public class STT
    {
        private string exePythonPath;
        private string directory;
        private string script;

        #region Singleton
        private static STT instance;
        public static STT GetInstance()
        {
            if (instance == null)
                instance = new STT();
            return instance;
        }
        #endregion

        public Process STTProcess { get; private set; }

        private STT()
        {
            STTProcess = new Process();
            string currentDirectory = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            exePythonPath = Path.Combine(
                currentDirectory, "Python311\\python.exe");
            directory = Path.Combine(currentDirectory, "stt\\");
            script = "main.py";
        }

        public void Start() { InitProcess(); STTProcess.Start(); }
        public void Stop() => STTProcess.Kill(); 

        private void InitProcess()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = exePythonPath;

            startInfo.WorkingDirectory = directory;
            startInfo.Arguments = script;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
            STTProcess.StartInfo = startInfo;
        }
    }
}
