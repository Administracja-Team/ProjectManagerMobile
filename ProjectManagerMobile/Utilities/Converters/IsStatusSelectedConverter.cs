using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagerMobile.ViewModels;
using TaskStatus = ProjectManagerMobile.ViewModels.TaskStatus;

namespace ProjectManagerMobile.Utilities.Converters
{
    public class IsStatusSelectedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TaskStatus selectedStatus && parameter is string statusString)
            {
                if (Enum.TryParse<TaskStatus>(statusString, out var buttonStatus))
                {
                    return selectedStatus == buttonStatus;
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
