using AngleSharp;
using AngleSharp.Dom;
using HarmonyAssistant.Core.Skills.WeatherSkills.WeatherData;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HarmonyAssistant.Core.Skills.WeatherSkills
{
    public class WeatherParser
    {
        public WeatherToday WeatherToday { get; set; }

        public WeatherParser()
        {
            WeatherToday = new WeatherToday();
        }

        public void Parse()
        {
            var mainPageDoc = GetDocument("https://world-weather.ru/");
            var tagWithCurrentCity = mainPageDoc.GetElementsByClassName(
                "loc-now-t-city")[0].GetElementsByTagName("a")[0];
            var urlToCurrentCity = tagWithCurrentCity.GetAttribute("href");

            var docCurrentCity = GetDocument("https:" + urlToCurrentCity);
            var leftContent = docCurrentCity.GetElementById("content-left");
            var weatherNowHorizon = leftContent.GetElementsByClassName("weather-now horizon")[0];

            #region Weather Now Info

            var weatherNowInfo = weatherNowHorizon.GetElementsByClassName("weather-now-info")[0];

            WeatherToday.CurrentCity = tagWithCurrentCity.Text();
            WeatherToday.LastUpdateDate = weatherNowInfo.GetElementsByTagName("p")[0].
                GetElementsByTagName("b")[0].Text();
            WeatherToday.CurrentTemperature = weatherNowInfo.GetElementsByTagName("div").
                Where(p => p.GetAttribute("id") == "weather-now-number").First().Text();
            WeatherToday.AtmosphericPhenomena = weatherNowInfo.GetElementsByTagName("span").
                Where(p => Equals(p.GetAttribute("id"), "weather-now-icon")).
                First().GetAttribute("title");
            WeatherToday.CurrentTemperatureWater = weatherNowInfo.GetElementsByTagName("a").
                Where(p => p.ClassName.Contains("tooltip water-now")).First().Text();

            #endregion

            #region Weather Now Property

            var weathetNowDescription = weatherNowHorizon.
                GetElementsByTagName("div").Where(p => Equals(
                p.GetAttribute("id"), "weather-now-description")).First();
            //var dl = weathetNowDescription.GetElementsByTagName("dl")[0];
            var dt = weathetNowDescription.GetElementsByTagName("dt");
            var dd = weathetNowDescription.GetElementsByTagName("dd");

            WeatherToday.FeelingString = dt[0].Text();
            WeatherToday.FeelingTemperature = dd[0].Text();

            WeatherToday.PressureString = dt[1].Text();
            WeatherToday.Pressure_mmHg = dd[1].Text();

            WeatherToday.HumidityString = dt[2].Text();
            WeatherToday.HumidityPercent = dd[2].Text();

            WeatherToday.WindString = dt[3].Text();
            WeatherToday.WindSpeed = dd[3].Text().Trim();

            try
            {
                WeatherToday.GustsOfWindString = dt[4].Text();
                WeatherToday.GustsOfWindSpeed = dd[4].Text();

                WeatherToday.CloudCoverString = dt[5].Text();
                WeatherToday.CloudCoverPercent = dd[5].Text();

                WeatherToday.VisibilityString = dt[6].Text();
                WeatherToday.VisibilityDistance = dd[6].Text();
            }
            catch
            {
                WeatherToday.GustsOfWindString = "Порывы ветра";
                WeatherToday.GustsOfWindSpeed = "Неизвестно";

                WeatherToday.CloudCoverString = "Облачность";
                WeatherToday.CloudCoverPercent = "Неизвестно";

                WeatherToday.VisibilityString = "Видимость";
                WeatherToday.VisibilityDistance = "Неизвестно";
            }

            #endregion

            #region Sun

            var sun = weatherNowHorizon.GetElementsByClassName("sun")[0];
            var lies = sun.GetElementsByTagName("li");

            WeatherToday.SunTime = lies[0].Text();
            WeatherToday.LongitudeOfDay = lies[1].Text();
            WeatherToday.PhaseOfMoonString = lies[2].GetElementsByTagName("span")[0].Text();
            WeatherToday.PhaseOfMoon = lies[2].GetElementsByTagName("em")[0].Text();

            #endregion

            WeatherToday.DescriptionWeather = leftContent.GetElementsByClassName(
                "description-weather")[0].GetElementsByClassName("dw-into")[0].Text();

            #region Tables

            var tabs = leftContent.GetElementsByClassName("tabs tabs-db").
                Where(p => Equals(p.GetAttribute("id"), "vertical_tabs")).
                First().GetElementsByClassName("tab-w").ToList();
            var panes = leftContent.GetElementsByTagName("table").
                Where(p => Equals(p.GetAttribute("class"), "weather-today")).ToList();

            var header = panes[0].GetElementsByTagName("td").ToList();

            List<string> strings = new List<string>();
            for (int i = 1; i < header.Count; i++)
                strings.Add(header[i].Text());

            WeatherToday.WeatherDays = new List<WeatherDay>();
            for (int i = 0; i < tabs.Count; i++)
            {
                WeatherDay weatherDay = new WeatherDay();

                #region WeatherDay

                weatherDay.DayOfWeek = tabs[i].GetElementsByClassName("day-week")[0].Text();
                weatherDay.NumberMonth = tabs[i].GetElementsByClassName("numbers-month")[0].Text();
                weatherDay.Month = tabs[i].GetElementsByClassName("month")[0].Text();
                weatherDay.AtmosphericPhenomena = tabs[i].GetElementsByClassName(
                    "icon-weather")[0].GetAttribute("title");
                weatherDay.DayTemperature = tabs[i].GetElementsByClassName("day-temperature")[0].Text();
                weatherDay.NightTemperature = tabs[i].GetElementsByClassName("night-temperature")[0].Text();
                weatherDay.Header = strings;

                #endregion

                weatherDay.QuatersOfDay = new List<WeatherQuaterOfDay>();
                var currentTable = panes[i + 1].GetElementsByTagName("tr").ToList();
                for (int j = 0; j < currentTable.Count; j++)
                {
                    #region QuaterOfDay

                    WeatherQuaterOfDay quaterOfDay = new WeatherQuaterOfDay();

                    quaterOfDay.QuaterOfDayName = currentTable[j].
                        GetElementsByClassName("weather-day")[0].Text();

                    var g1 = currentTable[j].GetElementsByClassName("weather-temperature")[0];
                    quaterOfDay.Temperature = g1.Text();
                    quaterOfDay.AtmosphericPhenomena = g1.GetElementsByTagName(
                        "div")[0].GetAttribute("title");

                    quaterOfDay.FeelingTemperature = currentTable[j].
                        GetElementsByClassName("weather-feeling")[0].Text();

                    quaterOfDay.ProbabilityOfPrecipitation = currentTable[j].
                        GetElementsByClassName("weather-probability")[0].Text();

                    quaterOfDay.Pressure = currentTable[j].
                        GetElementsByClassName("weather-pressure")[0].Text();

                    quaterOfDay.WindSpeed = currentTable[j].
                        GetElementsByClassName("weather-wind")[0].Text();

                    quaterOfDay.AirHumidity = currentTable[j].
                        GetElementsByClassName("weather-humidity")[0].Text();

                    weatherDay.QuatersOfDay.Add(quaterOfDay);

                    #endregion
                }

                WeatherToday.WeatherDays.Add(weatherDay);
            }

            #endregion
        }

        private IDocument GetDocument(string url)
        {
            return Task.Run(async () =>
            {
                HttpClient client = new HttpClient();
                string page = await client.GetStringAsync(url);

                var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
                var doc = await context.OpenAsync(req => req.Content(page));
                return doc;
            }).Result;
        }
    }
}
