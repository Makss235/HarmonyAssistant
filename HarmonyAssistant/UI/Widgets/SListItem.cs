using HarmonyAssistant.UI.Styles;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HarmonyAssistant.UI.Widgets
{
    public class SListItem : ListBoxItem
    {
#pragma warning disable CS8618

        public static readonly DependencyProperty ContentListItemProperty =
                DependencyProperty.Register(
                        "ContentListItem",
                        typeof(object),
                        typeof(ContentControl),
                        new FrameworkPropertyMetadata(
                                (object)null,
                                new PropertyChangedCallback(OnContentListItemChanged)));

        [Bindable(true)]
        public object ContentListItem
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            border.Background = Brushes.AliceBlue;
        }
        
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            border.Background = Brushes.Transparent;
        }

        private static void OnContentListItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SListItem ctrl = (SListItem)d;

            ctrl.OnContentListItemChanged(e.OldValue, e.NewValue);
        }

        protected void OnContentListItemChanged(object oldContent, object newContent)
        {
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

        public SListItem()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            textBlock = new TextBlock();
            textBlock.Style = new CommonTextBlockStyle();

            contentPresenter = new ContentPresenter();

            border = new Border();
            //border.MouseEnter += Border_MouseEnter;
            //border.MouseLeave += Border_MouseLeave;
            border.Child = textBlock;

            Content = border;
        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var b = sender as Border;
            b.Background = Brushes.Transparent;
        }

        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var b = sender as Border;
            b.Background = Brushes.AliceBlue;
        }
    }
}
