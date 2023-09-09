using System.Collections.Generic;
using System.Windows;

namespace HarmonyAssistant.UI.Themes
{
    public static class ThemesManager
    {
        public static List<ResourceDictionary> Resources { get; set; }

        private static ResourceDictionary _Current;
        public static ResourceDictionary Current
        {
            get => _Current;
            set
            {
                if (_Current != value)
                {
                    _Current = value;
                    for (int i = 0; i < elements.Count; i++)
                        elements[i].Resources = Current;
                }
            }
        }

        private static List<FrameworkElement> elements;

        static ThemesManager()
        {
            Resources = new List<ResourceDictionary>();
            elements = new List<FrameworkElement>();
        }

        public static void AddResourceSource(FrameworkElement element)
        {
            element.Resources = Current;
            elements.Add(element);
        }
    }
}
