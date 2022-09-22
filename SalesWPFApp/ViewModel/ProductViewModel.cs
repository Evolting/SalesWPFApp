using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessObject;
using DataAccess.Entity;
using DataAccess.Repository;

namespace SalesWPFApp.ViewModel
{
    public class ProductViewModel
    {
        IProductRepository productRepository = new ProductRepository();

        private readonly ObservableCollection<ProductObject> _products;

        public ObservableCollection<ProductObject> Products => _products;

        public ProductViewModel()
        {
            List<Product> productList = (List<Product>)productRepository.GetProducts();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            this._products = new ObservableCollection<ProductObject>(productList.Select(mem => mapper.Map<Product, ProductObject>(mem)));
        }
    }
}
