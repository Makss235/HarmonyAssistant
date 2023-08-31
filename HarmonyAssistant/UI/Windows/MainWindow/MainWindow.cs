using HarmonyAssistant.Core.STT;
using HarmonyAssistant.UI.Icons.CaptionButtonIcons;
using HarmonyAssistant.UI.Widgets.CaptionButtons;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.AboutProgramTab;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.ChatTab;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            Closing += MainWindow_Closing;

            InitializeStyles();
            InitializeWindow();
            InitializeComponent();
        }

        private void MainWindow_Closing(object? sender, CancelEventArgs e)
        {
            STT.GetInstance().Stop();
            CCSTTF.GetInstance().Stop();

            Application.Current.Shutdown();
        }

        private void InitializeStyles()
        {
            windowChrome = new WindowChrome()
            {
                CaptionHeight = 40,
                NonClientFrameEdges = NonClientFrameEdges.Left,
                ResizeBorderThickness = new Thickness(5),
            };

            windowStyle = new Style(typeof(Window));
            windowStyle.Setters.Add(new Setter(WindowChrome.WindowChromeProperty, windowChrome));
        }

        private void InitializeWindow()
        {
            Title = "Привет, Иван!";
            Style = windowStyle;
            Background = ProgramBrushes.DarkerBlue;
            WindowStyle = WindowStyle.SingleBorderWindow;
            ResizeMode = ResizeMode.CanResize;
            Width = 750;
            Height = 650;
            MinWidth = 600;
            MinHeight = 400;
            MaxWidth = 1000;
            MaxHeight = 800;
            WindowStartupLocation = WindowStartupLocation.Manual;
            widthScreen = SystemParameters.PrimaryScreenWidth;
            heightScreen = SystemParameters.PrimaryScreenHeight;
            Top = heightScreen - Height - 55;
            Left = widthScreen - Width - 10;

            KeyBinding inputBinding = 
                new KeyBinding(SystemCommands.CloseWindowCommand, 
                new KeyGesture(Key.W, ModifierKeys.Alt));

            InputBindings.Add(inputBinding);
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

            MinimizeButton minimizeButton = new MinimizeButton(this);
            minimizeButton.VerticalAlignment = VerticalAlignment.Stretch;
            minimizeButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            Grid.SetColumn(minimizeButton, 0);

            MaximizeButton minimizeButton1 = new MaximizeButton(this, new MaximizeIcon(10));
            minimizeButton1.VerticalAlignment = VerticalAlignment.Stretch;
            minimizeButton1.HorizontalAlignment = HorizontalAlignment.Stretch;
            Grid.SetColumn(minimizeButton1, 1);

            CloseButton minimizeButton2 = new CloseButton(this);
            minimizeButton.VerticalAlignment = VerticalAlignment.Stretch;
            minimizeButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            Grid.SetColumn(minimizeButton2, 2);

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };
            
            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };
            
            ColumnDefinition columnDefinition2 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            Grid grid1 = new Grid()
            {
                Width = 100,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Stretch,
            };
            grid1.ColumnDefinitions.Add(columnDefinition);
            //grid1.ColumnDefinitions.Add(columnDefinition1);
            grid1.ColumnDefinitions.Add(columnDefinition2);
            grid1.Children.Add(minimizeButton);
            //grid1.Children.Add(minimizeButton1);
            grid1.Children.Add(minimizeButton2);
            Grid.SetColumn(grid1, 1);
            Grid.SetRow(grid1, 0);

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
                Background = ProgramBrushes.LessDarkBlue,
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
            mainGrid.Children.Add(grid1);

            Content = mainGrid;
        }
    }
}
