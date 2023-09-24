using System.Collections.Generic;

namespace HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerYandex.DataParse
{
    public class QuickDefinition
    {
        public string FactAnswer { get; set; }
        public List<FactFragment> FactFragments { get; set; }
        public string SitePath { get; set; }
        public string SiteName { get; set; }
        public string SiteType { get; set; }
        public string ArticleName { get; set; }
    }
}
