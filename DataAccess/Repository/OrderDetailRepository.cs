using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void DeleteOrderDetail(OrderDetail orderDetail) => OrderDetailManagement.Instance.Remove(orderDetail);

        public OrderDetail GetOrderDetailByID(int orderID, int productID) => OrderDetailManagement.Instance.GetOrderDetailByID(orderID, productID);

        public IEnumerable<OrderDetail> GetOrderDetailByID(int orderID) => OrderDetailManagement.Instance.GetOrderDetailByID(orderID);

        public IEnumerable<OrderDetail> GetOrderDetails() => OrderDetailManagement.Instance.GetOrderDetailList();

        public void InsertOrderDetail(OrderDetail orderDetail) => OrderDetailManagement.Instance.AddNew(orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail) => OrderDetailManagement.Instance.Update(orderDetail);
    }
}
