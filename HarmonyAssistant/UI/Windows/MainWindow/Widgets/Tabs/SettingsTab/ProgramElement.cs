using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Widgets;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class ProgramElement : ContentControl
    {
        private ProgramObject programObject;

        public ObservableCollection<SListItem> sListItem;

        public ProgramElement(ProgramObject programObject)
        {
            this.programObject = programObject;

            sListItem = new ObservableCollection<SListItem>();
            foreach(string item in programObject.CallingNames)
                sListItem.Add(new SListItem(item));

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ItemsControl itemsControl = new ItemsControl()
            {
                ItemsSource = sListItem
            };

            AddButton addButton = new AddButton();
            addButton.Click += AddButton_Click;

            StackPanel stackPanel = new StackPanel()
            {
                Children = { itemsControl, addButton },
                Margin = new Thickness(0, 0, 5, 0)
            };
            Grid.SetColumn(stackPanel, 0);

            TextBlock textBlock1 = new TextBlock()
            {
                Text = programObject.Path,
                Style = new CommonTextBlockStyle(),
                Margin = new Thickness(5, 0, 0, 0)
            };
            Grid.SetColumn(textBlock1, 1);

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
                Children = { stackPanel, textBlock1, line },
                Margin = new Thickness(5, 0, 5, 13)
            };

            Content = grid;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
