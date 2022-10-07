using Microsoft.EntityFrameworkCore;
using ShopOn.CommonLayer.Models;
using ShopOn.DataLayer.Contracts;
using ShopOnEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnEFLayer.Implementations
{
    public class ProductRepositoryEFImpl : IProductRepository
    {
        private readonly db_shoponContext context=null;

        public ProductRepositoryEFImpl(db_shoponContext context)
        {
            //context = new db_shoponContext();
            this.context = context;
        }

        public bool DeleteProduct(int productId)
        {
            bool isDeleted = false;

            try
            {
                var productToDelete = this.context.Products.FirstOrDefault(x => x.Pid == productId);
                if (productToDelete == null)
                {
                    Console.WriteLine("product not found");
                }
                else
                {
                    productToDelete.IsDeleted = true;

                    this.context.SaveChanges();
                    isDeleted = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return isDeleted;
        }

        public ShopOn.CommonLayer.Models.Product GetProductById(int productId)
        {
            ShopOn.CommonLayer.Models.Product product = null;
            try
            {
                
                var productToDisplay = this.context.Products.FirstOrDefault(x => x.Pid == productId);
                if (productToDisplay == null)
                {
                    Console.WriteLine("product not found");
                }
                else
                {
                    product = new ShopOn.CommonLayer.Models.Product()
                    {
                        ProductId = productToDisplay.Pid,
                        ProductName = productToDisplay.Productname,
                        Availability = productToDisplay.Availablestatus,
                        ProductPrice = productToDisplay.Price.Value,// since price is nullable
                        ImageUrl = productToDisplay.ImageUrl,
                        CompanyId = productToDisplay.Companyid.Value,
                        CategoryId = productToDisplay.Categoryid.Value
                    };

                   
                }
            }
            catch (Exception)
            {

                throw;
            }

            return product;
        }

        public IEnumerable<ShopOn.CommonLayer.Models.Product> GetProducts()
        {
            //the commented method is older method, we are using linq method instead.
            //List<CommonLayer.Models.Product> products = new List<CommonLayer.Models.Product>();

            var productsDb = context.Products.Include(x => x.Company);
            /*
            foreach (var productDb in productsDb)
            {
                CommonLayer.Models.Product product = new CommonLayer.Models.Product()
                {
                    PId = productDb.Pid,
                    ProductName = productDb.Productname,
                    AvailabileStatus = productDb.Availablestatus,
                    ImageUrl = productDb.ImageUrl,
                    Price = productDb.Price ?? 0,
                    CategoryId = productDb.Categoryid.Value,
                    CompanyId = productDb.Companyid.Value,
                    Company = new CommonLayer.Models.Company()
                    {
                        CompanyId = productDb.Company.Companyid,
                        CompanyName = productDb.Company.Companyname
                    }
                };
                products.Add(product);
            }
            */
            var products = from p in productsDb
                           where p.IsDeleted == false
                           select new ShopOn.CommonLayer.Models.Product
                           {
                               ProductId=p.Pid,
                               ProductName = p.Productname,
                               Availability = p.Availablestatus,
                               ImageUrl = p.ImageUrl,
                               ProductPrice = p.Price ?? 0,
                               CategoryId = p.Categoryid.Value,
                               CompanyId = p.Companyid.Value,
                               Company = new ShopOn.CommonLayer.Models.Company()
                               {
                                   CompanyId = p.Company.Companyid,
                                   CompanyName = p.Company.Companyname
                               }
                           };

            return products.ToList();
        }

        public bool InsertProduct(ShopOn.CommonLayer.Models.Product product, out string errMessage)
        {
            bool isInserted = false;
            errMessage = String.Empty;

            try
            {
                var productDb = new Models.Product()
                {
                    Pid = product.ProductId,
                    Productname = product.ProductName,
                    Price = product.ProductPrice,
                    Availablestatus = product.Availability,
                    Companyid = product.CompanyId,
                    Categoryid = product.CategoryId,
                    IsDeleted = false,
                    ImageUrl = product.ImageUrl

                };

                this.context.Products.Add(productDb);
                this.context.SaveChanges();
                isInserted = true;
            }
            catch (Exception)
            {

                throw;
            }

            return isInserted;
        }

        //implementation not completed.
        public IEnumerable<ShopOn.CommonLayer.Models.Product> Search(string key)
        {
            var productsDb = context.Products.Include(x => x.Company);
            var products = from p in productsDb
                           where p.IsDeleted == false && p.Productname.ToLower().Contains(key.ToLower())
                           select new ShopOn.CommonLayer.Models.Product
                           {
                               ProductId = p.Pid,
                               ProductName = p.Productname,
                               Availability = p.Availablestatus,
                               ImageUrl = p.ImageUrl,
                               ProductPrice = p.Price ?? 0,
                               CategoryId = p.Categoryid.Value,
                               CompanyId = p.Companyid.Value,
                               Company = new ShopOn.CommonLayer.Models.Company()
                               {
                                   CompanyId = p.Company.Companyid,
                                   CompanyName = p.Company.Companyname
                               }
                           };

            return products.ToList();

        }

        public bool UpdateProduct(ShopOn.CommonLayer.Models.Product product)
        {
            bool isUpdated = false;

            try
            {
                var productToUpdate = this.context.Products.FirstOrDefault(x=>x.Pid== product.ProductId);
                if (productToUpdate == null)
                {
                    Console.WriteLine("product not found");
                }
                else
                {
                    productToUpdate.Productname = product.ProductName;
                    productToUpdate.Availablestatus = product.Availability;
                    productToUpdate.Companyid = product.CompanyId;
                    productToUpdate.Categoryid = product.CategoryId;
                    productToUpdate.ImageUrl = product.ImageUrl;
                    productToUpdate.Price = product.ProductPrice;

                    this.context.SaveChanges();
                    isUpdated = true;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return isUpdated;

        }
    }
}
