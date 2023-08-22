using HarmonyAssistant.UI.Widgets.Base;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shell;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets
{
    public class LeftPanelMenu : ContentControl
    {
        public List<Tab> Tabs { get; }

        private List<LeftPanelMenuButton> buttons;

        private Border iconBorder;
        private TButton iconButton;

        private TextBlock titleTextBlock;
        private Border headerBorder;

        private StackPanel menuButtonsStackPanel;

        private ColumnDefinition leftColumnDefinition;
        private ColumnDefinition mainColumnDefinition;
        private RowDefinition headerRowDefinition;
        private RowDefinition menuRowDefinition;
        private Grid mainGrid;

        public LeftPanelMenu(List<Tab> tabs) 
        {
            Tabs = tabs;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            iconBorder = new Border()
            {
                Background = new SolidColorBrush(new Color()
                { R = 1, G = 6, B = 108, A = 255 }),
                CornerRadius = new CornerRadius(13),
                Width = 26,
                Height = 26,
            };

            iconButton = new TButton()
            {
                Content = new ProgrammIcon(),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.Yellow,
            };
            iconButton.SetValue(WindowChrome.IsHitTestVisibleInChromeProperty, true);
            iconButton.Click += Button_Click;

            titleTextBlock = new TextBlock()
            {
                Text = "Привет, Иван!",
                FontFamily = new FontFamily("Candara"),
                FontSize = 17,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20, 5, 5, 7),
                Foreground = Brushes.AliceBlue
            };

            headerBorder = new Border()
            { Width = 200 };
            headerBorder.Child = titleTextBlock;
            Grid.SetColumn(headerBorder, 1);
            Grid.SetRow(headerBorder, 0);

            buttons = new List<LeftPanelMenuButton>();

            LeftPanelMenuButton leftPanelMenuButton = new LeftPanelMenuButton("Главная");
            leftPanelMenuButton.ButtonClicked += LeftPanelMenu_ButtonClicked;
            leftPanelMenuButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            leftPanelMenuButton.Margin = new Thickness(7, 5, 7, 5);
            buttons.Add(leftPanelMenuButton);
            LeftPanelMenuButton HomeMenuButton = new LeftPanelMenuButton("Главная", new HomeIcon());
            HomeMenuButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            HomeMenuButton.Margin = new Thickness(7, 5, 7, 5);

            LeftPanelMenuButton OptionsMenuButton = new LeftPanelMenuButton("Главная", new HomeIcon()); // если добавить в текст на один символ больше, начнет прыгать, также блюет от того, что в 3 кнопках разный текст, жопа
            OptionsMenuButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            OptionsMenuButton.Margin = new Thickness(7, 5, 7, 5);

            LeftPanelMenuButton InfoMenuButton = new LeftPanelMenuButton("Главная", new HomeIcon());
            InfoMenuButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            InfoMenuButton.Margin = new Thickness(7, 5, 7, 5);

            //Button button1 = new Button();
            //button1.Height = 35;
            //button1.HorizontalAlignment = HorizontalAlignment.Stretch;
            //button1.Margin = new Thickness(7, 5, 7, 5);
            LeftPanelMenuButton leftPanelMenuButton1 = new LeftPanelMenuButton("Настройки");
            leftPanelMenuButton1.ButtonClicked += LeftPanelMenu_ButtonClicked;
            leftPanelMenuButton1.HorizontalAlignment = HorizontalAlignment.Stretch;
            leftPanelMenuButton1.Margin = new Thickness(7, 5, 7, 5);
            buttons.Add(leftPanelMenuButton1);

            LeftPanelMenuButton leftPanelMenuButton2 = new LeftPanelMenuButton("О программе");
            leftPanelMenuButton2.ButtonClicked += LeftPanelMenu_ButtonClicked;
            leftPanelMenuButton2.HorizontalAlignment = HorizontalAlignment.Stretch;
            leftPanelMenuButton2.Margin = new Thickness(7, 5, 7, 5);
            buttons.Add(leftPanelMenuButton2);

            if (buttons.Count != Tabs.Count)
                throw new Exception("Quantity of tabs and buttons are not equal");

            for (int i = 0; i < Tabs.Count; i++)
                buttons[i].Tab = Tabs[i];

            menuButtonsStackPanel = new StackPanel()
            { 
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
            menuButtonsStackPanel.Children.Add(leftPanelMenuButton);
            menuButtonsStackPanel.Children.Add(leftPanelMenuButton1);
            menuButtonsStackPanel.Children.Add(leftPanelMenuButton2);
            //menuButtonsStackPanel.Children.Add(leftPanelMenuButton);
            menuButtonsStackPanel.Children.Add(HomeMenuButton);
            menuButtonsStackPanel.Children.Add(OptionsMenuButton);
            menuButtonsStackPanel.Children.Add(InfoMenuButton);
            Grid.SetColumn(menuButtonsStackPanel, 0);
            Grid.SetColumnSpan(menuButtonsStackPanel, 2);
            Grid.SetRow(menuButtonsStackPanel, 1);

            leftColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(50, GridUnitType.Pixel) };

            mainColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };

            headerRowDefinition = new RowDefinition()
            { Height = new GridLength(40, GridUnitType.Pixel) };
            
            menuRowDefinition = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            mainGrid = new Grid();
            mainGrid.ColumnDefinitions.Add(leftColumnDefinition);
            mainGrid.ColumnDefinitions.Add(mainColumnDefinition);
            mainGrid.RowDefinitions.Add(headerRowDefinition);
            mainGrid.RowDefinitions.Add(menuRowDefinition);
            mainGrid.Children.Add(iconButton);
            mainGrid.Children.Add(headerBorder);
            mainGrid.Children.Add(menuButtonsStackPanel);

            Content = mainGrid;
        }

        private void LeftPanelMenu_ButtonClicked(Tab obj)
        {
            foreach (var item in buttons)
            {
                if (item.Tab == obj)
                {
                    item.Tab.Visibility = Visibility.Visible;
                }
                else item.Tab.Visibility = Visibility.Collapsed;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (headerBorder.Visibility == Visibility.Collapsed)
                headerBorder.Visibility = Visibility.Visible;
            else headerBorder.Visibility = Visibility.Collapsed;
        }
    }
}
