using HarmonyAssistant.Data.DataSerialize.SerializeObjects;
using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Widgets;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System;

namespace HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab
{
    public class ProgramElement : ContentControl
    {
        private ProgramObject programObject;

        private AddButton addButton;
        private TextBox textBox;
        private Grid grid1;
        private AddButton addButtonAddNew;
        private AddButton addButtonAddNew1;
        private AddButton addButtonChange;
        private AddButton addButtonCancel;
        private AddButton addButtonCancel1;
        private TextBox textBox1;
        private TextBlock textBlock1;

        private SListItem current;

        public ObservableCollection<SListItem> sListItem;

        public ProgramElement(ProgramObject programObject)
        {
            this.programObject = programObject;

            sListItem = new ObservableCollection<SListItem>();
            foreach(string item in programObject.CallingNames)
            {
                var f = new SListItem(item);
                f.ClickChange += F_ClickChange;
                f.ClickDelete += F_ClickDelete;

                sListItem.Add(f);
            }

            InitializeComponent();
        }

        private void F_ClickDelete(SListItem obj)
        {
            sListItem.Remove(obj);
        }

        private void F_ClickChange(SListItem obj)
        {
            current = obj;
            ShowChange(obj.ContentListItem.ToString());
        }

        private void InitializeComponent()
        {
            ItemsControl itemsControl = new ItemsControl()
            {
                ItemsSource = sListItem
            };

            addButton = new AddButton(TypeButton.Add);
            addButton.Click += (s, e) => ShowAdd();
            Grid.SetColumnSpan(addButton, 3);

            textBox = new TextBox()
            {
                Background = Brushes.Transparent,
                Style = new CommonTextBlockStyle(),
                BorderThickness = new Thickness(0, 0, 0, 1),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(0, 5, 0, 0),
                Margin = new Thickness(5, 0, 5, 0)
            };
            ThemeManager.AddResourceReference(textBox);
            textBox.SetResourceReference(TextBox.CaretBrushProperty,
                nameof(IAppBrushes.CommonForegroundBrush));
            textBox.SetResourceReference(TextBox.BorderBrushProperty,
                nameof(IAppBrushes.CommonForegroundBrush));
            Grid.SetColumn(textBox, 0);

            addButtonAddNew = new AddButton(TypeButton.Add);
            addButtonAddNew.Click += AddButtonAddNew_Click;
            Grid.SetColumn(addButtonAddNew, 1);
            
            addButtonChange = new AddButton(TypeButton.Change);
            addButtonChange.Click += AddButtonChange_Click;
            Grid.SetColumn(addButtonChange, 1);

            addButtonCancel = new AddButton(TypeButton.Cancel);
            addButtonCancel.Click += (s, e) => HideAll();
            Grid.SetColumn(addButtonCancel, 2);

            HideAll();

            RowDefinition rowDefinition = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };

            ColumnDefinition columnDefinition2 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };
            
            ColumnDefinition columnDefinition3 = new ColumnDefinition()
            { Width = new GridLength(30, GridUnitType.Pixel) };
            
            ColumnDefinition columnDefinition4 = new ColumnDefinition()
            { Width = new GridLength(30, GridUnitType.Pixel) };

            grid1 = new Grid()
            {
                ColumnDefinitions = { columnDefinition2, columnDefinition3, columnDefinition4 },
                RowDefinitions = { rowDefinition },
                Children = { addButton, textBox, addButtonAddNew, addButtonChange, addButtonCancel },
            };

            StackPanel stackPanel = new StackPanel()
            {
                Children = { itemsControl, grid1 },
                Margin = new Thickness(0, 0, 5, 0)
            };
            Grid.SetColumn(stackPanel, 0);

            textBlock1 = new TextBlock()
            {
                Text = programObject.Path,
                Style = new CommonTextBlockStyle()
            };
            textBlock1.PreviewMouseLeftButtonUp += TextBlock1_PreviewMouseLeftButtonUp;
            Grid.SetColumn(textBlock1, 0);
            Grid.SetColumnSpan(textBlock1, 2);

            textBox1 = new TextBox()
            {
                Background = Brushes.Transparent,
                Style = new CommonTextBlockStyle(),
                BorderThickness = new Thickness(0, 0, 0, 1),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Padding = new Thickness(0, 5, 0, 0),
                Margin = new Thickness(-2, -5, 0, 0),
                Visibility = Visibility.Hidden,
            };
            ThemeManager.AddResourceReference(textBox1);
            textBox1.SetResourceReference(TextBox.CaretBrushProperty,
                nameof(IAppBrushes.CommonForegroundBrush));
            textBox1.SetResourceReference(TextBox.BorderBrushProperty,
                nameof(IAppBrushes.CommonForegroundBrush));
            Grid.SetColumn(textBox1, 0);
            Grid.SetColumnSpan(textBox1, 2);

            addButtonAddNew1 = new AddButton(TypeButton.Change)
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                Visibility = Visibility.Collapsed
            };
            addButtonAddNew1.Width = addButtonAddNew1.Height = 30;
            addButtonAddNew1.Click += AddButtonAddNew1_Click;
            Grid.SetColumn(addButtonAddNew1, 0);
            Grid.SetRow(addButtonAddNew1, 1);

            addButtonCancel1 = new AddButton(TypeButton.Cancel)
            {
                Visibility = Visibility.Collapsed,
            };
            addButtonCancel1.Width = addButtonCancel1.Height = 30;
            addButtonCancel1.Click += AddButtonCancel1_Click;
            Grid.SetColumn(addButtonCancel1, 1);
            Grid.SetRow(addButtonCancel1, 1);

            ColumnDefinition columnDefinition5 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };
            
            ColumnDefinition columnDefinition6 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Auto) };

            RowDefinition rowDefinition7 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };
            
            RowDefinition rowDefinition8 = new RowDefinition()
            { Height = new GridLength(1, GridUnitType.Auto) };

            Grid grid2 = new Grid()
            {
                ColumnDefinitions = { columnDefinition5, columnDefinition6 },
                RowDefinitions = { rowDefinition7, rowDefinition8 },
                Children = { textBlock1, textBox1, addButtonAddNew1, addButtonCancel1 },
                Margin = new Thickness(5, 0, 5, 0)
            };
            Grid.SetColumn(grid2, 1);

            Line line = new Line()
            {
                X1 = 0,
                Y1 = 0,
                X2 = 1000,
                Y2 = 0,
                StrokeThickness = 1,
                Opacity = 0.5,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(0, 0, 0, -8)
            };
            ThemeManager.AddResourceReference(line);
            line.SetResourceReference(Line.StrokeProperty,
                nameof(IAppBrushes.CommonForegroundBrush));
            Grid.SetColumnSpan(line, 2);

            ColumnDefinition columnDefinition = new ColumnDefinition()
            { Width = new GridLength(1.5, GridUnitType.Star) };

            ColumnDefinition columnDefinition1 = new ColumnDefinition()
            { Width = new GridLength(1, GridUnitType.Star) };

            Grid grid = new Grid()
            {
                ColumnDefinitions = { columnDefinition, columnDefinition1 },
                Children = { stackPanel, grid2, line },
                Margin = new Thickness(5, 0, 5, 13)
            };

            Content = grid;
        }

        private void AddButtonCancel1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();

            addButtonAddNew1.Visibility = Visibility.Collapsed;
            addButtonCancel1.Visibility = Visibility.Collapsed;
            textBox1.Visibility = Visibility.Hidden;
            textBlock1.Visibility = Visibility.Visible;
        }

        private void AddButtonAddNew1_Click(object sender, RoutedEventArgs e)
        {
            string text = textBox1.Text;
            if (string.IsNullOrEmpty(text)) return;

            textBlock1.Text = text;
            textBox1.Clear();

            addButtonAddNew1.Visibility = Visibility.Collapsed;
            addButtonCancel1.Visibility = Visibility.Collapsed;
            textBox1.Visibility = Visibility.Hidden;
            textBlock1.Visibility = Visibility.Visible;

            textBox1.Focus();
        }

        private void TextBlock1_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            textBox1.Text = textBlock1.Text;

            addButtonAddNew1.Visibility = Visibility.Visible;
            addButtonCancel1.Visibility = Visibility.Visible;
            textBox1.Visibility = Visibility.Visible;
            textBlock1.Visibility = Visibility.Hidden;
        }

        private void AddButtonChange_Click(object sender, RoutedEventArgs e)
        {
            string text = textBox.Text;
            if (string.IsNullOrEmpty(text)) return;

            current.ContentListItem = text;
            HideAll();
        }

        private void AddButtonAddNew_Click(object sender, RoutedEventArgs e)
        {
            string text = textBox.Text;
            if (string.IsNullOrEmpty(text)) return;
            if (programObject.CallingNames.Contains(text)) return;

            var f = new SListItem(text);
            f.ClickChange += F_ClickChange;
            f.ClickDelete += F_ClickDelete;
            sListItem.Add(f);

            HideAll();
        }

        private void HideAll()
        {
            textBox.Clear();

            textBox.Visibility = Visibility.Hidden;
            addButtonAddNew.Visibility = Visibility.Hidden;
            addButtonCancel.Visibility = Visibility.Hidden;
            addButtonChange.Visibility = Visibility.Hidden;

            addButton.Visibility = Visibility.Visible;
        }

        private void ShowAdd()
        {
            textBox.Clear();

            textBox.Visibility = Visibility.Visible;
            addButtonAddNew.Visibility = Visibility.Visible;
            addButtonCancel.Visibility = Visibility.Visible;
            addButtonChange.Visibility = Visibility.Hidden;

            addButton.Visibility = Visibility.Hidden;

            textBox.Focus();
        }

        private void ShowChange(string text)
        {
            textBox.Text = text;

            textBox.Visibility = Visibility.Visible;
            addButtonAddNew.Visibility = Visibility.Hidden;
            addButtonCancel.Visibility = Visibility.Visible;
            addButtonChange.Visibility = Visibility.Visible;

            addButton.Visibility = Visibility.Hidden;

            textBox.Focus();
        }
    }
}
