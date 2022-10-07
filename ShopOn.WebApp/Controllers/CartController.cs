using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOn.BusinessLayer.Contracts;
using ShopOn.WebApp.Models;
using ShopOn.WebApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOn.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductManager productManager;

        public CartController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public IActionResult AddToCart(int pId)
        {
            var product = this.productManager.GetProduct(pId);
            if (product != null)
            {
                var cartVM = new CartVM()
                {
                    Pid = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.ProductPrice,
                    ImageUrl = product.ImageUrl,
                    Qty = 1,
                    TotalAmount=product.ProductPrice*1
                };

                var cartVMs = HttpContext.Session.GetSession<List<CartVM>>("CartData");
                if (cartVMs == null)
                {
                    cartVMs = new List<CartVM>();
                }
                var cartVMProduct = cartVMs.FirstOrDefault(x => x.Pid == cartVM.Pid);
                if (cartVMProduct == null)
                {
                    //add new data to a temporary list
                    cartVMs.Add(cartVM);
                }
                else
                {
                    if (cartVMProduct.Qty == 5)
                    {
                        //Console.WriteLine("You have reached the maximum quantity");
                    }
                    else
                    {
                        cartVMProduct.Qty += 1;
                        cartVMProduct.TotalAmount = cartVMProduct.Qty * cartVMProduct.Price;
                    }
                }
                var cartCnt = cartVMs.Count();
                HttpContext.Session.SetInt32("CartCount", cartCnt);
                //push the new list to session
                HttpContext.Session.SetSession<List<CartVM>>("CartData", cartVMs);

                ////first check if session has cart dara/fetch cart data to list
                //var cartVMs = HttpContext.Session.GetSession<List<CartVM>>("CartData");
                //if (cartVMs == null)
                //{
                //    //creating list as session is empty
                //    cartVMs = new List<CartVM>();
                //}
                ////adding first element to list
                //cartVMs.Add(cartVM);
                //var cartCount = 0; //adding cart count var

                ////push list to session
                //HttpContext.Session.SetSession<List<CartVM>>("CartData",cartVMs);
                ////pushing cart count to session
                //HttpContext.Session.SetInt32("CartCount",cartCount);

                ////TempData["Cart"] = JsonConvert.SerializeObject(cartVM); //serializing the cart object 

            }
            return RedirectToAction("DisplayCartData");
        }

        public IActionResult DisplayCartData()
        {
            //var cartVM = JsonConvert.DeserializeObject<CartVM>(TempData["Cart"].ToString());
            var cartVMs = HttpContext.Session.GetSession<List<CartVM>>("CartData");
            var cartCount = 0;
            if (cartVMs != null)
            {
                cartCount = cartVMs.Count;//cart count
            }
           
            HttpContext.Session.SetInt32("CartCount", cartCount);//cart count at nav bar
            ViewBag.CartCount = cartCount;
            return View("Cart",cartVMs);
        }

        public IActionResult DeleteCart(int id)
        {

            
            //get list of cart from session
            var cartVMs = HttpContext.Session.GetSession<List<CartVM>>("CartData");
            //remove cart item from the list
            var cartVM = cartVMs.FirstOrDefault(x => x.Pid == id);
            cartVMs.Remove(cartVM);
            //set the list to session (if not empty)
            HttpContext.Session.SetSession<List<CartVM>>("CartData", cartVMs);

            var cartCount = cartVMs.Count;//cart count
            HttpContext.Session.SetInt32("CartCount", cartCount);//cart count at nav bar

            ViewBag.CartCount = cartCount;

            //redirect to cart page
            return RedirectToAction("DisplayCartData","Cart");
        }

        public IActionResult UpdateCart(int id, int qty, double amount)
        {
            var cartVMs = HttpContext.Session.GetSession<List<CartVM>>("CartData");
            foreach (var cartVM in cartVMs)
            {
                if (cartVM.Pid == id)
                {
                    cartVM.Qty = qty;
                    cartVM.TotalAmount = amount;
                }
            }
            HttpContext.Session.SetSession<List<CartVM>>("CartData", cartVMs);
            return RedirectToAction("DisplayCartData");
        }
    }
}
