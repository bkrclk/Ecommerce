using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public static List<ProductModel> Products = new List<ProductModel>();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ProductsBind();

        }
        public void ProductsBind()
        {
            if (Products == null || Products.Count == 0)
            {
                var path = System.IO.Path.GetFullPath(".\\wwwroot\\product.json");
                var webClient = new WebClient();
                var json = webClient.DownloadString(path);
                Products = JsonConvert.DeserializeObject<List<ProductModel>>(json);
            }

        }
        public IActionResult Index()
        {
            return View(Products);
        }

        public IActionResult Checkout()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                return RedirectToAction(nameof(ShoppingCard), "Home");
            }
            return View();
        }


        public IActionResult ConfirmPayment()
        {
            return RedirectToAction(nameof(ShoppingCard), "Home");
        }
        [HttpPost]
        public IActionResult ConfirmPayment(PaymentModel Payment)
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");

            var ConfirmPayment = new ConfirmPaymentModel();

            ConfirmPayment.Product = cart;
            ConfirmPayment.Payment = Payment;

            if (ConfirmPayment != null)
            {
                return View(ConfirmPayment);
            }
            return RedirectToAction(nameof(ShoppingCard), "Home");
        }

        public IActionResult ShoppingCard()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");
            if (cart != null && !cart.Count.Equals(0))
            {
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
            var cardlist = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");
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
           
            var returnMessage = new ReturnMessage();
            var product = Products.Where(q => q.Id == productId).FirstOrDefault();
            if (product == null)
            {
                returnMessage.SetErrorMessage("Ürün listesinde bulunamadı.");
                return Json(returnMessage);
            }

            var cartList = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");
            if (cartList == null)
            {
                cartList = new List<ProductModel>();
            }
            if (!cartList.Any(q => q.Id == productId))
            {
                if (product.Quantity >= count)
                {
                    product.BasketCount = count;
                }
                else
                {
                    returnMessage.setMessageFirst("Yetersiz Stok!", product.BasketCount, product);
                    return Json(returnMessage);
                }
                cartList.Add(product);
                returnMessage.SetSuccessMessage("Ürün başarıyla eklendi.", product);
            }
            else
            {
                var cartItem = cartList.FirstOrDefault(q => q.Id == productId);
                if (cartItem.BasketCount > 0)
                {
                    if (cartItem.Quantity >= count)
                    {
                        cartItem.BasketCount = count;
                    }

                    returnMessage.setMessage("Ürün sepette mevcut, artırmak ister misiniz?", cartItem.BasketCount, cartItem);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartList);
                    return Json(returnMessage);
                }
                cartItem.BasketCount = count;
                returnMessage.SetSuccessMessage("Ürün başarıyla eklendi.", cartItem);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartList);
            return Json(returnMessage);

        }

        public IActionResult UpdatePrice(int productId, int count)
        {
            var getProduct = Products.Where(q => q.Id == productId).FirstOrDefault();
            ProductModel updatePrice = new ProductModel();
            List<ProductModel> cart = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.Equals(productId))
                {
                    if (count <= getProduct.Quantity && getProduct.Id == productId)
                    {
                        cart[i].TotalPrice = getProduct.Price * count;
                        cart[i].BasketCount = count;
                        updatePrice = cart[i];
                    }
                }

            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);


            return Json(updatePrice);
        }
        public IActionResult ItemControl()
        {
            int basketCount = 0;
            var cart = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                basketCount = cart.Count;
            }
            return Json(basketCount);
        }

        public IActionResult OrderComplated()
        {

            var isSession = 1;
            var basketList = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");

            foreach (var item1 in basketList)
            {
                foreach (var item2 in Products)
                {
                    if (item1.Id == item2.Id)
                        item2.Quantity = item2.Quantity - item1.BasketCount;
                }

            }

            HttpContext.Session.Clear();
            isSession = 0;

            return Json(isSession);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult BasketPartial()
        {
            List<ProductModel> cart = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");

            return PartialView("_BasketPartial", cart);
        }

    }
}
