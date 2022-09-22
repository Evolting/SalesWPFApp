using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class OrderManagement
    {
        //---------------------------------------------------
        // Using Singleton Pattern
        private static OrderManagement instance = null;
        private static readonly object instanceLock = new object();
        private OrderManagement() { }
        public static OrderManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderManagement();
                    }
                    return instance;
                }
            }
        }

        //---------------------------------------------------
        public IEnumerable<Order> GetOrderList()
        {
            List<Order> orders;
            try
            {
                var context = new SalesManagementSystemContext();
                orders = context.Orders.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return orders;
        }
        //---------------------------------------------------
        public Order GetOrderByID(int orderId)
        {
            Order order = null;
            try
            {
                var context = new SalesManagementSystemContext();
                order = context.Orders.SingleOrDefault(order => order.OrderId == orderId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }
        //---------------------------------------------------
        public void AddNew(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if (_order == null)
                {
                    var context = new SalesManagementSystemContext();
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //---------------------------------------------------
        public void Update(Order order)
        {
            try
            {
                Order c = GetOrderByID(order.OrderId);
                if (c != null)
                {
                    var context = new SalesManagementSystemContext();
                    context.Entry<Order>(order).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order doesn't exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //---------------------------------------------------
        public void Remove(Order order)
        {
            try
            {
                Order _order = GetOrderByID(order.OrderId);
                if (_order != null)
                {
                    var context = new SalesManagementSystemContext();
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The order doesn't exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
