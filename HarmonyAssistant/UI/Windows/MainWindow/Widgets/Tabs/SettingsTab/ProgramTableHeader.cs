using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class ProgramTableHeader : ContentControl
    {
        private Style headerStyle;

        public ProgramTableHeader()
        {
            InitializeStyles();
            InitializeComponent();
        }

        private void InitializeStyles()
        {
            headerStyle = new Style(
                targetType: typeof(TextBlock),
                basedOn: new CommonTextBlockStyle());
            headerStyle.Setters.Add(new Setter(HorizontalAlignmentProperty, HorizontalAlignment.Center));
            headerStyle.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.Bold));
            headerStyle.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)17));
        }

        private void InitializeComponent()
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = "Название",
                Style = headerStyle
            };
            Grid.SetColumn(textBlock, 0);
            
            TextBlock textBlock1 = new TextBlock()
            {
                Text = "Путь",
                Style = headerStyle
            };
            Grid.SetColumn(textBlock1 , 1);

            Line line = new Line()
            {
                X1 = 0,
                Y1 = 0,
                X2 = 1000,
                Y2 = 0,
                StrokeThickness = 1,
                Opacity = 0.5,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 0, -8)
            };
            ThemeManager.AddResourceReference(line);
            line.SetResourceReference(Line.StrokeProperty,
                nameof(IAppBrushes.CommonForegroundBrush));
            Grid.SetColumnSpan(line, 2);

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };
            
            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            Grid grid = new Grid()
            {
                ColumnDefinitions = { columnDefinition, columnDefinition1 },
                Children = { textBlock, textBlock1, line },
                Margin = new Thickness(5, 0, 5, 13)
            };

            Content = grid;
        }
    }
}
