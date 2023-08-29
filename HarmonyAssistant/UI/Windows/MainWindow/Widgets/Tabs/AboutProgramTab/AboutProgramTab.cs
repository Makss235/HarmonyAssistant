using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.AboutProgramTab
{
    public class AboutProgramTab : Tab
    {
        private Style styleTextBlock;

        #region UI Elements
        private TextBlock titleTextBlock;

        private TextBlock nameProgramLocTextBlock;
        private TextBlock nameProgramTextBlock;
        private StackPanel nameProgramStackPanel;

        private TextBlock nameBuildLocTextBlock;
        private TextBlock nameBuildTextBlock;
        private StackPanel nameBuildStackPanel;

        private TextBlock versionLocTextBlock;
        private TextBlock versionTextBlock;
        private StackPanel versionStackPanel;

        private TextBlock authorsLocTextBlock;
        private TextBlock makssAuthorTextBlock;
        private TextBlock mrVeserAuthorTextBlock;
        private TextBlock cripol1AuthorTextBlock;
        private StackPanel authorsStackPanel1;
        private StackPanel authorsStackPanel;

        private TextBlock downloadLinkLocTextBlock;
        private Hyperlink downloadHyperlink;
        private TextBlock downloadHyperlinkTextBlock;
        private Label downloadQRLabel;
        private StackPanel downloadHyperlinkStackPanel;
        private TextBlock GitHubLinkLocTextBlock;
        //private StackPanel linksStackPanel;

        private TextBlock warningTextBlock;
        private StackPanel mainStackPanel;
        private Grid mainGrid;
        #endregion

        public AboutProgramTab()
        {
            InitializeStyles();
            InitializeComponent();
        }

        private void InitializeStyles()
        {
            styleTextBlock = new Style(typeof(Tab));
            styleTextBlock.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)17));
            styleTextBlock.Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Cambria")));
            styleTextBlock.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
            styleTextBlock.Setters.Add(new Setter(TextBlock.ForegroundProperty, Brushes.AliceBlue));
            styleTextBlock.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.Bold));
            Style = styleTextBlock;
        }

        private void InitializeComponent()
        {
            titleTextBlock = new TextBlock()
            {
                Text = "О программе",
                FontSize = 20,
                Margin = new Thickness(0, 15, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            #region NameProgram

            nameProgramLocTextBlock = new TextBlock()
            {
                Text = "Название программы:"
            };
            nameProgramTextBlock = new TextBlock()
            {
                // TODO: Makss localize
                Text = "Привет, Иван!",
                Margin = new Thickness(10, 0, 0, 0)
            };

            nameProgramStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            nameProgramStackPanel.Children.Add(nameProgramLocTextBlock);
            nameProgramStackPanel.Children.Add(nameProgramTextBlock);

            #endregion

            #region NameBuild

            nameBuildLocTextBlock = new TextBlock()
            {
                Text = "Название сборки:"
            };
            nameBuildTextBlock = new TextBlock()
            {
                Text = "HarmonyAssistant",
                Margin = new Thickness(10, 0, 0, 0)
            };

            nameBuildStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            nameBuildStackPanel.Children.Add(nameBuildLocTextBlock);
            nameBuildStackPanel.Children.Add(nameBuildTextBlock);

            #endregion

            #region Version

            versionLocTextBlock = new TextBlock()
            {
                Text = "Версия:"
            };
            versionTextBlock = new TextBlock()
            {
                Text = "0.0.2.1",
                Margin = new Thickness(10, 0, 0, 0)
            };

            versionStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            versionStackPanel.Children.Add(versionLocTextBlock);
            versionStackPanel.Children.Add(versionTextBlock);

            #endregion

            #region Authors

            authorsLocTextBlock = new TextBlock()
            {
                Text = "Авторы:"
            };

            makssAuthorTextBlock = new TextBlock()
            { Text = "Makss (Широков Максим)" };
            mrVeserAuthorTextBlock = new TextBlock()
            { Text = "MrVeser (Кузнецов Виктор)" };
            cripol1AuthorTextBlock = new TextBlock()
            { Text = "Cripol1 (Инкин Максим)" };

            authorsStackPanel1 = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(10, 0, 0, 0),
            };
            authorsStackPanel1.Children.Add(makssAuthorTextBlock);
            authorsStackPanel1.Children.Add(mrVeserAuthorTextBlock);
            authorsStackPanel1.Children.Add(cripol1AuthorTextBlock);

            authorsStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0),
            };
            authorsStackPanel.Children.Add(authorsLocTextBlock);
            authorsStackPanel.Children.Add(authorsStackPanel1);

            #endregion

            #region Links

            downloadLinkLocTextBlock = new TextBlock()
            {
                Text = "Ссылка на скачивание"
            };
            downloadHyperlink = new Hyperlink()
            {
                NavigateUri = new Uri("https://goo.su/YCMpX2")
            };
            downloadHyperlink.RequestNavigate += DownloadHyperlink_RequestNavigate;
            downloadHyperlink.Inlines.Add("https://goo.su/YCMpX2");

            downloadHyperlinkTextBlock = new TextBlock();
            downloadHyperlinkTextBlock.Inlines.Add(downloadHyperlink);

            //GitHubLinkLocTextBlock = new TextBlock()
            //{
            //    //Text = loc.GitHubLinkLoc,
            //    TextAlignment = TextAlignment.Left,
            //    Margin = new Thickness(25, 10, 0, 0),
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //    VerticalAlignment = VerticalAlignment.Top,
            //    Width = 300,
            //    TextWrapping = TextWrapping.Wrap
            //};

            //linksStackPanel = new StackPanel()
            //{ Orientation = Orientation.Horizontal };
            //linksStackPanel.Children.Add(downloadHyperlinkStackPanel);
            //linksStackPanel.Children.Add(GitHubLinkLocTextBlock);

            #endregion

            downloadQRLabel = new Label()
            {
                Content = new Image()
                {
                    Source = new BitmapImage(
                    new Uri("pack://application:,,,/Resources/QRDownload.png",
                    UriKind.RelativeOrAbsolute))
                },
                Width = 150,
                Height = 150,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };

            downloadHyperlinkStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(0, 10, 0, 0),
            };
            downloadHyperlinkStackPanel.Children.Add(downloadLinkLocTextBlock);
            downloadHyperlinkStackPanel.Children.Add(downloadHyperlinkTextBlock);
            downloadHyperlinkStackPanel.Children.Add(downloadQRLabel);

            GitHubLinkLocTextBlock = new TextBlock()
            {
                //Text = loc.GitHubLinkLoc,
                TextAlignment = TextAlignment.Left,
                Margin = new Thickness(25, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 300,
                TextWrapping = TextWrapping.Wrap
            };

            linksStackPanel = new StackPanel()
            { Orientation = Orientation.Horizontal };
            linksStackPanel.Children.Add(downloadHyperlinkStackPanel);
            linksStackPanel.Children.Add(GitHubLinkLocTextBlock);

            #endregion

            warningTextBlock = new TextBlock()
            {
                //Text = loc.WarningLoc,
                TextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                TextWrapping = TextWrapping.Wrap
            };

            mainStackPanel = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(20, 0, 20, 10)
            };
            mainStackPanel.Children.Add(titleTextBlock);
            mainStackPanel.Children.Add(nameProgramStackPanel);
            mainStackPanel.Children.Add(nameBuildStackPanel);
            mainStackPanel.Children.Add(versionStackPanel);
            mainStackPanel.Children.Add(authorsStackPanel);
            mainStackPanel.Children.Add(linksStackPanel);
            mainStackPanel.Children.Add(warningTextBlock);

            //SButton a = new SButton{ 
            //    Width = 50, 
            //    Height = 50, 
            //    ButContent = "MyGegg", 
            //    ButBackground = Brushes.Green, 
            //    ButCornerRadius = new CornerRadius(10) 
            //};

            mainGrid = new Grid();
            mainGrid.Children.Add(mainStackPanel);
            //mainGrid.Children.Add(a);
            Content = mainGrid;
        }

        private void DownloadHyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://goo.su/YCMpX2") { UseShellExecute = true });
        }
    }
}
