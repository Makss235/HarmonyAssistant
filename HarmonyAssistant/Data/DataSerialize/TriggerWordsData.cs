using HarmonyAssistant.Data.DataSerialize.Base;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class TriggerWordsData : BaseDataSerialize<List<string>>
    {
        public override List<string> JsonObject 
        { 
            get => base.JsonObject; 
            set => base.JsonObject = value; 
        }

        #region Singleton

        private static TriggerWordsData instance;

        public static TriggerWordsData GetInstance()
        {
            if (instance == null)
                instance = new TriggerWordsData();
            return instance;
        }

        #endregion

        private TriggerWordsData() : base() { }

        public override void Initialize(
            string language = "RU",
            string fileName = "TriggerWords.json")
        {
            base.Initialize(fileName, language);
            Deserialize();
        }
    }
}
