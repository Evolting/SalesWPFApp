using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(Order order) => OrderManagement.Instance.Remove(order);

        public Order GetOrderByID(int orderID) => OrderManagement.Instance.GetOrderByID(orderID);

        public IEnumerable<Order> GetOrders() => OrderManagement.Instance.GetOrderList();

        public void InsertOrder(Order order) => OrderManagement.Instance.AddNew(order);

        public void UpdateOrder(Order order) => OrderManagement.Instance.Update(order);
    }
}
