using HarmonyAssistant.UI.Styles;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using HarmonyAssistant.UI.Themes;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class AddButton : ButtonBase
    {
        private Border border;

        public AddButton()
        {
            InitializeComponent();
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            border.Background = ThemeManager.CurrentTheme.MouseOverBrush;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            border.Background = Brushes.Transparent;
        }

        private void InitializeComponent()
        {
            TextBlock textBlock = new TextBlock()
            {
                Text = "+",
                Style = new CommonTextBlockStyle(),
                FontSize = 25,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, -5, 0, 0)
            };

            border = new Border()
            {
                Child = textBlock,
                CornerRadius = new CornerRadius(5),
                HorizontalAlignment = HorizontalAlignment.Stretch, 
                VerticalAlignment = VerticalAlignment.Stretch
            };

            Content = border;
        }
    }
}
