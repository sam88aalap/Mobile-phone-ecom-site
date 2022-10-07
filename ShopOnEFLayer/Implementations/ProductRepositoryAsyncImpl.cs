using Microsoft.EntityFrameworkCore;
using ShopOn.CommonLayer.Models;
using ShopOn.DataLayer.Contracts;
using ShopOnEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOn.DataLayer.Implementation
{
    public class ProductRepositoryAsyncImpl : IProductAsync
    {
        private readonly db_shoponContext context = null;

        public ProductRepositoryAsyncImpl(db_shoponContext context)
        {
            this.context = context;
        }

        public async Task<CommonLayer.Models.Product> AddProduct(CommonLayer.Models.Product product)
        {
            try
            {
                var productDb = new ShopOnEFLayer.Models.Product()
                {
                    Pid = product.ProductId,
                    Productname = product.ProductName,
                    Price = product.ProductPrice,
                    Availablestatus = product.Availability,
                    ImageUrl = product.ImageUrl,
                    IsDeleted = false,
                    Categoryid = product.CategoryId,
                    Companyid = product.CompanyId
                };
                var result = await this.context.AddAsync(productDb);
                await this.context.SaveChangesAsync();
                return new CommonLayer.Models.Product()
                {
                    ProductId = result.Entity.Pid,
                    ProductName = result.Entity.Productname,
                    Availability = result.Entity.Availablestatus,
                    ImageUrl = result.Entity.ImageUrl,
                    ProductPrice = result.Entity.Price.Value,
                    CompanyId = result.Entity.Companyid.Value,
                    CategoryId = result.Entity.Categoryid.Value
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteProduct(int id)
        {
            var productToDelete = await this.context.Products.FirstOrDefaultAsync(x => x.Pid == id);
            if (productToDelete != null)
            {
                productToDelete.IsDeleted = true;
                //this.context.Remove(await productToDelete);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<CommonLayer.Models.Product> GetProduct(int id)
        {
            var result = await this.context.Products
                        .Include(prop => prop.Company).FirstOrDefaultAsync(p => p.Pid == id);
            if (result != null)
            {
                return new CommonLayer.Models.Product()
                {
                    ProductId = result.Pid,
                    ProductName = result.Productname,
                    ProductPrice = result.Price.Value,
                    Availability = result.Availablestatus,
                    ImageUrl = result.ImageUrl,
                    CompanyId = result.Companyid.Value,
                    CategoryId = result.Categoryid.Value,
                    Company = new CommonLayer.Models.Company()
                    {
                        CompanyId = result.Company.Companyid,
                        CompanyName = result.Company.Companyname
                    }
                };
            }
            return null;
        }

        public async Task<IEnumerable<CommonLayer.Models.Product>> GetProducts()
        {
            try
            {

                var result = await this.context.Products.ToListAsync();
                var products = (from p in result
                                where p.IsDeleted == false
                                select new CommonLayer.Models.Product
                                {
                                    ProductId = p.Pid,
                                    ProductName = p.Productname,
                                    ProductPrice = p.Price.Value,
                                    Availability = p.Availablestatus,
                                    ImageUrl = p.ImageUrl,
                                    CompanyId = p.Companyid.Value,
                                    CategoryId = p.Categoryid ?? 0
                                }).ToList();

                return products;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CommonLayer.Models.Product>> Search(string key)
        {
            IQueryable<ShopOnEFLayer.Models.Product> query = this.context.Products;
            if (!string.IsNullOrEmpty(key))
            {
                query = query.Where(p => p.Productname.ToLower().Contains(key) ||
                p.Company.Companyname.ToLower().Contains(key));
            }
            var result = await query.ToListAsync();
            var products = (from p in result
                            where p.IsDeleted == false
                            select new CommonLayer.Models.Product
                            {
                                ProductId = p.Pid,
                                ProductName = p.Productname,
                                ProductPrice = p.Price.Value,
                                Availability = p.Availablestatus,
                                ImageUrl = p.ImageUrl,
                                CompanyId = p.Companyid.Value,
                                CategoryId = p.Categoryid ?? 0
                            }).ToList();

            return products;
        }

        public async Task<CommonLayer.Models.Product> UpdateProduct(CommonLayer.Models.Product product)
        {
            var productToUpdate = await this.context.Products.FirstOrDefaultAsync(p => p.Pid == product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Availablestatus = product.Availability;
                productToUpdate.Categoryid = product.CategoryId;
                productToUpdate.Companyid = product.CompanyId;
                productToUpdate.ImageUrl = product.ImageUrl;
                productToUpdate.Price = product.ProductPrice;
                productToUpdate.Productname = product.ProductName;

                await this.context.SaveChangesAsync();
                return product;
            }
            return null;
        }
    }
}
