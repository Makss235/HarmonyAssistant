using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace HarmonyAssistant.UI.Widgets.Buttons
{
    public class LeftMenuButton : ContentControl
    {
        private string text;
        private Grid image;
        public LeftMenuButton(string text, Grid image)
        {
            this.text = text;
            this.image = image;
            InitialazeComponent();
        }

        private void InitialazeComponent()
        {
            TextBlock textBlock = new TextBlock()
            {
                Background = Brushes.Transparent,
                Text = text,
                FontFamily = new FontFamily("Caladea"),
                FontSize = 17
            };

            StackPanel grid = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Children = { textBlock, image },
            };

            Border border = new Border()
            {
                Height = 35,
                Background = Brushes.White,
                Child = textBlock
            };

            Content = border;
        }
    }
}
