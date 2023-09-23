using HarmonyAssistant.Core.Base;
using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle;
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
            QAGoogleParser googleParser = new QAGoogleParser("https://www.google.ru/search?q=%D1%87%D1%82%D0%BE+%D1%82%D0%B0%D0%BA%D0%BE%D0%B5+%D0%B4%D0%BE%D0%BC&newwindow=1&sca_esv=567392669&sxsrf=AM9HkKm1juJ8K8emuZTu-ANt-_haozyGLQ%3A1695329813266&source=hp&ei=Fa4MZYnsDevFwPAPluqi6AQ&iflsig=AO6bgOgAAAAAZQy8JZcnGV5z4qTEP9D2luY2zEmGhzUy&oq=%D1%87%D1%82%D0%BE+&gs_lp=Egdnd3Mtd2l6IgfRh9GC0L4gKgIIATIHECMYigUYJzIHECMYigUYJzIHECMYigUYJzIEEAAYAzILEAAYigUYsQMYgwEyCxAAGIoFGLEDGIMBMgUQABiABDILEAAYigUYsQMYgwEyCxAAGIAEGLEDGMkDMggQABiABBiSA0ikH1CaCFioD3ABeACQAQCYAbsCoAHbBKoBBzIuMS4wLjG4AQHIAQD4AQGoAgrCAgcQIxjqAhgnwgIHEAAYigUYQ8ICBRAuGIAEwgILEAAYgAQYsQMYgwE&sclient=gws-wiz");
            googleParser.Parse();

            SettingsData.GetInstance().Initialize();
            WordsData.GetInstance().Initialize();
            TriggerWordsData.GetInstance().Initialize();
            DictionaryWordsData.GetInstance().Initialize();
            GreetingWordsData.GetInstance().Initialize();
            ProgramsData.GetInstance().Initialize();
            SitesData.GetInstance().Initialize();

            StateManager.GetInstance();

            STT sTT = STT.GetInstance();
            sTT.Start();

            CCSTTF cCSTTF = CCSTTF.GetInstance();
            cCSTTF.Start();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            StateManager.GetInstance().InitCheckStates();
            SkillManager.GetInstance();

            Application application = new Application();
            application.MainWindow = mainWindow;
            application.Run();
        }
    }
}
