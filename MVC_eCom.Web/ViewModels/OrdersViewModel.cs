using MVC_eCom.Entities;
using MVC_eCom.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_eCom.Web.ViewModels
{
    public class OrdersViewModel
    {
        public List<Order> Orders { get; set; }
        public string UserID { get; set; }
        public Pager Pager { get; set; }
        public string Status { get; set; }
    }
    public class OrderDetailViewModel
    {
        public Order Order { get; set; }
        public ApplicationUser OrderBy { get; set; }
        public List<string> AvailableStatuses { get; set; }
    }
}