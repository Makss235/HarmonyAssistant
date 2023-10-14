using HarmonyAssistant.Data.DataSerialize;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class ProgramsTable : ContentControl
    {
        public ObservableCollection<object> Programs;

        public ProgramsTable()
        {
            Programs = new ObservableCollection<object>
            {
                new ProgramTableHeader()
            };
            foreach (var item in ProgramsData.GetInstance().JsonObject)
                Programs.Add(new ProgramElement(item));

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ItemsControl itemsControl = new ItemsControl()
            {
                ItemsSource = Programs,
                Margin = new Thickness(5)
            };

            Content = itemsControl;
        }
    }
}
