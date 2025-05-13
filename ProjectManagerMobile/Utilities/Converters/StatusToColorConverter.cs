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
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TaskStatus status)
            {
                return status switch
                {
                    TaskStatus.TODO => Color.FromArgb("#2196F3"), // Blue for TODO
                    TaskStatus.IN_PROGRESS => Color.FromArgb("#FFC107"), // Yellow for IN_PROGRESS
                    TaskStatus.DONE => Color.FromArgb("#4CAF50"), // Green for DONE
                    _ => Colors.Transparent // Fallback
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
