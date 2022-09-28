using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderDetailObject
    {
        private int orderId;
        private int productId;
        private decimal unitPrice;
        private int quantity;
        private float discount;

        public OrderDetailObject(int orderId, int productId, decimal unitPrice, int quantity, float discount)
        {
            this.orderId = orderId;
            this.productId = productId;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
            this.discount = discount;
        }

        public int OrderId { get => orderId; set => orderId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Discount { get => discount; set => discount = value; }
    }
}
