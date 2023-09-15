using HarmonyAssistant.Data.DataSerialize;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class ThemeButton : ButtonBase
    {
        public IAppBrushes AppBrushes { get; set; }

        public ThemeButton(IAppBrushes appBrushes)
        {
            AppBrushes = appBrushes;

            Border mainBorder = new Border()
            {
                Background = AppBrushes.CommonBackgroundBrush,
                BorderBrush = Brushes.AliceBlue,
                Width = 25,
                Height = 25,
                CornerRadius = new CornerRadius(5),
                BorderThickness = new Thickness(1),
                Margin = new Thickness(2.5, 0, 2.5, 0)
            };
            mainBorder.MouseEnter += (s, e) => mainBorder.BorderThickness = new Thickness(2);
            mainBorder.MouseLeave += (s, e) => mainBorder.BorderThickness = new Thickness(1);

            Click += (s, e) =>
            {
                ThemeManager.CurrentTheme = AppBrushes;
                //SettingsData.GetInstance().JsonObject.Theme = appBrushes.GetType().Name;
                //SettingsData.GetInstance().Serialize();
            };

            Content = mainBorder;
        }

    }
}
