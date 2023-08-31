using HarmonyAssistant.UI.Icons.CaptionButtonIcons;
using HarmonyAssistant.UI.Widgets.CaptionButtons.Base;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Widgets.CaptionButtons
{
    public class MinimizeButton : CaptionButton
    {
        private readonly Window window;

        public MinimizeButton(Window window) 
            : base(new MinimizeIcon(10))
        {
            this.window = window;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Click += Button_Click;
            PreviewMouseLeftButtonDown += Button_PreviewMouseLeftButtonDown;
            MouseEnter += Button_MouseEnter;
            MouseLeave += Button_MouseLeave;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            window.WindowState = WindowState.Minimized;
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
