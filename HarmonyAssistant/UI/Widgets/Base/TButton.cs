using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AdvaDirectStorage.Widgets.Base
{
    public class TButton : ButtonBase
    {
        public TButton()
        {
            Content = new Border()
            { Background = new SolidColorBrush(Colors.Transparent) };
        }
    }
}
