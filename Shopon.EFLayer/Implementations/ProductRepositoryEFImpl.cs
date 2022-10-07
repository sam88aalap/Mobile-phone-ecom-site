using Shopon.EFLayer.Models;
using ShopOn.CommonLayer.Models;
using ShopOn.DataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shopon.EFLayer.Implementations
{
    public class ProductRepositoryEFImpl : IProductRepository
    {
        private readonly db_shoponContext context;

        public ProductRepositoryEFImpl()
        {
            this.context = new db_shoponContext();
        }
        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public ShopOn.CommonLayer.Models.Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShopOn.CommonLayer.Models.Product> GetProducts()
        {
            var productsDb = context.Products.ToList();
            var companiesDb = context.Companies.ToList();
            var categoriesDb = context.Categories.ToList();

            var products = from p in productsDb
                           join c in companiesDb
                           on p.Companyid equals c.Companyid
                           join ca in categoriesDb
                           on p.Categoryid equals ca.Categoryid
                           select new ShopOn.CommonLayer.Models.Product
                           {
                               Availability = p.Availablestatus,
                               ImageUrl = p.ImageUrl,
                               ProductId = p.Pid,
                               ProductPrice = p.Price.Value,
                               ProductName = p.Productname,
                               Company = new ShopOn.CommonLayer.Models.Company()
                               {
                                   CompanyId = c.Companyid,
                                   CompanyName = c.Companyname
                               },
                               //Category = new ShopOn.CommonLayer.Models.Category()
                               //{
                               //    CategoryId = ca.Categoryid,
                               //    CategoryName = ca.Category1
                               //}
                           };

            return products;
        }

        public bool InsertProduct(ShopOn.CommonLayer.Models.Product product, out string errMessage)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(ShopOn.CommonLayer.Models.Product product)
        {
            throw new NotImplementedException();
        }

        
    }
}
