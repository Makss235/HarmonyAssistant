using HarmonyAssistant.Core.Skills.WeatherSkills.WeatherData;
using System;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Widgets.WeatherWidgets.Base
{
    public abstract class WeatherWidget : ContentControl
    {
        public WeatherToday WeatherToday { get; set; }

        public WeatherWidget(WeatherToday weatherToday)
        {
            WeatherToday = weatherToday;

            InitializeComponent();
        }

        protected abstract void InitializeComponent();
    }
}
