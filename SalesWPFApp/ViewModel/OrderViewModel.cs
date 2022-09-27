using AutoMapper;
using BusinessObject;
using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SalesWPFApp.ViewModel
{
    public class OrderViewModel
    {
        IOrderRepository orderRepository = new OrderRepository();

        private readonly ObservableCollection<OrderObject> _orders;

        public ObservableCollection<OrderObject> Orders => _orders;

        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public OrderViewModel()
        {
            List<Order> orderList = (List<Order>)orderRepository.GetOrders();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            this._orders = new ObservableCollection<OrderObject>(orderList.Select(mem => mapper.Map<Order, OrderObject>(mem)));
        }
    }
}
