using HarmonyAssistant.UI.Styles;
using System;
using System.Windows;
using System.Windows.Controls;

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

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(2, GridUnitType.Star) };
            
            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            Grid grid = new Grid()
            {
                ColumnDefinitions = { columnDefinition, columnDefinition1 },
                Children = { textBlock, textBlock1 }
            };

            Content = grid;
        }
    }
}
