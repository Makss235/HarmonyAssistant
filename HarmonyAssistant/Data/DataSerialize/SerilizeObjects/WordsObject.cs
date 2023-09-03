using System.Collections.Generic;

namespace HarmonyAssistant.Data.DataSerialize.SerilizeObjects
{
    public class WordsObject
    {
        public List<string> TriggerWords { get; set; }
        public Parameters Parameters { get; set; }
        public Answers Answers { get; set; }
    }

    public class Parameters
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public List<string> Args { get; set; }
    }

    public class Answers
    {
        public List<string> Positive { get; set; }
        public List<string> Negative { get; set; }
    }
}
