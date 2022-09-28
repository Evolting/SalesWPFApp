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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {
            WindowMembers wdMembers = new WindowMembers();

            wdMembers.ShowDialog();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowProducts wdProducts = new WindowProducts();

            wdProducts.ShowDialog();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowOrders wdOrders = new WindowOrders();

            wdOrders.ShowDialog();
        }

        private void btnStatistic_Click(object sender, RoutedEventArgs e)
        {
            WindowStatistic wdStatistic = new WindowStatistic();

            wdStatistic.ShowDialog();
        }
    }
}
