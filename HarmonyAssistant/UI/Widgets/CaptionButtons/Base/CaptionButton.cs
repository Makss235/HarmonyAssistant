using HarmonyAssistant.UI.Themes.AppBrushes.Base;
using HarmonyAssistant.UI.Themes;
using HarmonyAssistant.UI.Widgets.Base;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;

namespace HarmonyAssistant.UI.Widgets.CaptionButtons.Base
{
    public class CaptionButton : ContentControl, INotifyPropertyChanged
    {
        #region NPC

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            //if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        #endregion

        #region Background

        private Brush _Background;

        public new Brush Background
        {
            get => _Background;
            set => SetProperty(ref _Background, value);
        }

        #endregion

        #region Icon

        private ContentControl _Icon;

        public ContentControl Icon
        {
            get => _Icon;
            set => SetProperty(ref _Icon, value);
        }

        #endregion

        public event RoutedEventHandler Click;
        public new event MouseButtonEventHandler PreviewMouseLeftButtonDown;

        private Border border;
        private TButton button;

        public CaptionButton(ContentControl icon)
        {
            Icon = icon;
            PropertyChanged += CaptionButton_PropertyChanged;

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Icon.HorizontalAlignment = HorizontalAlignment.Center;
            Icon.VerticalAlignment = VerticalAlignment.Center;

            ThemeManager.AddResourceReference(Icon);
            Icon.SetResourceReference(BackgroundProperty,
                nameof(IAppBrushes.CommonForegroundBrush));

            border = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Background = Brushes.Transparent
            };
            border.Child = Icon;

            button = new TButton()
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch
            };
            button.Click += (s, e) => Click?.Invoke(s, e);
            button.PreviewMouseLeftButtonDown += (s, e) => 
            PreviewMouseLeftButtonDown?.Invoke(s, e);
            button.Content = border;

            SetValue(WindowChrome.IsHitTestVisibleInChromeProperty, true);
            Content = button;
        }

        private void CaptionButton_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Background):
                    border.Background = Background;
                    break;
                case nameof(Icon):
                    border.Child = Icon;
                    break;
                default:
                    break;
            }
        }
    }
}
