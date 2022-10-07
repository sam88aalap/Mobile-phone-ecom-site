using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOn.BusinessLayer.Contracts;
using ShopOn.CommonLayer.Models;
using ShopOn.WebApp.Models;
using ShopOn.WebApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopOn.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderManager orderManager;

        public OrderController(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
        }

        [Authorize]
        public IActionResult PlaceOrder()
        {
            var cartData = HttpContext.Session.GetSession<List<CartVM>>("displayCartData");
            if (cartData == null || cartData.Count == 0)
            {
                return RedirectToAction("DisplayCartData", "Cart");
            }
            var customerId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            double totalAmount = 0;
            var order = new Order()
            {
                AspCustomerId = customerId,
                OrderDate = DateTime.UtcNow,
                OrderTotal = totalAmount
            };
            foreach (var cartItem in cartData)
            {
                order.AddOrderItem(new OrderItem()
                {
                    PId = cartItem.Pid,
                    Qty = cartItem.Qty,
                    product = new Product()
                    {
                        ProductName = cartItem.ProductName,
                        ImageUrl = cartItem.ImageUrl,
                        ProductPrice = cartItem.Price
                    }
                });
                totalAmount += cartItem.TotalAmount;

            }
            order.OrderTotal = totalAmount;
            this.orderManager.AddOrder(order);
            HttpContext.Session.Clear();

            return View(order);

        }
    }
}
