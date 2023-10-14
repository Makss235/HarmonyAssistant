using HarmonyAssistant.UI.Themes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace HarmonyAssistant.UI.Styles.ContextMenuStyles
{
    public class CommonContextMenuItemStyle : Style
    {
        public CommonContextMenuItemStyle()
        {
            FrameworkElementFactory contentPresenter_FEF = new FrameworkElementFactory(typeof(TextBlock));
            contentPresenter_FEF.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            contentPresenter_FEF.SetValue(TextBlock.MarginProperty, new Thickness(10, 5, 10, 5));
            contentPresenter_FEF.SetValue(TextBlock.StyleProperty, new CommonTextBlockStyle());
            contentPresenter_FEF.SetBinding(TextBlock.TextProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Header")
            });

            FrameworkElementFactory border_FEF = new FrameworkElementFactory(typeof(Border));
            border_FEF.SetValue(Border.CornerRadiusProperty, new CornerRadius(3));
            border_FEF.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });
            border_FEF.SetBinding(FrameworkElement.MinWidthProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("MinWidth")
            });
            border_FEF.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Background")
            });

            border_FEF.AppendChild(contentPresenter_FEF);

            Trigger mouseOverTrigger = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true,
                Setters = { new Setter(Control.BackgroundProperty, ThemeManager.CurrentTheme.MouseOverBrush) }
            };

            Triggers.Add(mouseOverTrigger);
            Setters.Add(new Setter(FrameworkElement.MinWidthProperty, (double)170));
            Setters.Add(new Setter(Control.ForegroundProperty, ThemeManager.CurrentTheme.CommonForegroundBrush));
            Setters.Add(new Setter(Control.BackgroundProperty, ThemeManager.CurrentTheme.TabBackgroundBrush));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(MenuItem))
            {
                VisualTree = border_FEF
            }));
        }
    }
}
