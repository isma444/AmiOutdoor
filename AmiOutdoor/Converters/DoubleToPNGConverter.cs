using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace AmiOutdoor.Converters
{
    public class DoubleToPNGConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double valueRainAsDouble = (double)values[0];
            double valueNebulositeAsDouble = (double)values[1];
            if (valueRainAsDouble > 0)
            {
                return new BitmapImage(new Uri("pack://application:,,,/Images/rain.png"));
            }
            else
            {
                if (valueNebulositeAsDouble == 0)
                {
                    return new BitmapImage(new Uri("pack://application:,,,/Images/cloud.png"));
                }
                else if (valueNebulositeAsDouble == 8)
                {
                    return new BitmapImage(new Uri("pack://application:,,,/Images/sun.png"));
                }
                else
                {
                    return new BitmapImage(new Uri("pack://application:,,,/Images/cloudy.png"));
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
