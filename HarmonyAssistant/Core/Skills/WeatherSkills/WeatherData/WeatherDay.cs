using System.Collections.Generic;

namespace HarmonyAssistant.Core.Skills.WeatherSkills.WeatherData
{
    public class WeatherDay
    {
        public string DayOfWeek { get; set; }
        public string NumberMonth { get; set; }
        public string Month { get; set; }
        public string AtmosphericPhenomena { get; set; }
        public string ClassPhenomena { get; set; }
        public string DayTemperature { get; set; }
        public string NightTemperature { get; set; }

        public List<string> Header { get; set; }
        public List<WeatherQuaterOfDay> QuatersOfDay { get; set; }
    }
}
