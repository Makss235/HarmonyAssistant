using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class SomeButton : ContentControl
    {
        public SomeButton(string text/*, double height, double width*/)
        {
            Label content = new Label()
            {
                Content = text,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = Brushes.Transparent,
                Foreground = Brushes.AliceBlue,
                FontSize = 16,
                FontFamily = new FontFamily("Segoe UI"),
                FontWeight = FontWeights.SemiBold,
                Height = Height,
                Width = Width,
            };
            Border mainBorder = new Border()
            {
                Child = content,
                CornerRadius = new CornerRadius(5),
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Transparent,
                //Height = height,
                //Width = width,
                Height = Height,
                Width = Width,
            };
            mainBorder.MouseEnter += (s, e) => mainBorder.BorderBrush = Brushes.AliceBlue;
            mainBorder.MouseLeave += (s, e) => mainBorder.BorderBrush = Brushes.Transparent;

            Content = mainBorder;
        }
    }
}
