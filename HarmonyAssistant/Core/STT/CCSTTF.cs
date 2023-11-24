using HarmonyAssistant.Core.Base;

namespace HarmonyAssistant.Core.STT
{
    /// <summary>CCSTTF - Catching Changes Speech To Text File;
    /// Отслеживание изменений файла STT.</summary>
    public class CCSTTF : CatchingChangesFile
    {
        #region Singleton

        /// <summary>Ссылка на объект текущего класса.</summary>
        private static CCSTTF instance;

        /// <summary>Метод получения объекта текущего класса.</summary>
        /// <returns>Объект текущего класса.</returns>
        public static CCSTTF GetInstance()
        {
            if (instance == null)
                instance = new CCSTTF();
            return instance;
        }

        #endregion

        /// <summary>Инициализирует новый объект класса CCSTTF.</summary>
        private CCSTTF() : base("STTF.txt") { }
    }
}
