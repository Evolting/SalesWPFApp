using BusinessObject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SalesWPFApp
{
    internal class OrderConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == null || values[i].Equals(""))
                {
                    return null;
                }
            }
            var objects = (object[])values;
            var orderId = (string)objects[0];
            var memberId = (string)values[1];
            var orderDate = (DateTime)values[2];
            var requiredDate = (DateTime)values[3];
            var shippedDate = (DateTime)values[4];
            var freight = (string)values[5];
            return new OrderObject(Int32.Parse(orderId), Int32.Parse(memberId), orderDate, requiredDate, shippedDate, Decimal.Parse(freight));

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
