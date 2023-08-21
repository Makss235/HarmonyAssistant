using HarmonyAssistant.UI.Windows.MainWindow.Widgets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shell;

namespace HarmonyAssistant.UI.Windows.MainWindow
{
    public class MainWindow : Window
    {
        private Style windowStyle;

        public MainWindow()
        {
            InitializeStyles();
            Title = "Привет, Иван!";
            Style = windowStyle;
            Background = new SolidColorBrush(new Color()
            { R = 14, G = 12, B = 30, A = 255 });
            WindowStyle = WindowStyle.None;
            Width = 750;
            Height = 650;
            MinWidth = 600;
            MinHeight = 400;
            WindowStartupLocation = WindowStartupLocation.Manual;
            double w = SystemParameters.PrimaryScreenWidth;
            double h = SystemParameters.PrimaryScreenHeight;
            Top = h - Height - 55;
            Left = w - Width - 10;

            InitializeComponent();
        }

        private void InitializeStyles()
        {
            WindowChrome windowChrome = new WindowChrome()
            {
                CaptionHeight = 40,
                CornerRadius = new CornerRadius(5),
                GlassFrameThickness = new Thickness(-1),
                NonClientFrameEdges = NonClientFrameEdges.None,
                ResizeBorderThickness = new Thickness(5),
                UseAeroCaptionButtons = true
            };

            windowStyle = new Style(typeof(Window));
            windowStyle.Setters.Add(new Setter(WindowChrome.WindowChromeProperty, windowChrome));
        }

        private void InitializeComponent()
        {
            LeftPanelMenu leftPanelMenu = new LeftPanelMenu();
            Grid.SetColumn(leftPanelMenu, 0);
            Grid.SetRow(leftPanelMenu, 0);
            Grid.SetRowSpan(leftPanelMenu, 2);

            Border bordermainfield = new Border()
            {
                Background = new SolidColorBrush(new Color() 
                { R = 10, G = 13, B = 40, A = 255 }),
                CornerRadius = new CornerRadius(10, 0, 0, 0)
            };
            Grid.SetColumn(bordermainfield, 1);
            Grid.SetRow(bordermainfield, 1);

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };

            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            RowDefinition rowDefinition = new RowDefinition()
            { Height = new GridLength(40, GridUnitType.Pixel) };
            
            RowDefinition rowDefinition1 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(columnDefinition);
            grid.ColumnDefinitions.Add(columnDefinition1);
            grid.RowDefinitions.Add(rowDefinition);
            grid.RowDefinitions.Add(rowDefinition1);
            grid.Children.Add(leftPanelMenu);
            grid.Children.Add(bordermainfield);

            Content = grid;
        }
    }
}
