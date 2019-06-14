using System;
using System.Globalization;
using FriendsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendsApp.Resources.Converters
{
    public class FriendViewModelToColorConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is FriendViewModel friendViewModel)
                {
                    if (friendViewModel.Name.Contains("H"))
                    {
                        return Color.FromHex("#FA9A85");
                    }
                    return Color.FromHex("#FFFFFF");
                }
            }

            throw new ArgumentException("Something wrong with the argument");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}