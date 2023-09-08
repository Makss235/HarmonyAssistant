using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace HarmonyAssistant.Core.Base
{
    public class StartPythonScript
    {
        public Process SPSProcess { get; private set; }

        private string exePythonPath;
        private string directory;
        private string script;

        public StartPythonScript(string directoryName, string script)
        {
            string currentDirectory = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);
            exePythonPath = Path.Combine(
                currentDirectory, "Python311\\python.exe");
            directory = Path.Combine(currentDirectory, directoryName);
            this.script = script;

            SPSProcess = new Process();
        }

        public void Start() { InitProcess(); SPSProcess.Start(); }
        public void Stop() => SPSProcess.Kill();

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
            SPSProcess.StartInfo = startInfo;
        }
    }
}
