using HarmonyAssistant.Core.STT;
using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.Data.DataSerialize;
using HarmonyAssistant.UI.Windows.MainWindow;
using System.Windows;

namespace HarmonyAssistant.Core
{
    internal class HarmonyApplication
    {
        internal static HarmonyApplication Current { get; private set; }

        private STT.STT sTT;
        private CCSTTF cCSTTF;
        private MainWindow mainWindow;
        private Application application;

        internal HarmonyApplication()
        {
            if (Current == null)
                Current = this;

            Initialize();
        }

        internal void Run() => application.Run();

        private void Initialize()
        {
            InitializeData();
            StateManager.GetInstance();
            InitializeSTT();
            InitializeMainWindow();
            InitializeTTC();
            InitializeApplication();
        }

        private void InitializeData()
        {
            SettingsData.GetInstance().Initialize();
            WordsData.GetInstance().Initialize();
            TriggerWordsData.GetInstance().Initialize();
            DictionaryWordsData.GetInstance().Initialize();
            GreetingWordsData.GetInstance().Initialize();
            ProgramsData.GetInstance().Initialize();
            SitesData.GetInstance().Initialize();
        }

        private void InitializeSTT()
        {
            sTT = STT.STT.GetInstance();
            sTT.Start();

            cCSTTF = CCSTTF.GetInstance();
            cCSTTF.Start();
        }

        private void InitializeMainWindow()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void InitializeTTC()
        {
            StateManager.GetInstance().InitCheckStates();
            SkillManager.GetInstance();
        }

        private void InitializeApplication()
        {
            application = new Application();
            application.MainWindow = mainWindow == null ? 
                new MainWindow() : mainWindow;
        }
    }
}
