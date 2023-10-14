using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Themes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Data;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class SContextMenu : ContextMenu
    {
        public SContextMenu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Border border = new Border()
            {
                Background = Brushes.AliceBlue
            };
            ThemeManager.AddResourceReference(border);
            border.SetResourceReference(Border.BackgroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            FrameworkElementFactory contentPresenterF = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterF.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenterF.SetValue(FrameworkElement.MarginProperty, new Thickness(10, 5, 10, 5));
            contentPresenterF.SetBinding(ContentPresenter.ContentProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Header")
            });

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(2));
            borderF.SetValue(Border.BorderThicknessProperty, new Thickness(2));

            borderF.AppendChild(contentPresenterF);

            ControlTemplate itemsPanelTemplate = new ControlTemplate()
            {
                VisualTree = borderF
            };

            

            ItemContainerStyle = new Style(typeof(MenuItem))
            {
                Setters =
                {
                    new Setter(MenuItem.TemplateProperty, itemsPanelTemplate)
                }
            };

            Background = Brushes.Yellow;
            BorderThickness = new Thickness(0);
            //HasDropShadow = false;
            //Effect = new DropShadowEffect() { Color = Colors.Black };
        }
    }
}
