﻿using MVC_eCom.Services;
using MVC_eCom.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_eCom.Web.Controllers
{
    public class WidgetsController : Controller
    {
        // GET: Widgets
        public ActionResult Products(bool isLatestProducts)
        {

            ProductsWidgetViewModel model = new ProductsWidgetViewModel();
            model.IsLatestProducts = isLatestProducts;
            if (isLatestProducts)
            {
                model.Products = ProductsService.Instance.GetLatestProducts(4);
            }
            else
            {
                model.Products = ProductsService.Instance.GetProducts(1, 8);
            }
        
            return PartialView(model);
        }
    }
}
