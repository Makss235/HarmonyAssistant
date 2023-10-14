using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartAssistant.Infrastructure.Styles.Base.ContextMenuS
{
    public class CommonContextMenuItemStyle : Style
    {
        public CommonContextMenuItemStyle(CornerRadius cornerRadius)
        {
            FrameworkElementFactory contentPresenterF = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenterF.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            contentPresenterF.SetValue(FrameworkElement.MarginProperty, new Thickness(3));
            contentPresenterF.SetBinding(ContentPresenter.ContentProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Header")
            });

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetValue(Border.CornerRadiusProperty, cornerRadius);
            borderF.SetValue(Border.BorderThicknessProperty, new Thickness(2));
            borderF.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });
            borderF.SetBinding(FrameworkElement.MinWidthProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("MinWidth")
            });
            borderF.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Background")
            });

            borderF.AppendChild(contentPresenterF);

            Trigger mouseOverT = new Trigger
            {
                Property = UIElement.IsMouseOverProperty,
                Value = true
            };
            mouseOverT.Setters.Add(new Setter(Control.BorderBrushProperty, Brushes.Green));

            Triggers.Add(mouseOverT);
            Setters.Add(new Setter(FrameworkElement.MinWidthProperty, (double)50));
            Setters.Add(new Setter(Control.ForegroundProperty, Brushes.Red));
            Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Yellow));
            Setters.Add(new Setter(Control.TemplateProperty, new ControlTemplate(typeof(MenuItem))
            {
                VisualTree = borderF
            }));

        }
    }
}
