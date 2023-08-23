using HarmonyAssistant.UI.Widgets.Base;
using HarmonyAssistant.UI.Windows.MainWindow.Styles;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Icons;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shell;
using FontAwesome.WPF;
using HarmonyAssistant.UI.Widgets.Icons;

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
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(14, 10, 0, 0),
            };
            iconButton.SetValue(WindowChrome.IsHitTestVisibleInChromeProperty, true);
            iconButton.Click += Button_Click;

            titleTextBlock = new TextBlock()
            {
                Text = "Привет, Иван!",
                Style = TextBlocksStyles.textBlockStyle,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20, 5, 5, 7),
            };

            headerBorder = new Border()
            { Width = 200 };
            headerBorder.Child = titleTextBlock;
            Grid.SetColumn(headerBorder, 1);
            Grid.SetRow(headerBorder, 0);

            buttons = new List<LeftPanelMenuButton>();

            ImageAwesome imageAwesome = new ImageAwesome()
            {
                Icon = FontAwesomeIcon.Home,
                Foreground = Brushes.AliceBlue
            };
            
            ImageAwesome imageAwesome1 = new ImageAwesome()
            {
                Icon = FontAwesomeIcon.Gear,
                Foreground = Brushes.AliceBlue
            };
            
            ImageAwesome imageAwesome2 = new ImageAwesome()
            {
                Icon = FontAwesomeIcon.Info,
                Foreground = Brushes.AliceBlue
            };

            LeftPanelMenuButton homeMenuButton = new LeftPanelMenuButton("Главная", imageAwesome);
            homeMenuButton.ButtonClicked += LeftPanelMenu_ButtonClicked;
            homeMenuButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            homeMenuButton.Margin = new Thickness(7, 5, 7, 5);
            buttons.Add(homeMenuButton);

            LeftPanelMenuButton settingsMenuButton = new LeftPanelMenuButton("Настройки", imageAwesome1); // если добавить в текст на один символ больше, начнет прыгать, также блюет от того, что в 3 кнопках разный текст, жопа
            settingsMenuButton.ButtonClicked += LeftPanelMenu_ButtonClicked;
            settingsMenuButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            settingsMenuButton.Margin = new Thickness(7, 5, 7, 5);
            buttons.Add(settingsMenuButton);

            LeftPanelMenuButton aboutProgramMenuButton = new LeftPanelMenuButton("О программе", imageAwesome2);
            aboutProgramMenuButton.ButtonClicked += LeftPanelMenu_ButtonClicked;
            aboutProgramMenuButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            aboutProgramMenuButton.Margin = new Thickness(7, 5, 7, 5);
            buttons.Add(aboutProgramMenuButton);

            if (buttons.Count != Tabs.Count)
                throw new Exception("Quantity of tabs and buttons are not equal");

            for (int i = 0; i < Tabs.Count; i++)
                buttons[i].Tab = Tabs[i];

            menuButtonsStackPanel = new StackPanel()
            { 
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
            menuButtonsStackPanel.Children.Add(homeMenuButton);
            menuButtonsStackPanel.Children.Add(settingsMenuButton);
            menuButtonsStackPanel.Children.Add(aboutProgramMenuButton);
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
            {
                headerBorder.Visibility = Visibility.Visible;
                foreach (var item in buttons)
                    item.OpenButton();
            }
            else
            {
                headerBorder.Visibility = Visibility.Collapsed;
                foreach (var item in buttons)
                    item.CloseButton();
            }
        }
    }
}
