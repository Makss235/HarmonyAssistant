using HarmonyAssistant.Data.DataSerialize.Base;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class DictionaryWordsData : BaseDataSerialize<List<List<string>>>
    {
        public override List<List<string>> JsonObject 
        { 
            get => base.JsonObject; 
            set => base.JsonObject = value; 
        }

        #region Singleton

        private static DictionaryWordsData instance;

        public static DictionaryWordsData GetInstance()
        {
            if (instance == null)
                instance = new DictionaryWordsData();
            return instance;
        }

        #endregion

        private DictionaryWordsData() : base() { }

        public override void Initialize(
            string language = "RU", 
            string fileName = "DictionaryWords.json")
        {
            base.Initialize(language, fileName);
            Deserialize();
        }
    }
}
