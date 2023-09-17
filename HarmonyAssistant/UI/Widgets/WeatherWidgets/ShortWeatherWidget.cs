using HarmonyAssistant.Core.Skills.WeatherSkills.WeatherData;
using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Widgets.WeatherWidgets.Base;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Widgets.WeatherWidgets
{
    public class ShortWeatherWidget : WeatherWidget
    {
        public ShortWeatherWidget(WeatherToday weatherToday) : base(weatherToday) { }

        protected override void InitializeComponent()
        {
            int index = 0;
            DateTime dateTime = DateTime.Now;
            if (dateTime.Hour >= 4 && dateTime.Hour < 10)
                index = 1;
            else if (dateTime.Hour >= 10 && dateTime.Hour < 16)
                index = 2;
            else if (dateTime.Hour >= 16 && dateTime.Hour < 22)
                index = 3;
            else if (dateTime.Hour >= 22 || dateTime.Hour < 4)
                index = 0;

            var probability = WeatherToday.WeatherDays[0].QuatersOfDay[index].ProbabilityOfPrecipitation;

            Label label = new Label()
            {
                Content = new Image()
                {
                    Source = new BitmapImage(
                    new Uri("pack://application:,,,/Data/Resources/Images/Weather/mountain.png",
                    UriKind.RelativeOrAbsolute))
                },
                Width = 100,
                Height = 100,
                Margin = new Thickness(-7, -10, 0, 0)
            };
            Grid.SetColumn(label, 0);
            Grid.SetRow(label, 0);

            TextBlock textBlock = new TextBlock()
            {
                Text = WeatherToday.CurrentTemperature,
                Style = TextBlockStyles.CommonTextBlockStyle,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                FontSize = 30
            };

            TextBlock textBlock1 = new TextBlock()
            {
                Text = WeatherToday.FeelingString,
                Style = TextBlockStyles.CommonTextBlockStyle,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                FontSize = 14,
                Margin = new Thickness(0, -6, 0, 0)
            };

            TextBlock textBlock2 = new TextBlock()
            {
                Text = WeatherToday.FeelingTemperature,
                Style = TextBlockStyles.CommonTextBlockStyle,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, -4, 0, 0)
            };

            StackPanel stackPanel = new StackPanel()
            {
                Children = { textBlock, textBlock1, textBlock2 }
            };
            Grid.SetColumn(stackPanel, 1);
            Grid.SetRow(stackPanel, 0);

            TextBlock textBlock3 = new TextBlock()
            {
                Text = WeatherToday.AtmosphericPhenomena,
                Style = TextBlockStyles.CommonTextBlockStyle,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                Margin = new Thickness(-6, -6, 0, 0),
                MaxWidth = 150,
                LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
                LineHeight = 15,
                FontSize = 15
            };
            Grid.SetColumn(textBlock3, 0);
            Grid.SetColumnSpan(textBlock3, 2);
            Grid.SetRow(textBlock3, 1);

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };

            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            RowDefinition rowDefinition = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };

            RowDefinition rowDefinition1 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            Grid grid = new Grid()
            {
                ColumnDefinitions = { columnDefinition, columnDefinition1 },
                RowDefinitions = { rowDefinition, rowDefinition1 },
                Children = { label, stackPanel, textBlock3 },
                Margin = new Thickness(0, 0, 10, 5)
            };


            TextBlock textBlock4 = new TextBlock()
            {
                Text = "Вероятность осадков",
                Style = TextBlockStyles.CommonTextBlockStyle,
            };
            Grid.SetColumn(textBlock4, 0);
            Grid.SetRow(textBlock4, 0);

            TextBlock textBlock5 = new TextBlock()
            {
                Text = probability,
                Style = TextBlockStyles.CommonTextBlockStyle,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                Margin = new Thickness(7, 0, 0, 0)
            };
            Grid.SetColumn(textBlock5, 1);
            Grid.SetRow(textBlock5, 0);

            TextBlock textBlock6 = new TextBlock()
            {
                Text = WeatherToday.HumidityString,
                Style = TextBlockStyles.CommonTextBlockStyle,
            };
            Grid.SetColumn(textBlock6, 0);
            Grid.SetRow(textBlock6, 1);

            TextBlock textBlock7 = new TextBlock()
            {
                Text = WeatherToday.HumidityPercent,
                Style = TextBlockStyles.CommonTextBlockStyle,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                Margin = new Thickness(7, 0, 0, 0)
            };
            Grid.SetColumn(textBlock7, 1);
            Grid.SetRow(textBlock7, 1);

            TextBlock textBlock8 = new TextBlock()
            {
                Text = WeatherToday.WindString,
                Style = TextBlockStyles.CommonTextBlockStyle,
            };
            Grid.SetColumn(textBlock8, 0);
            Grid.SetRow(textBlock8, 2);

            TextBlock textBlock9 = new TextBlock()
            {
                Text = WeatherToday.WindSpeed.Split(", ")[0],
                Style = TextBlockStyles.CommonTextBlockStyle,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                Margin = new Thickness(7, 0, 0, 0)
            };
            Grid.SetColumn(textBlock9, 1);
            Grid.SetRow(textBlock9, 2);

            TextBlock textBlock10 = new TextBlock()
            {
                Text = WeatherToday.CurrentCity,
                Style = TextBlockStyles.CommonTextBlockStyle,
                FontSize = 14
            };

            TextBlock textBlock11 = new TextBlock()
            {
                Text = WeatherToday.LastUpdateDate,
                Style = TextBlockStyles.CommonTextBlockStyle,
                FontSize = 14
            };

            Line line = new Line()
            {
                X1 = 0,
                Y1 = 0,
                X2 = 0,
                Y2 = 12,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                Margin = new Thickness(8, 0, 8, 0),
                Stroke = Brushes.AliceBlue,
                StrokeThickness = 1,
            };

            TextBlock textBlock12 = new TextBlock()
            {
                Text = "пт",
                Style = TextBlockStyles.CommonTextBlockStyle,
                FontSize = 14,
            };

            StackPanel stackPanel1 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Children = { textBlock11, line, textBlock12 },
                Margin = new Thickness(0, -2, 0, 0)
            };

            StackPanel stackPanel2 = new StackPanel()
            {
                HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                VerticalAlignment = System.Windows.VerticalAlignment.Bottom,
                Margin = new Thickness(0, 5, 0, 0),
                Children = { textBlock10, stackPanel1 }
            };
            Grid.SetColumnSpan(stackPanel2, 2);
            Grid.SetColumn(stackPanel2, 0);
            Grid.SetRow(stackPanel2, 3);


            ColumnDefinition columnDefinition2 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            ColumnDefinition columnDefinition3 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };

            RowDefinition rowDefinition2 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };

            RowDefinition rowDefinition3 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };

            RowDefinition rowDefinition4 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };

            RowDefinition rowDefinition5 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            Grid grid1 = new Grid()
            {
                ColumnDefinitions = { columnDefinition2, columnDefinition3 },
                RowDefinitions = { rowDefinition2, rowDefinition3, rowDefinition4, rowDefinition5 },
                Children = { textBlock4, textBlock5,
                             textBlock6, textBlock7,
                             textBlock8, textBlock9,
                             stackPanel2 },
                Margin = new Thickness(5)
            };

            WrapPanel wrapPanel = new WrapPanel()
            {
                Orientation = Orientation.Horizontal,
                Children = { grid, grid1 }
            };

            Content = wrapPanel;
        }
    }
}
