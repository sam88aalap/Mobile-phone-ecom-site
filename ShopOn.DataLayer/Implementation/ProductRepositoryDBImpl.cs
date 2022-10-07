using ShopOn.CommonLayer.Models;
using ShopOn.DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.DataLayer.Implementation
{
    public class ProductRepositoryDBImpl : IProductRepository
    {
        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            // 1. establish connection using ConnectionString
            // 2. command object: to execute query(DDL/DML/DQL)
            // 3. create data reader to fetch data
            // 4. close connection
            throw new NotImplementedException();
        }

        public bool InsertProduct(Product product, out string errMessage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search(string key)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
