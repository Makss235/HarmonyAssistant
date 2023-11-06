using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Widgets;
using System.Windows;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Windows
{
    public class TestWindow : Window
    {
        public TestWindow()
        {
            //SvgViewbox svgViewbox = new SvgViewbox();
            //svgViewbox.Source = new Uri("pack://application:,,,/Data/Resources/Images/tr.svg", UriKind.Absolute);
            //svgViewbox.MessageStrokeBrush = Brushes.Yellow;
            //svgViewbox.MessageFillBrush = Brushes.YellowGreen;

            HExpander hExpander = new HExpander()
            {
                HeaderContent = new TextBlock() { Text = "hello", Style = new CommonTextBlockStyle(), },
                BodyContent = new TextBlock() { Text = "world", Style = new CommonTextBlockStyle(), },
                Width = 150
            };

            Background = ThemeManager.CurrentTheme.TabBackgroundBrush;

            Content = hExpander;
        }
    }
}
