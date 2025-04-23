using ProjectManagerMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectManagerMobile.ViewModels.CreateTaskViewModel;

namespace ProjectManagerMobile.Utilities.Converters
{
    public class IsPrioritySelectedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Priority selectedPriority && parameter is string priorityString)
            {
                if (Enum.TryParse<Priority>(priorityString, true, out var priority))
                {
                    return selectedPriority == priority;
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
