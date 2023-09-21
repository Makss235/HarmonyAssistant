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
            QAGoogleParser googleParser = new QAGoogleParser("https://www.google.ru/search?q=%D0%B7%D0%B0%D1%87%D0%B5%D0%BC+%D0%BD%D1%83%D0%B6%D0%BD%D0%B0+%D1%88%D0%BA%D0%BE%D0%BB%D0%B0&newwindow=1&sca_esv=564194868&source=hp&ei=wB3-ZLe6A42bseMP2KWRkAk&iflsig=AD69kcEAAAAAZP4r0Ob7AVYjtW1ksVXTnYkVLpPqDz8G&ved=0ahUKEwi3ms-L6KCBAxWNTWwGHdhSBJIQ4dUDCAk&uact=5&oq=%D0%B7%D0%B0%D1%87%D0%B5%D0%BC+%D0%BD%D1%83%D0%B6%D0%BD%D0%B0+%D1%88%D0%BA%D0%BE%D0%BB%D0%B0&gs_lp=Egdnd3Mtd2l6IiDQt9Cw0YfQtdC8INC90YPQttC90LAg0YjQutC-0LvQsDIFEAAYgAQyBhAAGBYYHjIGEAAYFhgeMgYQABgWGB4yBhAAGBYYHjIIEAAYFhgeGA8yBhAAGBYYHjIGEAAYFhgeMgYQABgWGB4yBhAAGBYYHkiYGlC9Fli9FnACeACQAQCYAT6gAT6qAQExuAEDyAEA-AEC-AEBqAIKwgIaEAAYigUY5QIY5QIY6gIYtAIYigMYtwMY1AM&sclient=gws-wiz");
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
