using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Widgets.Base;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Widgets
{
    public class SExpander : UserControl, INotifyPropertyChanged
    {
        private object _HeaderContent;

        public object HeaderContent
        {
            get => _HeaderContent;
            set => SetProperty(ref _HeaderContent, value);
        }

        private object _BodyContent;

        public object BodyContent
        {
            get => _BodyContent;
            set => SetProperty(ref _BodyContent, value);
        }

        private bool _IsExpanded = true;

        public bool IsExpanded
        {
            get => _IsExpanded;
            set => SetProperty(ref _IsExpanded, value);
        }

        public event Action<bool> Expanded;

        private ContentPresenter headerContentPresenter;
        private StackPanel headerStackPanel;
        private TButton headerTButton;
        private ContentPresenter bodyContentPresenter;
        private StackPanel expanderStackPanel;
        private Polygon headerTriangle;

        public SExpander()
        {
            InitialazeComponent();
            PropertyChanged += SExpander_PropertyChanged;
        }

        #region NPC

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            //if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        #endregion

        private void SExpander_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IsExpanded):
                    bodyContentPresenter.Visibility = 
                        IsExpanded ? Visibility.Visible : Visibility.Collapsed;
                    break;
                default:
                    break;
            }
            
        }

        private void InitialazeComponent()
        {
            FontSize = 15;
            FontFamily = new FontFamily("Times new roman");
            //Foreground = ResApp.GetResources<SolidColorBrush>("CommonMediumBrush");

            headerTriangle = new Polygon
            {
                Fill = Brushes.Transparent,
                StrokeThickness = 1,
                Stretch = Stretch.Fill,
                Height = 10,
                Width = 10,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Points = new PointCollection { new Point(0, 0), new Point(1, 0), new Point(1, 1) },
                RenderTransformOrigin = new Point(1, 1),
                LayoutTransform = new RotateTransform { Angle = 45 }
            };

            ThemeManager.AddResourceReference(headerTriangle);
            headerTriangle.SetResourceReference(Polygon.StrokeProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            //BackgroundBorder backgroundBorder = new BackgroundBorder()
            //{
            //    Width = 20,
            //    Height = 20
            //};

            headerContentPresenter = new ContentPresenter()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(6, 0, 0, 0),
                Content = _HeaderContent
            };
            headerContentPresenter.SetBinding(
                ContentPresenter.ContentProperty,
                new Binding("HeaderContent") { Source = this });

            headerStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Height = 30
            };
            headerStackPanel.Children.Add(headerTriangle);
            headerStackPanel.Children.Add(headerContentPresenter);

            headerTButton = new TButton()
            {
                Content = headerStackPanel,
                ContextMenu = new ContextMenu() { },
            };
            headerTButton.Click += HeaderTButton_Click;
            headerTButton.MouseEnter += HeaderTButton_ME;
            headerTButton.MouseLeave += HeaderTButton_ML;


            bodyContentPresenter = new ContentPresenter()
            {
                Margin = new Thickness(30, 0, 5, 0),
                Content = _BodyContent
            };
            bodyContentPresenter.Visibility = IsExpanded ? Visibility.Visible : Visibility.Collapsed;
            bodyContentPresenter.SetBinding(
                ContentPresenter.ContentProperty,
                new Binding("BodyContent") { Source = this });

            expanderStackPanel = new StackPanel();
            expanderStackPanel.Children.Add(headerTButton);
            expanderStackPanel.Children.Add(bodyContentPresenter);

            Content = expanderStackPanel;
        }
        
        private void HeaderTButton_Click(object sender, RoutedEventArgs e)
        {
            if (bodyContentPresenter.Visibility == Visibility.Collapsed)
            {
                bodyContentPresenter.Visibility = Visibility.Visible;
                headerTriangle.LayoutTransform = new RotateTransform { Angle = 90 };
                headerTriangle.Fill = headerTriangle.Stroke;
                headerTriangle.Margin = new Thickness(4.2, 0, 0, 0);
                IsExpanded = true;
                Expanded?.Invoke(IsExpanded);
            }
            else if (bodyContentPresenter.Visibility == Visibility.Visible)
            {
                bodyContentPresenter.Visibility = Visibility.Collapsed;
                headerTriangle.LayoutTransform = new RotateTransform { Angle = 45 };
                headerTriangle.Margin = new Thickness(0);
                IsExpanded = false;
                Expanded?.Invoke(IsExpanded);
            }
        }
        private void HeaderTButton_ME(object sender, System.Windows.Input.MouseEventArgs e)
        {
            headerTriangle.Fill = headerTriangle.Stroke;
        }
        private void HeaderTButton_ML(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!IsExpanded)
                headerTriangle.Fill = Brushes.Transparent;
        }
    }
}
