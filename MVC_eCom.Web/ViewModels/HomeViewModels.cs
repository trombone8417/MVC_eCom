using MVC_eCom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_eCom.Web.ViewModels
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}