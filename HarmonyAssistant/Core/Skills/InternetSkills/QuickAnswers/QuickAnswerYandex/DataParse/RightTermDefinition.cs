using System.Collections.Generic;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerYandex.DataParse
{
    public class RightTermDefinition
    {
        public string Term { get; set; }
        public string SubTitle { get; set; }
        public List<string> DefinitionParagraphes { get; set; }
        public string SourceLink { get; set; }
        public string SourceTitle { get; set; }
    }
}
