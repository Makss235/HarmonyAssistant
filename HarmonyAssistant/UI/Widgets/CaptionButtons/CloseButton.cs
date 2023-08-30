using HarmonyAssistant.UI.Icons.CaptionButtonIcons;
using HarmonyAssistant.UI.Widgets.CaptionButtons.Base;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Widgets.CaptionButtons
{
    public class CloseButton : CaptionButton
    {
        private readonly Window window;

        public CloseButton(Window window)
            : base(new CloseIcon(10, 10))
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
            window.Close();
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Background = new SolidColorBrush(new Color()
            { R = 255, G = 0, B = 0, A = 150 });
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Background = Brushes.Transparent;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Background = new SolidColorBrush(new Color()
            { R = 255, G = 0, B = 0, A = 200 });
        }
    }
}
