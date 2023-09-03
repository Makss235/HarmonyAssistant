using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace HarmonyAssistant.UI.Windows.MainWindow.Styles
{
    //[TemplatePart(Name = "PART_VerticalScrollBar", Type = typeof(ScrollBar))]
    public class ScrollBarStyle : ScrollBar, IScrollInfo
    {
        public ScrollBarStyle() 
        {
        }

        public bool CanHorizontallyScroll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool CanVerticallyScroll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double ExtentHeight => throw new NotImplementedException();

        public double ExtentWidth => throw new NotImplementedException();

        public double HorizontalOffset => throw new NotImplementedException();

        public ScrollViewer ScrollOwner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public double VerticalOffset => throw new NotImplementedException();

        public double ViewportHeight => throw new NotImplementedException();

        public double ViewportWidth => throw new NotImplementedException();

        public void LineDown()
        {
            throw new NotImplementedException();
        }

        public void LineLeft()
        {
            throw new NotImplementedException();
        }

        public void LineRight()
        {
            throw new NotImplementedException();
        }

        public void LineUp()
        {
            
        }

        public Rect MakeVisible(Visual visual, Rect rectangle)
        {
            throw new NotImplementedException();
        }

        public void MouseWheelDown()
        {
            throw new NotImplementedException();
        }

        public void MouseWheelLeft()
        {
            throw new NotImplementedException();
        }

        public void MouseWheelRight()
        {
            throw new NotImplementedException();
        }

        public void MouseWheelUp()
        {
            throw new NotImplementedException();
        }

        public void PageDown()
        {
            throw new NotImplementedException();
        }

        public void PageLeft()
        {
            throw new NotImplementedException();
        }

        public void PageRight()
        {
            throw new NotImplementedException();
        }

        public void PageUp()
        {
            throw new NotImplementedException();
        }

        public void SetHorizontalOffset(double offset)
        {
            throw new NotImplementedException();
        }

        public void SetVerticalOffset(double offset)
        {
            throw new NotImplementedException();
        }
    }


    public class ScrollViewerStyle : ScrollViewer
    {
        public ScrollViewerStyle() 
        {
            //FrameworkElementFactory content = new FrameworkElementFactory(typeof(ScrollContentPresenter));

            ////FrameworkElementFactory sb = new FrameworkElementFactory(typeof(ScrollBar));
            ////sb.SetValue(ScrollBar.HorizontalAlignmentProperty, HorizontalAlignment.Right);
            ////RegisterName("PART_VerticalScrollBar", sb);
            ////sb.SetValue(ScrollBar.ViewportSizeProperty, (double)10);
            ////sb.SetValue(ScrollBar.MinimumProperty, (double)0);
            ////sb.SetValue(ScrollBar.MaximumProperty, (double)20);
            ////sb.SetValue(ScrollBar.NameProperty, "PART_VerticalScrollBar");
            ////sb.SetValue(ScrollBar.StyleProperty, new ScrollBarStyle());
            //ScrollBar sb2 = new ScrollViewer().FindName("PART_VerticalScrollBar") as ScrollBar;
            //ScrollBar sb = (ScrollBar)new ScrollViewer().FindName("PART_VerticalScrollBar");

            //FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));
            //grid.SetValue(Grid.BackgroundProperty, Brushes.Transparent);

            ////.AppendChild(sb);
            //grid.AppendChild(content);


            //Setters.Add(new Setter(ScrollViewer.TemplateProperty, new ControlTemplate(typeof(ScrollViewer))
            //{
            //    VisualTree = grid
            //}));

            //var style = new Style(typeof(ScrollViewer));
            //style.Setters.Add(new Setter(ScrollViewer.OverridesDefaultStyleProperty, true));

            //var template = new ControlTemplate(typeof(ScrollViewer));
            //var grid = new FrameworkElementFactory(typeof(Grid));
            //var column1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            //column1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
            //var column2 = new FrameworkElementFactory(typeof(ColumnDefinition));
            //grid.AppendChild(column1);
            //grid.AppendChild(column2);

            //var row1 = new FrameworkElementFactory(typeof(RowDefinition));
            //grid.AppendChild(row1);
            //var row2 = new FrameworkElementFactory(typeof(RowDefinition));
            //row2.SetValue(RowDefinition.HeightProperty, new GridLength(1, GridUnitType.Auto));
            //grid.AppendChild(row2);

            //var scrollContentPresenter = new FrameworkElementFactory(typeof(ScrollContentPresenter));
            //scrollContentPresenter.SetValue(Grid.ColumnProperty, 1);
            //grid.AppendChild(scrollContentPresenter);

            //var verticalScrollBar = new FrameworkElementFactory(typeof(ScrollBar));
            ////verticalScrollBar.SetValue(RangeBase.NameProperty, "PART_VerticalScrollBar");
            //verticalScrollBar.SetValue(ScrollBar.BackgroundProperty, Brushes.Transparent);
            //RegisterName("PART_VerticalScrollBar", verticalScrollBar);
            ////verticalScrollBar.SetBinding(RangeBase.ValueProperty, new TemplateBindingExtension(ScrollViewer.VerticalOffsetProperty));
            ////verticalScrollBar.SetBinding(RangeBase.MaximumProperty, new TemplateBindingExtension(ScrollViewer.ScrollableHeightProperty));
            ////verticalScrollBar.SetBinding(ScrollBar.ViewportSizeProperty, new TemplateBindingExtension(ScrollViewer.ViewportHeightProperty));
            ////verticalScrollBar.SetBinding(UIElement.VisibilityProperty, new TemplateBindingExtension(ScrollViewer.ComputedVerticalScrollBarVisibilityProperty));
            //grid.AppendChild(verticalScrollBar);

            //var horizontalScrollBar = new FrameworkElementFactory(typeof(ScrollBar));
            //horizontalScrollBar.SetValue(RangeBase.NameProperty, "PART_HorizontalScrollBar");
            //horizontalScrollBar.SetValue(ScrollBar.OrientationProperty, Orientation.Horizontal);
            //horizontalScrollBar.SetValue(Grid.RowProperty, 1);
            //horizontalScrollBar.SetValue(Grid.ColumnProperty, 1);
            ////horizontalScrollBar.SetBinding(RangeBase.ValueProperty, new TemplateBindingExtension(ScrollViewer.HorizontalOffsetProperty));
            ////horizontalScrollBar.SetBinding(RangeBase.MaximumProperty, new TemplateBindingExtension(ScrollViewer.ScrollableWidthProperty));
            ////horizontalScrollBar.SetBinding(ScrollBar.ViewportSizeProperty, new TemplateBindingExtension(ScrollViewer.ViewportWidthProperty));
            ////horizontalScrollBar.SetBinding(UIElement.VisibilityProperty, new TemplateBindingExtension(ScrollViewer.ComputedHorizontalScrollBarVisibilityProperty));
            //grid.AppendChild(horizontalScrollBar);

            //template.VisualTree = grid;
            ////style.Setters.Add(new Setter(ScrollViewer.BackgroundProperty, Brushes.Violet));
            //Setters.Add(new Setter(ScrollViewer.TemplateProperty, template));

            Grid g = new Grid();
            ScrollContentPresenter scp = new ScrollContentPresenter();
        }
    }
}
