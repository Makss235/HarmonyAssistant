using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Widgets.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using System;

namespace HarmonyAssistant.UI.Widgets
{
    public class HExpander : HorizontalExpander
    {
        protected static readonly DependencyProperty IconProperty;

        public object Icon
        {
            get { return GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        private Path path;
        private ContentPresenter grid1;
        private ContentPresenter grid2;
        private ContentPresenter grid3;
        private Border border;

        public HExpander()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            path = new Path()
            {
                Data = Geometry.Parse("m63.48,516.88c-34.73,0-62.98-28.25-62.98-62.96V63.46C.5,28.74,28.75.5,63.48.5c11.32,0,22.56,3.19,32.5,9.23l321.56,195.23c18.93,11.5,30.24,31.58,30.24,53.73s-11.3,42.24-30.24,53.73L95.98,507.65c-9.94,6.04-21.18,9.23-32.49,9.23h0Z"),
                StrokeThickness = 1,
                Stretch = Stretch.Uniform,
                Width = 18,
                Height = 18,
            };
            ThemeManager.AddResourceReference(path);
            path.SetResourceReference(Shape.StrokeProperty,
                nameof(IAppBrushes.CommonForegroundBrush));
            path.Fill = Brushes.Transparent;

            grid1 = new ContentPresenter()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(7, 5, 8, 5)
            };
            Grid.SetColumn(grid1, 0);
            Grid.SetRow(grid1, 0);

            Icon = path;

            grid2 = new ContentPresenter()
            {
                Margin = new Thickness(0, 5, 7, 5),
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(grid2, 1);
            Grid.SetRow(grid2, 0);

            TButton button = new TButton()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            button.Click += Button_Click;
            button.PreviewMouseLeftButtonDown += Button_MouseLeftButtonDown;
            button.PreviewMouseLeftButtonUp += Button_MouseLeftButtonUp;
            button.MouseEnter += Border_MouseEnter;
            button.MouseLeave += Border_MouseLeave;
            Grid.SetColumn(button, 0);
            Grid.SetColumnSpan(button, 2);
            Grid.SetRow(button, 0);
            Panel.SetZIndex(button, 2);

            border = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                CornerRadius = new CornerRadius(5)
            };
            Grid.SetColumn(border, 0);
            Grid.SetColumnSpan(border, 2);
            Grid.SetRow(border, 0);
            Panel.SetZIndex(border, -1);

            grid3 = new ContentPresenter()
            {
                Margin = new Thickness(0, 2, 0, 0),
                Visibility = Visibility.Collapsed,
            };
            Grid.SetColumn(grid3, 1);
            Grid.SetRow(grid3, 1);

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };
            
            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            RowDefinition rowDefinition = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };
            
            RowDefinition rowDefinition1 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };

            Grid grid = new Grid()
            {
                ColumnDefinitions = { columnDefinition, columnDefinition1 },
                RowDefinitions = { rowDefinition, rowDefinition1 },
                Children = { grid1, grid2, grid3, button, border }
            };

            Content = grid;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            border.Background = Brushes.Transparent;
            if (!IsExpanded)
            path.Fill = Brushes.Transparent;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            border.Background = ThemeManager.CurrentTheme.MouseOverBrush;
            path.SetResourceReference(Shape.FillProperty,
                nameof(IAppBrushes.CommonForegroundBrush));
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            border.Background = Brushes.Gray;
        }

        private void Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            border.Background = ThemeManager.CurrentTheme.MouseOverBrush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsExpanded = !IsExpanded;
        }

        static HExpander()
        {
            IconProperty = DependencyProperty.Register(
                    "Icon",
                    typeof(object),
                    typeof(HExpander),
                    new FrameworkPropertyMetadata(
                        null,
                        FrameworkPropertyMetadataOptions.AffectsMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnIconChanged)));
        }

        protected static void OnIconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HExpander hExpander = (HExpander)d;
            hExpander.OnIconChanged(e);
        }

        protected virtual void OnIconChanged(DependencyPropertyChangedEventArgs e)
        {
            grid1.Content = Icon;
        }

        protected override void OnHeaderContentChanged(DependencyPropertyChangedEventArgs e)
        {
            grid2.Content = HeaderContent;
        }

        protected override void OnBodyContentChanged(DependencyPropertyChangedEventArgs e)
        {
            grid3.Content = BodyContent;
        }

        protected override void OnIsExpandedChanged(DependencyPropertyChangedEventArgs e)
        {
            if (IsExpanded) grid3.Visibility = Visibility.Visible; 
            else grid3.Visibility = Visibility.Collapsed;
            RotateIcon();
        }

        protected virtual void RotateIcon()
        {
            if (IsExpanded)
            {
                path.LayoutTransform = new RotateTransform { Angle = 90 };
            }
            else
            {
                path.LayoutTransform = new RotateTransform { Angle = 0 };
            }
        }
    }
}
