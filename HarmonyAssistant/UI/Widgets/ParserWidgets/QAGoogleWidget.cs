using HarmonyAssistant.Core.Skills.InternetSkills.QuickAnswers.QuickAnswerGoogle;
using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using System.IO;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Windows.Media;
using System.Diagnostics;

namespace HarmonyAssistant.UI.Widgets.ParserWidgets
{
    public class QAGoogleWidget : ContentControl
    {
        public string Text { get; set; }

        protected QAGoogleParser qAGoogleParser;
        protected Style HeaderTextBlockStyle;

        public QAGoogleWidget(QAGoogleParser qAGoogleParser)
        {
            this.qAGoogleParser = qAGoogleParser;

            InitializeStyles();
            InitializeComponent();
        }

        protected virtual void InitializeStyles()
        {
            HeaderTextBlockStyle = new Style(
                targetType: typeof(TextBlock),
                basedOn: new CommonTextBlockStyle());
            HeaderTextBlockStyle.Setters.Add(new Setter(TextBlock.FontWeightProperty, FontWeights.Bold));
            HeaderTextBlockStyle.Setters.Add(new Setter(TextBlock.FontSizeProperty, (double)17));
        }

        private void InitializeComponent()
        {
            if (qAGoogleParser.QuickAnswerText != null)
            {
                var quickAnswerText = qAGoogleParser.QuickAnswerText;

                StackPanel stackPanel2 = new StackPanel();
                if (!string.IsNullOrEmpty(quickAnswerText.AnswerTitle))
                {
                    TextBlock mainTextBlock = new TextBlock()
                    {
                        Text = quickAnswerText.AnswerTitle,
                        Style = HeaderTextBlockStyle
                    };

                    stackPanel2.Children.Add(mainTextBlock);
                }

                if (!string.IsNullOrEmpty(quickAnswerText.Body))
                {
                    TextBlock textBlock1 = new TextBlock()
                    {
                        Text = quickAnswerText.Body,
                        Style = new CommonTextBlockStyle(),
                    };
                    ThemeManager.AddResourceReference(textBlock1);
                    textBlock1.SetResourceReference(TextBlock.ForegroundProperty,
                        nameof(IAppBrushes.CommonForegroundBrush));

                    if (!string.IsNullOrEmpty(quickAnswerText.AnswerTitle))
                        textBlock1.Margin = new Thickness(10, 0, 0, 0);

                        stackPanel2.Children.Add(textBlock1);
                }

                if (quickAnswerText.LinkGElement != null)
                {
                    var link = quickAnswerText.LinkGElement;

                    StackPanel stackPanel = new StackPanel()
                    { Margin = new Thickness(0, 15, 0, 0) };

                    StackPanel stackPanel1Site = new StackPanel()
                    { Margin = new Thickness(10, 0, 0, 0) };

                    if (!string.IsNullOrEmpty(link.SiteName))
                    {
                        TextBlock textBlock1 = new TextBlock()
                        {
                            Style = new CommonTextBlockStyle(),
                            Text = link.SiteName,
                            FontSize = 13
                        };
                        ThemeManager.AddResourceReference(textBlock1);
                        textBlock1.SetResourceReference(TextBlock.ForegroundProperty,
                            nameof(IAppBrushes.CommonForegroundBrush));
                        stackPanel1Site.Children.Add(textBlock1);
                    }

                    if (!string.IsNullOrEmpty(link.ArticlePathString))
                    {
                        TextBlock textBlock1 = new TextBlock()
                        {
                            Style = new CommonTextBlockStyle(),
                            Text = link.ArticlePathString,
                            Margin = new Thickness(0, -3, 0, 0),
                            FontSize = 12
                        };
                        ThemeManager.AddResourceReference(textBlock1);
                        textBlock1.SetResourceReference(TextBlock.ForegroundProperty,
                            nameof(IAppBrushes.CommonForegroundBrush));
                        stackPanel1Site.Children.Add(textBlock1);
                    }


                    string[] hh = link.IconSource.Split("base64,");
                    if (hh.Length == 2)
                    {
                        byte[] binaryData = Convert.FromBase64String(hh[1]);

                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = new MemoryStream(binaryData);
                        bi.EndInit();

                        Image img = new Image();
                        img.Source = bi;
                        //img.Width = 25;
                        img.Height = 25;

                        StackPanel stackPanel1icon = new StackPanel()
                        { Orientation = Orientation.Horizontal };
                        stackPanel1icon.Children.Add(img);

                        stackPanel1icon.Children.Add(stackPanel1Site);

                        stackPanel.Children.Add(stackPanel1icon);
                    }

                    if (!string.IsNullOrEmpty(link.ArticleTitle))
                    {
                        Hyperlink githubHyperlink = new Hyperlink()
                        {
                            NavigateUri = new Uri(link.SourceLink),
                            Style = new CommonTextBlockStyle(),
                            Foreground = Brushes.CornflowerBlue
                        };
                        githubHyperlink.RequestNavigate += (s, e) =>
                        Process.Start(new ProcessStartInfo(link.SourceLink) { UseShellExecute = true });
                        githubHyperlink.Inlines.Add(link.ArticleTitle);

                        TextBlock githubHyperlinkTextBlock = new TextBlock();
                        githubHyperlinkTextBlock.Inlines.Add(githubHyperlink);

                        stackPanel.Children.Add(githubHyperlinkTextBlock);
                    }
                    if (stackPanel.Children.Count > 0)
                        stackPanel2.Children.Add(stackPanel);
                }

                if (stackPanel2.Children.Count > 0)
                    Content = stackPanel2;
            }
        }
    }
}
