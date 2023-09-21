using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle.DataParse.Base;
using System.Collections.Generic;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle.DataParse
{
    public class QuickAnswerList : IReferenceAnswer
    {
        public List<string> QuickAnswerElements { get; set; }
        public LinkGElement LinkGElement { get; set; }
    }
}
