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
            return View(Products);
        }

        public IActionResult ShoppingCard()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            if (cart != null && !cart.Count.Equals(0))
            {
                TempData["itemCount"] = cart.Count();
                return View(cart);
            }
            else
            {
                TempData["itemCount"] = 0;
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


        public IActionResult AddToCard(int productId, int count)
        {
            if (count == 0) count = 1;
            var product = Products.Where(q => q.Id == productId).FirstOrDefault();
            product.BasketCount = count;
            product.TotalPrice = product.Price;

            if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart") == null)
            {
                List<Product> cart = new List<Product>();
                cart.Add(product);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Product> cartList = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
                var itemExist = cartList.FirstOrDefault(q => q.Id == productId);
                if (cartList.Any(q => q.Id == productId))
                {
                    return Json(1);
                }
                else
                {
                    cartList.Add(product);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartList);
            }
            return Json(product);
        }

        public IActionResult UpdatePrice(int productId, int count)
        {
            var getProduct = Products.Where(q => q.Id == productId).FirstOrDefault();
            Product updatePrice = new Product();
            List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.Equals(productId))
                {
                    cart[i].TotalPrice = getProduct.Price * count;
                    cart[i].BasketCount = count;
                    updatePrice = cart[i];
                }

            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);


            return Json(updatePrice);
        }
        public IActionResult ItemControl()
        {
            int basketCount = 0;
            var cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                basketCount = cart.Count;
            }
            return Json(basketCount);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult BasketPartial()
        {
            List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");

            return PartialView("_BasketPartial", cart);
        }

    }
}
