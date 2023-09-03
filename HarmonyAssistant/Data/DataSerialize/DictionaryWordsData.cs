using HarmonyAssistant.Data.DataSerialize.Base;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class DictionaryWordsData : DataSerialize<List<List<string>>>
    {
        public DictionaryWordsData(string language) : 
            base(language, "DictionaryWords.json") { }
    }
}
