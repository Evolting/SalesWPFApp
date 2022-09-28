using BusinessObject;
using SalesWPFApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowOrderDetail.xaml
    /// </summary>
    public partial class WindowOrderDetail : Window
    {
        public WindowOrderDetail(OrderObject o)
        {
            InitializeComponent();

            this.DataContext = new OrderDetailViewModel(o);
        }
    }
}
