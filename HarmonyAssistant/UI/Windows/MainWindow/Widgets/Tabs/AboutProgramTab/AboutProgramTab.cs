using HarmonyAssistant.UI.Animations;
using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Widgets;
using HarmonyAssistant.UI.Windows.MainWindow.Styles;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.AboutProgramTab
{
    public class AboutProgramTab : Tab
    {
        private TabAppear_Animation tabAppearAnim;

        #region UI Elements

        private TextBlock titleTextBlock;

        private TextBlock nameProgramLocTextBlock;
        private TextBlock nameProgramTextBlock;
        private WrapPanel nameProgramWrapPanel;

        private TextBlock nameBuildLocTextBlock;
        private TextBlock nameBuildTextBlock;
        private WrapPanel nameBuildWrapPanel;

        private TextBlock versionLocTextBlock;
        private TextBlock versionTextBlock;
        private WrapPanel versionWrapPanel;

        private TextBlock authorsLocTextBlock;
        private TextBlock makssAuthorTextBlock;
        private TextBlock mrVeserAuthorTextBlock;
        private TextBlock cripol1AuthorTextBlock;
        private StackPanel authorsStackPanel;
        private WrapPanel authorsWrapPanel;

        private TextBlock downloadLinkLocTextBlock;
        private Hyperlink downloadHyperlink;
        private TextBlock downloadHyperlinkTextBlock;
        private Label downloadQRLabel;
        private StackPanel downloadHyperlinkStackPanel;
        
        private TextBlock githubLinkLocTextBlock;
        private Hyperlink githubHyperlink;
        private TextBlock githubHyperlinkTextBlock;
        private Label githubQRLabel;
        private StackPanel githubHyperlinkStackPanel;

        private WrapPanel linksWrapPanel;

        private StackPanel mainStackPanel;
        private Grid mainGrid;

        private ScrollViewer scrollViewer;

        #endregion

        public AboutProgramTab()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            tabAppearAnim = new TabAppear_Animation(this);
            IsVisibleChanged += AboutProgramTab_IsVisibleChanged;

            titleTextBlock = new TextBlock()
            {
                Text = "О программе",
                Style = new CommonTextBlockStyle(),
                FontSize = 19,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            #region NameProgram

            nameProgramLocTextBlock = new TextBlock()
            {
                Text = "Название программы:",
                Style = new CommonTextBlockStyle()
            };
            nameProgramTextBlock = new TextBlock()
            {
                Text = "Привет, Иван!",
                Style = new CommonTextBlockStyle(),
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10, 0, 0, 0)
            };

            nameProgramWrapPanel = new WrapPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 5),
            };
            nameProgramWrapPanel.Children.Add(nameProgramLocTextBlock);
            nameProgramWrapPanel.Children.Add(nameProgramTextBlock);

            #endregion

            #region NameBuild

            nameBuildLocTextBlock = new TextBlock()
            {
                Text = "Название сборки:",
                Style = new CommonTextBlockStyle()
            };
            nameBuildTextBlock = new TextBlock()
            {
                Text = "HarmonyAssistant",
                Style = new CommonTextBlockStyle(),
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10, 0, 0, 0)
            };

            nameBuildWrapPanel = new WrapPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 5, 0, 5),
            };
            nameBuildWrapPanel.Children.Add(nameBuildLocTextBlock);
            nameBuildWrapPanel.Children.Add(nameBuildTextBlock);

            #endregion

            #region Version

            versionLocTextBlock = new TextBlock()
            {
                Text = "Версия:",
                Style = new CommonTextBlockStyle()
            };
            versionTextBlock = new TextBlock()
            {
                Text = "0.1.0.0",
                Style = new CommonTextBlockStyle(),
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(10, 0, 0, 0)
            };

            versionWrapPanel = new WrapPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 5, 0, 5),
            };
            versionWrapPanel.Children.Add(versionLocTextBlock);
            versionWrapPanel.Children.Add(versionTextBlock);

            #endregion

            #region Authors

            authorsLocTextBlock = new TextBlock()
            {
                Text = "Авторы:",
                Style = new CommonTextBlockStyle()
            };

            makssAuthorTextBlock = new TextBlock()
            {
                Text = "Makss (Широков Максим)",
                Style = new CommonTextBlockStyle(),
                FontWeight = FontWeights.Bold
            };
            mrVeserAuthorTextBlock = new TextBlock()
            {
                Text = "MrVeser (Кузнецов Виктор)",
                Style = new CommonTextBlockStyle(),
                FontWeight = FontWeights.Bold
            };
            cripol1AuthorTextBlock = new TextBlock()
            {
                Text = "Cripol1 (Инкин Максим)",
                Style = new CommonTextBlockStyle(),
                FontWeight = FontWeights.Bold
            };

            authorsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10, 0, 0, 0),
            };
            authorsStackPanel.Children.Add(makssAuthorTextBlock);
            authorsStackPanel.Children.Add(mrVeserAuthorTextBlock);
            authorsStackPanel.Children.Add(cripol1AuthorTextBlock);

            authorsWrapPanel = new WrapPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 5, 0, 5),
            };
            authorsWrapPanel.Children.Add(authorsLocTextBlock);
            authorsWrapPanel.Children.Add(authorsStackPanel);

            #endregion

            #region Links

            downloadLinkLocTextBlock = new TextBlock()
            { 
                Text = "Ссылка на скачивание:",
                Style = new CommonTextBlockStyle()
            };

            downloadHyperlink = new Hyperlink()
            { 
                NavigateUri = new Uri("https://clck.ru/335ThJ"),
                Style = new CommonTextBlockStyle(),
                Foreground = Brushes.CornflowerBlue
            };
            downloadHyperlink.RequestNavigate += DownloadHyperlink_RequestNavigate;
            downloadHyperlink.Inlines.Add("https://clck.ru/335ThJ");

            downloadHyperlinkTextBlock = new TextBlock();
            downloadHyperlinkTextBlock.Inlines.Add(downloadHyperlink);

            downloadQRLabel = new Label()
            {
                Content = new Image()
                {
                    Source = new BitmapImage(
                    new Uri("pack://application:,,,/Data/Resources/Images/QRDownload.png",
                    UriKind.RelativeOrAbsolute))
                },
                Width = 200,
                Height = 200,
                Margin = new Thickness(0, 5, 0, 0)
            };

            downloadHyperlinkStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 0, 5, 0),
            };
            downloadHyperlinkStackPanel.Children.Add(downloadLinkLocTextBlock);
            downloadHyperlinkStackPanel.Children.Add(downloadHyperlinkTextBlock);
            downloadHyperlinkStackPanel.Children.Add(downloadQRLabel);


            githubLinkLocTextBlock = new TextBlock()
            {
                Text = "Ссылка на GitHub:",
                Style = new CommonTextBlockStyle()
            };

            githubHyperlink = new Hyperlink()
            { 
                NavigateUri = new Uri("https://clck.ru/35WELg"),
                Style = new CommonTextBlockStyle(),
                Foreground = Brushes.CornflowerBlue
            };
            githubHyperlink.RequestNavigate += GithubHyperlink_RequestNavigate;
            githubHyperlink.Inlines.Add("https://clck.ru/35WELg");

            githubHyperlinkTextBlock = new TextBlock();
            githubHyperlinkTextBlock.Inlines.Add(githubHyperlink);

            githubQRLabel = new Label()
            {
                Content = new Image()
                {
                    Source = new BitmapImage(
                    new Uri("pack://application:,,,/Data/Resources/Images/QRGit.png",
                    UriKind.RelativeOrAbsolute))
                },
                Width = 200,
                Height = 200,
                Margin = new Thickness(0, 5, 0, 0)
            };

            githubHyperlinkStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(5, 0, 0, 0),
            };
            githubHyperlinkStackPanel.Children.Add(githubLinkLocTextBlock);
            githubHyperlinkStackPanel.Children.Add(githubHyperlinkTextBlock);
            githubHyperlinkStackPanel.Children.Add(githubQRLabel);

            linksWrapPanel = new WrapPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 5, 0, 5)
            };
            linksWrapPanel.Children.Add(downloadHyperlinkStackPanel);
            linksWrapPanel.Children.Add(githubHyperlinkStackPanel);

            #endregion

            mainStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(15, 7, 15, 7)
            };
            mainStackPanel.Children.Add(titleTextBlock);
            mainStackPanel.Children.Add(nameProgramWrapPanel);
            mainStackPanel.Children.Add(nameBuildWrapPanel);
            mainStackPanel.Children.Add(versionWrapPanel);
            mainStackPanel.Children.Add(authorsWrapPanel);
            mainStackPanel.Children.Add(linksWrapPanel);

            mainGrid = new Grid();
            mainGrid.Children.Add(mainStackPanel);


            ResourceDictionary svStyle = new ResourceDictionary()
            {
                Source =
                new Uri("pack://application:,,,/Data/Resources/ResourceDictionaries/ScrollViewerStyle.xaml",
                UriKind.RelativeOrAbsolute)
            };
            scrollViewer = new ScrollViewer() { Style = svStyle["ScrollViewerStyle"] as Style };
            scrollViewer.Content = mainGrid;

            ThemeManager.AddResourceReference(scrollViewer);
            scrollViewer.SetResourceReference(ScrollViewer.ForegroundProperty, nameof(IAppBrushes.CommonForegroundBrush));

            Content = scrollViewer;
        }

        private void AboutProgramTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                tabAppearAnim.StartAnim();
            }
        }

        private void DownloadHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://clck.ru/335ThJ") { UseShellExecute = true });
        }
        private void GithubHyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://clck.ru/35WELg") { UseShellExecute = true });
        }
    }
}
