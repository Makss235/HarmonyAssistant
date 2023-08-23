using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Diagnostics;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs
{
    public class AboutProgramTab : Tab
    {
        private Style styleTextBlock;

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
        private TextBlock flowenyAuthorTextBlock;
        private StackPanel authorsStackPanel1;
        private StackPanel authorsStackPanel;

        private TextBlock downloadLinkLocTextBlock;
        private Hyperlink downloadHyperlink;
        private TextBlock downloadHyperlinkTextBlock;
        private Label downloadQRLabel;
        private StackPanel downloadHyperlinkStackPanel;
        private TextBlock GitHubLinkLocTextBlock;
        private StackPanel linksStackPanel;

        private TextBlock warningTextBlock;
        private StackPanel mainStackPanel;
        private Grid mainGrid;

        public AboutProgramTab()
        {
            InitializeStyles();
            InitializeComponent();
        }

        private void InitializeStyles()
        {
            styleTextBlock = new Style(typeof(Tab));
            styleTextBlock.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)15));
            styleTextBlock.Setters.Add(new Setter(TextBlock.FontFamilyProperty, new FontFamily("Segoe UI Semibold")));
            styleTextBlock.Setters.Add(new Setter(TextBlock.TextWrappingProperty, TextWrapping.Wrap));
            Style = styleTextBlock;
        }

        private void InitializeComponent()
        {
            
        }

        private void DownloadHyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://goo.su/YCMpX2") { UseShellExecute = true });
        }
    }
}
