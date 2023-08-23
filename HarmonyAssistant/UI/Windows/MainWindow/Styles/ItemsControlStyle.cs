using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace HarmonyAssistant.UI.Windows.MainWindow.Styles
{
    public class ItemsControlStyle : Style
    {
        public ItemsControlStyle()
        {
            FrameworkElementFactory itemsPresenterF = new FrameworkElementFactory(typeof(ItemsPresenter));
            itemsPresenterF.SetValue(ItemsPresenter.SnapsToDevicePixelsProperty, true);
            itemsPresenterF.SetValue(ItemsPresenter.VerticalAlignmentProperty, VerticalAlignment.Bottom);

            FrameworkElementFactory borderF = new FrameworkElementFactory(typeof(Border));
            borderF.SetBinding(Border.BackgroundProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Background")
            });
            borderF.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });
            borderF.SetBinding(Border.BorderThicknessProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderThickness")
            });
            borderF.SetBinding(Border.BorderBrushProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("BorderBrush")
            });
            borderF.SetBinding(Border.PaddingProperty, new Binding
            {
                RelativeSource = RelativeSource.TemplatedParent,
                Path = new PropertyPath("Padding")
            });

            borderF.AppendChild(itemsPresenterF);
            Setters.Add(new Setter(ItemsControl.TemplateProperty, new ControlTemplate
            {
                VisualTree = borderF
            }));
        }
    }
}
