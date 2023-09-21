using FontAwesome.WPF;
using HarmonyAssistant.UI.Animations;
using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Widgets;
using HarmonyAssistant.UI.Widgets.Base;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shell;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets
{
    public class LeftPanelMenu : ContentControl
    {
        public List<Tab> Tabs { get; }

        private List<LeftPanelMenuButton> buttons;

        private TButton iconButton;

        private TextBlock titleTextBlock;
        private Border headerBorder;

        private StackPanel menuButtonsStackPanel;

        private ColumnDefinition leftColumnDefinition;
        private ColumnDefinition mainColumnDefinition;
        private RowDefinition headerRowDefinition;
        private RowDefinition menuRowDefinition;
        private Grid mainGrid;

        private LeftPanelSlideOutAnim lpAnim;
        private bool isClosed;
        private double requiredWidth;

        public LeftPanelMenu(List<Tab> tabs) 
        {
            Tabs = tabs;
            isClosed = false;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Border iconBorder = new Border
            {
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(20),
                Child = new Image()
                {
                    Margin = new Thickness(1),
                    Source = new BitmapImage(
                    new Uri("pack://application:,,,/Data/Resources/Images/Icon.png",
                    UriKind.RelativeOrAbsolute))
                }
            };

            ThemeManager.AddResourceReference(iconBorder);

            iconButton = new TButton()
            {
                Content = iconBorder,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(15, 10, 0, 0),
            };
            iconButton.SetValue(WindowChrome.IsHitTestVisibleInChromeProperty, true);
            iconButton.Click += Button_Click;
            iconButton.MouseEnter += (s, e) => iconBorder.BorderBrush = 
            (Brush)iconBorder.TryFindResource(nameof(IAppBrushes.HighlightingIconBrush));

            iconButton.MouseLeave += (s, e) => 
            iconBorder.BorderBrush = Brushes.Transparent;

            titleTextBlock = new TextBlock()
            {
                Text = "Привет, Иван!",
                Style = TextBlockStyles.CommonTextBlockStyle,
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
                Icon = FontAwesomeIcon.Home
            };
            ThemeManager.AddResourceReference(imageAwesome);
            imageAwesome.SetResourceReference(ImageAwesome.ForegroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            ImageAwesome imageAwesome1 = new ImageAwesome()
            {
                Icon = FontAwesomeIcon.Gear,
                Foreground = Brushes.AliceBlue
            };
            ThemeManager.AddResourceReference(imageAwesome1);
            imageAwesome1.SetResourceReference(ImageAwesome.ForegroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            ImageAwesome imageAwesome2 = new ImageAwesome()
            {
                Icon = FontAwesomeIcon.Info,
                Foreground = Brushes.AliceBlue
            };
            ThemeManager.AddResourceReference(imageAwesome2);
            imageAwesome2.SetResourceReference(ImageAwesome.ForegroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            LeftPanelMenuButton homeMenuButton = new LeftPanelMenuButton("Главная", imageAwesome);
            homeMenuButton.ButtonClicked += LeftPanelMenu_ButtonClicked;
            homeMenuButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            homeMenuButton.Margin = new Thickness(10, 5, 7, 5);
            buttons.Add(homeMenuButton);

            LeftPanelMenuButton settingsMenuButton = new LeftPanelMenuButton("Настройки", imageAwesome1);
            settingsMenuButton.ButtonClicked += LeftPanelMenu_ButtonClicked;
            settingsMenuButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            settingsMenuButton.Margin = new Thickness(10, 5, 7, 5);
            buttons.Add(settingsMenuButton);

            LeftPanelMenuButton aboutProgramMenuButton = new LeftPanelMenuButton("О программе", imageAwesome2);
            aboutProgramMenuButton.ButtonClicked += LeftPanelMenu_ButtonClicked;
            aboutProgramMenuButton.HorizontalAlignment = HorizontalAlignment.Stretch;
            aboutProgramMenuButton.Margin = new Thickness(10, 5, 7, 5);
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

            lpAnim = new LeftPanelSlideOutAnim(this);
            //lpAnim.Completed += (s, e) => MessageBox.Show("Anim was complete");

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
            if (isClosed)
            {
                headerBorder.Visibility = Visibility.Visible;

                lpAnim.StartAnim(this.ActualWidth, 250);
                isClosed = false;
                foreach (var item in buttons)
                    item.OpenButton();
                MessageBox.Show(mainColumnDefinition.ActualWidth.ToString());
            }
            else
            {
                headerBorder.Visibility = Visibility.Collapsed;

                lpAnim.StartAnim(this.ActualWidth, leftColumnDefinition.ActualWidth);
                isClosed = true;
                foreach (var item in buttons)
                    item.CloseButton();

            }
        }
    }
}
