using HarmonyAssistant.Core.Parsers.WeatherParser;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Widgets.WeatherWidgets.Base
{
    public abstract class WeatherWidget : ContentControl
    {
        public WeatherData WeatherToday { get; set; }

        public WeatherWidget(WeatherData weatherToday)
        {
            WeatherToday = weatherToday;

            InitializeComponent();
        }

        protected abstract void InitializeComponent();
    }
}
