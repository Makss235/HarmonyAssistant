using HarmonyAssistant.Data.DataSerialize;
using HarmonyAssistant.UI.Themes.AppBrushes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HarmonyAssistant.UI.Themes
{
    public static class ThemeManager
    {
        public static event Action CurrentThemeChanged;

        public static Dictionary<string, IAppBrushes> Resources { get; private set; }

        #region CurrentTheme

        private static IAppBrushes _CurrentTheme;
        public static IAppBrushes CurrentTheme
        {
            get => _CurrentTheme;
            set
            {
                if (_CurrentTheme != value)
                {
                    _CurrentTheme = value;
                    for (int i = 0; i < elements.Count; i++)
                        elements[i].Resources = CurrentTheme.ResourceDictionary;
                    CurrentThemeChanged?.Invoke();
                }
            }
        }

        #endregion

        private static List<FrameworkElement> elements;

        static ThemeManager()
        {
            Resources = new Dictionary<string, IAppBrushes>
            {
                { nameof(DarkGrayBrushes), DarkGrayBrushes.GetInstance() },
                { nameof(DarkBlueBrushes), DarkBlueBrushes.GetInstance() },
                { nameof(LightTurquoiseBrushes), LightTurquoiseBrushes.GetInstance() },
                { nameof(GreyBrushes), GreyBrushes.GetInstance() }
            };
            elements = new List<FrameworkElement>();

            CurrentTheme = Resources[SettingsData.GetInstance().JsonObject.Theme];
        }

        public static void AddResourceReference(FrameworkElement element)
        {
            element.Resources = CurrentTheme.ResourceDictionary;
            elements.Add(element);
        }
    }
}
