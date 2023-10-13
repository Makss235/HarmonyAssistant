using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Widgets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class ProgramElement : ContentControl
    {
        private ProgramObject programObject;

        public ProgramElement(ProgramObject programObject)
        {
            this.programObject = programObject;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(SListItem));
            frameworkElementFactory.SetValue(SListItem.ContentListItemProperty, new Binding() { Path = new PropertyPath("") });

            MultiTrigger ISISATT = new MultiTrigger
            {
                Conditions =
                {
                    new Condition
                    { Property = ListBoxItem.IsSelectedProperty, Value = true }
                },
                Setters =
                {
                    new Setter
                    { Property = SListItem.ContentListItemProperty, Value = "hvhvhv" },
                    new Setter
                    { Property = SListItem.ContentListItemProperty, Value = new Binding() { Path = new PropertyPath("") } }
                }
            };

            ListBox listBox = new ListBox();
            listBox.ItemsSource = programObject.CallingNames;
            listBox.ContextMenu = new ContextMenu()
            {
                Items =
                {
                    new MenuItem() { Header = "hvhjv" },
                    new MenuItem() { Header = "1" }
                }
            };
            listBox.ItemContainerStyle = new Style(typeof(ListBoxItem))
            {
                Setters =
                {
                    new Setter(ListBox.TemplateProperty, new ControlTemplate(typeof(ListBoxItem))
                    {
                         VisualTree = frameworkElementFactory
                    }),
                    new Setter(ListBoxItem.BorderThicknessProperty, new Thickness(0)),
                }
            };
            listBox.Style = new Style(typeof(ListBox))
            {
                Setters =
                {
                    new Setter(ListBox.BackgroundProperty, Brushes.Transparent),
                    new Setter(ListBox.BorderBrushProperty, Brushes.Transparent)
                }
            };
            Grid.SetColumn(listBox, 0);

            TextBlock textBlock1 = new TextBlock()
            {
                Text = programObject.Path,
                Style = new CommonTextBlockStyle()
            };
            Grid.SetColumn(textBlock1, 1);

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(2, GridUnitType.Star) };

            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            Grid grid = new Grid()
            {
                ColumnDefinitions = { columnDefinition, columnDefinition1 },
                Children = { listBox, textBlock1 }
            };

            Content = grid;
        }
    }
}
