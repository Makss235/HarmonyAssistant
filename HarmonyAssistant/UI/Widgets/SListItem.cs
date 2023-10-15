using HarmonyAssistant.UI.Styles;
using HarmonyAssistant.UI.Styles.ContextMenuStyles;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Windows.MainWindow.Widgets.Tabs.SettingsTab;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Widgets
{
    public class SListItem : ContentControl
    {
#pragma warning disable CS8618

        public event Action<SListItem> ClickChange;
        public event Action<SListItem> ClickDelete;

        public static readonly DependencyProperty ContentListItemProperty =
                DependencyProperty.Register(
                        "ContentListItem",
                        typeof(object),
                        typeof(SListItem),
                        new FrameworkPropertyMetadata(
                                (object)null,
                                new PropertyChangedCallback(OnContentListItemChanged)));

        [Bindable(true)]
        public object ContentListItem
        {
            get { return GetValue(ContentListItemProperty); }
            set { SetValue(ContentListItemProperty, value); }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            border.BorderBrush = ThemeManager.CurrentTheme.MouseOverBrush;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            border.BorderBrush = Brushes.Transparent;
        }

        private static void OnContentListItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SListItem ctrl = (SListItem)d;

            ctrl.OnContentListItemChanged(e.OldValue, e.NewValue);
        }

        protected void OnContentListItemChanged(object? oldContent, object newContent)
        {
            ContentListItem = newContent;

            if (newContent.GetType() == typeof(string))
            {
                string newString = (string)newContent;
                textBlock.Text = newString;
                border.Child = textBlock;
            }
            else
            {
                contentPresenter.Content = newContent;
                border.Child = contentPresenter;
            }
        }

        private TextBlock textBlock;
        private ContentPresenter contentPresenter;
        private Border border;
        private object content;

        public SListItem()
        {
            InitializeComponent();
        }
        
        public SListItem(object content)
        {
            this.content = content;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            textBlock = new TextBlock()
            {
                Style = new CommonTextBlockStyle(),
                Margin = new Thickness(6, 2, 6, 2)
            };

            contentPresenter = new ContentPresenter()
            {
                Margin = new Thickness(6, 2, 6, 2)
            };

            border = new Border()
            {
                Child = textBlock,
                BorderBrush = Brushes.Transparent,
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(3),
                ContextMenu = CreateContextMenu()
            };

            ThemeManager.CurrentThemeChanged += () => border.ContextMenu = CreateContextMenu();

            if (content != null)
                OnContentListItemChanged(null, content);

            Content = border;
        }

        private ContextMenu CreateContextMenu()
        {
            MenuItem menuItem = new MenuItem()
            {
                Header = "Изменить",
                Style = new CommonContextMenuItemStyle()
            };
            menuItem.Click += (sender, args) => ClickChange?.Invoke(this);

            MenuItem menuItem1 = new MenuItem()
            {
                Header = "Удалить",
                Style = new CommonContextMenuItemStyle()
            };
            menuItem1.Click += (sender, args) => ClickDelete?.Invoke(this);

            ContextMenu menu = new ContextMenu()
            {
                Items = { menuItem, menuItem1 },
                Style = new CommonContextMenuStyle()
            };

            return menu;
        }
    }
}
