 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_eCom.Web.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Checkout()
        {
            var CartProductsCookie = Request.Cookies["CartProducts"];
            if (CartProductsCookie != null)
            {
                var productIDs = CartProductsCookie.Value;
            }
            return View();
        }
    }
}