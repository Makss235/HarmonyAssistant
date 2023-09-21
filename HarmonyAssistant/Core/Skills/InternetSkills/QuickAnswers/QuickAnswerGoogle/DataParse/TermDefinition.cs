using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle.DataParse.Base;
using System.Collections.Generic;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle.DataParse
{
    public class TermDefinition : IQuickAnswer
    {
        public string Term { get; set; }
        public string Gender { get; set; }
        public List<TermDefinitionElement> TermDefinitionElements { get; set; }
    }
}
