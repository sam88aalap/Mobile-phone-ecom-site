using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopOn.CommonLayer.Models;
using ShopOn.DataLayer.Contracts;

namespace ShopOn.DataLayer.Implementation
{
    public class ProductRepositoryInMemoryArray : IProductRepository
    {
        private const int CAPACITY = 10;
        private Product[] products = null;
        private int index = -1;

        public ProductRepositoryInMemoryArray()
        {
            products = new Product[CAPACITY];
        }

        public ProductRepositoryInMemoryArray(int capacity)
        {
            products = new Product[capacity];
        }

        public bool InsertProduct(Product product, out string errMessage)
        {
            bool isInserted = false;
            errMessage = string.Empty;

            if (product.ProductId == 0 || string.IsNullOrEmpty(product.ProductName) || product.ProductPrice == 0)
            {
                errMessage = "Invalid ProductId or ProdcutName or ProductPrice";
                return isInserted;
            }
            if(index >= products.Length)
            {
                Product[] temp = new Product[products.Length];
                Array.Copy(products, temp, products.Length);
                products = new Product[products.Length * 2];
                Array.Copy(temp, products , temp.Length);
                temp = null;
            }
            products[++index] = product;
            isInserted = true;

            return isInserted;
        }

        public Product GetProductById(int productId)
        {
            //Product searchProduct = null;
            //foreach (var product in this.products)
            //{
            //    if(product.ProductId == productId)
            //    {
            //        searchProduct = product;
            //        break;
            //    }
            //}
            //return searchProduct;

            var temp = new Product[index+1];
            Array.Copy(this.products, temp, index+1);
            return temp.SingleOrDefault(x => x.ProductId == productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            Product[] temp = new Product[index+1];
            Array.Copy(products, temp, index+1);
            return temp;
        }

        public bool UpdateProduct(Product product)
        {
            var getProduct = GetProductById(product.ProductId);
            bool isPresent = false; 
            if(getProduct != null)
            {
                int index = Array.IndexOf(products, getProduct);
                products[index] = product;
                isPresent = true;
            }
            return isPresent;
        }

        public bool DeleteProduct(int productId)
        {
            bool isDelete = false;
            if (GetProductById(productId) != null)
            {
                var deleteProduct = GetProductById(productId);
               for(int i=0; i<index; i++)
                {
                    if(products[i].ProductId == deleteProduct.ProductId)
                    {
                        for(int j=i; j<index; j++)
                        {
                            products[j] = products[j + 1];
                        }
                    }
                }
                index--;
                isDelete = true;
            }
            return isDelete;
        }

        public IEnumerable<Product> Search(string key)
        {
            throw new NotImplementedException();
        }
    }
}
