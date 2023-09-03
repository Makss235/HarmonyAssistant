using HarmonyAssistant.Data.DataSerialize.Base;
using HarmonyAssistant.Data.DataSerialize.SerilizeObjects;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class WordsData : DataSerialize<List<WordsObject>>
    {
        public WordsData(string language) : base(language, "Words.json") { }
    }
}
