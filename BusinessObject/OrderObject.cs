using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderObject
    {
        private int orderId;
        private int memberId;
        private DateTime orderDate;
        private DateTime requiredDate;
        private DateTime shippedDate;
        private decimal money;

        public int OrderId { get => orderId; set => orderId = value; }
        public int MemberId { get => memberId; set => memberId = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public DateTime RequiredDate { get => requiredDate; set => requiredDate = value; }
        public DateTime ShippedDate { get => shippedDate; set => shippedDate = value; }
        public decimal Money { get => money; set => money = value; }
    }
}
