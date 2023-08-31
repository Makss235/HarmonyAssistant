using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Widgets.Base
{
    public class TButton : ButtonBase
    {
        public TButton()
        {
            Content = new Border()
            { Background = Brushes.Transparent };
        }
    }
}
