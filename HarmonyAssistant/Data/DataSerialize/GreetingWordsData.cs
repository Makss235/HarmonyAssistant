using HarmonyAssistant.Data.DataSerialize.Base;
using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize
{
    public class GreetingWordsData : DataSerialize<List<string>>
    {
        public GreetingWordsData(string language) : base(language, "GreetingWords.json") { }
    }
}
