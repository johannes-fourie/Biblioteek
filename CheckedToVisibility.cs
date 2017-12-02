using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Biblioteek
{
    public class CheckedToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                throw new InvalidCastException("CheckedToVisibility can only convert bool to Visibility");

            var isChecked = (bool)value;

            return isChecked ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}