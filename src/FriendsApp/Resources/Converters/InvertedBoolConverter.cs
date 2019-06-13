using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendsApp.Resources.Converters
{
    public class InvertedBoolConverter : IMarkupExtension, IValueConverter
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                throw new ArgumentException($"{nameof(InvertedBoolConverter)} : Value was null");
            }

            if (value is bool booleanValue)
            {
                return !booleanValue;
            }

            throw new ArgumentException($"{nameof(InvertedBoolConverter)} : Value is not bool");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}