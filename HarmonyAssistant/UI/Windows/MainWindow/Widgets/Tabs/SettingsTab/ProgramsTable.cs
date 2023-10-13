using HarmonyAssistant.Data.DataSerialize;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class ProgramsTable : ContentControl
    {
        public ProgramsTable()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ItemsControl itemsControl = new ItemsControl();
            itemsControl.Items.Add(new ProgramTableHeader());
            itemsControl.Items.Add(new ProgramElement(ProgramsData.GetInstance().JsonObject[2]));

            Content = itemsControl;
        }
    }
}
