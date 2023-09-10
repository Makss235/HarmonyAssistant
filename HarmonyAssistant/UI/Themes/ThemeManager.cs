using System;
using System.Collections.Generic;
using System.Windows;

namespace HarmonyAssistant.UI.Themes
{
    public static class ThemeManager
    {
        public static event Action CurrentThemeChanged;

        public static List<ResourceDictionary> Resources { get; set; }

        private static ResourceDictionary _CurrentTheme;
        public static ResourceDictionary CurrentTheme
        {
            get => _CurrentTheme;
            set
            {
                if (_CurrentTheme != value)
                {
                    _CurrentTheme = value;
                    for (int i = 0; i < elements.Count; i++)
                        elements[i].Resources = CurrentTheme;
                    CurrentThemeChanged?.Invoke();
                }
            }
        }

        private static List<FrameworkElement> elements;

        static ThemeManager()
        {
            Resources = new List<ResourceDictionary>();
            elements = new List<FrameworkElement>();
        }

        public static void AddResourceReference(FrameworkElement element)
        {
            element.Resources = CurrentTheme;
            elements.Add(element);
        }
    }
}
