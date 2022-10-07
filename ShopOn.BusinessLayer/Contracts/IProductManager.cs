using ShopOn.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.BusinessLayer.Contracts
{
    public interface IProductManager
    {
        bool AddProduct(Product product, out string errMessage);
        IEnumerable<Product> GetProducts();
        Product GetProduct(int productId);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);
        IEnumerable<Product> SortById();
        IEnumerable<Product> SortByPrice();
        IEnumerable<Product> SortByName();

        IEnumerable<Product> Search(string key);
    }
}
