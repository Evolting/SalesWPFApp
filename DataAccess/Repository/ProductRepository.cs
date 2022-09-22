using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product product) => ProductManagement.Instance.Remove(product);

        public Product GetProductByID(int productID) => ProductManagement.Instance.GetProductByID(productID);

        public IEnumerable<Product> GetProducts() => ProductManagement.Instance.GetProductList();

        public void InsertProduct(Product product) => ProductManagement.Instance.AddNew(product);
        public void UpdateProduct(Product product) => ProductManagement.Instance.Update(product);
    }
}
