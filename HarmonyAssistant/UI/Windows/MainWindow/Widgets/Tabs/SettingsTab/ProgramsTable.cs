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

        public ProgramsTable()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Programs = new ObservableCollection<object>
            {
                new ProgramTableHeader()
            };
            foreach (var item in ProgramsData.GetInstance().JsonObject)
            {
                var gg = new ProgramElement(item.CallingNames, item.Path);
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
                p => p.Path.Equals(obj.Path) && p.CallingNames.Equals(obj.Names));

            try
            {
                Programs.RemoveAt(index);
                ProgramsData.GetInstance().JsonObject.RemoveAt(index);
                ProgramsData.GetInstance().Serialize();
            }
            catch { }
        }

        private void Gg_ProgramElementChanged(ProgramElement obj)
        {
            int index = ProgramsData.GetInstance().JsonObject.FindIndex(
                p => p.Path.Equals(obj.Path) || p.CallingNames.Equals(obj.Names));

            var ff = new ProgramObject()
            {
                CallingNames = obj.Names,
                Path = obj.Path,
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
            var gg = new ProgramElement(new List<string>(), string.Empty);
            gg.ProgramElementChanged += Gg_ProgramElementChanged;
            gg.ProgramElementSeleted += Gg_ProgramElementSeleted;
            Programs.Add(gg);
        }
    }
}
