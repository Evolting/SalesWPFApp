using AutoMapper;
using BusinessObject;
using DataAccess.Entity;
using DataAccess.Repository;
using SalesWPFApp.Ultility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SalesWPFApp.ViewModel
{
    public class OrderDetailViewModel
    {
        IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();

        private readonly ObservableCollection<OrderDetailObject> _orderDetails;

        public ObservableCollection<OrderDetailObject> OrderDetails => _orderDetails;

        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public OrderDetailViewModel(OrderObject o)
        {
            List<OrderDetail> orderDetailList = (List<OrderDetail>)orderDetailRepository.GetOrderDetailByID(o.OrderId);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            this._orderDetails = new ObservableCollection<OrderDetailObject>(orderDetailList.Select(mem => mapper.Map<OrderDetail, OrderDetailObject>(mem)));

            DeleteCommand = new RelayCommand<OrderDetailObject>(
                (od) => od != null, // CanExecute()
                (od) => removeOrderDetail(od, o.OrderId) // Execute()
            );
            AddCommand = new RelayCommand<OrderDetailObject>(
                (od) => true, // CanExecute()
                (od) => addOrderDetail(mapper.Map<OrderDetailObject, OrderDetail>(od), o.OrderId) // Execute()
            );
            UpdateCommand = new RelayCommand<OrderDetailObject>(
                (od) => true, // CanExecute()
                (od) => updateOrderDetail(mapper.Map<OrderDetailObject, OrderDetail>(od), o.OrderId) // Execute()
            );
        }

        private void updateOrderDetail(OrderDetail orderDetail, int id)
        {
            orderDetail.OrderId = id;

            orderDetailRepository.UpdateOrderDetail(orderDetail);
        }

        private void addOrderDetail(OrderDetail orderDetail, int id)
        {
            orderDetail.OrderId = id;

            orderDetailRepository.InsertOrderDetail(orderDetail);
        }

        private void removeOrderDetail(OrderDetailObject od, int id)
        {
            od.OrderId = id;

            OrderDetail odDel = orderDetailRepository.GetOrderDetailByID(od.OrderId, od.ProductId);
            orderDetailRepository.DeleteOrderDetail(odDel);
        }
    }
}
