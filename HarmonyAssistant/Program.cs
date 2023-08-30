using HarmonyAssistant.Core.STT;
using HarmonyAssistant.UI.Windows.MainWindow;
using System;
using System.Windows;

namespace HarmonyAssistant
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            STT sTT = STT.GetInstance();
            sTT.Start();

            CCSTTF cCSTTF = CCSTTF.GetInstance();
            cCSTTF.ChangingTextSTTFEvent += (s) => MessageBox.Show(s);
            cCSTTF.Start();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Application application = new Application();
            application.MainWindow = mainWindow;
            application.Run();
        }
    }
}
