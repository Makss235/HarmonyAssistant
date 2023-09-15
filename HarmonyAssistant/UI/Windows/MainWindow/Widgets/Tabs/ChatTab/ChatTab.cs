using FontAwesome.WPF;
using HarmonyAssistant.Core.TTC;
using HarmonyAssistant.UI.Animations;
using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Widgets;
using HarmonyAssistant.UI.Widgets.Base;
using HarmonyAssistant.UI.Windows.MainWindow.Styles;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.Base;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tools;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.ChatTab
{
    public enum SendMessageBy
    {
        ByMe,
        ByBot
    }

    public class ChatTab : Tab
    {
        public ObservableCollection<Message> Messages;

        private TabAppearAnim tabAppearAnim;

        private ScrollViewer scrollViewer;
        private TextBox textBox;
        private Border border;
        private SendButton button;

        public ChatTab()
        {
            Messages = new ObservableCollection<Message>();
            StateManager.GetInstance().SpeechStateVerifiedEvent += (s) =>
                SendMessage(s, SendMessageBy.ByMe);
            SkillManager.GetInstance().AnswerPresenterChanged += (s) =>
                SendMessage(s, SendMessageBy.ByBot);

            InitializeComponent();
        }

        public void SendMessage(object content, SendMessageBy sendMessageBy)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(new Message(content, sendMessageBy));
                scrollViewer.ScrollToEnd();
            });
        }

        private void InitializeComponent()
        {
            tabAppearAnim = new TabAppearAnim(this);
            IsVisibleChanged += ChatTab_IsVisibleChanged;

            ItemsControl ic = new ItemsControl()
            {
                ItemsSource = Messages,
                Style = new ItemsControlStyle(),
                Margin = new Thickness(12)
            };

            ResourceDictionary svStyle = new ResourceDictionary()
            {
                Source =
                new Uri("pack://application:,,,/Data/Resources/ResourceDictionaries/ScrollViewerStyle.xaml",
                UriKind.RelativeOrAbsolute)
            };
            scrollViewer = new ScrollViewer()
            { Style = svStyle["ScrollViewerStyle"] as Style };
            scrollViewer.Content = ic;

            border = new Border()
            {
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0, 0, 0, 3),
                Child = scrollViewer,
            };
            Grid.SetColumn(border, 0);
            Grid.SetColumnSpan(border, 2);
            Grid.SetRow(border, 0);

            ThemeManager.AddResourceReference(border);
            border.SetResourceReference(Border.BorderBrushProperty,
                nameof(IAppBrushes.CommonBackgroundBrush));

            textBox = new TextBox()
            {
                Style = TextBlockStyles.CommonTextBlockStyle,
                BorderThickness = new Thickness(0),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Background = Brushes.Transparent,
                Margin = new Thickness(15, 5, 15, 5)
            };
            Grid.SetColumn(textBox, 0);
            Grid.SetRow(textBox, 1);

            ThemeManager.AddResourceReference(textBox);
            textBox.SetResourceReference(TextBoxBase.CaretBrushProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            button = new SendButton(35) 
            { 
                _SendButtonForm = SendButtonForm.plane
            };
            //button._SendButtonForm = SendButtonForm.plane;
            button.Click += Button_Click;
            Grid.SetColumn(button, 1);
            Grid.SetRow(button, 1);


            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(50, GridUnitType.Pixel) };

            RowDefinition rowDefinition = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            RowDefinition rowDefinition1 = new RowDefinition()
            { Height = new GridLength(50, GridUnitType.Pixel) };

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(columnDefinition);
            grid.ColumnDefinitions.Add(columnDefinition1);
            grid.RowDefinitions.Add(rowDefinition);
            grid.RowDefinitions.Add(rowDefinition1);
            grid.Children.Add(border);
            grid.Children.Add(textBox);
            grid.Children.Add(button);

            Content = grid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                SendMessage(textBox.Text, SendMessageBy.ByMe);
                SkillManager.GetInstance().DefineSkills(textBox.Text);
                textBox.Clear();
                button._SendButtonForm = SendButtonForm.plane;
            }
        }

        private void ChatTab_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
                tabAppearAnim.StartAnim();
        }
    }
}
