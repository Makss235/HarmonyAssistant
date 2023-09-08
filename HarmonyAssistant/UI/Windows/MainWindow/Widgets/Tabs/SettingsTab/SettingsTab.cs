using HarmonyAssistant.UI.Animations;
using HarmonyAssistant.UI.Windows.MainWindow.Styles;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tools;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class SettingsTab : Tab
    {
        private TabAppearAnim tabAppearAnim;
        public SettingsTab()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            tabAppearAnim = new TabAppearAnim(this);
            IsVisibleChanged += SettingsTab_IsVisibleChanged;

            Image userImage = new Image()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Margin = new Thickness(10, 10, 7, 10),
                Width = 65,
                Height = 65,
                Source = new BitmapImage(
                    new Uri("pack://application:,,,/Data/Resources/Images/Icon.png",
                    UriKind.RelativeOrAbsolute)),
            };

            UserTable userTable = new UserTable(userImage, "Пиписьк Яблонович");
            Grid.SetColumn(userTable, 0);
            Grid.SetRow(userTable, 0);
            Grid.SetColumnSpan(userTable, 2);

            TextBlock themeTB = new TextBlock()
            {
                Text = "Тема",
                Style = TextBlocksStyles.TextBlockStyle,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 10, 7, 10)
            };
            Grid.SetColumn(themeTB, 0);
            Grid.SetRow(themeTB, 1);
            
            ThemeButton themeBRed = new ThemeButton(Brushes.Red);
            themeBRed.PreviewMouseLeftButtonDown += (s, e) => ProgramBrushes.LessDarkBlue = Brushes.Green;
            ThemeButton themeBYellow = new ThemeButton(Brushes.Yellow);

            WrapPanel themeStackPanel = new WrapPanel()
            { 
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(10, 10, 7, 10),
                Children =
                {
                    themeBRed,
                    themeBYellow,
                }
            };
            Grid.SetColumn(themeStackPanel, 1);
            Grid.SetRow(themeStackPanel, 1);

            TextBlock soundTB = new TextBlock()
            {
                Text = "Звук",
                Style = TextBlocksStyles.TextBlockStyle,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 10, 7, 10)
            };
            Grid.SetColumn(soundTB, 0);
            Grid.SetRow(soundTB, 2);

            Slider soundSlider = new Slider()
            {
                Background = Brushes.Transparent,
                Orientation = Orientation.Horizontal,
                Width = 150,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(7, 0, 10, 0),
            };
            Grid.SetColumn(soundSlider, 1);
            Grid.SetRow(soundSlider, 2);


            ColumnDefinition leftColumnDfn = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };
            ColumnDefinition rightColumnDfn = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            RowDefinition soundRowDfn = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };
            RowDefinition themeRowDfn = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };
            RowDefinition userRowDfn = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };

            Grid mainGrid = new Grid() 
            { HorizontalAlignment = HorizontalAlignment.Stretch };
            mainGrid.ColumnDefinitions.Add(leftColumnDfn);
            mainGrid.ColumnDefinitions.Add(rightColumnDfn);
            mainGrid.RowDefinitions.Add(soundRowDfn);
            mainGrid.RowDefinitions.Add(themeRowDfn);
            mainGrid.RowDefinitions.Add(userRowDfn);
            mainGrid.Children.Add(soundTB);
            mainGrid.Children.Add(soundSlider);
            mainGrid.Children.Add(themeTB);
            mainGrid.Children.Add(themeStackPanel);
            mainGrid.Children.Add(userTable);

            ResourceDictionary svStyle = new ResourceDictionary()
            {
                Source =
                new Uri("pack://application:,,,/Data/Resources/ResourceDictionaries/ScrollViewerStyle.xaml",
                UriKind.RelativeOrAbsolute)
            };
            ScrollViewer mainScrollViewer = new ScrollViewer() { Style = svStyle["ScrollViewerStyle"] as Style };
            mainScrollViewer.Content = mainGrid;

            Content = mainScrollViewer;
        }

        private void SettingsTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
                tabAppearAnim.StartAnim();
        }
    }
}
