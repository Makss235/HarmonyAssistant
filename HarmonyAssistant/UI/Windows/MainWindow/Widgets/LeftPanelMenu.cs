using AdvaDirectStorage.Widgets.Base;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shell;
using FontAwesome.WPF;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets
{
    public class LeftPanelMenu : ContentControl
    {
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

        public LeftPanelMenu() 
        {
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
                Content = iconBorder,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(14, 10, 0, 0)
            };
            iconButton.SetValue(WindowChrome.IsHitTestVisibleInChromeProperty, true);
            iconButton.Click += Button_Click;


            titleTextBlock = new TextBlock()
            {
                Text = "Привет, Иван!",
                FontFamily = new FontFamily("Candara"),
                FontSize = 17,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20, 5, 5, 7),
                Foreground = Brushes.AliceBlue
            };

            headerBorder = new Border()
            { Width = 200 };
            headerBorder.Child = titleTextBlock;
            Grid.SetColumn(headerBorder, 1);
            Grid.SetRow(headerBorder, 0);


            Button button1 = new Button();
            button1.Height = 35;
            button1.HorizontalAlignment = HorizontalAlignment.Stretch;
            button1.Margin = new Thickness(7, 5, 7, 5);

            Button button2 = new Button();
            button2.Height = 35;
            button2.HorizontalAlignment = HorizontalAlignment.Stretch;
            button2.Margin = new Thickness(7, 5, 7, 5);

            Button button3 = new Button();
            button3.Height = 35;
            button3.HorizontalAlignment = HorizontalAlignment.Stretch;
            button3.Margin = new Thickness(7, 5, 7, 5);

            menuButtonsStackPanel = new StackPanel()
            { 
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
            menuButtonsStackPanel.Children.Add(button1);
            menuButtonsStackPanel.Children.Add(button2);
            menuButtonsStackPanel.Children.Add(button3);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (headerBorder.Visibility == Visibility.Collapsed)
                headerBorder.Visibility = Visibility.Visible;
            else headerBorder.Visibility = Visibility.Collapsed;
        }
    }
}
