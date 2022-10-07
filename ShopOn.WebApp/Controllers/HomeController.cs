using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopOn.BusinessLayer.Contracts;
using ShopOn.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOn.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductManager productManager;

        public HomeController(ILogger<HomeController> logger, IProductManager productManager)
        {
            _logger = logger;
            this.productManager = productManager;
        }

        public IActionResult Index(int pg=1)
        {
            //var products = this.productManager.GetProducts();
            //return View(products);

            var products = this.productManager.GetProducts();

            const int pageSize = 12;
            if (pg < 1)
            {
                pg = 1;
            }

            int recsCount = products.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;

            var data = products.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;

            //return View(products);
            return View(data);
        }

        public IActionResult Details(int pid)
        {
            var product = this.productManager.GetProduct(pid);
            return View(product);
        }
        public IActionResult Search(string key)
        {
            if (key == null)
            {
                return RedirectToAction("Index");
            }
            var products = this.productManager.Search(key);
            return View("Index",products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
