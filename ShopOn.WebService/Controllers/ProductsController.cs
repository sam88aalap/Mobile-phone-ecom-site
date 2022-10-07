using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOn.BusinessLayer.Contracts;
using ShopOn.CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOn.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAsyncManager productAsyncManager;
        
        public ProductsController(IProductAsyncManager productAsyncManager)
        {
            this.productAsyncManager = productAsyncManager;
            
        }

        //GET: /api/Products/
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var products = await this.productAsyncManager.GetProducts();
                if (products == null)
                {
                    return NotFound("No Products found");
                }
                return Ok(products);
            }
            catch (Exception)
            {

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error retrieving products in server");
            }
        }

        //GET: /api/Products/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var product = await this.productAsyncManager.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error retrieving product in server");
            }
        }

        //GET: /api/Products/Search/key
        [HttpGet]
        [Route("/api/Product/Search/{key}")]
        public async Task<ActionResult> Search(string key)
        {
            try
            {
                var products = await this.productAsyncManager.Search(key);
                if (products == null)
                {
                    return NotFound($"Product with key {key} not found");
                }
                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error retrieving products by key in server");
            }
        }

        //POST: /api/Products/
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                var result = await this.productAsyncManager.AddProduct(product);
                return CreatedAtAction(nameof(Get), new { id = result.ProductId }, result);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error creating products in server");
            }
        }

        //PUT: /api/Products/1
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> Update(int id, Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                if (id != product.ProductId)
                {
                    return BadRequest();
                }
                if (product.ProductId == 0 || product.ProductPrice == 0 || product.ProductName == null)
                {
                    return BadRequest();
                }
                var updatedProduct = await this.productAsyncManager.UpdateProduct(product);
                if (updatedProduct == null)
                {
                    return NotFound($"Product with id {id} not found");
                }
                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error updating products in server");
            }
        }

        //DELETE: /api/Products/Product ID
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var product = await this.productAsyncManager.GetProduct(id);
                if (product == null)
                {
                    return NotFound($"Product with id {id} not found");
                }
                await this.productAsyncManager.DeleteProduct(id);
                return Ok($"Product with id {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error deleting products in server");
            }
        }

    }
}
