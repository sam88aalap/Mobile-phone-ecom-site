using ShopOn.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.DataLayer.Contracts
{
    public interface IProductRepository
    {
        bool InsertProduct(Product product, out string errMessage);
        Product GetProductById(int productId);
        IEnumerable<Product> GetProducts();
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);

        IEnumerable<Product> Search(string key);

    }
}
