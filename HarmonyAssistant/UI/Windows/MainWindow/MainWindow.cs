using HarmonyAssistant.UI.Windows.MainWindow.Widgets;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shell;

namespace HarmonyAssistant.UI.Windows.MainWindow
{
    public class MainWindow : Window
    {
        private double widthScreen;
        private double heightScreen;

        private WindowChrome windowChrome;
        private Style windowStyle;

        private LeftPanelMenu leftPanelMenu;
        private Border mainFieldBorder;

        private ColumnDefinition leftMenuColumnDefinition;
        private ColumnDefinition mainFieldColumnDefinition;
        private RowDefinition headerRowDefinition;
        private RowDefinition clientZoneRowDefinition;
        private Grid mainGrid;

        public MainWindow()
        {
            InitializeStyles();
            InitializeWindow();
            InitializeComponent();
        }

        private void InitializeStyles()
        {
            windowChrome = new WindowChrome()
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

        private void InitializeWindow()
        {
            Title = "Привет, Иван!";
            Style = windowStyle;
            Background = new SolidColorBrush(new Color()
            { R = 15, G = 20, B = 35, A = 255 });
            WindowStyle = WindowStyle.None;
            Width = 750;
            Height = 650;
            MinWidth = 600;
            MinHeight = 400;
            WindowStartupLocation = WindowStartupLocation.Manual;
            widthScreen = SystemParameters.PrimaryScreenWidth;
            heightScreen = SystemParameters.PrimaryScreenHeight;
            Top = heightScreen - Height - 55;
            Left = widthScreen - Width - 10;
        }

        private void InitializeComponent()
        {
            List<Tab> tabs = new List<Tab>();

            ChatTab chatTab = new ChatTab() { Visibility = Visibility.Visible };
            tabs.Add(chatTab);

            SettingsTab settingsTab = new SettingsTab() { Visibility = Visibility.Collapsed };
            tabs.Add(settingsTab);

            AboutProgramTab aboutProgramTab = new AboutProgramTab() { Visibility = Visibility.Collapsed };
            tabs.Add(aboutProgramTab);

            leftPanelMenu = new LeftPanelMenu(tabs);
            Grid.SetColumn(leftPanelMenu, 0);
            Grid.SetRow(leftPanelMenu, 0);
            Grid.SetRowSpan(leftPanelMenu, 2);

            Grid grid = new Grid();
            grid.Children.Add(chatTab);
            grid.Children.Add(settingsTab);
            grid.Children.Add(aboutProgramTab);

            mainFieldBorder = new Border()
            {
                Background = new SolidColorBrush(new Color() 
                { R = 13, G = 27, B = 42, A = 255 }),
                CornerRadius = new CornerRadius(10, 0, 0, 0)
            };
            mainFieldBorder.Child = grid;
            Grid.SetColumn(mainFieldBorder, 1);
            Grid.SetRow(mainFieldBorder, 1);

            leftMenuColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };

            mainFieldColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            headerRowDefinition = new RowDefinition()
            { Height = new GridLength(40, GridUnitType.Pixel) };
            
            clientZoneRowDefinition = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            mainGrid = new Grid();
            mainGrid.ColumnDefinitions.Add(leftMenuColumnDefinition);
            mainGrid.ColumnDefinitions.Add(mainFieldColumnDefinition);
            mainGrid.RowDefinitions.Add(headerRowDefinition);
            mainGrid.RowDefinitions.Add(clientZoneRowDefinition);
            mainGrid.Children.Add(leftPanelMenu);
            mainGrid.Children.Add(mainFieldBorder);

            Content = mainGrid;
        }
    }
}
