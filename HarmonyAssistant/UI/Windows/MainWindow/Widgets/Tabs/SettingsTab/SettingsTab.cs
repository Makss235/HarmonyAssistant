using HarmonyAssistant.Data.DataSerialize;
using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using HarmonyAssistant.UI.Animations;
using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Widgets;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using System;
using System.Windows;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class SettingsTab : Tab
    {
        private TabAppear_Animation tabAppearAnim;

        public SettingsTab()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            tabAppearAnim = new TabAppear_Animation(this);
            IsVisibleChanged += SettingsTab_IsVisibleChanged;

            #region MyRegion
            //Image userImage = new Image()
            //{
            //    HorizontalAlignment = HorizontalAlignment.Stretch,
            //    VerticalAlignment = VerticalAlignment.Stretch,
            //    Margin = new Thickness(10, 10, 7, 10),
            //    Width = 65,
            //    Height = 65,
            //    Source = new BitmapImage(
            //        new Uri("pack://application:,,,/Data/Resources/Images/Icon.png",
            //        UriKind.RelativeOrAbsolute)),
            //};

            //UserTable userTable = new UserTable(userImage, "Пиписьк Яблонович");
            //Grid.SetColumn(userTable, 0);
            //Grid.SetRow(userTable, 0);
            //Grid.SetColumnSpan(userTable, 2); 
            #endregion

            TextBlock textBlock3 = new TextBlock()
            {
                Text = "Настройки",
                HorizontalAlignment = HorizontalAlignment.Center,
                Style = new CommonTextBlockStyle(),
                FontWeight = FontWeights.Bold,
                FontSize = 19,
            };

            TextBlock textBlock2 = new TextBlock()
            {
                Text = "Основные",
                Style = new CommonTextBlockStyle(),
                FontWeight = FontWeights.Bold
            };

            TextBlock themeTextBlock = new TextBlock()
            {
                Text = "Тема:",
                Style = new CommonTextBlockStyle(),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 5, 9, 5)
            };
            Grid.SetColumn(themeTextBlock, 0);
            Grid.SetRow(themeTextBlock, 0);


            ThemeButton greyThemeButton = new ThemeButton(GreyBrushes.GetInstance());
            ThemeButton darkGrayThemeButton = new ThemeButton(DarkGrayBrushes.GetInstance());
            ThemeButton darkBlueThemeButton = new ThemeButton(DarkBlueBrushes.GetInstance());
            ThemeButton lightTurquoiseThemeButton = new ThemeButton(LightTurquoiseBrushes.GetInstance());

            WrapPanel themeStackPanel = new WrapPanel()
            { 
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(0, 5, 0, 5),
                Children =
                {
                    greyThemeButton,
                    darkGrayThemeButton,
                    darkBlueThemeButton,
                    lightTurquoiseThemeButton,
                }
            };
            Grid.SetColumn(themeStackPanel, 1);
            Grid.SetRow(themeStackPanel, 0);

            foreach (ThemeButton item in themeStackPanel.Children)
            {
                item.Click += (s, e) =>
                {
                    SettingsData.GetInstance().JsonObject.Theme =
                    item.AppBrushes.GetType().Name;
                    SettingsData.GetInstance().Serialize();
                };
            }

            ColumnDefinition leftColumnDfn = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };
            ColumnDefinition rightColumnDfn = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            RowDefinition themeRowDfn = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };

            Grid mainGrid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                ColumnDefinitions = { leftColumnDfn, rightColumnDfn },
                RowDefinitions = { themeRowDfn },
                Children = { themeTextBlock, themeStackPanel }
            };

            HExpander hExpander = new HExpander()
            {
                HeaderContent = textBlock2,
                BodyContent = mainGrid,
                IsExpanded = true,
                Margin = new Thickness(0, 5, 0, 0)
            };


            #region MyRegion
            //TextBlock soundTB = new TextBlock()
            //{
            //    Text = "Звук",
            //    Style = TextBlockStyles.CommonTextBlockStyle,
            //    VerticalAlignment = VerticalAlignment.Center,
            //    Margin = new Thickness(10, 10, 7, 10)
            //};
            //Grid.SetColumn(soundTB, 0);
            //Grid.SetRow(soundTB, 2);

            //Slider soundSlider = new Slider()
            //{
            //    Background = Brushes.Transparent,
            //    Orientation = Orientation.Horizontal,
            //    Width = 150,
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    VerticalAlignment = VerticalAlignment.Center,
            //    Margin = new Thickness(7, 0, 10, 0),
            //};
            //Grid.SetColumn(soundSlider, 1);
            //Grid.SetRow(soundSlider, 2);

            //TextBlock searchSystTB = new TextBlock()
            //{
            //    Text = "Поисковая система",
            //    Style = TextBlockStyles.CommonTextBlockStyle,
            //    VerticalAlignment = VerticalAlignment.Center,
            //    Margin = new Thickness(10, 10, 7, 10)
            //};
            //Grid.SetColumn(searchSystTB, 0);
            //Grid.SetRow(searchSystTB, 3);

            //SomeButton searchSystBtnGoogle = new SomeButton("Google") 
            //{ Height = 35 };
            //SomeButton searchSystBtnYandex = new SomeButton("Яндекс")
            //{ Height = 35 };

            //StackPanel searchSystSP = new StackPanel
            //{
            //    Orientation = Orientation.Horizontal,
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    Children = { searchSystBtnGoogle, searchSystBtnYandex }
            //};
            //Grid.SetColumn(searchSystSP, 1);
            //Grid.SetRow(searchSystSP, 3); 
            #endregion

            ProgramsTable programsTable = new ProgramsTable(ProgramsData.GetInstance());

            TextBlock textBlock = new TextBlock()
            {
                Text = "Программы",
                Style = new CommonTextBlockStyle(),
                FontWeight = FontWeights.Bold
            };

            HExpander sExpander = new HExpander()
            {
                HeaderContent = textBlock,
                BodyContent = programsTable,
                Margin = new Thickness(0, 5, 0, 0)
            };


            ProgramsTable programsTable1 = new ProgramsTable(SitesData.GetInstance());

            TextBlock textBlock1 = new TextBlock()
            {
                Text = "Сайты",
                Style = new CommonTextBlockStyle(),
                FontWeight = FontWeights.Bold
            };

            HExpander sExpander1 = new HExpander()
            {
                HeaderContent = textBlock1,
                BodyContent = programsTable1,
                Margin = new Thickness(0, 5, 0, 0)
            };

            StackPanel stackPanel = new StackPanel()
            {
                Children = { textBlock3, hExpander, sExpander, sExpander1 },
                Margin = new Thickness(7)
            };

            ResourceDictionary svStyle = new ResourceDictionary()
            {
                Source =
                new Uri("pack://application:,,,/Data/Resources/ResourceDictionaries/ScrollViewerStyle.xaml",
                UriKind.RelativeOrAbsolute)
            };
            ScrollViewer mainScrollViewer = new ScrollViewer() { Style = svStyle["ScrollViewerStyle"] as Style };
            mainScrollViewer.Content = stackPanel;

            ThemeManager.AddResourceReference(mainScrollViewer);
            mainScrollViewer.SetResourceReference(ScrollViewer.ForegroundProperty, nameof(IAppBrushes.CommonForegroundBrush));

            Content = mainScrollViewer;
        }

        private void SaveSettings(SettingsObject settingsObject)
        {
            SettingsData.GetInstance().JsonObject = settingsObject;
            SettingsData.GetInstance().Serialize();
        }

        private void SettingsTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
                tabAppearAnim.StartAnim();
        }
    }
}
