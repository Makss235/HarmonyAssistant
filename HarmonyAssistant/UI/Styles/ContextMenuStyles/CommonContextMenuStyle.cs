using HarmonyAssistant.UI.Themes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace HarmonyAssistant.UI.Styles.ContextMenuStyles
{
    public class CommonContextMenuStyle : Style
    {
        public CommonContextMenuStyle()
        {
            FrameworkElementFactory itemPresenter_FEF = new FrameworkElementFactory(typeof(ItemsPresenter));
            itemPresenter_FEF.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            itemPresenter_FEF.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            itemPresenter_FEF.SetValue(FrameworkElement.MarginProperty, new Thickness(4));

            FrameworkElementFactory border_FEF = new FrameworkElementFactory(typeof(Border));
            border_FEF.SetValue(Border.BackgroundProperty, ThemeManager.CurrentTheme.TabBackgroundBrush);
            border_FEF.SetValue(Border.BorderBrushProperty, ThemeManager.CurrentTheme.MouseOverBrush);
            border_FEF.SetValue(Border.BorderThicknessProperty, new Thickness(1));
            border_FEF.SetValue(Border.CornerRadiusProperty, new CornerRadius(5));
            border_FEF.AppendChild(itemPresenter_FEF);

            FrameworkElementFactory grid_FEF = new FrameworkElementFactory(typeof(Grid));
            grid_FEF.SetValue(Grid.MarginProperty, new Thickness(10));
            grid_FEF.AppendChild(border_FEF);

            Setters.Add(new Setter(Control.EffectProperty, new DropShadowEffect()
            {
                BlurRadius = 10,
                Opacity = 0.5,
                ShadowDepth = 5,
                Color = Colors.Black
            }));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(ContextMenu))
            {
                VisualTree = grid_FEF
            }));
        }
    }
}
