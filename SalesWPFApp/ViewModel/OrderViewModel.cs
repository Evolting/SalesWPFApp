using AutoMapper;
using AutoMapper.Execution;
using BusinessObject;
using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SalesWPFApp.ViewModel
{
    public class OrderViewModel
    {
        IOrderRepository orderRepository = new OrderRepository();

        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();

        private readonly ObservableCollection<OrderObject> _orders;

        public ObservableCollection<OrderObject> Orders => _orders;

        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DetailCommand { get; set; }

        public OrderViewModel()
        {
            List<Order> orderList = (List<Order>)orderRepository.GetOrders();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            this._orders = new ObservableCollection<OrderObject>(orderList.Select(mem => mapper.Map<Order, OrderObject>(mem)));

            DeleteCommand = new RelayCommand<OrderObject>(
                (o) => o != null, // CanExecute()
                (o) => removeOrder(o) // Execute()
            );
            AddCommand = new RelayCommand<OrderObject>(
                (o) => true, // CanExecute()
                (o) => addOrder(mapper.Map<OrderObject, Order>(o)) // Execute()
            );
            UpdateCommand = new RelayCommand<OrderObject>(
                (o) => true, // CanExecute()
                (o) => updateOrder(mapper.Map<OrderObject, Order>(o)) // Execute()
            );
            DetailCommand = new RelayCommand<OrderObject>(
                (o) =>  true, // CanExecute()
                (o) => seeDetail(o) // Execute()
            );
        }

        private void seeDetail(OrderObject o)
        {
            WindowOrderDetail wdOrderDetail = new WindowOrderDetail(o);
            wdOrderDetail.ShowDialog();
        }

        private void updateOrder(Order order)
        {
            orderRepository.UpdateOrder(order);
        }

        private void addOrder(Order order)
        {
            orderRepository.InsertOrder(order);
        }

        private void removeOrder(OrderObject o)
        {
            Order order = orderRepository.GetOrderByID(o.OrderId);

            orderRepository.DeleteOrder(order);
        }
    }
}
