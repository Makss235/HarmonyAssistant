using HarmonyAssistant.Core.STT;
using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.Data.DataSerialize;
using HarmonyAssistant.UI.Windows;
using HarmonyAssistant.UI.Windows.MainWindow;
using System.Windows;

namespace HarmonyAssistant.Core
{
    /// <summary>Класс, содержация средства для инициализации 
    /// данных и компонентов (модулей) программы.</summary>
    internal class HarmonyApplication
    {
        /// <summary>Ссылка на текущий объект класса HarmonyApplication.</summary>
        internal static HarmonyApplication Current { get; private set; }

        /// <summary>Ссылка на объект класса STT.STT для инициализации модуля STT.</summary>
        private STT.STT sTT;
        /// <summary>Ссылка на объект класса CCSTTF для инициализации модуля CCSTTF.</summary>
        private CCSTTF cCSTTF;
        /// <summary>Ссылка на главное окно.</summary>
        private MainWindow mainWindow;
        /// <summary>Ссылка на объект класса Application.</summary>
        private Application application;

        /// <summary>Инициализирует новый объект класса HarmonyApplication.</summary>
        internal HarmonyApplication()
        {
            if (Current == null)
                Current = this;

            Initialize();
        }

        /// <summary>Запуск приложения.</summary>
        internal void Run() => application.Run();

        /// <summary>Инициализация данный и основных компонентов (модулей) программы.</summary>
        private void Initialize()
        {
            InitializeData();
            StateManager.GetInstance();
            InitializeSTT();
            InitializeMainWindow();
            InitializeTTC();
            InitializeApplication();
        }

        /// <summary>Инициализация (десериализация) данных.</summary>
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

        /// <summary>Инициализация модулей STT (распознавание голоса) и CCSTTF.</summary>
        private void InitializeSTT()
        {
            sTT = STT.STT.GetInstance();
            sTT.Start();

            cCSTTF = CCSTTF.GetInstance();
            cCSTTF.Start();
        }

        /// <summary>Инициализация главного окна программы.</summary>
        private void InitializeMainWindow()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
            //TestWindow testWindow = new TestWindow();
            //testWindow.Show();
        }

        /// <summary>Инициализация модуля TTC (распозавание команд).</summary>
        private void InitializeTTC()
        {
            StateManager.GetInstance().InitCheckStates();
            SkillManager.GetInstance();
        }

        /// <summary>Инициализация главной программы (Application).</summary>
        private void InitializeApplication()
        {
            application = new Application
            {
                MainWindow = mainWindow == null ?
                new MainWindow() : mainWindow
            };
        }
    }
}
