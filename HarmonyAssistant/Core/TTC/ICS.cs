using HarmonyAssistant.Data.DataSerialize.SerializeObjects;

namespace HarmonyAssistant.Core.TTC
{
    public struct ICS
    {
        public string ProcessedText { get; set; }
        public string CleanText { get; set; }
        public WordsObject WordsObject { get; set; }

        public ICS(string processedText, string cleanText, WordsObject wordsObject = null)
        {
            ProcessedText = processedText;
            CleanText = cleanText;
            WordsObject = wordsObject;
        }
    }
}
