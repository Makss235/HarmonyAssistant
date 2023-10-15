using HarmonyAssistant.UI.Styles;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using HarmonyAssistant.UI.Themes;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public enum TypeButton
    {
        Add, Change, Cancel
    }

    public class AddButton : ButtonBase
    {
        private Border border;
        private TypeButton typeButton;

        public AddButton(TypeButton typeButton)
        {
            this.typeButton = typeButton;

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
            border = new Border()
            {
                CornerRadius = new CornerRadius(5),
                HorizontalAlignment = HorizontalAlignment.Stretch, 
                VerticalAlignment = VerticalAlignment.Stretch
            };

            if (typeButton == TypeButton.Add)
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = "+",
                    Style = new CommonTextBlockStyle(),
                    FontSize = 25,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, -6, 0, 0)
                };
                border.Child = textBlock;
            }
            else if (typeButton == TypeButton.Change)
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = "✓",
                    Style = new CommonTextBlockStyle(),
                    FontWeight = FontWeights.UltraBold,
                    FontSize = 14,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(-1, -1, 0, 0)
                };
                border.Child = textBlock;
            }
            else if (typeButton == TypeButton.Cancel)
            {
                TextBlock textBlock = new TextBlock()
                {
                    Text = "✖",
                    Style = new CommonTextBlockStyle(),
                    FontWeight = FontWeights.UltraLight,
                    FontSize = 10,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, -2, 0, 0)
                };
                border.Child = textBlock;
            }

            Content = border;
        }
    }
}
