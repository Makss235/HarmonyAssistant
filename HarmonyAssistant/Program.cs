using HarmonyAssistant.Core.Base;
using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle;
using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerYandex;
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
            QAYandexParser googleParser = new QAYandexParser("https://ya.ru/search/?text=%D1%87%D1%82%D0%BE+%D0%BF%D0%BE%D1%8F%D0%B2%D0%B8%D0%BB%D0%BE%D1%81%D1%8C+%D1%80%D0%B0%D0%BD%D1%8C%D1%88%D0%B5+%D0%BA%D1%83%D1%80%D0%B8%D1%86%D0%B0+%D0%B8%D0%BB%D0%B8+%D1%8F%D0%B9%D1%86%D0%BE&lr=120612&search_source=yaru_desktop_common&search_domain=yaru&src=suggest_B");
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
