using HarmonyAssistant.Data.DataSerialize.Base;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class TriggerWordsData : DataSerialize<List<string>>
    {
        public TriggerWordsData(string language) : base(language, "TriggerWords.json") { }
    }
}
