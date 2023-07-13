using Plants.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Plants.Converters
{
    internal class RoleToEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            User principal = value as User;
            if (principal != null)
            {
                return principal.UserRole.Name.Equals((string)parameter) ? true : false;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            User principal = value as User;
            if (principal != null)
            {
                return principal.UserRole.Name.Equals((string)parameter) ? false : true;
            }

            return false;
        }
    }
}
