using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InteractiveCV.Converters
{
    public class ThresholdTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(string))
            {
                if (value is ThresholdTypes thresholdType)
                {
                    return thresholdType.ToString();
                }
                return string.Empty;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(ThresholdTypes))
            {
                if (value is string strValue)
                {
                    if (Enum.TryParse(typeof(ThresholdTypes), strValue, out object result))
                    {
                        return (ThresholdTypes)result;
                    }
                }
                return ThresholdTypes.Binary; // Default value if conversion fails
            }

            return null;
        }
    }
}
