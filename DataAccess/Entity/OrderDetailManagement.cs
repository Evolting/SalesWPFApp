using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class OrderDetailManagement
    {
        //---------------------------------------------------
        // Using Singleton Pattern
        private static OrderDetailManagement instance = null;
        private static readonly object instanceLock = new object();
        private OrderDetailManagement() { }
        public static OrderDetailManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailManagement();
                    }
                    return instance;
                }
            }
        }

        //---------------------------------------------------
        public IEnumerable<OrderDetail> GetOrderDetailList()
        {
            List<OrderDetail> orderDetails;
            try
            {
                var context = new SalesManagementSystemContext();
                orderDetails = context.OrderDetails.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return orderDetails;
        }
        //---------------------------------------------------
        public OrderDetail GetOrderDetailByID(int orderId, int productId)
        {
            OrderDetail orderDetail = null;
            try
            {
                var context = new SalesManagementSystemContext();
                orderDetail = context.OrderDetails.SingleOrDefault(orderDetail => orderDetail.OrderId == orderId && orderDetail.ProductId == productId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderDetail;
        }
        //---------------------------------------------------
        public void AddNew(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId);
                if (_orderDetail == null)
                {
                    var context = new SalesManagementSystemContext();
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The orderDetail is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //---------------------------------------------------
        public void Update(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail c = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId);
                if (c != null)
                {
                    var context = new SalesManagementSystemContext();
                    context.Entry<OrderDetail>(orderDetail).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The orderDetail doesn't exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //---------------------------------------------------
        public void Remove(OrderDetail orderDetail)
        {
            try
            {
                OrderDetail _orderDetail = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId);
                if (_orderDetail != null)
                {
                    var context = new SalesManagementSystemContext();
                    context.OrderDetails.Remove(orderDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The orderDetail doesn't exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
