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
            WordsData wordsData = new WordsData("RU");
            wordsData.Deserialize();

            TriggerWordsData triggerWordsData = 
                new TriggerWordsData("RU");
            triggerWordsData.Deserialize();

            GreetingWordsData greetingWordsData = 
                new GreetingWordsData("RU");
            greetingWordsData.Deserialize();

            DictionaryWordsData dictionaryWordsData = 
                new DictionaryWordsData("RU");
            dictionaryWordsData.Deserialize();

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
