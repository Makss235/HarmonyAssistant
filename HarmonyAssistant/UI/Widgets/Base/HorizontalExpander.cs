using System;
using System.Windows;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Widgets.Base
{
    public abstract class HorizontalExpander : ContentControl
    {
        public static readonly DependencyProperty HeaderContentProperty;

        public object HeaderContent
        {
            get { return GetValue(HeaderContentProperty); }
            set { SetValue(HeaderContentProperty, value); }
        }

        public static readonly DependencyProperty BodyContentProperty;

        public object BodyContent
        {
            get { return GetValue(BodyContentProperty); }
            set { SetValue(BodyContentProperty, value); }
        }

        public static readonly DependencyProperty IsExpandedProperty;

        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set { SetValue(IsExpandedProperty, value); }
        }

        static HorizontalExpander()
        {
            HeaderContentProperty = DependencyProperty.Register(
                    "HeaderContent",
                    typeof(object),
                    typeof(HorizontalExpander),
                    new FrameworkPropertyMetadata(
                        null,
                        FrameworkPropertyMetadataOptions.AffectsMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnHeaderContentChanged)));

            BodyContentProperty = DependencyProperty.Register(
                    "BodyContent",
                    typeof(object),
                    typeof(HorizontalExpander),
                    new FrameworkPropertyMetadata(
                        null,
                        FrameworkPropertyMetadataOptions.AffectsMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnBodyContentChanged)));

            IsExpandedProperty = DependencyProperty.Register(
                    "IsExpanded",
                    typeof(bool),
                    typeof(HorizontalExpander),
                    new FrameworkPropertyMetadata(
                        false,
                        FrameworkPropertyMetadataOptions.AffectsMeasure |
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnIsExpandedChanged)));
        }

        protected static void OnHeaderContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HorizontalExpander horizontalExpander = (HorizontalExpander)d;
            horizontalExpander.OnHeaderContentChanged(e);
        }

        protected virtual void OnHeaderContentChanged(DependencyPropertyChangedEventArgs e)
        {
            
        }

        protected static void OnBodyContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HorizontalExpander horizontalExpander = (HorizontalExpander)d;
            horizontalExpander.OnBodyContentChanged(e);
        }

        protected virtual void OnBodyContentChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        private static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HorizontalExpander horizontalExpander = (HorizontalExpander)d;
            horizontalExpander.OnIsExpandedChanged(e);
        }

        protected virtual void OnIsExpandedChanged(DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
