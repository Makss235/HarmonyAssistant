using HarmonyAssistant.Core.Base;
using HarmonyAssistant.Core.STT;
using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.Data.DataSerialize;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes;
using HarmonyAssistant.UI.Windows.MainWindow;
using System;
using System.Diagnostics;
using System.Windows;

namespace HarmonyAssistant
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            SettingsData.GetInstance().Initialize();
            WordsData.GetInstance().Initialize();
            TriggerWordsData.GetInstance().Initialize();
            DictionaryWordsData.GetInstance().Initialize();
            GreetingWordsData.GetInstance().Initialize();
            ProgramsData.GetInstance().Initialize();
            SitesData.GetInstance().Initialize();

            STT sTT = STT.GetInstance();
            sTT.Start();

            CCSTTF cCSTTF = CCSTTF.GetInstance();
            cCSTTF.Start();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            StateManager.GetInstance();
            SkillManager.GetInstance();

            Application application = new Application();
            application.MainWindow = mainWindow;
            application.Run();
        }
    }
}
