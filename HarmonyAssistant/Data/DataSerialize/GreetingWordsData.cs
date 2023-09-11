using HarmonyAssistant.Data.DataSerialize.Base;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class GreetingWordsData : BaseDataSerialize<List<string>>
    {
        public override List<string> JsonObject 
        { 
            get => base.JsonObject; 
            set => base.JsonObject = value; 
        }

        #region Singleton

        private static GreetingWordsData instance;

        public static GreetingWordsData GetInstance()
        {
            if (instance == null)
                instance = new GreetingWordsData();
            return instance;
        }

        #endregion

        private GreetingWordsData() : base() { }

        public override void Initialize(
            string language = "RU",
            string fileName = "GreetingWords.json")
        {
            base.Initialize(fileName, language);
            Deserialize();
        }
    }
}
