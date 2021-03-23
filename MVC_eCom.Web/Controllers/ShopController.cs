﻿using MVC_eCom.Services;
using MVC_eCom.Web.Code;
using MVC_eCom.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_eCom.Web.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Index(string searchTerm, int? minimumPrice, int? maximumPrice,int? categoryID,int? sortBy)
        {
            ShopViewModel model = new ShopViewModel();
            model.FeaturedCategories = CategoriesService.Instance.GetFeaturedCategories();
            model.MaximumPrice = ProductsService.Instance.GetMaximumPrice();
            model.Products = ProductsService.Instance.SearchProducts(searchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            model.SortBy = sortBy;
            return View(model);
        }

        //ProductsServices productsService = new ProductsServices();
        // GET: Shop
        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();
            var CartProductsCookie = Request.Cookies["CartProducts"];
            if (CartProductsCookie != null)
            {
                //縮寫
                //var productIDs = CartProductsCookie.Value;
                //var ids = productIDs.Split('-');
                //List<int> pIDs = ids.Select(x => int.Parse(x)).ToList();
                model.CartProductIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CartProducts = ProductsService.Instance.GetProducts(model.CartProductIDs);
            }
            return View(model);
        }
    }
}