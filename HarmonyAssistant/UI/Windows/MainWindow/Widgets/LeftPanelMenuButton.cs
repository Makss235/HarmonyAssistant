using FontAwesome.WPF;
using HarmonyAssistant.UI.Widgets.Base;
using HarmonyAssistant.UI.Windows.MainWindow.Styles;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets
{
    public class LeftPanelMenuButton : ContentControl
    {
        public Tab Tab { get; set; }

        public event Action<Tab> ButtonClicked;

        private string text;
        private ImageAwesome icon;

        private TextBlock titleTextBlock;
        private Border border1;
        Border border;

        public LeftPanelMenuButton(string text, ImageAwesome icon)
        {
            this.text = text;
            this.icon = icon;
            InitializeComponent();
        }

        public void OpenButton()
        {
            border1.Visibility = Visibility.Visible;
        }

        public void CloseButton()
        {
            border1.Visibility = Visibility.Collapsed;
        }

        private void InitializeComponent()
        {
            Border iconBorder = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 25,
                Width = 25,
                Background = Brushes.Transparent,
                Child = icon,
            };
            Grid.SetColumn(iconBorder, 0);

            titleTextBlock = new TextBlock()
            {
                Text = text,
                Style = TextBlocksStyles.textBlockStyle,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(20, 0, 0, 0)
            };

            border1 = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
            border1.Child = titleTextBlock;
            Grid.SetColumn(border1, 1);

            ColumnDefinition iconColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(36, GridUnitType.Pixel) };
            
            ColumnDefinition titleColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            Grid mainGrid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Height = 36
            };
            mainGrid.ColumnDefinitions.Add(iconColumnDefinition);
            mainGrid.ColumnDefinitions.Add(titleColumnDefinition);
            mainGrid.Children.Add(iconBorder);
            mainGrid.Children.Add(border1);

            border = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                CornerRadius = new CornerRadius(5),
            };
            border.Child = mainGrid;

            TButton button = new TButton();
            button.Click += Button_Click;
            //button.MouseEnter += Button_MouseEnter;
            //button.MouseLeave += Button_MouseLeave;
            button.Content = border;
            MouseEnter += (s, e) => border.Background = new SolidColorBrush(new Color()
            { R = 13, G = 27, B = 42, A = 255 });
            MouseLeave += (s, e) => border.Background = Brushes.Transparent;

            Content = button;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(Tab);
        }
    }
}
