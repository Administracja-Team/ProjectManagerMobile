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
    public class PriorityToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Priority priority)
            {
                return priority switch
                {
                    Priority.Low => Color.FromArgb("#55FF55"),    // Зеленый
                    Priority.Medium => Color.FromArgb("#FFFF55"), // Желтый
                    Priority.High => Color.FromArgb("#FF5555"),   // Красный
                    _ => Colors.Transparent
                };
            }
            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
