using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class ProductManagement
    {
        //---------------------------------------------------
        // Using Singleton Pattern
        private static ProductManagement instance = null;
        private static readonly object instanceLock = new object();
        private ProductManagement() { }
        public static ProductManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductManagement();
                    }
                    return instance;
                }
            }
        }

        //---------------------------------------------------
        public IEnumerable<Product> GetProductList()
        {
            List<Product> products;
            try
            {
                var context = new SalesManagementSystemContext();
                products = context.Products.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return products;
        }
        //---------------------------------------------------
        public Product GetProductByID(int productId)
        {
            Product product = null;
            try
            {
                var context = new SalesManagementSystemContext();
                product = context.Products.SingleOrDefault(product => product.ProductId == productId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return product;
        }
        //---------------------------------------------------
        public void AddNew(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product == null)
                {
                    var context = new SalesManagementSystemContext();
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //---------------------------------------------------
        public void Update(Product product)
        {
            try
            {
                Product c = GetProductByID(product.ProductId);
                if (c != null)
                {
                    var context = new SalesManagementSystemContext();
                    context.Entry<Product>(product).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product doesn't exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //---------------------------------------------------
        public void Remove(Product product)
        {
            try
            {
                Product _product = GetProductByID(product.ProductId);
                if (_product != null)
                {
                    var context = new SalesManagementSystemContext();
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The product doesn't exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
