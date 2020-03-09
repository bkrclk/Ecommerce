using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ECommerce.Models;
using System.Net;
using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public List<Product> Products = new List<Product>();



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Bind();


        }
        public void Bind()
        {
            var webClient = new WebClient();


            var json = webClient.DownloadString(@"C:\Users\DetaySoft\source\repos\ECommerce\ECommerce\wwwroot\product.json");
            var product = JsonConvert.DeserializeObject<List<Product>>(json);
            foreach (var item in product)
            {
                Products.Add(item);
            }
        }
        public IActionResult Index()
        {


            return View(Products);

        }

        public IActionResult ShoppingCard()
        {
            return View();
        }

        public IActionResult ViewProduct(int productId)
        {

            var datas = Products.Where(q => q.Id == productId).FirstOrDefault();

            return Json(datas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
