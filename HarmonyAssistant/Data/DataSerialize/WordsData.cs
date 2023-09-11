using HarmonyAssistant.Data.DataSerialize.Base;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class WordsData : BaseDataSerialize<List<WordsObject>>
    {
        #region Singleton

        private static WordsData instance;

        public static WordsData GetInstance()
        {
            if (instance == null)
                instance = new WordsData();
            return instance;
        }

        #endregion

        private WordsData() : base() { }

        public override void Initialize(
            string language = "RU",
            string fileName = "Words.json")
        {
            base.Initialize(fileName, language);
            Deserialize();
        }
    }
}
