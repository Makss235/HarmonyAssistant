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
        private Border openpanelborder;

        private ColumnDefinition leftColumn;
        private ColumnDefinition mainColumn;
        private Grid mainGrid;

        public LeftPanelMenu() 
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Border bordericon = new Border()
            {
                Background = new SolidColorBrush(new Color()
                { R = 1, G = 6, B = 108, A = 255 }),
                CornerRadius = new CornerRadius(13),
                Width = 26,
                Height = 26,
            };

            TButton button = new TButton()
            {
                Content = bordericon,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(14, 10, 0, 0)
            };
            button.SetValue(WindowChrome.IsHitTestVisibleInChromeProperty, true);
            button.Click += Button_Click;

            openpanelborder = new Border()
            {
                Width = 250,
                Background = Brushes.Transparent,
                VerticalAlignment = VerticalAlignment.Stretch,
                Visibility = Visibility.Collapsed,
            };
            Grid.SetColumn(openpanelborder, 0);
            Grid.SetColumnSpan(openpanelborder, 2);
            Grid.SetRow(openpanelborder, 1);

            Button button1 = new Button();
            button1.Height = 35;
            button1.HorizontalAlignment = HorizontalAlignment.Stretch;
            button1.Margin = new Thickness(7, 5, 7, 5);

            Button button12 = new Button();
            button12.Height = 35;
            button12.HorizontalAlignment = HorizontalAlignment.Stretch;
            button12.Margin = new Thickness(7, 5, 7, 5);

            Button button13 = new Button();
            button13.Height = 35;
            button13.HorizontalAlignment = HorizontalAlignment.Stretch;
            button13.Margin = new Thickness(7, 5, 7, 5);

            //Пример использования иконок
            ImageAwesome imageAwesome = new ImageAwesome()
            { Icon = FontAwesomeIcon.Google, Foreground = Brushes.AliceBlue };

            StackPanel stackPanel = new StackPanel()
            { 
                VerticalAlignment = VerticalAlignment.Center
            };
            stackPanel.Children.Add(button1);
            stackPanel.Children.Add(button12);
            stackPanel.Children.Add(button13);
            //stackPanel.Children.Add(imageAwesome);
            Grid.SetColumn(stackPanel, 0);
            Grid.SetRow(stackPanel, 1);

            leftColumn = new ColumnDefinition()
            { Width = new GridLength(50, GridUnitType.Pixel) };

            mainColumn = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };

            RowDefinition rowDefinition = new RowDefinition()
            { Height = new GridLength(40, GridUnitType.Pixel) };
            
            RowDefinition rowDefinition1 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Star) };

            mainGrid = new Grid();
            mainGrid.ColumnDefinitions.Add(leftColumn);
            mainGrid.ColumnDefinitions.Add(mainColumn);
            mainGrid.RowDefinitions.Add(rowDefinition);
            mainGrid.RowDefinitions.Add(rowDefinition1);
            mainGrid.Children.Add(button);
            mainGrid.Children.Add(openpanelborder);
            mainGrid.Children.Add(stackPanel);

            Content = mainGrid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (openpanelborder.Visibility == Visibility.Collapsed)
                openpanelborder.Visibility = Visibility.Visible;
            else openpanelborder.Visibility = Visibility.Collapsed;
        }
    }
}
