using HarmonyAssistant.Data.DataSerialize;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class ProgramsTable : ContentControl
    {
        public ObservableCollection<object> Programs;
        private List<NamesAndPathObject> namesAndPathObjects;

        public ProgramsTable(List<NamesAndPathObject> namesAndPathObjects)
        {
            this.namesAndPathObjects = namesAndPathObjects;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Programs = new ObservableCollection<object>
            {
                new ProgramTableHeader()
            };
            for (int i = 0; i < namesAndPathObjects.Count; i++)
            {
                var hh = namesAndPathObjects[i];
                var gg = new ProgramElement(ref hh);
                gg.ProgramElementChanged += Gg_ProgramElementChanged;
                gg.ProgramElementSeleted += Gg_ProgramElementSeleted;
                Programs.Add(gg);
            }

            ItemsControl itemsControl = new ItemsControl()
            {
                ItemsSource = Programs,
                Margin = new Thickness(5)
            };

            AddButton addButton = new AddButton(TypeButton.Add)
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(10, 0, 10, 10)
            };
            addButton.Click += AddButton_Click;

            StackPanel stackPanel = new StackPanel()
            {
                Children = { itemsControl, addButton },
            };

            Content = stackPanel;
        }

        private void Gg_ProgramElementSeleted(ProgramElement obj)
        {
            int index = ProgramsData.GetInstance().JsonObject.FindIndex(
                p => p.Path.Equals(obj.namesAndPathObject.Path) && p.Names.Equals(obj.namesAndPathObject.Names));

            try
            {
                Programs.Remove(obj);
                ProgramsData.GetInstance().JsonObject.RemoveAt(index);
                ProgramsData.GetInstance().Serialize();
            }
            catch { }
        }

        private void Gg_ProgramElementChanged(ProgramElement obj)
        {
            int index = ProgramsData.GetInstance().JsonObject.FindIndex(
                p => p.Path.Equals(obj.namesAndPathObject.Path) || p.Names.Equals(obj.namesAndPathObject.Names));

            var ff = new NamesAndPathObject()
            {
                Names = obj.namesAndPathObject.Names,
                Path = obj.namesAndPathObject.Path,
            };

            if (index == -1)
            {
                ProgramsData.GetInstance().JsonObject.Add(ff);
            }
            else
            {
                ProgramsData.GetInstance().JsonObject[index] = ff;
            }

            ProgramsData.GetInstance().Serialize();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var hh = new NamesAndPathObject()
            {
                Names = new List<string>(),
                Path = string.Empty
            };

            var gg = new ProgramElement(ref hh);
            gg.ProgramElementChanged += Gg_ProgramElementChanged;
            gg.ProgramElementSeleted += Gg_ProgramElementSeleted;
            Programs.Add(gg);
            namesAndPathObjects.Add(hh);
        }
    }
}
