using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class SMenuItem : MenuItem
    {
        private ContentPresenter contentPresenter;
        private Border mainBorder;

        public SMenuItem()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            FrameworkElementFactory itemsPresenterF = new FrameworkElementFactory(typeof(ItemsPresenter));
            itemsPresenterF.SetValue(ItemsPresenter.MarginProperty, new Thickness(5));
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(Border));
            factory.AppendChild(itemsPresenterF);

            ControlTemplate itemsPanelTemplate1 = new ControlTemplate()
            {
                VisualTree = factory
            };

            contentPresenter = new ContentPresenter
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = "RRRRR",
            };

            //ItemsPresenter a = new ItemsPresenter();

            mainBorder = new Border
            {
                Child = contentPresenter,
                Background = Brushes.Transparent,
                Width = 200,
                //Height = 50,
                Margin = new Thickness(-20)
            };

            Template = new ControlTemplate() { VisualTree = factory };
        }
    }
}
