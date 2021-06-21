using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Desktop.Infrastructure.Converters
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = DateTime.Parse(value.ToString());
            if (date == new DateTime())
            {
                return "Отсутствует";
            }
            else
            {
                if (date.Hour == 0 && date.Minute == 0 && date.Second == 0)
                {
                    return date.ToString("dd.MM.yyyy");
                }
                else
                {
                    return date.ToString("dd.MM.yyyy HH:mm:ss");
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var date = DateTime.Parse(value.ToString());
                if(date > DateTime.UtcNow)
                {
                    return date;
                }
                else
                {
                    return DependencyProperty.UnsetValue;
                } 
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
