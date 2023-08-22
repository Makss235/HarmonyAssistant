using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets
{
    public class LeftPanelMenuButton : ContentControl
    {
        private string text;
        private Grid image;

        private TextBlock titleTextBlock;
        private Border border1;

        public LeftPanelMenuButton(string text/*, Grid image*/)
        {
            this.text = text;
            //this.image = image;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Border iconBorder = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 36, 
                Height = 36,
                Background = Brushes.White
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
                BorderBrush = Brushes.White,
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

            Border border = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch
            };
            border.Child = mainGrid;


            Content = border;
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
