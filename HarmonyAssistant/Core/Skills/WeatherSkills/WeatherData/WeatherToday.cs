using System.Collections.Generic;

namespace HarmonyAssistant.Core.Skills.WeatherSkills.WeatherData
{
    public class WeatherToday
    {
        public string CurrentCity { get; set; }
        public string LastUpdateDate { get; set; }
        public string AtmosphericPhenomena { get; set; }
        public string CurrentTemperature { get; set; }
        public string CurrentTemperatureWater { get; set; }

        public string FeelingString { get; set; }
        public string FeelingTemperature { get; set; }
        public string PressureString { get; set; }
        public string Pressure_mmHg { get; set; }
        public string HumidityString { get; set; }
        public string HumidityPercent { get; set; }
        public string WindString { get; set; }
        public string WindSpeed { get; set; }
        public string GustsOfWindString { get; set; }
        public string GustsOfWindSpeed { get; set; }
        public string CloudCoverString { get; set; }
        public string CloudCoverPercent { get; set; }
        public string VisibilityString { get; set; }
        public string VisibilityDistance { get; set; }

        public string SunTime { get; set; }
        public string LongitudeOfDay { get; set; }
        public string PhaseOfMoonString { get; set; }
        public string PhaseOfMoon { get; set; }

        public string DescriptionWeather { get; set; }
        public List<WeatherDay> WeatherDays { get; set; }
    }
}
