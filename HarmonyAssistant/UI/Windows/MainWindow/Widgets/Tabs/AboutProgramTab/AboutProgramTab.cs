using HarmonyAssistant.UI.Animations;
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
        private TabAppearAnim tabAppearAnim;

        #region UI Elements

        private CommonTextBlockStyled titleTextBlock;

        private CommonTextBlockStyled nameProgramLocTextBlock;
        private CommonTextBlockStyled nameProgramTextBlock;
        private WrapPanel nameProgramWrapPanel;

        private CommonTextBlockStyled nameBuildLocTextBlock;
        private CommonTextBlockStyled nameBuildTextBlock;
        private WrapPanel nameBuildWrapPanel;

        private CommonTextBlockStyled versionLocTextBlock;
        private CommonTextBlockStyled versionTextBlock;
        private WrapPanel versionWrapPanel;

        private CommonTextBlockStyled authorsLocTextBlock;
        private CommonTextBlockStyled makssAuthorTextBlock;
        private CommonTextBlockStyled mrVeserAuthorTextBlock;
        private CommonTextBlockStyled cripol1AuthorTextBlock;
        private StackPanel authorsStackPanel;
        private WrapPanel authorsWrapPanel;

        private CommonTextBlockStyled downloadLinkLocTextBlock;
        private Hyperlink downloadHyperlink;
        private CommonTextBlockStyled downloadHyperlinkTextBlock;
        private Label downloadQRLabel;
        private StackPanel downloadHyperlinkStackPanel;
        
        private CommonTextBlockStyled githubLinkLocTextBlock;
        private Hyperlink githubHyperlink;
        private CommonTextBlockStyled githubHyperlinkTextBlock;
        private Label githubQRLabel;
        private StackPanel githubHyperlinkStackPanel;

        private WrapPanel linksWrapPanel;

        private CommonTextBlockStyled warningTextBlock;
        private StackPanel mainStackPanel;
        private Grid mainGrid;

        #endregion

        public AboutProgramTab()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            tabAppearAnim = new TabAppearAnim(this);
            IsVisibleChanged += AboutProgramTab_IsVisibleChanged;

            titleTextBlock = new CommonTextBlockStyled()
            {
                Text = "О программе",
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            #region NameProgram

            nameProgramLocTextBlock = new CommonTextBlockStyled()
            {
                Text = "Название программы:"
            };
            nameProgramTextBlock = new CommonTextBlockStyled()
            {
                // TODO: Makss localize
                Text = "Привет, Иван!",
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

            nameBuildLocTextBlock = new CommonTextBlockStyled()
            {
                Text = "Название сборки:"
            };
            nameBuildTextBlock = new CommonTextBlockStyled()
            {
                Text = "HarmonyAssistant",
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

            versionLocTextBlock = new CommonTextBlockStyled()
            {
                Text = "Версия:"
            };
            versionTextBlock = new CommonTextBlockStyled()
            {
                Text = "0.1.0.0",
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

            authorsLocTextBlock = new CommonTextBlockStyled()
            {
                Text = "Авторы:"
            };

            makssAuthorTextBlock = new CommonTextBlockStyled()
            { 
                Text = "Makss (Широков Максим)",
                FontWeight = FontWeights.Bold
            };
            mrVeserAuthorTextBlock = new CommonTextBlockStyled()
            { 
                Text = "MrVeser (Кузнецов Виктор)",
                FontWeight = FontWeights.Bold
            };
            cripol1AuthorTextBlock = new CommonTextBlockStyled()
            { 
                Text = "Cripol1 (Инкин Максим)",
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

            downloadLinkLocTextBlock = new CommonTextBlockStyled()
            { Text = "Ссылка на скачивание:" };

            downloadHyperlink = new Hyperlink()
            { 
                NavigateUri = new Uri("https://clck.ru/335ThJ"),
                Foreground = Brushes.CornflowerBlue
            };
            downloadHyperlink.RequestNavigate += DownloadHyperlink_RequestNavigate;
            downloadHyperlink.Inlines.Add("https://clck.ru/335ThJ");

            downloadHyperlinkTextBlock = new CommonTextBlockStyled();
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


            githubLinkLocTextBlock = new CommonTextBlockStyled()
            { Text = "Ссылка на GitHub:" };

            githubHyperlink = new Hyperlink()
            { 
                NavigateUri = new Uri("https://clck.ru/35WELg"),
                Foreground = Brushes.CornflowerBlue
            };
            githubHyperlink.RequestNavigate += GithubHyperlink_RequestNavigate;
            githubHyperlink.Inlines.Add("https://clck.ru/35WELg");

            githubHyperlinkTextBlock = new CommonTextBlockStyled();
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
                Margin = new Thickness(15, 10, 15, 10)
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
            ScrollViewer scrollViewer = new ScrollViewer() { Style = svStyle["ScrollViewerStyle"] as Style };
            scrollViewer.Content = mainGrid;
            
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
