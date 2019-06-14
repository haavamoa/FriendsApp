using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendsApp.Resources.Converters
{
    public class InvertedBoolConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentException($"{nameof(InvertedBoolConverter)} input is null");
            }

            if (value is bool booleanValue)
            {
                return !booleanValue;
            }

            throw new ArgumentException($"{nameof(InvertedBoolConverter)} input is something else than bool");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("InvertedBoolConverter");
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}