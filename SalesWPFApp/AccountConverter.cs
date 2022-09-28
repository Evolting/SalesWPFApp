using BusinessObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SalesWPFApp
{
    internal class AccountConverter : IMultiValueConverter
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
            var mail = (string)values[0];
            var password = (string)values[1];

            Credential credential = new Credential();
            credential.Email = mail;
            credential.Password = password;

            return credential;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
