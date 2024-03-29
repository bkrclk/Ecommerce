﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ECommerce.Context;
using ECommerce.Helpers;
using ECommerce.Models;
using ECommerce.Models.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        #region Properties
        private readonly ILogger<ProductController> _logger;
        private ProductContext _context;

        public static List<ProductModel> Products = new List<ProductModel>();

        #endregion

        #region Constructors
        public ProductController(ILogger<ProductController> logger, ProductContext context)
        {
            _logger = logger;
            _context = context;
            ProductsBind();
        }
        #endregion

        #region Method

        #region ViewMethod
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

            //PaymentValidation paymentValidation = new PaymentValidation();
            //ValidationResult result = paymentValidation.Validate(Payment);
            //if (result.IsValid)
            //{
            //    var cart = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");

            //    var ConfirmPayment = new ConfirmPaymentModel();

            //    ConfirmPayment.Product = cart;
            //    ConfirmPayment.Payment = Payment;

            //    if (ConfirmPayment != null)
            //    {
            //        return View(ConfirmPayment);
            //    }

            //}
            //else
            //{
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //}
            return View(nameof(Checkout), Payment);
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

        #endregion

        #region FunctionMethod
        public void ProductsBind()
        {
                Products = _context.ProductModel.ToList();
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

        public IActionResult BasketPartial()
        {
            List<ProductModel> cart = SessionHelper.GetObjectFromJson<List<ProductModel>>(HttpContext.Session, "cart");

            return PartialView("_BasketPartial", cart);
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

            //var path = System.IO.Path.GetFullPath(".\\wwwroot\\product.json");
            //var webClient = new WebClient();
            //var json = webClient.DownloadString(path);
            //Products = JsonConvert.DeserializeObject<List<ProductModel>>(json);

            foreach (var item in basketList)
            {
                var updateProducts = Products.Find(q => q.Id == item.Id);
                updateProducts.Quantity = updateProducts.Quantity - item.BasketCount;
            }
            _context.SaveChanges();
            //var output = JsonConvert.SerializeObject(Products, Formatting.Indented);

            //System.IO.File.WriteAllText(path, output);

            HttpContext.Session.Clear();
            isSession = 0;

            return Json(isSession);
        }
        #endregion

        #region ErrorMethod
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        #endregion
    }
}