using ShopOn.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.DataLayer.Contracts
{
    public interface IProductAsync
    {
        /// <summary>
        /// method to add product and return newly created
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> AddProduct(Product product);

        /// <summary>
        /// method to get all products
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProducts();

        /// <summary>
        /// method to search based on a key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> Search(string key);

        /// <summary>
        /// method to get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProduct(int id);

        /// <summary>
        /// method to update product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> UpdateProduct(Product product);

        /// <summary>
        /// method to delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteProduct(int id);

    }
}
