using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Widgets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class UserTable : ContentControl
    {
        public UserTable(Image userImage, string userName)
        {
            Ellipse userEllipse = new Ellipse()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Width = 75,
                Height = 75,
                StrokeThickness = 2,
                Stroke = Brushes.AliceBlue,
                Margin = new Thickness(10, 10, 7, 10)
            };
            Grid.SetColumn(userEllipse, 0);

            Grid.SetColumn(userImage, 0);

            TextBlock userNameTB = new TextBlock()
            {
                Text = userName,
                Style = new CommonTextBlockStyle(),
                Background = Brushes.Transparent
            };

            UserButton userButton = new UserButton();

            StackPanel sp = new StackPanel()
            {
                Orientation = Orientation.Vertical,
                Children = { userNameTB, userButton },
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10, 10, 7, 10),
            };
            Grid.SetColumn(sp, 1);

            ColumnDefinition leftColumnDfn = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };
            ColumnDefinition rightColumnDfn = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            Grid mainGrid = new Grid();
            mainGrid.ColumnDefinitions.Add(leftColumnDfn);
            mainGrid.ColumnDefinitions.Add(rightColumnDfn);
            mainGrid.Children.Add(userEllipse);
            mainGrid.Children.Add(userImage);
            mainGrid.Children.Add(sp);

            Content = mainGrid;
        }
    }

    public class UserButton : ContentControl
    {
        public UserButton()
        {
            Style ellipseST = new Style(targetType: typeof(Ellipse));
            ellipseST.Setters.Add(new Setter(Shape.StrokeProperty, Brushes.AliceBlue));
            ellipseST.Setters.Add(new Setter(Shape.FillProperty, Brushes.AliceBlue));
            ellipseST.Setters.Add(new Setter(WidthProperty, (double)7));
            ellipseST.Setters.Add(new Setter(HeightProperty, (double)7));
            ellipseST.Setters.Add(new Setter(MarginProperty, new Thickness(2.5, 0, 2.5, 0)));

            Ellipse circle1 = new Ellipse() { Style = ellipseST };
            Ellipse circle2 = new Ellipse() { Style = ellipseST };
            Ellipse circle3 = new Ellipse() { Style = ellipseST };


            StackPanel mainSP = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Children = { circle1, circle2, circle3 }
            };
            Border mainBorder = new Border()
            {
                CornerRadius = new CornerRadius(5),
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(1),
                Height = 25,
                Child = mainSP
            };
            mainBorder.MouseEnter += (s, e) => mainBorder.BorderBrush = Brushes.AliceBlue;
            mainBorder.MouseLeave += (s, e) => mainBorder.BorderBrush = Brushes.Transparent;

            ThemeManager.AddResourceReference(mainBorder);
            mainBorder.SetResourceReference(BackgroundProperty,
                nameof(IAppBrushes.TabBackgroundBrush));

            Content = mainBorder;
        }
    }
}
