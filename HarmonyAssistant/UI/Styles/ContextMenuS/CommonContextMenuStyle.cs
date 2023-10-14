using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.Base.ContextMenuS
{
    public class CommonContextMenuStyle : Style
    {
        public CommonContextMenuStyle()
        {
            FrameworkElementFactory itemPresenterF = new FrameworkElementFactory(typeof(ItemsPresenter));
            itemPresenterF.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
            itemPresenterF.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            itemPresenterF.SetValue(FrameworkElement.MarginProperty, new Thickness(-0.1, 8, -0.1, 8));

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetValue(Border.BackgroundProperty, Brushes.Red);
            borderF.SetValue(Border.BorderBrushProperty, Brushes.Violet);
            borderF.SetValue(Border.BorderThicknessProperty, new Thickness(2));
            borderF.SetValue(Border.CornerRadiusProperty, new CornerRadius(10));

            borderF.AppendChild(itemPresenterF);

            Setters.Add(new Setter(ContextMenu.TemplateProperty, new ControlTemplate(typeof(ContextMenu))
            {
                VisualTree = borderF
            }));
        }
    }
}
