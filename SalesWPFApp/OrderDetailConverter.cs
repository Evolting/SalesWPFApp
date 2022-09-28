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
    internal class OrderDetailConverter : IMultiValueConverter
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
            var productId = (string)objects[0];
            var unitPrice = (string)values[1];
            var quantity = (string)values[2];
            var discount = (string)values[3];
            return new OrderDetailObject(0, Int32.Parse(productId), Decimal.Parse(unitPrice), Int32.Parse(quantity), float.Parse(discount));

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
