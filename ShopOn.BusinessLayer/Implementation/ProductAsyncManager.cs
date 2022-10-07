using ShopOn.BusinessLayer.Contracts;
using ShopOn.CommonLayer.Models;
using ShopOn.DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.BusinessLayer.Implementation
{
    public class ProductAsyncManager : IProductAsyncManager
    {
        private readonly IProductAsync asyncRepository;

        public ProductAsyncManager(IProductAsync asyncRepository)
        {
            this.asyncRepository = asyncRepository;
        }

        public Task<Product> AddProduct(Product product)
         => this.asyncRepository.AddProduct(product);

        public Task DeleteProduct(int id)
            => this.asyncRepository.DeleteProduct(id);

        public Task<Product> GetProduct(int id)
            => this.asyncRepository.GetProduct(id);

        public Task<IEnumerable<Product>> GetProducts()
            => this.asyncRepository.GetProducts();

        public Task<IEnumerable<Product>> Search(string key)
            => this.asyncRepository.Search(key);

        public Task<Product> UpdateProduct(Product product)
            => this.asyncRepository.UpdateProduct(product);
    }
}
