using System.Collections.Generic;

namespace HarmonyAssistant.Core.Parsers.WeatherParser
{
#pragma warning disable CS8618
    /// <summary>Данные о погоде.</summary>
    public class WeatherData
    {
        /// <summary>Текущий город.</summary>
        public string CurrentCity;
        /// <summary>Последнее время обновления данных.</summary>
        public string LastUpdateDate;
        /// <summary>Атмосферная характеристика (ясно, пасмурно и т.д.).</summary>
        public string AtmosphericPhenomena;
        /// <summary>Название класса CSS, соответствующее атмосферной характеристики.</summary>
        public string ClassNamePhenomena;
        /// <summary>Текущая темпетатура воздуха.</summary>
        public string CurrentTemperature;
        /// <summary>Текущая темпетатура воды.</summary>
        public string CurrentTemperatureWater;

        /// <summary>Строка: "Ощущается".</summary>
        public string FeelingString;
        /// <summary>Ощущаяемая температура в градусах Цельсия.</summary>
        public string FeelingTemperature;
        /// <summary>Строка: "Давление".</summary>
        public string PressureString;
        /// <summary>Давление в миллиметрах ртутного столба.</summary>
        public string Pressure;
        /// <summary>Строка: "Влажность".</summary>
        public string HumidityString;
        /// <summary>Влажность воздуха в процентах.</summary>
        public string Humidity;
        /// <summary>Строка: "Ветер".</summary>
        public string WindString;
        /// <summary>Средняя скорость ветра в метрах в секунду, направление.</summary>
        public string WindSpeed;
        /// <summary>Строка: "Порывы ветра".</summary>
        public string WindGustsString;
        /// <summary>Порывы ветра в метрах в секунду.</summary>
        public string WindGustsSpeed;
        /// <summary>Строка: "Облачность".</summary>
        public string CloudCoverString;
        /// <summary>Облачность в процентах.</summary>
        public string CloudCover;
        /// <summary>Строка: "Видимость".</summary>
        public string VisibilityString;
        /// <summary>Видимость в километрах.</summary>
        public string VisibilityDistance;

        /// <summary>Данные о восходе и закате: "Восход: ... Закат: ...".</summary>
        public string SunTime;
        /// <summary>Данные о долготе дня: "Долгота дня: ...".</summary>
        public string DayLongitude;
        /// <summary>Строка: "Фаза луны:".</summary>
        public string MoonPhaseString;
        /// <summary>Фаза луны.</summary>
        public string MoonPhase;

        /// <summary>Описание погоды.</summary>
        public string DescriptionWeather;
        /// <summary>Данные погоды 7-ми дней.</summary>
        public List<WeatherDataDay> WeatherDays;
    }

    /// <summary>Данные о погоде одного дня.</summary>
    public class WeatherDataDay
    {
        /// <summary>День недели.</summary>
        public string DayOfWeek;
        /// <summary>Число в месяце.</summary>
        public string NumberMonth;
        /// <summary>Месяц.</summary>
        public string Month;
        /// <summary>Атмосферная характеристика (ясно, пасмурно и т.д.).</summary>
        public string AtmosphericPhenomena;
        /// <summary>Название класса CSS, соответствующее атмосферной характеристики.</summary>
        public string ClassNamePhenomena;
        /// <summary>Температура днем в градусах Цельсия.</summary>
        public string DayTemperature;
        /// <summary>Температура ночью в градусах Цельсия.</summary>
        public string NightTemperature;

        /// <summary>Заголовки таблицы, обозначающие названия характеристик.</summary>
        public List<string> Header;
        /// <summary>Данные о каждой четверти данного дня.</summary>
        public List<WeatherDataQuaterOfDay> QuatersOfDay;
    }

    /// <summary>Данные о погоде четверти дня.</summary>
    public class WeatherDataQuaterOfDay
    {
        /// <summary>Название четверти дня.</summary>
        public string QuaterOfDayName;
        /// <summary>Атмосферная характеристика (ясно, пасмурно и т.д.).</summary>
        public string AtmosphericPhenomena;
        /// <summary>Название класса CSS, соответствующее атмосферной характеристики.</summary>
        public string ClassNamePhenomena;
        /// <summary>Средняя темпетатура в градусах Цельсия.</summary>
        public string Temperature;
        /// <summary>Ощущаемая температура в градусах Цельсия.</summary>
        public string FeelingTemperature;
        /// <summary>Вероятность осадков в процентах.</summary>
        public string ProbabilityOfPrecipitation;
        /// <summary>Давление в миллиметрах ртутного столба.</summary>
        public string Pressure;
        /// <summary>Средняя скорость ветра в метрах в секунду, направление.</summary>
        public string WindSpeed;
        /// <summary>Влажность воздуха в процентах.</summary>
        public string Humidity;
    }
}
