using HarmonyAssistant.Core.Parsers.WeatherParser;
using HarmonyAssistant.Core.Skills.Base;
using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.UI.Widgets.WeatherWidgets;

namespace HarmonyAssistant.Core.Skills.WeatherSkills
{
    public class WeatherSkill : Skill
    {
        public OCS WhatWeather(ICS iCS)
        {
            OCS oCS = new OCS()
            {
                AnswerString = NegativeAnswer(iCS),
                Result = false
            };

            WeatherParser parser = new WeatherParser();
            parser.Parse();

            ShortWeatherWidget shortWeatherWidget = 
                new ShortWeatherWidget(parser.WeatherData);
            
            oCS.AnswerString = PositiveAnswer(iCS);
            oCS.Result = true;
            oCS.AnswerPresenter = shortWeatherWidget;
            return oCS;
        }
    }
}
