using ShopOn.BusinessLayer.Contracts;
using ShopOn.BusinessLayer.Utility;
using ShopOn.CommonLayer.Models;
using ShopOn.DataLayer.Contracts;
using ShopOn.DataLayer.Implementation;
using ShoponCommon.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.BusinessLayer.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository productRepository;

        //private ProductRepositoryInMemoryArray productRepository = new ProductRepositoryInMemoryArray();

        //private ProductRepositoryInMemoryDictionary productRepository = new ProductRepositoryInMemoryDictionary();

        public ProductManager(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public bool AddProduct(Product product, out string errMessage)
        {
            try
            {
                return productRepository.InsertProduct(product, out errMessage);
            }
            catch (InvalidProductException e)
            {
                throw new InvalidProductException("Trying to add duplicate Product", e); 
            }
        } 
         
        public IEnumerable<Product> GetProducts()
            => productRepository.GetProducts();

        public Product GetProduct(int productId)
            => productRepository.GetProductById(productId);

        public bool UpdateProduct(Product product)
            => productRepository.UpdateProduct(product);

        public bool DeleteProduct(int productId)
            => productRepository.DeleteProduct(productId);

        public IEnumerable<Product> SortById()
        {
            var result = this.productRepository.GetProducts();
            var sortData = result.ToList();
            sortData.Sort(new IdComparer());
            return sortData;
        }

        public IEnumerable<Product> SortByPrice()
        {
            var result = this.productRepository.GetProducts();
            var sortData = result.ToList();
            sortData.Sort(new PriceComparer());
            return sortData;
        }

        public IEnumerable<Product> SortByName()
        {
            var result = this.productRepository.GetProducts();
            var sortData = result.ToList();
            sortData.Sort(new NameComparer());
            return sortData;
        }

        public IEnumerable<Product> Search(string key)
        {
           return productRepository.Search(key);
        }
    }
}
