using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ProductObject
    {
        private int productId;
        private int categoryId;
        private string productName;
        private string weight;
        private decimal unitPrice;
        private int unitsInStock;

        public ProductObject(int productId, int categoryId, string productName, string weight, decimal unitPrice, int unitsInStock)
        {
            this.productId = productId;
            this.categoryId = categoryId;
            this.productName = productName;
            this.weight = weight;
            this.unitPrice = unitPrice;
            this.unitsInStock = unitsInStock;
        }

        public int ProductId { get => productId; set => productId = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string Weight { get => weight; set => weight = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int UnitsInStock { get => unitsInStock; set => unitsInStock = value; }
    }
}
