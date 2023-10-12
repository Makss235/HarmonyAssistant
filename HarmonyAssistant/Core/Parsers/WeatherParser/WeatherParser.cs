using AngleSharp.Dom;
using HarmonyAssistant.Core.Parsers.Base;
using System.Collections.Generic;
using System.Linq;

namespace HarmonyAssistant.Core.Parsers.WeatherParser
{
    /// <summary>Класс для парсинга сайта погоды.</summary>
    public class WeatherParser : Parser
    {
        /// <summary>Данные о погоде.</summary>
        public WeatherData WeatherData { get; set; }

        /// <summary>Инициализирует новый объект класса WeatherParser.</summary>
        public WeatherParser()
        {
            WeatherData = new WeatherData();
        }

        public override void Parse()
        {
            // Получение ссылки на страницу с погодой текущего города.
            var mainPageDoc = GetDocumentFromString(GetStringFromUrl("https://world-weather.ru/"));
            var CurrentCityElement = mainPageDoc.GetElementsByClassName(
                "loc-now-t-city")[0].GetElementsByTagName("a")[0];
            string? urlToCurrentCity = CurrentCityElement.GetAttribute("href");

            // Документ страницы текущего города.
            var currentCityDoc = GetDocumentFromString(GetStringFromUrl("https:" + urlToCurrentCity));
            var contentLeftElement = currentCityDoc.GetElementById("content-left");
            // Элемент с описанием текущей погоды.
            var weatherNowElement = contentLeftElement.GetElementsByClassName("weather-now horizon")[0];

            #region Инициализация полей с кратким описанием погоды.

            // Элемент с кратким описанием текущей погоды.
            var weatherNowInfoElement = weatherNowElement.GetElementsByClassName("weather-now-info")[0];

            WeatherData.CurrentCity = CurrentCityElement.Text();
            WeatherData.LastUpdateDate = weatherNowInfoElement.GetElementsByTagName("p")[0].
                GetElementsByTagName("b")[0].Text();

            WeatherData.CurrentTemperature = weatherNowInfoElement.GetElementsByTagName("div").
                Where(p => p.GetAttribute("id") == "weather-now-number").First().Text();

            // Элемент, содержащий определение иконки.
            var weatherNowIconElement = weatherNowInfoElement.GetElementsByTagName("span").
                Where(p => Equals(p.GetAttribute("id"), "weather-now-icon"));

            WeatherData.AtmosphericPhenomena = weatherNowIconElement.First().GetAttribute("title");

            // Список классов элемента, содержащего определение иконки.
            var weatherNowIconElementСlassNames = weatherNowIconElement.First().ClassName?.Split(" ");
            if (weatherNowIconElementСlassNames.Length >= 3)
                WeatherData.ClassNamePhenomena = weatherNowIconElementСlassNames[1];
            // Название класса по умолчанию, если условие не выполнено.
            else WeatherData.ClassNamePhenomena = "d000";

            WeatherData.CurrentTemperatureWater = weatherNowInfoElement.GetElementsByTagName("a").
                Where(p => p.ClassName.Contains("tooltip water-now")).First().Text();

            #endregion

            #region Инициализация полей с подробным описанием погоды.

            // Элемент с подробным описанием текущей погоды.
            var weathetNowDescriptionElement = weatherNowElement.
                GetElementsByTagName("div").Where(p => Equals(
                p.GetAttribute("id"), "weather-now-description")).First();
            
            // Элементы с названием свойства.
            var dtElements = weathetNowDescriptionElement.GetElementsByTagName("dt");
            // Эелементы со значениями свойств.
            var ddElements = weathetNowDescriptionElement.GetElementsByTagName("dd");

            WeatherData.FeelingString = dtElements[0].Text();
            WeatherData.FeelingTemperature = ddElements[0].Text();

            WeatherData.PressureString = dtElements[1].Text();
            WeatherData.Pressure = ddElements[1].Text();

            WeatherData.HumidityString = dtElements[2].Text();
            WeatherData.Humidity = ddElements[2].Text();

            WeatherData.WindString = dtElements[3].Text();
            WeatherData.WindSpeed = ddElements[3].Text().Trim();

            // Попытка проинициализировать свойства (может возникнуть ошибка из-за того,
            // что элементов с индексами больше 3 нет - сайт может их не выдать).
            try
            {
                WeatherData.WindGustsString = dtElements[4].Text();
                WeatherData.WindGustsSpeed = ddElements[4].Text();

                WeatherData.CloudCoverString = dtElements[5].Text();
                WeatherData.CloudCover = ddElements[5].Text();

                WeatherData.VisibilityString = dtElements[6].Text();
                WeatherData.VisibilityDistance = ddElements[6].Text();
            }
            // Инициализация свойств по умолчанию в случае ошибки.
            catch
            {
                WeatherData.WindGustsString = "Порывы ветра";
                WeatherData.WindGustsSpeed = "Неизвестно";

                WeatherData.CloudCoverString = "Облачность";
                WeatherData.CloudCover = "Неизвестно";

                WeatherData.VisibilityString = "Видимость";
                WeatherData.VisibilityDistance = "Неизвестно";
            }

            #endregion

            #region Инициализация полей с данными о солнце.

            // Элементы для инициализации свойств солнца.
            var sunElements = weatherNowElement.GetElementsByClassName("sun")[0];
            var lies = sunElements.GetElementsByTagName("li");

            WeatherData.SunTime = lies[0].Text();
            WeatherData.DayLongitude = lies[1].Text();
            WeatherData.MoonPhaseString = lies[2].GetElementsByTagName("span")[0].Text();
            WeatherData.MoonPhase = lies[2].GetElementsByTagName("em")[0].Text();

            #endregion

            // Инициализация поля с описанием погоды в виде небольшого текста.
            WeatherData.DescriptionWeather = contentLeftElement.GetElementsByClassName(
                "description-weather")[0].GetElementsByClassName("dw-into")[0].Text();

            #region Инициализация дней.

            // Элементы с описанием погоды отдельного дня.
            var tabElements = contentLeftElement.GetElementsByClassName("tabs tabs-db").
                Where(p => Equals(p.GetAttribute("id"), "vertical_tabs")).
                First().GetElementsByClassName("tab-w").ToList();

            // Элементы с описанием погоды каждой четверти отдельного дня.
            var paneElements = contentLeftElement.GetElementsByTagName("table").
                Where(p => Equals(p.GetAttribute("class"), "weather-today")).ToList();

            // Инициализация заголовков таблицы, обозначающих названия характеристик.
            var headerElement = paneElements[0].GetElementsByTagName("td").ToList();
            List<string> headerStrings = new List<string>();
            for (int i = 1; i < headerElement.Count; i++)
                headerStrings.Add(headerElement[i].Text());

            // Инициализация данных 7-ми дней.
            WeatherData.WeatherDays = new List<WeatherDataDay>();
            for (int i = 0; i < tabElements.Count; i++)
            {
                #region Инициализация полей одного дня.

                WeatherDataDay weatherDataDay = new WeatherDataDay();

                weatherDataDay.DayOfWeek = tabElements[i].GetElementsByClassName("day-week")[0].Text();
                weatherDataDay.NumberMonth = tabElements[i].GetElementsByClassName("numbers-month")[0].Text();
                weatherDataDay.Month = tabElements[i].GetElementsByClassName("month")[0].Text();

                // Элемент, содержащий определение иконки.
                var weatherIconElement = tabElements[i].GetElementsByClassName("icon-weather")[0];

                weatherDataDay.AtmosphericPhenomena = weatherIconElement.GetAttribute("title");

                // Список классов элемента, содержащего определение иконки.
                var weatherIconElementСlassNames = weatherIconElement.ClassName?.Split(" ");
                if (weatherIconElementСlassNames.Length >= 4)
                    weatherDataDay.ClassNamePhenomena = weatherIconElementСlassNames[2];
                // Название класса по умолчанию, если условие не выполнено.
                else weatherDataDay.ClassNamePhenomena = "d000";

                weatherDataDay.DayTemperature = tabElements[i].GetElementsByClassName("day-temperature")[0].Text();
                weatherDataDay.NightTemperature = tabElements[i].GetElementsByClassName("night-temperature")[0].Text();
                weatherDataDay.Header = headerStrings;

                #endregion

                weatherDataDay.QuatersOfDay = new List<WeatherDataQuaterOfDay>();
                var quatersOfDayElements = paneElements[i + 1].GetElementsByTagName("tr").ToList();
                for (int j = 0; j < quatersOfDayElements.Count; j++)
                {
                    #region Инициализация полей одной четверти дня.

                    WeatherDataQuaterOfDay quaterOfDay = new WeatherDataQuaterOfDay();

                    quaterOfDay.QuaterOfDayName = quatersOfDayElements[j].
                        GetElementsByClassName("weather-day")[0].Text();

                    // Элемент, содержащий определение средней температуры и иконки.
                    var weatherTemperatureElement = quatersOfDayElements[j].GetElementsByClassName("weather-temperature")[0];

                    quaterOfDay.Temperature = weatherTemperatureElement.Text();

                    // Элемент, содержащий определение иконки.
                    var weatherIconQuaterOfDayElement = weatherTemperatureElement.GetElementsByTagName("div")[0];

                    quaterOfDay.AtmosphericPhenomena = weatherIconQuaterOfDayElement.GetAttribute("title");

                    // Список классов элемента, содержащего определение иконки.
                    var weatherIconQuaterOfDayElementСlassNames = weatherIconQuaterOfDayElement.ClassName?.Split(" ");
                    if (weatherIconQuaterOfDayElementСlassNames.Length >= 3)
                        quaterOfDay.ClassNamePhenomena = weatherIconQuaterOfDayElementСlassNames[1];
                    // Название класса по умолчанию, если условие не выполнено.
                    else quaterOfDay.ClassNamePhenomena = "d000";

                    quaterOfDay.FeelingTemperature = quatersOfDayElements[j].
                        GetElementsByClassName("weather-feeling")[0].Text();

                    quaterOfDay.ProbabilityOfPrecipitation = quatersOfDayElements[j].
                        GetElementsByClassName("weather-probability")[0].Text();

                    quaterOfDay.Pressure = quatersOfDayElements[j].
                        GetElementsByClassName("weather-pressure")[0].Text();

                    quaterOfDay.WindSpeed = quatersOfDayElements[j].
                        GetElementsByClassName("weather-wind")[0].Text();

                    quaterOfDay.Humidity = quatersOfDayElements[j].
                        GetElementsByClassName("weather-humidity")[0].Text();

                    // Добавление данных о четверти дня в данные отдельного дня.
                    weatherDataDay.QuatersOfDay.Add(quaterOfDay);

                    #endregion
                }

                // Добавление данных отдельного дня.
                WeatherData.WeatherDays.Add(weatherDataDay);
            }

            #endregion
        }
    }
}