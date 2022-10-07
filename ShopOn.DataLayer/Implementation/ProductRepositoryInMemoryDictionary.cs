using ShopOn.CommonLayer.Models;
using ShopOn.DataLayer.Contracts;
using ShoponCommon.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.DataLayer.Implementation
{
    public class ProductRepositoryInMemoryDictionary : IProductRepository
    {
        private Dictionary<int,Product> products = new Dictionary<int, Product>();
        public ProductRepositoryInMemoryDictionary()
        {
            InitProducts();
        }

        public bool InsertProduct(Product product, out string errMessage)
        {
            errMessage = string.Empty;
            var id = GetProductById(product.ProductId);
            if (product.ProductId == 0 || string.IsNullOrEmpty(product.ProductName) || product.ProductPrice == 0)
            {
                errMessage = "Invalid ProductId or ProdcutName or ProductPrice";
                return false;
            }

            else if ((GetProductById(product.ProductId)) != null)
            {
                throw new InvalidProductException("Trying to add duplicate Product");
            }
            products.Add(product.ProductId, product);
           

              //  errMessage = "Invalid ProductId or ProdcutName or ProductPrice";

            
            return true;
        }

        public Product GetProductById(int productId)
        {
            Dictionary<int, Product>.KeyCollection keyColl = products.Keys;
            Product searchProduct = null;
            foreach(int pId in keyColl)
            {
                if(pId == productId)
                {
                     searchProduct = products[pId];

                }
            }
            return searchProduct;
        }

        public IEnumerable<Product> GetProducts()
        {
            //Dictionary<int, Product>.ValueCollection valueColl = products.Values;
            Product[] values = new Product[products.Count];
            products.Values.CopyTo(values, 0);
            return values; 
        }

        public bool UpdateProduct(Product product)
        {
            var getProduct = GetProductById(product.ProductId);
            bool isPresent = false;
            if (getProduct != null)
            {
                products[getProduct.ProductId] = product;
            }
            return isPresent;
        }

        public bool DeleteProduct(int productId)
        {
            bool isPresent = false;
            if (GetProductById(productId) != null)
            {
                products.Remove(productId);
                isPresent = true;
            }
            return isPresent;
        }

        private void InitProducts()
        {
            products.Add(247, new Product()
            {
                Availability = "yes",
                ImageUrl = "rccar.jpg",
                ProductId = 247,
                ProductName = "Rc Car",
                ProductPrice = 2500
            });
            products.Add(20, new Product()
            {
                Availability = "yes",
                ImageUrl = "coffemug.jpg",
                ProductId = 20,
                ProductName = "coffee mug",
                ProductPrice = 247
            });
            products.Add(56, new Product()
            {
                Availability = "yes",
                ImageUrl = "screencleaner.jpg",
                ProductId = 56,
                ProductName = "Apple Screen Cleaner",
                ProductPrice = 467
            });
            products.Add(598, new Product()
            {
                Availability = "yes",
                ImageUrl = "nurfgun.jpg",
                ProductId = 598,
                ProductName = "Nerf Gun",
                ProductPrice = 1437
            });
        }

        public IEnumerable<Product> Search(string key)
        {
            throw new NotImplementedException();
        }
    }
}

