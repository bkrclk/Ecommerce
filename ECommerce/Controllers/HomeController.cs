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
using Microsoft.AspNetCore.Http;
using ECommerce.Helpers;

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

            SessionControl();
            return View(Products);

        }

        public IActionResult ShoppingCard()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                TempData["itemCount"] = cart.Count;
                return View(cart);
            }
            return View();



        }

        public IActionResult ViewProduct(int productId)
        {

            var datas = Products.Where(q => q.Id == productId).FirstOrDefault();
            return Json(datas);
        }

        public IActionResult DeleteToCard(int productId)
        {
            var cardlist = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            if (cardlist != null && cardlist.Any())
            {
                var selectedItem = cardlist.FirstOrDefault(q => q.Id == productId);
                if (selectedItem != null)
                {
                    cardlist.Remove(selectedItem);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cardlist);
                }
            }

            return PartialView("_BasketPartial", cardlist);
        }

        public IActionResult AddToCard(int productId)
        {

            var datas = Products.Where(q => q.Id == productId).FirstOrDefault();

            if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart") == null)
            {
                List<Product> cart = new List<Product>();
                cart.Add(datas);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
                int index = isExist(productId);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(datas);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            SessionControl();
            return Json(datas);
        }
        private int isExist(int productId)
        {
            List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.Equals(productId))
                {
                    return i;
                }
            }
            return -1;
        }

        public void SessionControl()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                TempData["itemCount"] = cart.Count;
                RedirectToAction("Index", "Home");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
