using HarmonyAssistant.UI.Widgets.Base;
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
        private ContentControl icon;

        private TextBlock titleTextBlock;
        private Border border1;
        Border border;

        public LeftPanelMenuButton(string text, ContentControl icon)
        {
            this.text = text;
            this.icon = icon;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Border iconBorder = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 36, 
                Height = 40,
                Background = Brushes.Transparent,
                Margin = new Thickness(10, 0, 0, 0),
                Child = icon,
            };
            Grid.SetColumn(iconBorder, 0);

            titleTextBlock = new TextBlock()
            {
                Text = text,
                FontFamily = new FontFamily("Candara"),
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.AliceBlue,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(20, 0, 0, 0)
            };

            border1 = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                BorderBrush = Brushes.Yellow,
                //BorderThickness = new Thickness(1)
            };
            border1.Child = titleTextBlock;
            border1.SizeChanged += Border1_SizeChanged;
            Grid.SetColumn(border1, 1);

            ColumnDefinition iconColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };
            
            ColumnDefinition titleColumnDefinition = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            Grid mainGrid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch
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
            this.MouseEnter += (s, e) => border.Background = new SolidColorBrush(new Color()
            { R = 13, G = 27, B = 42, A = 255 });
            this.MouseLeave += (s, e) => border.Background = Brushes.Transparent;

            Content = button;
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked?.Invoke(Tab);
        }

        private void Border1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //MessageBox.Show(border1.RenderSize.Width.ToString() + "\n" + titleTextBlock.DesiredSize.Width.ToString());

            if (border1.RenderSize.Width - 15 <= titleTextBlock.DesiredSize.Width)
                titleTextBlock.Visibility = Visibility.Collapsed;
            else titleTextBlock.Visibility = Visibility.Visible;
        }
    }
}
