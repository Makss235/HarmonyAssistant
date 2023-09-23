using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle.DataParse.Base;
using System.Collections.Generic;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle.DataParse
{
    public class RightTermDefinition : IQuickAnswer
    {
        public string Term { get; set; }
        public string SubTitle { get; set; }
        public List<RightTermDefinitionElement> Definitions { get; set; }
    }

    public class RightTermDefinitionElement
    {
        public string Definition { get; set; }
        public string SourceLink { get; set; }
        public string SourceTitle { get; set; }
    }
}
