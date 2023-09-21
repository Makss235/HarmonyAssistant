using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle.DataParse.Base;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle.DataParse
{
    public class QuickAnswerText : IReferenceAnswer
    {
        public string AnswerTitle { get; set; }
        public string Body { get; set; }
        public string Date { get; set; }
        public LinkGElement LinkGElement { get; set; }
    }
}
