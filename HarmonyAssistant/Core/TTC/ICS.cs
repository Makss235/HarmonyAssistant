using HarmonyAssistant.Data.DataSerialize.SerilizeObjects;

namespace HarmonyAssistant.Core.TTC
{
    public struct ICS
    {
        public string Text { get; set; }
        public WordsObject WordsObject { get; set; }

        public ICS(string text, WordsObject wordsObject)
        {
            Text = text;
            WordsObject = wordsObject;
        }
    }
}
