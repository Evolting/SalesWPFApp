using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using BusinessObject;
using DataAccess.Entity;
using DataAccess.Repository;
using SalesWPFApp.Ultility;

namespace SalesWPFApp.ViewModel
{
    public class ProductViewModel
    {
        IProductRepository productRepository = new ProductRepository();

        private readonly ObservableCollection<ProductObject> _products;

        public ObservableCollection<ProductObject> Products => _products;

        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }

        public ProductViewModel()
        {
            List<Product> productList = (List<Product>)productRepository.GetProducts();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            this._products = new ObservableCollection<ProductObject>(productList.Select(mem => mapper.Map<Product, ProductObject>(mem)));

            DeleteCommand = new RelayCommand<ProductObject>(
                (p) => true, // CanExecute()
                (p) => removeProduct(p) // Execute()
            );
            AddCommand = new RelayCommand<ProductObject>(
                (p) => true, // CanExecute()
                (p) => addProduct(mapper.Map<ProductObject, Product>(p)) // Execute()
            );
            UpdateCommand = new RelayCommand<ProductObject>(
                (p) => true, // CanExecute()
                (p) => updateProduct(mapper.Map<ProductObject, Product>(p)) // Execute()
            );
        }

        private void removeProduct(ProductObject p)
        {
            List<Product> products = (List<Product>)productRepository.GetProducts();
            Product pDel = products.FirstOrDefault(product => product.ProductId == p.ProductId);

            productRepository.DeleteProduct(pDel);
        }

        private void addProduct(Product product)
        {
            productRepository.InsertProduct(product);
        }

        private void updateProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }
    }
}
