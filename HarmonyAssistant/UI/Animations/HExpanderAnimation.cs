using System.Globalization;
using System.Windows.Data;
using System;
using System.Windows.Media.Animation;
using System.Windows.Controls;

namespace HarmonyAssistant.UI.Animations
{
    public class HExpanderAnimation : DoubleAnimation
    {
        ContentPresenter contentPresenter;
        public HExpanderAnimation(ContentPresenter contentPresenter)
        {
            this.contentPresenter = contentPresenter;
            InitializeAnimations();
        }

        private void InitializeAnimations()
        {
            From = 0;
            To = 1;
            Duration = TimeSpan.FromSeconds(1);
        }

        public void StartAnim()
        {
            contentPresenter.BeginAnimation(ContentPresenter.TagProperty, this);
        }
    }

    public class MultiplyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
               object parameter, CultureInfo culture)
        {
            double result = 1.0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] is double)
                    result *= (double)values[i];
            }

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
               object parameter, CultureInfo culture)
        {
            throw new Exception("Not implemented");
        }
    }
}
