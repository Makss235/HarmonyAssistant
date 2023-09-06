using HarmonyAssistant.Core.STT;
using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.Data.DataSerialize;
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
            WordsData.GetInstance().Initialize();
            TriggerWordsData.GetInstance().Initialize();
            DictionaryWordsData.GetInstance().Initialize();
            GreetingWordsData.GetInstance().Initialize();
            ProgramsData.GetInstance().Initialize();
            SitesData.GetInstance().Initialize();

            STT sTT = STT.GetInstance();
            sTT.Start();

            CCSTTF cCSTTF = CCSTTF.GetInstance();
            //cCSTTF.ChangingTextSTTFEvent += (s) => MessageBox.Show(s);
            cCSTTF.Start();

            StateManager.GetInstance();
            SkillManager.GetInstance();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Application application = new Application();
            application.MainWindow = mainWindow;
            application.Run();
        }
    }
}
