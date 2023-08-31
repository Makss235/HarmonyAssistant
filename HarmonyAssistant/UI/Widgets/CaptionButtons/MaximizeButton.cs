using HarmonyAssistant.UI.Icons.CaptionButtonIcons;
using HarmonyAssistant.UI.Widgets.CaptionButtons.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Widgets.CaptionButtons
{
    public class MaximizeButton : CaptionButton
    {
        private readonly Window window;

        private MaximizeIcon maximizeIcon;
        private NormalStateIcon normalStateIcon;

        public MaximizeButton(Window window, ContentControl icon)
            : base(icon)
        {
            this.window = window;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            maximizeIcon = new MaximizeIcon(10)
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            normalStateIcon = new NormalStateIcon(10)
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            Click += Button_Click;
            PreviewMouseLeftButtonDown += Button_PreviewMouseLeftButtonDown;
            MouseEnter += Button_MouseEnter;
            MouseLeave += Button_MouseLeave;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (window.WindowState == WindowState.Maximized)
            {
                Icon = normalStateIcon;
                window.WindowState = WindowState.Normal;
            }
            else if (window.WindowState == WindowState.Normal)
            {
                Icon = maximizeIcon;
                window.WindowState = WindowState.Maximized;
            }
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Background = ProgramBrushes.QuarterTransparentDarkGray;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Background = Brushes.Transparent;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Background = ProgramBrushes.HalfTransparentDarkGray;
        }
    }
}
